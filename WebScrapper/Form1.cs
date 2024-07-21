using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Xml.Linq;

namespace WebScrapper
{
    public partial class Form1 : Form
    {
        private WebView2 webView;

        public Form1()
        {
            InitializeComponent();
            InitializeControls();
        }
        private async void InitializeControls()
        {
            webView = new WebView2();
            webView.Top = 40;
            webView.Left = 10;
            webView.Width = this.ClientSize.Width - 20;
            webView.Height = this.ClientSize.Height - 50;
            webView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Controls.Add(webView);

            await webView.EnsureCoreWebView2Async(null);

            webView.CoreWebView2.DOMContentLoaded += WebView_DOMContentLoaded;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

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
                        innerHTML: event.target.innerHTML
                    });
                });
            ";
            await webView.CoreWebView2.ExecuteScriptAsync(script);

            //Listen
            webView.CoreWebView2.WebMessageReceived += WebView_WebMessageReceived;
        }

         private void WebView_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            //Recieve
            string message = e.WebMessageAsJson;
            dynamic element = Newtonsoft.Json.JsonConvert.DeserializeObject(message);

            string innerHTML = element.innerHTML;


            var form = new Form
            {
                Width = 400,
                Height = 200,
                Text = "Seçilen Element Bilgisi"
            };

            var label = new Label
            {
                Left = 10,
                Top = 10,
                Width = 360,
                Text = innerHTML
            };

            var copyButton = new Button
            {
                Text = "Kopyala",
                Left = 10,
                Width = 100,
                Top = label.Bottom + 10
            };

            copyButton.Click += (s, args) =>
            {
                Clipboard.SetText(innerHTML);
                MessageBox.Show("HTML içeriði kopyalandý.");
            };

            form.Controls.Add(label);
            form.Controls.Add(copyButton);
            form.ShowDialog();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string url = textBoxUrl.Text;
            if (!string.IsNullOrWhiteSpace(url))
            {
                webView.CoreWebView2.Navigate(url);
            }
        }
    }
}
