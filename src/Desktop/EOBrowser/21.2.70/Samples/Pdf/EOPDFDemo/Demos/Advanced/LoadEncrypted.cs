using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EO.Pdf;

namespace EOPDFDemo.Demos.Advanced
{
    public class LoadEncrypted : Demo
    {
        public LoadEncrypted(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Get the path of the demo file
            string fileName = GetInputFilePath("Secured.pdf");

            //Open the file with password "1234". An exception
            //will be thrown if the password is incorrect
            PdfDocumentSecurity security = new PdfDocumentSecurity("1234");
            PdfDocument doc = new PdfDocument(fileName, security);

            //Add some new content to it to prove
            //we opened it successfully!
            HtmlToPdf.Options.StartPosition = 6;
            HtmlToPdf.ConvertHtml(
                "We opened a password protected file and added some new contents to it!", 
                doc.Pages[0]);

            //Clear the password. Otherwise the document will be
            //saved with the same password we used to open it
            doc.Security.UserPassword = null;
            doc.Security.OwnerPassword = null;

            //Save it
            doc.Save(result);


            return null;
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>//Get the path of the demo file</span>
<span class='kwd'>string</span> fileName = GetInputFilePath(<span class='st'>&quot;Secured.pdf&quot;</span>);

<span class='cmt'>//Open the file with password &quot;1234&quot;. An exception
//will be thrown if the password is incorrect</span>
PdfDocumentSecurity security = <span class='kwd'>new</span> PdfDocumentSecurity(<span class='st'>&quot;1234&quot;</span>);
PdfDocument doc = <span class='kwd'>new</span> PdfDocument(fileName, security);

<span class='cmt'>//Add some new content to it to prove
//we opened it successfully!</span>
HtmlToPdf.Options.StartPosition = 6;
HtmlToPdf.ConvertHtml(
    <span class='st'>&quot;We opened a password protected file and added some new contents to it!&quot;</span>, 
    doc.Pages[0]);

<span class='cmt'>//Clear the password. Otherwise the document will be
//saved with the same password we used to open it</span>
doc.Security.UserPassword = <span class='kwd'>null</span>;
doc.Security.OwnerPassword = <span class='kwd'>null</span>;

<span class='cmt'>//Save it</span>
doc.Save(result);</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>'Get the path of the demo file</span>
<span class='kwd'>Dim</span> fileName <span class='kwd'>As String</span> = GetInputFilePath(<span class='st'>&quot;Secured.pdf&quot;</span>)

<span class='cmt'>'Open the file with password &quot;1234&quot;. An exception
'will be thrown if the password is incorrect</span>
<span class='kwd'>Dim</span> security <span class='kwd'>As New</span> PdfDocumentSecurity(<span class='st'>&quot;1234&quot;</span>)
<span class='kwd'>Dim</span> doc <span class='kwd'>As New</span> PdfDocument(fileName, security)

<span class='cmt'>'Add some new content to it to prove
'we opened it successfully!</span>
HtmlToPdf.Options.StartPosition = 6
HtmlToPdf.ConvertHtml(<span class='st'>&quot;We opened a password protected file and added some new contents to it!&quot;</span>, _
              doc.Pages(0))

<span class='cmt'>'Clear the password. Otherwise the document will be
'saved with the same password we used to open it</span>
doc.Security.UserPassword = <span class='kwd'>Nothing</span>
doc.Security.OwnerPassword = <span class='kwd'>Nothing</span>

<span class='cmt'>'Save it</span>
doc.Save(result)</pre>";

        }
    }
}
