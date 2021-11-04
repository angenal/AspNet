In order for "100%" width/height to work for an inner
element, the element's can not have border or paddings. 
This sample takes the following steps to remove border
and paddings on the TreeView and Grid control but still
produce the same visual result: 

<ul>
	<li>
	Remove border settings on the TreeView. Border settings
	can be applied to a TreeView at two places: Using the
	control's BorderWidth, BorderStyle and BorderColor property;
	Or setting the TreeView's TopGroup.Style property to include
	border related CSS attributes; 
	</li>
	<li>
	Move padding settings from the TreeView to the left
	SplitterPane object by removing padding settings on
	the TreeView and applying the same amount of padding
	on the SplitterPane object. Paddings are usually 
	specified through the TreeView's TopGroup.Style
	property; 
	</li>
	<li>
	Move scroll bars for the TreeView to the left SplitterPane
	by setting the TreeView's AutoScroll to False and setting
	the SplitterPane's ScrollBars to Auto;
	</li>
	<li>
	Remove the Grid's border settings by setting the Grid's
	BorderStyle to None;
	</li>
</ul>



