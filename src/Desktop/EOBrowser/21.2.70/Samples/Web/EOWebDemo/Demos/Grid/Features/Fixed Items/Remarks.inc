<p>
These properties are set in this sample:
</p>
<ul>
	<li><b>FixedTopItemCount</b> is set to 3. This property specifies
	the total number of fixed items on the top;</li>
	<li><b>FixedBottomItemCount</b> is set to 2. This property specifies
	the total number of fixed items on the bottom;</li>
	<li>Both <b>FixedTopItemStyle</b> and <b>FixedBottomItemStyle</b>
	are set to give fixed top items and fixed bottom items a different
	background color;
	</li>
	<li>Both columns' <b>StyleField</b> are set in order to provide
	individual cells different styles. At runtime, the Grid retrieves
	the value of the data field specified by <b>StyleField</b> for each
	cell and interprets the result as a CSS class name to be applied
	on that cell. For example, cell "1GB DDR2 Memory" has a style
	field value "indent1", which is a CSS class defined in EOWebDemo.css.
	"indent1" has padding-left attribute set thus indent the content. 
	</li>
</ul>