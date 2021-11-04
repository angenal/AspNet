using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demos_Spell_Checker_Features_Custom_Word_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region SAMPLE_BLOCK#1
    protected void SpellChecker1_CustomWord(
        object sender, EO.Web.SpellCheckerEventArgs e)
    {
        //Add a "local" custom word. This custom word is not
        //saved and is applied to the current session only
        SpellChecker1.AddCustomWord(e.CustomWord);
    }
    #endregion
}
