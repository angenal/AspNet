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

public partial class Demos_Progress_Bar_Server_Side_Task___Advanced_2_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region SAMPLE_BLOCK#1
    protected void ProgressBar1_RunTask(object sender, EO.Web.ProgressTaskEventArgs e)
    {
        //You can not change anything else in the page inside
        //RunTask handler except for calling UpdateProgress.
        //If you do need to change other contents on the page
        //based on progress information, you can make use of
        //the second parameter of UpdateProgress.

        //The following code demonstrates how to pass addtional
        //data to the client side with UpdateProgress.
        //Here we call UpdateProgress with an additonal parameter.
        //This addtional parameter is passed to the client side
        //and can be accessed by getExtraData client side function.
        //The sample code handles ClientSideOnValueChanged on the
        //client side and checks the return value of getExtraData.
        //The handler then displays this extra value to the user 
        //when it sees it.
        e.UpdateProgress(0, "Running...");

        //Import Notes:
        //1. The progress bar does not figure out the progress
        //   by itself because it does not know how long your
        //   task will run;
        //2. The progress bar does not move by itself because
        //   it can not figure out the progress by itself;
        //This means you must repeatly report your progress to
        //the progress bar (by calling UpdateProgress). 

        //Here we use a loop to demonstrate this. You do not 
        //have to use a loop but you must repeatly report the 
        //progress information to the progress bar. For example,
        //if your long running task is copying 100 files, you
        //can loop 100 times like this code does, but replacing
        //Thread.Sleep with code to copy a single file and report
        //your progress to the progress bar after each file. 
        //Likewise, if your task is copying a single file, you 
        //can get the file length first, then use a loop to copy 
        //chunk by chunk and report the progress after each
        //chunk. 
        for (int i = 0; i < 100; i++)
        {
            //Stop the task as soon as we can if the user has
            //stopped it from the client side
            if (e.IsStopped)
                break;

            //Here we call Thread.Sleep just for demonstration
            //purpose. You should replace this with code that
            //performs your long running task. 
            System.Threading.Thread.Sleep(500);

            //You should frequently call UpdateProgress in order
            //to notify the client about the current progress
            if (i > 50)
                e.UpdateProgress(i, "Half done...");
            else
                e.UpdateProgress(i);
        }

        e.UpdateProgress(100, "The task is done!");
    }

    protected void CallbackPanel1_Execute(object sender, EO.Web.CallbackEventArgs e)
    {
        if (e.Parameter == "start")
        {
            e.Data = "start";

            //Perform additional action before RunTask
            Label1.Text = "Performed additional action before RunTask starts!";
        }
        else if (e.Parameter == "done")
        {
            e.Data = "done";

            //Perform additional action after RunTask
            Label1.Text = "Performed additional action after RunTask is done!";
        }
    }
    #endregion
}
