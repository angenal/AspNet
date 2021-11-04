using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demos_Editable_Label_Hint_Text_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Button1_Click(this, EventArgs.Empty);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(EditableLabel1.Value))
            Label1.Text = "The EditableLabel's Value is empty.";
        else
            Label1.Text = "The EditableLabel's Value is: " + EditableLabel1.Value;
    }
}
