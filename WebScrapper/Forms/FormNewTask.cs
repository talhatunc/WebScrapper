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
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;
using System.Windows;

namespace WebScrapper
{
    public partial class FormNewTask : Form
    {
        private List<ScrapingTask> tasks;
        private WebView2 webView;

        public FormNewTask()
        {
            tasks = new List<ScrapingTask>();
            InitializeComponent();
            InitializeControls();
        }
        public FormNewTask(string load)
        {
            tasks = new List<ScrapingTask>();
            InitializeComponent();
            InitializeControls();
            LoadTasks(load);
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

        private void LoadTasks(string fileName)
        {
            string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tasks");
            fileName += ".json";
            if (File.Exists(directory + "\\" + fileName))
            {
                string json = File.ReadAllText(directory + "\\" + fileName);
                var saveData = JsonConvert.DeserializeObject<SaveData>(json);
                tasks = saveData.Tasks;

                foreach (var task in tasks)
                {
                    if(task.Action == "GO") { 
                    dataGridViewTask.Rows.Add(new object[] { task.FieldName, task.Action, task.ExtractedData });
                    break;
                    }
                }
            }
            else
            {
                tasks = new List<ScrapingTask>();
            }
            ReplayTasks();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string url = textBoxUrl.Text;
            if (!string.IsNullOrWhiteSpace(url))
            {
                var task = new ScrapingTask
                {
                    FieldName = url,
                    Action = "GO"
                };
                dataGridViewTask.Rows.Add(new object[] { "Website", "Go", url });
                tasks.Add(task);
                webView.CoreWebView2.Navigate(url);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fileName = InputBox.Show("Enter the file name:", "Save Task File");

            if (!string.IsNullOrWhiteSpace(fileName))
            {
                string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tasks");
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                string filePath = Path.Combine(directory, fileName + ".json");

                var saveData = new SaveData
                {
                    Tasks = tasks
                };

                string json = JsonConvert.SerializeObject(saveData, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            //using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            //{
            //    saveFileDialog.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tasks");
            //    saveFileDialog.Filter = "JSON files (*.json)|*.json";
            //    saveFileDialog.Title = "Save Task File";

            //    if (!Directory.Exists(saveFileDialog.InitialDirectory))
            //    {
            //        Directory.CreateDirectory(saveFileDialog.InitialDirectory);
            //    }

            //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        var saveData = new SaveData
            //        {
            //            Tasks = tasks,
            //            Url = lastUrl
            //        };
            //        string json = JsonConvert.SerializeObject(saveData, Formatting.Indented);
            //        File.WriteAllText(saveFileDialog.FileName, json);
            //    }
            //}
        }

        private async void ReplayTasks()
        {
            string script = "document.removeEventListener('mouseover', mouseoverListener);" +
                       "document.removeEventListener('mouseout', mouseoutListener);" +
                      " document.removeEventListener('click', clickListener);";
            foreach (var task in tasks)
            {
                switch (task.Action)
                {
                    case "GO":
                        Uri uriResult;
                        bool isValidUrl = Uri.TryCreate(task.FieldName, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                        if (isValidUrl)
                        {
                            await Task.Delay(3000);
                            textBoxUrl.Text = task.FieldName;
                            if (webView.CoreWebView2 != null)
                            {
                                webView.CoreWebView2.Navigate(task.FieldName);
                                await Task.Delay(2000);
                            }
                            else
                            {
                                System.Windows.Forms.MessageBox.Show("WebView2 baþlatýlamadý.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show($"Geçersiz URL: {task.FieldName}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "Extract Inner Text":
                        script += GenerateScript(task, "innerText", "Extract Inner Text");
                        break;
                    case "Extract Inner HTML":
                        script += GenerateScript(task, "innerHTML", "Extract Inner HTML");
                        break;
                    case "Extract Outer HTML":
                        script += GenerateScript(task, "outerHTML", "Extract Outer Text");
                        break;
                    case "Click Event":
                        script += GenerateScript(task, "click", "Click");
                        break;
                }
            }
            if (script != null)
            {
                await webView.CoreWebView2.ExecuteScriptAsync(script);
            }
        }

        private string GenerateScript(ScrapingTask task, string action,string name)
        {
            string script = null;
            if (!string.IsNullOrEmpty(task.ElementId))
            {
                if (action == "click")
                {
                    script += $"document.getElementById('{task.ElementId}').click();\n";
                }
                else
                {
                    script += $"console.log(document.getElementById('{task.ElementId}').{action});\n";
                }
            }
            else if (!string.IsNullOrEmpty(task.xPath))
            {
                string escapedXPath = task.xPath.Replace("\"", "\\\"");
                if (action == "click")
                {
                    script += $"document.evaluate(\"{escapedXPath}\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.click();\n";
                }
                else
                {
                    script += "console.log('kedi');" +
                    $"var xpath = \"{escapedXPath}\";" +
                    "var node = document.evaluate(xpath, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;" +
                    "if (node) {" +
                        "window.chrome.webview.postMessage(JSON.stringify({" +
                        "    action: '" + name + "'," +
                        "    element: {" +
                        "        tagName: node.tagName," +
                        "        id: node.id," +
                        "        className: node.className," +
                        "        " + action + ": node." + action + "," +
                        "        xpath: xpath" +
                        "    }" +
                        "}));" +
                    "}" +
                    "console.log('kedi');";
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
    }

    public static class InputBox
    {
        public static string Show(string prompt, string title)
        {
            Form form = new Form();
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
            FontAwesome.Sharp.IconButton buttonOk = new FontAwesome.Sharp.IconButton();

            form.Text = title;
            label.Text = prompt;
            textBox.Text = "";

            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOk.FlatAppearance.BorderColor = Color.FromArgb(172, 126, 241);
            buttonOk.FlatStyle = FlatStyle.Flat;
            buttonOk.ForeColor = Color.FromArgb(172, 126, 241);
            buttonOk.IconChar = FontAwesome.Sharp.IconChar.Save;
            buttonOk.IconColor = Color.FromArgb(172, 126, 241);
            buttonOk.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonOk.IconSize = 18;
            buttonOk.Location = new System.Drawing.Point(165, 35);
            buttonOk.Margin = new Padding(3, 3, 8, 8);
            buttonOk.Name = "btnSave";
            buttonOk.Size = new System.Drawing.Size(75, 28);
            buttonOk.TabIndex = 6;
            buttonOk.Text = "SAVE";
            buttonOk.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonOk.UseVisualStyleBackColor = true;

            buttonOk.DialogResult = DialogResult.OK;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);

            label.AutoSize = true;
            label.ForeColor = Color.FromArgb(172, 126, 241);
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new System.Drawing.Size(396, 107);
            form.Controls.AddRange(new System.Windows.Forms.Control[] { label, textBox, buttonOk,
    });

            form.BackColor = Color.FromArgb(34, 33, 74);
            form.ClientSize = new System.Drawing.Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.TopMost = true;

            DialogResult dialogResult = form.ShowDialog();
            return dialogResult == DialogResult.OK ? textBox.Text : null;
        }
    }
}
