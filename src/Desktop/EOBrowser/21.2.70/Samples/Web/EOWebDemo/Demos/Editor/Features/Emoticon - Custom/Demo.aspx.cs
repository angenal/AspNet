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

public partial class Demos_Editor_Features_Emoticon___Custom_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EO.Web.Editor.RegisterEmoticonSet("Smiley",
            System.IO.Path.Combine(this.TemplateSourceDirectory, "Icons"),
            "Don't know!.gif", "Whistle.gif", "Silenced.gif", "Shhh.gif",
            "Sick.gif", "Liar.gif", "Think.gif", "Eh.gif",
            "Not talking.gif", "Pray.gif", "Shame on you.gif", "Dancing.gif",
            "Brick wall.gif", "Speak to the hand.gif", "Applause.gif", "Drool.gif",
            "Anxious.gif", "Angel.gif");
    }
}
