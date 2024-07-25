using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Metadata;
using Newtonsoft.Json.Linq;

namespace WebScrapper
{
    public partial class FormNewTask : Form
    {
        private List<ScrapingTask> tasks;
        private WebView2 webView;
        private string lastUrl;

        public FormNewTask()
        {
            InitializeComponent();
            InitializeControls();
            //LoadTasks();
        }


        private async Task InitializeControls()
        {
            webView = new WebView2
            {
                Dock = DockStyle.Fill,
            };
            this.tableLayoutPanelMain.Controls.Add(webView);

            // WebView2'nin baþlatýlmasýný bekleyin
            await webView.EnsureCoreWebView2Async(null);

            // WebView2 baþlatýldýktan sonra CoreWebView2'yi kullanýn
            webView.CoreWebView2.DOMContentLoaded += WebView_DOMContentLoaded;
            webView.CoreWebView2.WebMessageReceived += WebView_WebMessageReceived;
        }
        private async void WebView_DOMContentLoaded(object sender, CoreWebView2DOMContentLoadedEventArgs e)
        {
            string script = @"
               let currentElement = null;

                let clickListener = function(event) {
                    event.preventDefault();
                    if (!document.getElementById('modalWebScrapper')) {
                        document.removeEventListener('mouseover', mouseoverListener);
                        document.removeEventListener('mouseout', mouseoutListener);
                        document.removeEventListener('click', clickListener);

                        currentElement = event.target; 

                        var modalContent = `
                            <div id='modalWebScrapper' style='position: fixed; top: 0; left: 0; width: 100%; height: 100%; background-color: rgba(0,0,0,0.5); display: flex; justify-content: center; align-items: center;'>
                                <div style='background-color: white; padding: 20px; border-radius: 10px;'>
                                    <h3>Choose an action for the element:</h3>
                                    <button title=' `+ escapeHtml(currentElement.innerText) + `' onclick='extractInnerText()'>Extract Inner Text</button>
                                    <button title=' `+ escapeHtml(currentElement.innerHTML) + `' onclick='extractInnerHTML()'>Extract Inner HTML</button>
                                    <button title=' `+ escapeHtml(currentElement.outerHTML) + `' onclick='extractOuterHTML()'>Extract Outer HTML</button>
                                    <button title='click' onclick='extractClickEvent()'>Click</button>
                                    <button onclick='closeModal()'>Close</button>
                                </div>
                            </div>
                        `;
                        document.body.insertAdjacentHTML('beforeend', modalContent);
                    }
                };
                function escapeHtml(html) {
                    return html
                        .replace(/&/g, '&amp;')
                        .replace(/</g, '&lt;')
                        .replace(/>/g, '&gt;')
                        .replace(/""/g, '&quot;')
                        .replace(/'/g, '&#039;');
                }

                let mouseoverListener = function(event) {
                    event.target.style.border = '2px solid red';
                };

                let mouseoutListener = function(event) {
                    event.target.style.border = '';
                };

                document.addEventListener('mouseover', mouseoverListener);
                document.addEventListener('mouseout', mouseoutListener);
                document.addEventListener('click', clickListener);

                function extractInnerText() {
                    if (currentElement) {
                        window.chrome.webview.postMessage(JSON.stringify({
                            action: 'Extract Inner Text',
                            element: {
                                tagName: currentElement.tagName,
                                id: currentElement.id,
                                className: currentElement.className,
                                innerText: currentElement.innerText
                            }
                        }));
                        closeModal();
                    }
                }

                function extractInnerHTML() {
                    if (currentElement) {
                        window.chrome.webview.postMessage(JSON.stringify({
                            action: 'Extract Inner HTML',
                            element: {
                                tagName: currentElement.tagName,
                                id: currentElement.id,
                                className: currentElement.className,
                                innerHTML: currentElement.innerHTML
                            }
                        }));
                        closeModal();
                    }
                }

                function extractClickEvent() {
                    if (currentElement) {
                        window.chrome.webview.postMessage(JSON.stringify({
                            action: 'Click Event',
                            element: {
                                tagName: currentElement.tagName,
                                id: currentElement.id,
                                className: currentElement.className,
                                outerHTML: currentElement.outerHTML 
                            }
                        }));
                        currentElement.click();
                        closeModal();
                    }
                }

                function extractOuterHTML() {
                    if (currentElement) {
                        window.chrome.webview.postMessage(JSON.stringify({
                            action: 'Extract Outer HTML',
                            element: {
                                tagName: currentElement.tagName,
                                id: currentElement.id,
                                className: currentElement.className,
                                outerHTML: currentElement.outerHTML
                            }
                        }));
                        closeModal();
                    }
                }

                function closeModal() {
                    var modal = document.getElementById('modalWebScrapper');
                    if (modal) {
                        modal.remove();
                        setTimeout(() => {
                            document.addEventListener('click', clickListener);
                            document.addEventListener('mouseover', mouseoverListener);
                            document.addEventListener('mouseout', mouseoutListener);
                        }, 100);
                    }
                }
            ";
            await webView.CoreWebView2.ExecuteScriptAsync(script);

        }

        private void WebView_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            Console.WriteLine("WebMessageReceived event triggered.");
            try
            {
                string message = e.WebMessageAsJson;
                Console.WriteLine("Received message: " + message);
                message = message.Trim('"');
                message = message.Replace("\\\"", "\"");
                message = message.Replace("\\\\", "\\");
                dynamic element = JsonConvert.DeserializeObject(message);

                if (element?.action != null && element?.element != null)
                {
                    string action = (string)element.action;
                    dynamic el = element.element;

                    string result = null;

                    if (el is JObject)
                    {
                        switch (action)
                        {
                            case "Extract Inner Text":
                                result = (string)el.innerText;
                                break;
                            case "Extract Inner HTML":
                                result = (string)el.innerHTML;
                                break;
                            case "Extract Outer HTML":
                                result = (string)el.outerHTML;
                                break;
                            case "Click Event":
                                result = "Click";
                                break;
                            default:
                                Console.WriteLine("Unknown action: " + action);
                                return;
                        }

                        if (result != null)
                        {
                            AddTask(el, action, result);
                        }
                        else
                        {
                            Console.WriteLine("Failed to extract " + action);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Element is not of type JObject");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid message format");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("WebMessageReceived event processing completed.");
            }
        }


        private void AddTask(dynamic element, string action, string extractedData)
        {
            // Add To DataGriedView
            dataGridViewTask.Rows.Add(new object[] { element.tagName, action, extractedData });

            //var task = new ScrapingTask
            //{
            //    FieldName = element.tagName,
            //    Action = action,
            //    ExtractedData = extractedData,
            //    ElementId = element.id,
            //    ElementClassName = element.className
            //};
            //tasks.Add(task);


        }

        private void LoadTasks()
        {
            if (File.Exists("tasks.json"))
            {
                string json = File.ReadAllText("tasks.json");
                var saveData = JsonConvert.DeserializeObject<SaveData>(json);
                tasks = saveData.Tasks;
                lastUrl = saveData.Url;
                textBoxUrl.Text = lastUrl;

                if (!string.IsNullOrWhiteSpace(lastUrl) && webView.CoreWebView2 != null)
                {
                    webView.CoreWebView2.Navigate(lastUrl);
                }

                foreach (var task in tasks)
                {
                    dataGridViewTask.Rows.Add(new object[] { task.FieldName, task.Action, task.ExtractedData });
                }
            }
            else
            {
                tasks = new List<ScrapingTask>();
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string url = textBoxUrl.Text;
            if (!string.IsNullOrWhiteSpace(url))
            {
                dataGridViewTask.Rows.Add(new object[] { "Website", "Go", url });
                webView.CoreWebView2.Navigate(url);
                lastUrl = url;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var saveData = new SaveData
            {
                Tasks = tasks,
                Url = lastUrl
            };
            string json = JsonConvert.SerializeObject(saveData, Formatting.Indented);
            File.WriteAllText("tasks.json", json);
        }
    }
    public class ScrapingTask
    {
        public string FieldName { get; set; }
        public string Action { get; set; }
        public string ExtractedData { get; set; }
        public string ElementId { get; set; }
        public string ElementClassName { get; set; }
    }

    public class SaveData
    {
        public List<ScrapingTask> Tasks { get; set; }
        public string Url { get; set; }
    }
}
