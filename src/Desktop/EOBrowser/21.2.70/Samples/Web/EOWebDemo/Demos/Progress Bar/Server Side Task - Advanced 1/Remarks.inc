<p>
This sample demonstrates the following techniques:
</p>
<ol>
	<li>
	Inside RunTask event handler on the server side, use the second 
	parameter of <b>ProgressTaskEventArgs.UpdateProgress</b>
	to pass additional status information to the client. This is a 
	"pass through" parameter that is provided entirely for you to use.
	The progress bar does not use this parameter in any way;
	</li>
	<li>
	Handle the progress bar's <b>ClientSideOnValueChanged</b> event on the
	client side with JavaScript. This sample sets the event handler
	to "OnProgress", which is a client side JavaScript function to
	be called every time the progress indicator moves. You would
	provide your own version of this function;
	</li>
	<li>
	The client side OnProgress function retrieves the additional
	data (in this case the status information) from the progress bar
	using the progress bar's client side JavaScript interface. It
	then displays it to the user;
	</li>
</ol>
<p>Key Points:</p>
<ul>
	<li>You must updates other UI elements with client side JavaScript 
	code instead of server side code (VB.NET or C#);</li>
	<li>The progress bar can help you to transfer additional custom
	information from your server side code to your client side JavaScript
	code through the second parameter of UpdateProgress and calls your 
	client side JavaScript code every time the
	progress indicator moves;</li>
</ul>
<p>
	You can also use JavaScript to trigger additional server side
	actions through AJAX before or after the progress bar run. 
	<a href="javascript:GoToDemo('progressbar_adv2');">Server Side Task - Advanced 2</a>
	demonstrated this technique.
</p>