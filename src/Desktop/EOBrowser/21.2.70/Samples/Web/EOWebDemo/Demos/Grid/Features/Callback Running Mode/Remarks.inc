<p>
Callback mode has the same benefits as 
<a href="javascript:GoToDemo('grid_server_mode', 0);">Server</a>
mode but runs much faster because it
only re-fetches the grid data, not both grid data and grid
HTML element from the server. So it is the recommended mode
for handling large data set.
</p>
<p>
The steps needed to reap the benefit provided by
Callback mode is the same as Server mode. Your data binding code 
should only fetch the current page from the database. You should 
also provide the Grid the total number of records. Please see 
online documentation for more details on how to populate the 
current page. The code to populate the Grid is identical to 
Server mode. Sample code is available in
<a href="javascript:GoToDemo('grid_server_mode', 2);">VB.NET</a> or 
<a href="javascript:GoToDemo('grid_server_mode', 3);">C#</a>.
</p>