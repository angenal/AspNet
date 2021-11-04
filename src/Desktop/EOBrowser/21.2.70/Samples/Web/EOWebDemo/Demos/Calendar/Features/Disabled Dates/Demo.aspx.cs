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

public partial class Demos_Calendar_Features_Disabled_Dates_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Set the valid date range from today to two weeks later
        Calendar1.MinValidDate = DateTime.Today;
        Calendar1.MaxValidDate = DateTime.Today.AddDays(14);

        //Disables weekend days
        Calendar1.DisableWeekendDays = true;

        //Disables all thursday with the two weeks window
        int nDayOfWeek = (int)DateTime.Today.DayOfWeek;
        int nOffset = (int)DayOfWeek.Thursday - nDayOfWeek;
        if (nOffset < 0)
            nOffset += 7;
        Calendar1.DisabledDates.Add(DateTime.Today.AddDays(nOffset));
        Calendar1.DisabledDates.Add(DateTime.Today.AddDays(nOffset + 7));
    }
}
