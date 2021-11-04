<p>
This sample uses CallbackPanel to retrieve car information from the 
backend database and updates the product information area dynamically.
</p>
<p>
Click on the radio buttons to trigger the CallbackPanel control to update the car 
information area.
</p>
<p>
<span class="highlight">No code</span> is needed to trigger the callback. The callback is triggered by
assigning a list of <span class="highlight">Triggers</span> to the 
Callback or CallbackPanel control. To edit the trigger collection: 
</p>
<ol>
	<li>Select the Callback or CallbackPanel control;</li>
	<li>Click the "..." next to its <span class="highlight">Triggers</span> property
	    or right click the control and select <span class="highlight">Edit Triggers...</span>;
	</li>
	<li>Specify one or more triggers using the Trigger Collection Editor, optionally
	specify a parameter for each trigger;</li>
</ol>
<p>
At runtime, any action occurred on the trigger control that would normally
trigger a postback would now trigger an AJAX callback. However all the server
side code logic stays the same.
</p>
