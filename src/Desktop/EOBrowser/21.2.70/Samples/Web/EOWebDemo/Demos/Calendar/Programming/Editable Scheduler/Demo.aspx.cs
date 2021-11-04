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

public partial class Demos_Calendar_Programming_Editable_Scheduler_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Calendar1_DayRender(object sender, EO.Web.DayRenderEventArgs e)
    {
        string note = (string)Notes[e.Day.Date];

        //Create an ID for this day
        string dayId = "dayId_" + EO.Web.Calendar.DateToString(e.Day.Date);
        dayId = dayId.Replace('-', '_');

        string html = "<table id=\"{0}\" border=\"0\" cellSpacing=\"0\" cellPadding=\"0\"";
        html += "onclick=\"EditNote('{0}');\">";
        html += "<tr>";
        html += "    <td align=\"right\">";
        html += e.Day.DayNumberText;
        html += "    </td>";
        html += "</tr>";
        html += "<tr>";
        html += "    <td align=\"left\" valign=\"top\" style=\"width:72px;height:28px;overflow:hidden;line-height:14px;{1}\">";
        if (note != null)
            html += note;
        html += "    </td>";
        html += "</tr>";
        html += "</table>";

        string backgroundColor = string.Empty;
        if (note != null)
            backgroundColor = "BACKGROUND-COLOR: lemonchiffon;";
        html = string.Format(html, dayId, backgroundColor);

        e.Writer.Write(html);
    }

    protected void CallbackPanel1_Execute(object sender, EO.Web.CallbackEventArgs e)
    {
        string callbackParam = CallbackPanel1.LastTrigger.Parameter;

        //Validate the parameter. The first 10 characters
        //is the date. The rest is the note.
        if ((callbackParam != null) && (callbackParam.Length > 10))
        {
            string date = callbackParam.Substring(0, 10);
            string note = callbackParam.Substring(10);

            Notes[EO.Web.Calendar.StringToDate(date)] = note;
        }
    }

    private Hashtable Notes
    {
        get
        {
            object htNotes = ViewState["Notes"];
            if (htNotes == null)
            {
                htNotes = new Hashtable();
                ViewState["Notes"] = htNotes;
            }
            return (Hashtable)htNotes;
        }
    }
}
