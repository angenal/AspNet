<p>
This sample demonstrates how to populate an EO.Web Menu (or any other
navigational control) from a DataSet object. 
</p>
<p>
In order to populate the Menu from a DataSet object, one or more 
<span class="highlight">DataRelation</span> objects must be used to define the parent-child relationship
between DataTables in the DataSet. The DataRelation objects' Nested
must be set to true.
</p>
<p>
Once the DataRelation objects are in place, set the Menu's DataSource
property to the DataSet and call the Menu's DataBind method.
</p>