<p>
This sample uses CallbackPanel to dynamically change the edit
row contents. Like other samples, there is no code needed to
trigger the callback in this sample.
</p>
<p> 
The DataGrid is set as a <span class="highlight">Trigger</span>
(see the Remarks page for <a href="javascript:GoToDemo('callback_cars', 1);">Partial Page Updates - Cars</a>
for more details about Trigger) of the containing CallbackPanel control. When a DataGrid, 
or any controls that implements <span class="highlight">INamingContainer</span> 
is set as a trigger, all controls inside that container automatically trigger 
callback whenever it would usually do a postback.
</p>
<p>
Callbacks are automatically triggered not only by the "Edit" link button,
but also the drop down list boxes. The code on the server side then
dynamically fills/enable/disable those drop down list boxes accordingly.
</p>