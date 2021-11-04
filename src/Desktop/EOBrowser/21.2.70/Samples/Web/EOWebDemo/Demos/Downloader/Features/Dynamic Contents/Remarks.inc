<p>
Follow these steps to dynamically generates download contents:
</p>
<ol>
	<li>Set the Downloader's <b>DynamicContent</b> to true;</li>
	<li>Create a new class that derives from <b>DynamicDownloadContent</b>
	class, override <b>GenerateContent</b> method;
	</li>
	<li>
	Handle the Downloader's <b>Download</b> event, inside the event
	handler, call <b>DynamicDownload</b> method on the event argument,
	passing in the type of class defined in step 2 as the first
	argument and any additional arguments (for your content generating
	logic) as the second parameter;
	</li>
	<li>
	Inside your <b>GenerateContent</b>, checks for the additional
	argument passed and calls <b>SetFileName</b> to set
	the download file name, then call <b>Write</b> method to 
	dynamically generates the download content;
	</li>
</ol>