using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Xml.Linq;
using Newtonsoft.Json;

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
                document.addEventListener('mouseover', function(event) {
                    event.target.style.border = '2px solid red';
                });
                document.addEventListener('mouseout', function(event) {
                    event.target.style.border = '';
                });
                document.addEventListener('click', function(event) {
                    event.preventDefault();
                    window.chrome.webview.postMessage({
                        tagName: event.target.tagName,
                        id: event.target.id,
                        className: event.target.className,
                        innerHTML: event.target.innerHTML,
                        innerText: event.target.innerText,
                        outerHTML: event.target.outerHTML
                    });
                });
            ";
            await webView.CoreWebView2.ExecuteScriptAsync(script);

            // Önceki görevleri yeniden yükleyin
            if (tasks != null && tasks.Count > 0)
            {
                foreach (var task in tasks)
                {
                    string taskScript = $@"
                        var elements = document.getElementsByTagName('{task.FieldName}');
                        for (var i = 0; i < elements.length; i++) {{
                            if (elements[i].id === '{task.ElementId}' && elements[i].className === '{task.ElementClassName}') {{
                                window.chrome.webview.postMessage({{
                                    tagName: elements[i].tagName,
                                    id: elements[i].id,
                                    className: elements[i].className,
                                    innerHTML: elements[i].innerHTML,
                                    innerText: elements[i].innerText,
                                    outerHTML: elements[i].outerHTML
                                }});
                                break;
                            }}
                        }}
                    ";
                    await webView.CoreWebView2.ExecuteScriptAsync(taskScript);
                }
            }
        }

        private void WebView_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            string message = e.WebMessageAsJson;
            dynamic element = JsonConvert.DeserializeObject(message);

            var form = new Form
            {
                Width = 300,
                Height = 200,
                Text = "Choose an action"
            };

            var label = new Label
            {
                Left = 10,
                Top = 10,
                Width = 260,
                Text = "Choose what to extract from the element:"
            };
            form.Controls.Add(label);

            var innerTextButton = new Button
            {
                Text = "Extract Inner Text",
                Left = 10,
                Width = 120,
                Top = 40
            };
            innerTextButton.Click += (s, args) =>
            {
                AddTask(element, "Extract Inner Text", (string)element.innerText);
                form.Close();
            };
            form.Controls.Add(innerTextButton);

            var innerHTMLButton = new Button
            {
                Text = "Extract Inner HTML",
                Left = 150,
                Width = 120,
                Top = 40
            };
            innerHTMLButton.Click += (s, args) =>
            {
                AddTask(element, "Extract Inner HTML", (string)element.innerHTML);
                form.Close();
            };
            form.Controls.Add(innerHTMLButton);

            var outerHTMLButton = new Button
            {
                Text = "Extract Outer HTML",
                Left = 10,
                Width = 120,
                Top = 80
            };
            outerHTMLButton.Click += (s, args) =>
            {
                AddTask(element, "Extract Outer HTML", (string)element.outerHTML);
                form.Close();
            };
            form.Controls.Add(outerHTMLButton);

            form.ShowDialog();
        }

        private void AddTask(dynamic element, string action, string extractedData)
        {
            // DataGridView'a ekle
            dataGridViewTask.Rows.Add(new object[] { element.tagName, action, extractedData });

            // Yeni görevi listeye ekle
            var task = new ScrapingTask
            {
                FieldName = element.tagName,
                Action = action,
                ExtractedData = extractedData,
                ElementId = element.id,
                ElementClassName = element.className
            };
            tasks.Add(task);

            // Görevleri ve URL'yi kaydet
            SaveTasks();
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

        private void SaveTasks()
        {
            var saveData = new SaveData
            {
                Tasks = tasks,
                Url = lastUrl
            };
            string json = JsonConvert.SerializeObject(saveData, Formatting.Indented);
            File.WriteAllText("tasks.json", json);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string url = textBoxUrl.Text;
            if (!string.IsNullOrWhiteSpace(url))
            {
                webView.CoreWebView2.Navigate(url);
                lastUrl = url;
            }
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
