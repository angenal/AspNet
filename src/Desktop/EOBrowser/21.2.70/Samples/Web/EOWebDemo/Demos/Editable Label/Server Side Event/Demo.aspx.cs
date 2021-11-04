using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demos_Editable_Label_Server_Side_Event_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void EditableLabel1_Changed(object sender, EventArgs e)
    {
        Label1.Text = "EditableLabel Value changed at " + DateTime.Now.ToString();
    }
}
