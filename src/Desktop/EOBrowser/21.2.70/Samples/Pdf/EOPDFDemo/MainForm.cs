using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Web;
using System.Reflection;
using System.Diagnostics;
using Microsoft.Win32;
using EO.Pdf;

namespace EOPDFDemo
{
    public partial class MainForm : Form, IDemoArgs
    {
        //CSS for HTML messages
        private const string HTMLCSS = @"
.normal
{
    font-size: 11px;
    color: #606060;
    line-height: 16px;
    font-family: Verdana;
}

p
{
    margin-top: 5px;
    margin-bottom: 7px;
}

ul
{
    margin-top: 5px;
    margin-bottom: 5px;
}

ol
{
    margin-top: 5px;
    margin-bottom: 5px;
}

a{
    color: #5F7786;
    text-decoration: underline;
}

a:hover{
    color: #F89C01;
    text-decoration: none;
}

h1 {
    font-family: arial;
    font-size: 17px;
    font-weight: bold;
    border-bottom:1px solid #ccc;
    color:#2f4761;
    text-align:left;
}

h2 {
    font-family: arial;
    font-size: 14px;
    font-weight: normal;
    border-bottom:1px solid #ccc;
    color:#2f4761;
    text-align:left;
}

h3 
{
    font-family: tahoma; 
    font-size: 8pt;     
    font-weight: bold;
    border-bottom:1px solid #ccc;
    color:#2f4761;
    text-align:left;
}

h4 
{
    font-family: tahoma; 
    font-size: 8pt;     
    font-weight: bold;
    color:#2f4761;
    text-align:left;
    margin-bottom: 0px;
    padding-bottom: 0px;
}

.highlight
{
    color: #2f4761; font-weight: bold;
}

.coloredcode .cmt     { color: #008000; }
.coloredcode .cmtg     { color: #008000; }
.coloredcode .st         { color: #A11515; }
.coloredcode .kwdt     { color: #666; }
.coloredcode .kwd     { color: #00f; }
.coloredcode .attr     { color: #f00; }
.coloredcode .attrv     { color: #00f; }
.coloredcode .ec         { color: #00f; }
.coloredcode .tag     { color: #800000; }
.coloredcode .dir    { color: #000; background: #FEFF22; }
.coloredcode .sel    { color: #800000; }
.coloredcode .val    { color: #00f; }
.coloredcode .unit     { color: #800000; }
.coloredcode .sqlcmt { color: #008080; }
.coloredcode .sqlkwd { color: #00f; }
.coloredcode .sqlkwd2 { color: #f0f; }
.coloredcode .sqlkwd3 { color: #999; }
.coloredcode .sqlkwd4 { color: #800000; }
.coloredcode .num     { color: #00f; }
.coloredcode .sqlst  { color: #008000;}
.coloredcode b      { font-weight: normal; color: #008080; }    
";
        private const string UrlRunDemoGif = "sample://demo/RunDemo.gif";

        private Dictionary<string, TreeNode> m_NodesMap = new Dictionary<string, TreeNode>();
        private Demo m_CurDemo;
        private string m_szCurDemoName;
        private bool m_bSampleLoaded;
        private EO.WebBrowser.WebView m_wvInfo;
        private EO.WinForm.WebControl m_wcInfo;
        private EO.WinForm.PdfViewer m_PdfViewer;
        private byte[] m_ResultPdfData;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (LoadSamples())
                    m_bSampleLoaded = true;
            }
            catch (Exception ex)
            {
                ShowError(@"Failed to load samples.", ex);
            }
        }

        private bool LoadSamples()
        {
            try
            {
                EO.WebBrowser.Runtime.RegisterCustomSchemes("sample");

                //Initialize the WebControl that is used to
                //display sample UI HTML
                m_wcInfo = new EO.WinForm.WebControl();
                m_wcInfo.Parent = panClient;
                m_wcInfo.Dock = DockStyle.Fill;
                m_wvInfo = new EO.WebBrowser.WebView();
                m_wvInfo.RegisterJSExtensionFunction("eo_OpenHelp", webView_OpenHelp);
                m_wvInfo.RegisterJSExtensionFunction("eo_GoToDemo", webView_GoToDemo);
                m_wvInfo.RegisterJSExtensionFunction("eo_RunDemo", webView_RunDemo);
                m_wvInfo.RegisterResourceHandler(new SampleHandler(this));
                m_wcInfo.WebView = m_wvInfo;

                //Use a PdfViewer to display the result PDF
                m_PdfViewer = new EO.WinForm.PdfViewer();
                m_PdfViewer.Dock = DockStyle.Fill;
                panClient.Controls.Add(m_PdfViewer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Unable to initialize WebView");

                return false;
            }
            
            //HTML to PDF: Basic
            AddDemo(new EOPDFDemo.Demos.HtmlToPdfDemos.Basic.ConvertUrl("Html to PDF/Basic/Convert Url"));
            AddDemo(new EOPDFDemo.Demos.HtmlToPdfDemos.Basic.ConvertHtml("Html to PDF/Basic/Convert HTML"));
            AddDemo(new EOPDFDemo.Demos.HtmlToPdfDemos.Basic.PageLayout("Html to PDF/Basic/Page Layout"));
            AddDemo(new EOPDFDemo.Demos.HtmlToPdfDemos.Basic.AutoPaging("Html to PDF/Basic/Auto Paging"));
            AddDemo(new EOPDFDemo.Demos.HtmlToPdfDemos.Basic.ZoomLevel("Html to PDF/Basic/Zoom Level"));
            AddDemo(new EOPDFDemo.Demos.HtmlToPdfDemos.Basic.WebAuth("Html to PDF/Basic/Web Authentication"));
            AddDemo(new EOPDFDemo.Demos.HtmlToPdfDemos.Basic.WebPost("Html to PDF/Basic/Web Post Back"));
            AddDemo(new EOPDFDemo.Demos.HtmlToPdfDemos.Basic.Link("Html to PDF/Basic/Hyperlinks"));
            AddDemo(new EOPDFDemo.Demos.HtmlToPdfDemos.Basic.HeaderFooter("Html to PDF/Basic/Header & Footer"));
            AddDemo(new EOPDFDemo.Demos.HtmlToPdfDemos.Basic.AutoBookmark("Html to PDF/Basic/Auto Bookmarks"));

            //HTML to PDF: Advanced
            AddDemo(new EOPDFDemo.Demos.HtmlToPdfDemos.Advanced.ManualPaging("Html to PDF/Advanced/Manual Paging"));
            AddDemo(new EOPDFDemo.Demos.HtmlToPdfDemos.Advanced.UseAcm("Html to PDF/Advanced/Using with PDF Creator"));
            AddDemo(new EOPDFDemo.Demos.HtmlToPdfDemos.Advanced.MergeWebPages("Html to PDF/Advanced/Merge Web Pages"));
            AddDemo(new EOPDFDemo.Demos.HtmlToPdfDemos.Advanced.CustomBookmark("Html to PDF/Advanced/Custom Bookmarks"));
            AddDemo(new EOPDFDemo.Demos.HtmlToPdfDemos.Advanced.CustomLink("Html to PDF/Advanced/Custom Links"));
            AddDemo(new EOPDFDemo.Demos.HtmlToPdfDemos.Advanced.MultiLayer("Html to PDF/Advanced/Multi Layer Output"));
            AddDemo(new EOPDFDemo.Demos.HtmlToPdfDemos.Advanced.PartialPage("Html to PDF/Advanced/Partial Page Conversion"));
            AddDemo(new EOPDFDemo.Demos.HtmlToPdfDemos.Advanced.TableHeader("Html to PDF/Advanced/Repeating Table Header and Footer"));
            AddDemo(new EOPDFDemo.Demos.HtmlToPdfDemos.Advanced.ManualTrigger("Html to PDF/Advanced/Manually Triggering Conversion"));

            //ACM: Basic Demos
            AddDemo(new EOPDFDemo.Acm.Basic.HelloWorld("PDF Creator/Basic/Hello Word"));
            AddDemo(new EOPDFDemo.Acm.Basic.ContentStyle("PDF Creator/Basic/Content Style"));
            AddDemo(new EOPDFDemo.Acm.Basic.ContentTree1("PDF Creator/Basic/Content Tree 1"));
            AddDemo(new EOPDFDemo.Acm.Basic.ContentTree2("PDF Creator/Basic/Content Tree 2"));
            AddDemo(new EOPDFDemo.Acm.Basic.DocInfo("PDF Creator/Basic/Document Information"));

            //ACM: Advanced Formating Demo
            AddDemo(new EOPDFDemo.Acm.AdvancedFormatting.BlockBorder("PDF Creator/Advanced Formatting/Block Border & Margin"));
            AddDemo(new EOPDFDemo.Acm.AdvancedFormatting.InlineBorder("PDF Creator/Advanced Formatting/Inline Border"));
            AddDemo(new EOPDFDemo.Acm.AdvancedFormatting.StyleSheet("PDF Creator/Advanced Formatting/Style Sheet"));
            AddDemo(new EOPDFDemo.Acm.AdvancedFormatting.FloatContent("PDF Creator/Advanced Formatting/Float Content"));
            AddDemo(new EOPDFDemo.Acm.AdvancedFormatting.FixedPosByFloat("PDF Creator/Advanced Formatting/Fixed Position with Floating"));
            AddDemo(new EOPDFDemo.Acm.AdvancedFormatting.Image("PDF Creator/Advanced Formatting/Image"));
            AddDemo(new EOPDFDemo.Acm.AdvancedFormatting.Table("PDF Creator/Advanced Formatting/Table"));
            AddDemo(new EOPDFDemo.Acm.AdvancedFormatting.Table2("PDF Creator/Advanced Formatting/Table - Advanced"));
            AddDemo(new EOPDFDemo.Acm.AdvancedFormatting.MultiColumn("PDF Creator/Advanced Formatting/Multi-Column"));
            AddDemo(new EOPDFDemo.Acm.AdvancedFormatting.PageHeader("PDF Creator/Advanced Formatting/Page Header"));

            //ACM: Interactive Features
            AddDemo(new EOPDFDemo.Acm.Interactive.Bookmark("PDF Creator/Interactive Features/Bookmark"));
            AddDemo(new EOPDFDemo.Acm.Interactive.Link("PDF Creator/Interactive Features/Link"));
            AddDemo(new EOPDFDemo.Acm.Interactive.FillInForm("PDF Creator/Interactive Features/Fill in Form"));

            //ACM: Low Level Content API
            AddDemo(new EOPDFDemo.Acm.PdfContentAPI.Text("PDF Creator/Low Level Content API/Text"));
            AddDemo(new EOPDFDemo.Acm.PdfContentAPI.Image("PDF Creator/Low Level Content API/Image"));
            AddDemo(new EOPDFDemo.Acm.PdfContentAPI.Path("PDF Creator/Low Level Content API/Path"));
            AddDemo(new EOPDFDemo.Acm.PdfContentAPI.Watermark("PDF Creator/Low Level Content API/Watermark"));
            AddDemo(new EOPDFDemo.Acm.PdfContentAPI.RubberStamp("PDF Creator/Low Level Content API/Rubber Stamp"));

            //With Existing PDF files
            AddDemo(new EOPDFDemo.Demos.WithExistingFiles.Modify("With Existing PDF Files/Modify PDF file"));
            AddDemo(new EOPDFDemo.Demos.WithExistingFiles.ExtractPages("With Existing PDF Files/Extract Pages"));
            AddDemo(new EOPDFDemo.Demos.WithExistingFiles.Merge("With Existing PDF Files/Merge PDF Files"));

            //Advanced Features
            AddDemo(new EOPDFDemo.Demos.Advanced.FilePassword("Advanced Features/PDF File Password"));
            AddDemo(new EOPDFDemo.Demos.Advanced.FilePermission("Advanced Features/PDF File Permission"));
            AddDemo(new EOPDFDemo.Demos.Advanced.LoadEncrypted("Advanced Features/Load Password Protected File"));

            //PdfViewer
            AddDemo(new EOPDFDemo.Demos.PdfViewerDemo("Pdf Viewer"));

            return true;
        }

        #region Custom Resource Handler & JavaScript Extensions
        private class SampleHandler: EO.WebBrowser.ResourceHandler
        {
            private MainForm m_Owner;

            public SampleHandler(MainForm owner)
            {
                m_Owner = owner;
            }

            public override bool Match(EO.WebBrowser.Request request)
            {
                if (request.Url == UrlRunDemoGif)
                    return true;

                return false;
            }

            public override void ProcessRequest(EO.WebBrowser.Request request, EO.WebBrowser.Response response)
            {
                if (request.Url == UrlRunDemoGif)
                {
                    string resxName = "EOPDFDemo.RunDemo.gif";
                    response.WriteResource(this.GetType().Assembly, resxName, "image/gif");
                }
            }
        }

        void webView_OpenHelp(object sender, EO.WebBrowser.JSExtInvokeArgs e)
        {
            string topic = (string)e.Arguments[0];
            try
            {
                string helpFileName = "EO.Total Help.chm";
                string helpFilePath = Path.Combine(GetInstallDir(), helpFileName);

                Help.ShowHelp(this, helpFilePath, HelpNavigator.Topic, string.Format("{0}.chm::/{1}", helpFileName, topic));
            }
            catch
            {
                MessageBox.Show(this, "An error occured while loading the help topic. Please check whether EO.Pdf Help.chm is in the same directory as the EOPdfDemo.exe.",
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void webView_GoToDemo(object sender, EO.WebBrowser.JSExtInvokeArgs e)
        {
            GoToDemo((string)e.Arguments[0]);
        }

        void webView_RunDemo(object sender, EO.WebBrowser.JSExtInvokeArgs e)
        {
            //Can not call RunDemo directly here because:
            //1. This is a JavaScript extension function;
            //2. RunDemo calls EvalScript;
            //Calling EvalScript is not allowed inside a JavaScript
            //extension function because it would cause the JavaScript 
            //engine to re-enter, which is not allowed.
            //As a result, we use BeginInvoke to delay calling RunDemo 
            //until after this JavaScript extension function returns
            BeginInvoke(new EO.Base.Action(RunDemo));
        }
        #endregion

        #region Utility Functions
        private void AddDemo(Demo demo)
        {
            string[] path = demo.Path.Split('/');
            TreeNode node = GetNode(path, path.Length);
            node.Tag = demo;
        }

        private TreeNode GetNode(string[] path, int depth)
        {
            string key = GetNodeKey(path, depth);

            TreeNode node = null;
            if (m_NodesMap.TryGetValue(key, out node))
                return node;

            TreeNodeCollection nodes = null;
            if (depth == 1)
                nodes = tvDemos.Nodes[0].Nodes;
            else
            {
                TreeNode parentNode = GetNode(path, depth - 1);
                nodes = parentNode.Nodes;
            }

            node = new TreeNode();
            node.Text = path[depth - 1];
            nodes.Add(node);
            m_NodesMap[key] = node;
            return node;
        }

        private string GetNodeKey(string[] path, int depth)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < depth; i++)
            {
                if (sb.Length > 0)
                    sb.Append('/');
                sb.Append(path[i]);
            }
            return sb.ToString();
        }

        private void ShowError(string error, Exception ex)
        {
            error = string.Format(
                "<div style='font-size:12px;color:red;padding-bottom:20px;'>{0}</div>", error);
            if (ex != null)
            {
                error = string.Format("{0}<p>Exception:</p><pre>{1}</pre>",
                    error, HttpUtility.HtmlEncode(ex.ToString()));
            }

            ShowHTML(tbViewInst, error, true);
        }

        private void ShowHTML(ToolStripButton button, string message, bool error)
        {
            if (button != null)
            {
                tbViewInst.Checked = tbViewInst == button;
                tbViewCSCode.Checked = tbViewCSCode == button;
                tbViewVBCode.Checked = tbViewVBCode == button;
            }

            m_PdfViewer.Visible = false;
            m_wcInfo.Visible = true;

            //Add title and "Run This Demo" link button
            string title = string.Empty;
            string runDemo = string.Empty;
            if (m_szCurDemoName != null)
            {
                title = string.Format("<h3>{0}</h3>", m_szCurDemoName);
                if (tbViewInst.Checked && !error)
                    runDemo = string.Format(@"<div style=""padding-top:10px;"">
<a href=""javascript:eo_RunDemo();""><img border=""0"" src=""{0}"" alt=""Run Demo"" /></a>
</div>", UrlRunDemoGif);
            }

            //Create a full HTML document based on the
            //message that includes our styles and script
            Regex regex = new Regex(
                @"<body>([\w\W]*)</body>", RegexOptions.IgnoreCase);
            Match match = regex.Match(message);
            if (!match.Success)
            {
                message = string.Format(@"
<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
<body>
{0}
</body>
</html>
", message);
                match = regex.Match(message);
            }
            message = string.Format(@"{0}
<body>
<script type=""text/javascript"">
function getArgument(id)
{{
    var e = document.getElementById(id);
    if ((e.type == ""text"") || (e.type == ""textarea"") || (e.type==""password""))
        return e.value;
    else if (e.type == ""checkbox"")
        return e.checked ? ""1"" : ""0"";
    else if (e.tagName == ""SELECT"")
        return e.options[e.selectedIndex].value;
}}

function setArg(id, value)
{{
    var txt = document.getElementById(id);
    if (txt)
        txt.value = value;
}}

function setUrl(url)
{{
    setArg(""txtUrl"", url);
}}
</script>
<style type=""text/css"">
{1}
</style>
{2}
<div class=""normal"">
{3}
{4}
</div>
</body>
</html>",
                message.Substring(0, match.Index),
                HTMLCSS, title, match.Groups[1].Value, runDemo);
            //Load the HTML
            m_wvInfo.LoadHtml(message).OnDone(() =>
                {
                    InitDemoArgs(m_wvInfo);
                });
        }

        private void InitDemoArgs(EO.WebBrowser.WebView webView)
        {
            string webDemoUrl = null;
            if (m_CurDemo is EOPDFDemo.Demos.HtmlToPdfDemos.Basic.WebAuth)
                webDemoUrl = StartWebDemoForm.GetWebDemoUrl(this, "WebAuth.aspx?ReturnUrl=dummy");
            else if (m_CurDemo is EOPDFDemo.Demos.HtmlToPdfDemos.Basic.WebPost)
                webDemoUrl = StartWebDemoForm.GetWebDemoUrl(this, "WebPost.aspx");
            if (webDemoUrl != null)
                webView.InvokeFunction("setUrl", webDemoUrl);

            if (m_CurDemo is EOPDFDemo.Demos.WithExistingFiles.ExtractPages)
                webView.InvokeFunction("setArg", "txtFileName", Demo.GetInputFilePath("Wikipedia_HTML.pdf"));
            else if (m_CurDemo is EOPDFDemo.Demos.WithExistingFiles.Merge)
            {
                webView.InvokeFunction("setArg", "txtFile1", Demo.GetInputFilePath("Chapter1.pdf"));
                webView.InvokeFunction("setArg", "txtFile2", Demo.GetInputFilePath("Chapter2.pdf"));
            }
        }

        protected override void DestroyHandle()
        {
            try
            {
                base.DestroyHandle();
            }
            catch
            {
            }
        }

        private void GoToDemo(string demoPath)
        {
            string[] path = demoPath.Split('/');
            TreeNode node = GetNode(path, path.Length);
            tvDemos.SelectedNode = node;
        }

        internal static string GetInstallDir()
        {
            string exePath = typeof(MainForm).Assembly.Location;
            string exeDir = Path.GetDirectoryName(exePath);
            int index = exeDir.ToLower().IndexOf("samples\\cs\\pdf\\eopdfdemo\\");
            if (index < 0)
                index = exeDir.ToLower().IndexOf("samples\\vb\\pdf\\eopdfdemo\\");
            if (index > 0)
                exeDir = exeDir.Substring(0, index);
            return exeDir;
        }
        #endregion

        #region Event Handlers
        private void tvDemos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!m_bSampleLoaded)
                return;

            Demo curDemo = null;
            if ((tvDemos.SelectedNode != null) &&
                (tvDemos.SelectedNode.Tag != null))
                curDemo = (Demo)tvDemos.SelectedNode.Tag;

            m_CurDemo = curDemo;
            if (curDemo != null)
                m_szCurDemoName = tvDemos.SelectedNode.Text;
            else
                m_szCurDemoName = null;

            if (m_CurDemo == null)
            {
                tbViewInst.Enabled = false;
                tbViewCSCode.Enabled = false;
                tbViewVBCode.Enabled = false;

                tbViewInst_Click(null, null);
            }
            else
            {
                tbViewCSCode.Enabled = true;
                tbViewVBCode.Enabled = true;
                tbViewInst.Enabled = true;

                if (tbViewCSCode.Checked)
                    tbViewCSCode_Click(null, null);
                else if (tbViewVBCode.Checked)
                    tbViewVBCode_Click(null, null);
                else
                    tbViewInst_Click(null, null);
            }
        }

        private void RunDemo()
        {
            m_ResultPdfData = null;
            if (!m_CurDemo.HasPdfResult())
            {
                m_CurDemo.RunDemo(null, this);
                return;
            }

            try
            {
                string error = null;
                using (RunDemoForm form = new RunDemoForm(this, m_CurDemo))
                {
                    form.ShowDialog(this);
                    error = form.Error;
                    m_ResultPdfData = form.Result;
                }
                if (error != null)
                {
                    MessageBox.Show(this, error, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoadResult();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message, ex);
            }
        }

        private void ShowDemoCode(ToolStripButton button)
        {
            //Get the code to display
            string code = null;
            if (button == tbViewCSCode)
                code = m_CurDemo.GetCSCode();
            else if (button == tbViewVBCode)
                code = m_CurDemo.GetVBCode();
            else
                code = m_CurDemo.GetInstructions();
            if ((button == tbViewCSCode) ||
                (button == tbViewVBCode))
            {
                code = string.Format(@"
<p>
Below is the related source code. The full C# and VB source code of the 
demo project is available on your machine with project file in Visual 
Studio 2005, Visual Studio 2008 and Visual 2010 format. To go to the 
project folder, click <b>Start</b> -> <b>All Programs</b> -> <b>EO.Pdf 
xxxx</b> -> <b>Samples</b> -> <b>EO.Pdf Demo Source Code (C#)</b> or 
<b>EO.Pdf Demo Source Code (Visual Basic.NET)</b>.
</p>
<div style='background-color: ghostwhite;padding: 2px 10px 2px 10px;'>
    {0}
</div>
", code);
            }

            ShowHTML(button, code, false);
        }

        private void tbViewCSCode_Click(object sender, EventArgs e)
        {
            ShowDemoCode(tbViewCSCode);
        }

        private void tbViewVBCode_Click(object sender, EventArgs e)
        {
            ShowDemoCode(tbViewVBCode);
        }

        private void tbViewInst_Click(object sender, EventArgs e)
        {
            if (!m_bSampleLoaded)
                return;

            if (m_CurDemo == null)
            {
                ShowHTML(null,
                    @"EO.Pdf is a .NET class library for you to generate PDF 
                        file in your application. This demo application demonstrates
                        how to generate PDF file with EO.Pdf. Please select a demo 
                        from the TreeView on the left side, then click the
                        ""Run Demo"" button at the bottom of the page to run it. 
                        That will create a PDF file using EO.Pdf and display the 
                        result PDF file here.", false);
            }
            else
            {
                ShowDemoCode(tbViewInst);
            }
        }

        private void tbViewPDF_Click(object sender, EventArgs e)
        {
            m_wcInfo.Visible = false;
            m_PdfViewer.Visible = true;
            LoadResult();
        }

        public void LoadResult()
        {
            if (m_ResultPdfData != null)
            {
                tbViewPDF.Enabled = true;
                m_wcInfo.Visible = false;
                m_PdfViewer.Visible = true;
                m_PdfViewer.Load(m_ResultPdfData);
            }
            else
            {
                m_PdfViewer.Clear();
                m_PdfViewer.Visible = false;
                tbViewPDF.Enabled = false;
            }
        }
        #endregion

        #region IDemoArgs Members
        public string GetString(string id)
        {
            object retValue = m_wvInfo.InvokeFunction("getArgument", id);
            return retValue as string;
        }

        #endregion
    }
}
