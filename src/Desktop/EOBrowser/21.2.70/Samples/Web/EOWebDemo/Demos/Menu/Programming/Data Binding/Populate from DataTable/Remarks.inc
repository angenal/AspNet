<p>
This sample demonstrates how to populate an EO.Web Menu (or any
other EO.Web navigational control) from a single 
<span class="highlight">DataTable</span> object.
</p>
<p>
The key to populate the menu, which renders hierarchical
data, from a DataTable object is to define the hierarchical
data structure on the DataTable object. EO.Web Menu provides 
<span class="highlight">DataFields</span> property, through 
which you can provide a list of data fields that serves key fields. 
</p>
<p>
DataFields is set to "Country|State|City" in this sample. At
runtime, the menu first creates a menu item for each unique
value of "Country" field, and then creates a menu item for each
unique value of "State" field under each "Country". The same
logic goes on to "City" field.
</p>
<p>
A <span class="highlight">DataBinding</span> object is also
used to map WebSite field to NavigateUrl property.
</p>