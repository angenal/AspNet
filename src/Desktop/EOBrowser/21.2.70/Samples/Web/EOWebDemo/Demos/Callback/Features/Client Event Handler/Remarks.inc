<p>
EO.Web Callback and CallbackPanel supports several client events through
which you can further control the callback process:
</p>
<ul>
	<li><span class="highlight">ClientSideBeforeExecute</span>. Occurred
	before the callback is executed. You can cancel the callback at here;
	</li>
	<li><span class="highlight">ClientSideAfterExecute</span>. Occurred
	after the callback is executed, but before the new output is being
	applied. You can exam or even alter the output at here;
	</li>
	<li><span class="highlight">ClientSideAfterUpdate</span>. Occurred
	after the callback output is applied. You can initiate futher actions
	based on the new output;</li>
</ul>
<p>
This sample handles ClientSideBeforeExecute and asks user to confirm
each action, the callback is then canceled if the user chose "Cancel".
</p>