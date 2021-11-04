<p>
This sample demonstrates the following techniques:
</p>
<ol>
	<li>
	Instead of setting the progress bar's <b>StartButton</b> 
	property, this sample triggers a client side JavaScript function
	<b>Start</b>. This function does not start the progress bar
	immediately. It triggers an AJAX callback through a CallbackPanel control;
	</li>
	<li>
	This triggers the CallbackPanel's <b>Execute</b> event on the server side.
	You can perform any additional actions inside this handler (This sample
	merely updates Label1's Text. Also note any restrictions with CallbackPanel 
	control still applies);
	</li>
	<li>
	The CallbackPanel's <b>ClientSideAfterUpdate</b> is set to another JavaScript
	function <b>AfterCallbackUpate</b>. The code inside this function now starts
	the progress bar using the progress bar's client side JavaScript interface;
	</li>
	<li>
	Like previous samples, the code handles the progress bar's 
	<b>ClientSideOnValueChanged</b> event on the client side with JavaScript. 
	The handlers checks whether the progress bar is done by checking the
	additional data passed to the client side by the server side code.
	If the task is done, it triggers another AJAX call with
	CallbackPanel to perform additional task <b>after</b> the task run
	is done;
	</li>
	<li>
	The CallbackPanel's <b>Execute</b> event handler (server side) is called
	again. To distinguish step 2 and this step in the event handler,
	step 1 and step 4 pass different parameters to the server side when
	calling the callback panel's client side <b>execute</b> method;
	</li>
</ol>
<p>Key Points:</p>
<ul>
	<li>Different steps are linked together with various JavaScript handlers;</li>
	<li>All code are initiated from JavaScript, if you only need to
	perform additional actions on the client side but not on the server side,
	you do not need to use CallbackPanel;</li>
</ul>
