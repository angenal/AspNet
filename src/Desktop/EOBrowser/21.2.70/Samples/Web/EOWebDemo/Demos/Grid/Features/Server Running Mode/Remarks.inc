<p>
Server mode is designed to handle large data set because it
only download data for the current page to client. However
this does make it necessary to reload data from the server
when switching to another page. To avoid full page reload,
consider <a href="javascript:GoToDemo('grid_callback_mode', 0);">Callback</a>
mode. Callback mode runs faster than Server mode because it
only re-fetches the grid data, not both grid data and grid
HTML element from the server.
</p>
<p>
In order to reap the benefit provided by
Server mode, your data binding code should only fetch the
current page from the database. You should also provide the Grid 
the total number of records. Please see online documentation
for more details on how to populate the current page.
Sample code snippets are also available on the VB.NET or C# tab.