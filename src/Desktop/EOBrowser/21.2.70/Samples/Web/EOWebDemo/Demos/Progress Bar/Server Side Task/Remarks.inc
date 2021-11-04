<p>
	In order to associate a server side task with a ProgressBar, run the task 
	inside the ProgressBar's <b>RunTask</b> event and start the task either by 
	setting <b>StartTaskButton</b> or calling <b>startTask</b> client side method 
	on the client side ProgressBar object.
</p>
<p>
	Inside <b>RunTask</b>, you should frequently call <b>ProgressTaskEventArgs.UpdateProgress</b>
	to report the current progress of your task. The ProgressBar control transfers 
	this information to the client to update the progress.
</p>
<p>
	<b>Note</b>: RunTask is a very special event. <u>You can not use 
	any other server controls to update other page elements inside
	this event</u>. For details on how to perform additional actions
	before/after RunTask, or update other page elements, see
	<a href="javascript:GoToDemo('progressbar_adv1');">Server Side Task - Advanced 1</a> and 
	<a href="javascript:GoToDemo('progressbar_adv2');">Server Side Task - Advanced 2</a>.
</p>
