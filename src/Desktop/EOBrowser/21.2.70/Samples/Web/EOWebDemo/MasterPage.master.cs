using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public void LoadDemo()
    {
        //Check query string if it's an initial page request
        if (!IsPostBack)
        {
            //Check whether to display demo source information
            if (Request.QueryString["Source"] != null)
            {
                Response.Redirect("~/Source.aspx");
                return;
            }

            tvDemos.SelectedNode = null;
            string id = Request.QueryString["id"];
            if (id != null)
            {
                EO.Web.NavigationItem[] nodes = tvDemos.SearchItems(id);
                if (nodes.Length > 0)
                    LoadDemo((EO.Web.TreeNode)nodes[0]);
                else
                {
                    EO.Web.Runtime.ResetState(tvDemos);
                    Response.Redirect("~/Default.aspx");
                }
                return;
            }
            string path = Request.QueryString["path"];
            if (path != null)
            {
                EO.Web.TreeNode node = (EO.Web.TreeNode)tvDemos.FindItem(path);
                LoadDemo(node);
                return;
            }
        }
    }

    private string GetTitleFromNode(EO.Web.TreeNode node)
    {
        string titleText = string.Empty;
        while (node.Level >= 0)
        {
            if (titleText == string.Empty)
                titleText = node.Text;
            else
                titleText = node.Text + " : " + titleText;
            node = node.ParentNode;
        }
        titleText += " - EO.Web Controls Demo";
        return titleText;
    }

    private void LoadDemo(EO.Web.TreeNode node)
    {
        tvDemos.SelectedNode = node;

        //Get the demo path
        string demoPath = GetDemoPath(node);

        //Load demo file
        if (File.Exists(Server.MapPath(demoPath)))
            Response.Redirect(demoPath);
    }

    protected string GetDemoPath(EO.Web.TreeNode node)
    {
        string demoPath = node.Text;
        while (node.Level > 0)
        {
            demoPath = Path.Combine(node.ParentNode.Text, demoPath);
            node = node.ParentNode;
        }

        demoPath = Path.Combine("~\\Demos", demoPath);
        demoPath = demoPath.Replace("&", "and");
        demoPath = Path.Combine(demoPath, "Demo.aspx");

        return demoPath;
    }

    protected void Page_Init(object sender, System.EventArgs e)
    {
        //Make sure the tree view is populated
        tvDemos.DataBind();

        //Populate repeater to build menu items
        int rows = (tvDemos.Nodes.Count + 1) / 2;
        rptControls.DataSource = new object[rows];
        rptControls.DataBind();

        //Update version info
        lblEOWebVersion.Text = typeof(EO.Web.WebControl).Assembly.GetName().Version.ToString();
        lblDotNetVersion.Text = Environment.Version.ToString();
    }

    protected void rptControls_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        int index = e.Item.ItemIndex;
        EO.Web.TreeNode leftNode = tvDemos.Nodes[index];
        EO.Web.TreeNode rightNode = null;
        index = index + (tvDemos.Nodes.Count + 1) / 2;
        if (index < tvDemos.Nodes.Count)
            rightNode = tvDemos.Nodes[index];

        HyperLink leftLink = (HyperLink)e.Item.FindControl("lk1");
        HyperLink rightLink = (HyperLink)e.Item.FindControl("lk2");
        leftLink.Text = leftNode.Text;
        leftLink.NavigateUrl = leftNode.NavigateUrl;
        if (rightNode == null)
            rightLink.Visible = false;
        else
        {
            rightLink.Text = rightNode.Text;
            rightLink.NavigateUrl = rightNode.NavigateUrl;
        }
    }

    protected void tvDemos_ItemDataBound(object sender, EO.Web.NavigationItemEventArgs e)
    {
        string demoPath = GetDemoPath(e.TreeNode);
        if (File.Exists(Server.MapPath(demoPath)))
            e.TreeNode.NavigateUrl = demoPath;
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        tvDemos.AutoSelect();
        EO.Web.TreeNode selectedNode = tvDemos.SelectedNode;
        if (selectedNode != null)
            title.Text = GetTitleFromNode(selectedNode);

        //Load additional pages

        string[] optionalPages = new string[] { "Remarks", "ASPX", "VB", "CS", "JS" };
        for (int i = 0; i < optionalPages.Length; i++)
        {
            //Find the correct page view
            EO.Web.PageView pageView = null;
            string pageName = optionalPages[i];
            switch (pageName)
            {
                case "Remarks":
                    pageView = pvRemarks;
                    break;
                case "ASPX":
                    pageView = pvASPX;
                    break;
                case "CS":
                    pageView = pvCS;
                    break;
                case "VB":
                    pageView = pvVB;
                    break;
                case "JS":
                    pageView = pvJS;
                    break;
            }

            //Load the page
            string fileName = pageName + ".inc";
            fileName = Request.MapPath(fileName);
            if (File.Exists(fileName))
            {
                pageView.Controls.Add(LoadPageContent(fileName));
                tsDemo.Items[i + 1].Visible = true;
                pageView.Visible = true;
            }
            else
            {
                tsDemo.Items[i + 1].Visible = false;
                pageView.Visible = false;
            }
        }
    }

    private LiteralControl LoadPageContent(string fileName)
    {
        using (StreamReader reader = File.OpenText(fileName))
        {
            string content = reader.ReadToEnd();
            return new LiteralControl(content);
        }
    }
}
