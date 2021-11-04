using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EO.Pdf;

namespace EOPDFDemo.Demos.HtmlToPdfDemos.Advanced
{
    public class TableHeader : Demo
    {
        public TableHeader(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<table style='width:600px'>");
            sb.AppendLine("<thead><td>");
            sb.AppendLine("<div style='border-bottom:solid 1px black;font-weight:bold;'>Table Header</div>");
            sb.AppendLine("</td></thead>");

            for (int i = 0; i < 100; i++)
            {
                sb.Append("<tr><td>");
                sb.AppendFormat("Table Item {0}", i + 1);
                sb.AppendLine("</td></tr>");
            }

            sb.AppendLine("<tfoot><td>");
            sb.AppendLine("<div style='border-top:solid 1px black;font-style:italic;'>Table Footer</div>");
            sb.AppendLine("</td></tfoot>");
            sb.AppendLine("</table>");

            //Convert the Url to PDF
            HtmlToPdf.ConvertHtml(sb.ToString(), result);


            return null;
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'>StringBuilder sb = <span class='kwd'>new</span> StringBuilder();

sb.AppendLine(<span class='st'>&quot;&lt;table style=&#39;width:600px&#39;&gt;&quot;</span>);
sb.AppendLine(<span class='st'>&quot;&lt;thead&gt;&lt;td&gt;&quot;</span>);
sb.AppendLine(<span class='st'>&quot;&lt;div style=&#39;border-bottom:solid 1px black;font-weight:bold;&#39;&gt;Table Header&lt;/div&gt;&quot;</span>);
sb.AppendLine(<span class='st'>&quot;&lt;/td&gt;&lt;/thead&gt;&quot;</span>);

<span class='kwd'>for</span> (<span class='kwd'>int</span> i = 0; i < 100; i++)
{
    sb.Append(<span class='st'>&quot;&lt;tr&gt;&lt;td&gt;&quot;</span>);
    sb.AppendFormat(<span class='st'>&quot;Table Item {0}&quot;</span>, i + 1);
    sb.AppendLine(<span class='st'>&quot;&lt;/td&gt;&lt;/tr&gt;&quot;</span>);
}

sb.AppendLine(<span class='st'>&quot;&lt;tfoot&gt;&lt;td&gt;&quot;</span>);
sb.AppendLine(<span class='st'>&quot;&lt;div style=&#39;border-top:solid 1px black;font-style:italic;&#39;&gt;Table Footer&lt;/div&gt;&quot;</span>);
sb.AppendLine(<span class='st'>&quot;&lt;/td&gt;&lt;/tfoot&gt;&quot;</span>);
sb.AppendLine(<span class='st'>&quot;&lt;/table&gt;&quot;</span>);

<span class='cmt'>//Convert the Url to PDF</span>
HtmlToPdf.ConvertHtml(sb.ToString(), result);</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='kwd'>Dim</span> sb <span class='kwd'>As New</span> StringBuilder()

sb.AppendLine(<span class='st'>&quot;&lt;table style='width:600px'&gt;&quot;</span>)
sb.AppendLine(<span class='st'>&quot;&lt;thead&gt;&lt;td&gt;&quot;</span>)
sb.AppendLine(<span class='st'>&quot;&lt;div style='border-bottom:solid 1px black;font-weight:bold;'&gt;Table Header&lt;/div&gt;&quot;</span>)
sb.AppendLine(<span class='st'>&quot;&lt;/td&gt;&lt;/thead&gt;&quot;</span>)

<span class='kwd'>For</span> i <span class='kwd'>As Integer</span> = 0 <span class='kwd'>To</span> 99
    sb.Append(<span class='st'>&quot;&lt;tr&gt;&lt;td&gt;&quot;</span>)
    sb.AppendFormat(<span class='st'>&quot;Table Item {0}&quot;</span>, i + 1)
    sb.AppendLine(<span class='st'>&quot;&lt;/td&gt;&lt;/tr&gt;&quot;</span>)
<span class='kwd'>Next</span>

sb.AppendLine(<span class='st'>&quot;&lt;tfoot&gt;&lt;td&gt;&quot;</span>)
sb.AppendLine(<span class='st'>&quot;&lt;div style='border-top:solid 1px black;font-style:italic;'&gt;Table Footer&lt;/div&gt;&quot;</span>)
sb.AppendLine(<span class='st'>&quot;&lt;/td&gt;&lt;/tfoot&gt;&quot;</span>)
sb.AppendLine(<span class='st'>&quot;&lt;/table&gt;&quot;</span>)

<span class='cmt'>'Convert the Url to PDF</span>
HtmlToPdf.ConvertHtml(sb.ToString(), result)</pre>";

        }
    }
}
