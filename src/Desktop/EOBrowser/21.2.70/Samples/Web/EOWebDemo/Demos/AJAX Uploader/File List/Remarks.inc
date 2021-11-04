Follow these simple steps to use AJAXPostedFileList: 

<ol>
	<li>
	Place an AJAXPostedFileList control on the form; 
	</li>
	<li>
	Set the AJAXUploader's FinalFileList to the ID of the AJAXPostedFileList control; 
	</li>
	<li>
	Set the AJAXUploader's FinalFileLocation property; 
	</li>
	<li>
</ol>
Now the AJAXPostedFileList control automatically maintains the list of all 
uploaded files. Note:
<ul>
	<li>
	AJAXPostedFileList only maintains the data. It does not display it. This 
	sample uses a DataGrid control to display the list;
	</li>
	<li>
	AJAXPostedFileList maintains the <b>final file list</b>, not the
	<b>temporary file list</b>. The temporary file list is maintained by
	the uploader itself. Once the page submits, <b>FileUploaded</b> event 
	is fired and all files in the temporary list are moved to the 
	final list.
	</li>
</ul>



