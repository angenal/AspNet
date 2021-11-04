<p>
This sample demonstrates the following techniques:
</p>
<ul>
	<li>
	Associate the AJAXUploader to toolbar buttons by setting
	the AJAXUploader's <strong>StartToolBarButton</strong> and
	<strong>StopToolBarButton</strong>. These two properties can
	usually be set at design time. However this sample set them at
	runtime inside <strong>Page_Load</strong> since both the
	AJAXUploader control and the ToolBar control are inside the
	Editor controls' CustomHeaderTemplate/CustomFooterTemplate;
	</li>
	<li>
	Maintain uploaded file list using an <strong>AJAXPostedFileList</strong>
	control. A separate sample dedicated to demonstrate this feature
	can be found <a href="javascript:GoToDemo('uploader_filelist');">here</a>;
	</li>
	<li>
	Customize an Editor control's header and footer area. This
	sample customizes the Editor's toolbar to include two buttons
	for starting/stoping upload; It also customizes the Editor's
	footer to include the AJAXUploader and uploaded file list.
	For more information about customizing Editor's header and
	footer area, please see Editor documentations.
	</li>
</ul>