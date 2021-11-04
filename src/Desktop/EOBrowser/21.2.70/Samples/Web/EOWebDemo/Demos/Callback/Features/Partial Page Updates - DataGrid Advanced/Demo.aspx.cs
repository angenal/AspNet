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
using System.Data.OleDb;
using EO.Web.Demo;

public partial class Demos_Callback_Features_Partial_Page_Updates___DataGrid_Advanced_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Usually you would use IsPostBack to determine whether
        //you need to populate the DataGrid. However that does
        //not work at here because this Demo itself is being
        //dynamically loaded by a Callback, which is implemented
        //as a HTTP POST and result in IsPostBack returning true
        if (!CallbackPanel1.IsCallbackByMe)
        {
            LoadData(null, null, null);
        }
    }
    private string m_szCurMaker;
    private string m_szCurModel;
    private string m_szCurStyle;

    private void LoadData(string curMaker, string curModel, string curStyle)
    {
        m_szCurMaker = curMaker;
        m_szCurModel = curModel;
        m_szCurStyle = curStyle;

        using (DemoDB db = new DemoDB())
        {
            OleDbDataReader reader = db.ExecuteReader(
                "select Maker, Model, Style, Description from Cars Order By Maker");
            DataGrid1.DataSource = reader;
            DataGrid1.DataBind();
        }
    }

    protected void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            DataGrid1.EditItemIndex = e.Item.ItemIndex;
            LoadData(null, null, null);
        }
    }

    protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        if ((e.Item.ItemIndex >= 0) &&
            (e.Item.ItemIndex == DataGrid1.EditItemIndex))
        {
            //Find the drop down list
            DropDownList cbMaker = (DropDownList)e.Item.FindControl("cbMaker");
            DropDownList cbModel = (DropDownList)e.Item.FindControl("cbModel");
            DropDownList cbStyle = (DropDownList)e.Item.FindControl("cbStyle");
            Label lblDesc = (Label)e.Item.FindControl("lblDesc");

            using (DemoDB db = new DemoDB())
            {
                if (m_szCurMaker == null)
                {
                    //Hasn't selected Maker yet. Fill the Maker list
                    cbMaker.Items.Add("- Select -");
                    using (OleDbDataReader reader =
                               db.ExecuteReader("select distinct(Maker) from Cars order by Maker"))
                    {
                        while (reader.Read())
                            cbMaker.Items.Add(reader["Maker"].ToString());
                    }

                    //Disable Model and Style dropdown list
                    cbModel.Items.Add("- Select -");
                    cbModel.Enabled = false;
                    cbStyle.Items.Add("- Select -");
                    cbStyle.Enabled = false;

                    lblDesc.Text = "Please select a maker";
                }
                else if (m_szCurModel == null)
                {
                    //Maker has already been chosen, disable it
                    cbMaker.Items.Add(m_szCurMaker);
                    cbMaker.Enabled = false;

                    //Fill Model drop down list
                    cbModel.Items.Add("- Select -");
                    using (OleDbDataReader reader = db.ExecuteReader(
                               string.Format("select distinct(Model) from Cars where Maker = '{0}' order by Model", m_szCurMaker)))
                    {
                        while (reader.Read())
                            cbModel.Items.Add(reader["Model"].ToString());
                    }
                    cbModel.Enabled = true;

                    //Disable Style dropdown list
                    cbStyle.Items.Add("- Select -");
                    cbStyle.Enabled = false;

                    lblDesc.Text = "Please select a model";
                }
                else if (m_szCurStyle == null)
                {
                    //Maker has already been chosen, disable it
                    cbMaker.Items.Add(m_szCurMaker);
                    cbMaker.Enabled = false;

                    //Model has already been chosen, disable it
                    cbModel.Items.Add(m_szCurModel);
                    cbModel.Enabled = false;

                    //Fill Style drop down list
                    cbStyle.Items.Add("- Select -");
                    using (OleDbDataReader reader = db.ExecuteReader(
                        string.Format("select distinct(Style) from Cars where Maker = '{0}' and Model = '{1}' order by Style", m_szCurMaker, m_szCurModel)))
                    {
                        while (reader.Read())
                            cbStyle.Items.Add(reader["Style"].ToString());
                    }
                    cbStyle.Enabled = true;

                    lblDesc.Text = "Please select a style";
                }
                else
                {
                    //Use has done chosing the maker, model and style
                    //At this point in a real application we would enable
                    //some other UI elements allowing the user to move
                    //on (a "Next" button, for example), but at here
                    //we simply displays what user have chosen.
                    cbMaker.Items.Add(m_szCurMaker);
                    cbMaker.Enabled = false;
                    cbModel.Items.Add(m_szCurModel);
                    cbModel.Enabled = false;
                    cbStyle.Items.Add(m_szCurStyle);
                    cbStyle.Enabled = false;

                    //Displays the description of the selected car
                    using (OleDbDataReader reader = db.ExecuteReader(
                        string.Format("select Description from Cars where Maker = '{0}' and Model = '{1}' and Style = '{2}'",
                               m_szCurMaker, m_szCurModel, m_szCurStyle)))
                    {
                        reader.Read();
                        lblDesc.Text = reader["Description"].ToString();
                    }
                }
            }
        }
    }

    protected void CallbackPanel1_Execute(object sender, EO.Web.CallbackEventArgs e)
    {
        string eventTarget = CallbackPanel1.LastTrigger.EventTarget;
        if (eventTarget != null)
        {
            if (eventTarget.IndexOf("cbMaker") > 0)
            {
                //Maker dropdown list was clicked
                DropDownList cbMaker = (DropDownList)Page.FindControl(eventTarget);
                LoadData(cbMaker.SelectedItem.Text, null, null);
            }
            else if (eventTarget.IndexOf("cbModel") > 0)
            {
                //Model dropdown list was clicked
                DropDownList cbModel = (DropDownList)Page.FindControl(eventTarget);
                DataGridItem item = GetContainingItem(cbModel);
                DropDownList cbMaker = (DropDownList)item.FindControl("cbMaker");
                LoadData(cbMaker.SelectedItem.Text, cbModel.SelectedItem.Text, null);
            }
            else if (eventTarget.IndexOf("cbStyle") > 0)
            {
                //Style dropdown list was clicked
                DropDownList cbStyle = (DropDownList)Page.FindControl(eventTarget);
                DataGridItem item = GetContainingItem(cbStyle);
                DropDownList cbMaker = (DropDownList)item.FindControl("cbMaker");
                DropDownList cbModel = (DropDownList)item.FindControl("cbModel");
                LoadData(cbMaker.SelectedItem.Text, cbModel.SelectedItem.Text, cbStyle.SelectedItem.Text);
            }
        }
    }

    private DataGridItem GetContainingItem(System.Web.UI.Control ctrl)
    {
        while (ctrl != null)
        {
            if (ctrl is DataGridItem)
                return (DataGridItem)ctrl;

            ctrl = ctrl.Parent;
        }

        return null;
    }
}
