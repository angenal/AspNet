<p>
This sample uses CallbackPanel to sort the car information and re-render
it to the client. The sample does not have any code to trigger the callback,
even when the triggering link is actually rendered by an ASP.NET DataGrid 
control.
</p>
<p> 
The DataGrid is set as a <span class="highlight">Trigger</span>
(see the Remarks page for <a href="javascript:GoToDemo('callback_cars', 1);">Partial Page Updates - Cars</a> 
for more details about Trigger) of the containing CallbackPanel control. When a DataGrid, 
or any controls that implements <span class="highlight">INamingContainer</span> 
is set as a trigger, all controls inside that container automatically trigger 
callback whenever it would usually do a postback.
</p>