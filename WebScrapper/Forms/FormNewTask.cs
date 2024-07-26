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
            tasks = new List<ScrapingTask>();
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

            // WebView2'nin başlatılmasını bekleyin
            await webView.EnsureCoreWebView2Async(null);

            // WebView2 başlatıldıktan sonra CoreWebView2'yi kullanın
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

                        currentElement = event;

                        var modalContent = `
                            <div id='modalWebScrapper' style='position: fixed; top: 0; left: 0; width: 100%; height: 100%; background-color: rgba(0,0,0,0.5); display: flex; justify-content: center; align-items: center;'>
                                <div style='background-color: white; padding: 20px; border-radius: 10px;'>
                                    <h3>Choose an action for the element:</h3>
                                    <button title='` + escapeHtml(currentElement.target.innerText) + `' onclick='extractInnerText()'>Extract Inner Text</button>
                                    <button title='` + escapeHtml(currentElement.target.innerHTML) + `' onclick='extractInnerHTML()'>Extract Inner HTML</button>
                                    <button title='` + escapeHtml(currentElement.target.outerHTML) + `' onclick='extractOuterHTML()'>Extract Outer HTML</button>
                                    <button title='Click' onclick='extractClickEvent()'>Click</button>
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
                        var elementTarget = currentElement.target;
                        window.chrome.webview.postMessage(JSON.stringify({
                            action: 'Extract Inner Text',
                            element: {
                                tagName: elementTarget.tagName,
                                id: elementTarget.id,
                                className: elementTarget.className,
                                innerText: elementTarget.innerText,
                                xpath: generateXPath(elementTarget)
                            },
                            event: currentElement
                        }));
                        closeModal();
                    }
                }

                function extractInnerHTML() {
                    if (currentElement) {
                        var elementTarget = currentElement.target;
                        window.chrome.webview.postMessage(JSON.stringify({
                            action: 'Extract Inner HTML',
                            element: {
                                tagName: elementTarget.tagName,
                                id: elementTarget.id,
                                className: elementTarget.className,
                                innerHTML: elementTarget.innerHTML,
                                xpath: generateXPath(elementTarget)
                            }
                        }));
                        closeModal();
                    }
                }

                function extractClickEvent() {
                    if (currentElement) {
                        var elementTarget = currentElement.target;
                        window.chrome.webview.postMessage(JSON.stringify({
                            action: 'Click Event',
                            element: {
                                tagName: elementTarget.tagName,
                                id: elementTarget.id,
                                className: elementTarget.className,
                                outerHTML: elementTarget.outerHTML,
                                xpath: generateXPath(elementTarget)
                            }
                        }));
                        elementTarget.click();
                        closeModal();
                    }
                }

                function extractOuterHTML() {
                    if (currentElement) {
                        var elementTarget = currentElement.target;
                        window.chrome.webview.postMessage(JSON.stringify({
                            action: 'Extract Outer HTML',
                            element: {
                                tagName: elementTarget.tagName,
                                id: elementTarget.id,
                                className: elementTarget.className,
                                outerHTML: elementTarget.outerHTML,
                                xpath: generateXPath(elementTarget)
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

                //XPath
                function generateXPath(element) {
                    if (element.id !== '') {
                        return '//*[@id=""' + element.id + '""]';
                    }
                    if (element === document.body) {
                        return '/html/body';
                    }
                    var ix = 0;
                    var siblings = element.parentNode.childNodes;
                    for (var i = 0; i < siblings.length; i++) {
                        var sibling = siblings[i];
                        if (sibling === element) {
                            return generateXPath(element.parentNode) + '/' + element.tagName.toLowerCase() + '[' + (ix + 1) + ']';
                        }
                        if (sibling.nodeType === 1 && sibling.tagName === element.tagName) {
                            ix++;
                        }
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

            var task = new ScrapingTask
            {
                FieldName = element.tagName,
                Action = action,
                ExtractedData = extractedData,
                ElementId = element.id,
                ElementClassName = element.className,
                xPath = element.xpath,
            };
            tasks.Add(task);

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
            //var saveData = new SaveData
            //{
            //    Tasks = tasks,
            //    Url = lastUrl
            //};
            //string json = JsonConvert.SerializeObject(saveData, Formatting.Indented);
            //File.WriteAllText("tasks.json", json);
            ReplayTasks();
        }

        private async void ReplayTasks()
        {
            if (!string.IsNullOrWhiteSpace(lastUrl))
            {
                webView.CoreWebView2.Navigate(lastUrl);

                await Task.Delay(5000); // Wait for the page to load

                foreach (var task in tasks)
                {
                    string script = null;

                    switch (task.Action)
                    {
                        case "Extract Inner Text":
                            script = GenerateScript(task, "innerText");
                            break;
                        case "Extract Inner HTML":
                            script = GenerateScript(task, "innerHTML");
                            break;
                        case "Extract Outer HTML":
                            script = GenerateScript(task, "outerHTML");
                            break;
                        case "Click Event":
                            script = GenerateScript(task, "click");
                            break;
                    }

                    if (script != null)
                    {
                        await webView.CoreWebView2.ExecuteScriptAsync(script);
                    }
                }
            }
        }

        private string GenerateScript(ScrapingTask task, string action)
        {
            string script = "document.removeEventListener('mouseover', mouseoverListener);" +
                            "document.removeEventListener('mouseout', mouseoutListener);" +
                            " document.removeEventListener('click', clickListener);";
            if (!string.IsNullOrEmpty(task.ElementId))
            {
                if (action == "click")
                {
                    script += $"document.getElementById('{task.ElementId}').click();";
                }
                else
                {
                    script += $"console.log(document.getElementById('{task.ElementId}').{action});";
                }
            }
            else if (!string.IsNullOrEmpty(task.xPath))
            {
                string escapedXPath = task.xPath.Replace("\"", "\\\"");
                if (action == "click")
                {
                    script += $"document.evaluate(\"{escapedXPath}\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.click();";
                }
                else
                {
                    script += $"console.log(document.evaluate(\"{escapedXPath}\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.{action});";
                }
            }
            return script;
        }

    }
    public class ScrapingTask
    {
        public string FieldName { get; set; }
        public string Action { get; set; }
        public string ExtractedData { get; set; }
        public string ElementId { get; set; }
        public string ElementClassName { get; set; }
        public string xPath { get; set; }
    }

    public class SaveData
    {
        public List<ScrapingTask> Tasks { get; set; }
        public string Url { get; set; }
    }
}
