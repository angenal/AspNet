<p>
This sample demonstrates how to populate an EO.Web Menu (or any other
EO.Web navigational control) from a DataTable with parent-child key
relationship, such as the FolderID and ParentFolderID field in this
sample.
</p>
<p>
Follow these simple steps to bind to a DataTable with parent-child 
key relationship:
</p>
<ol>
	<li>Create a DataSet object, add the DataTable into the DataSet;</li>
	<li>Add a new DataRelation object into the DataSet's Relations collection,
	specifying the parent-child key fields;</li>
	<li>Set the DataRelation object's Nested to true</li>
	<li>Set the Menu's DataSource to the newly created DataSet object;</li>
	<li>Call the Menu's DataBind method;</li>
</ol>
