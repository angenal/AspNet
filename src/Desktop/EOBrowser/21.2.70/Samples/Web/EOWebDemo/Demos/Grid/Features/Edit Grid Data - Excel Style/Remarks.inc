<p>
	To facilitate server side handling code, EO.Web Grid offers <b>KeyField</b>
	property. Value of the <b>KeyField</b> is populated into each <b>GridItem</b>'s <b>Key</b>
	property and persisted accross post backs. User code can make use of this 
	property when updating backend data source.
</p>
<p>
   All changes items can be accessed through <b>ChangedItems</b> property.
   <b>ItemChanged</b> event is also fired for each changed item. Even
   though both <b>ItemChanged</b> and <b>ChangedItems</b> are based on
   the whole <b>GridItem</b>, you can use <b>GridCell.Modified</b>
   property to determine which cell has been modified.
</p>
