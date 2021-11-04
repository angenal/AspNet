using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPost : System.Web.UI.Page
{
    private string m_szName;
    private string m_szAddr1;
    private string m_szAddr2;
    private string m_szCity;
    private string m_szState;
    private string m_szZip;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Check the post command. Note you can not use
        //Page.IsPostBack here because that properties
        //checks view state, which our client side sample
        //did not include in the post form
        if (Request.Form["cmd"] == "AddressLabel")
        {
            //Store the form variables for data binding
            m_szName = Request.Form["name"];
            m_szAddr1 = Request.Form["addr1"];
            m_szAddr2 = Request.Form["addr2"];
            m_szCity = Request.Form["city"];
            m_szState = Request.Form["state"];
            m_szZip = Request.Form["zip"];

            //Repeat 5 rows
            rptAddrList.DataSource = new object[5];
            rptAddrList.DataBind();

            panInfo.Visible = false;
            panResult.Visible = true;
        }
    }

    public string Name { get { return m_szName; } }
    public string Addr1 { get { return m_szAddr1; } }
    public string Addr2 { get { return m_szAddr2; } }
    public string City { get { return m_szCity; } }
    public string State { get { return m_szState; } }
    public string Zip { get { return m_szZip; } }
}
