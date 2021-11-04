using System;
using System.IO;
using EOPDFDemo;
using EO.Pdf;
using EO.Pdf.Acm;

namespace EOPDFDemo.Acm.AdvancedFormatting
{
    public class Table2 : Demo
    {
        public Table2(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Create a new PdfDocument
            PdfDocument doc = new PdfDocument();

            //Create a new AcmRender object
            AcmRender render = new AcmRender(doc);

            AcmParagraph p1 = new AcmParagraph(
                new AcmText("2010 Box Office Top 5"));
            p1.Style.FontSize = 15f;
            p1.Style.FontStyle = System.Drawing.FontStyle.Bold;

            //Create the root paragraph
            AcmTable table = new AcmTable(-1, 2, 2);

            table.CellPadding = 0.05f;
            table.GridLineType = AcmGridLineType.All;
            table.GridLineInfo = new AcmLineInfo(0.01f);

            CreateTableRow(table, "Movie Title", "Studio", "Total Gross");
            CreateTableRow(table, "Toy Story 3", "BV", "$412,844,168");
            CreateTableRow(table, "Alice in Wonderland (2010)", "$334,191,110");
            CreateTableRow(table, "Iron Man 2", "Par.", "$312,128,345");
            CreateTableRow(table, "The Twilight Saga: Eclipse", "Sum.", "$300,523,113");
            CreateTableRow(table, "Inception", "WB", "$289,751,947");
            CreateTableRow(table, "Total", "$1,649,438,683");

            foreach (AcmTableCell cell in table.Rows[0].Cells)
                cell.Style.BackgroundColor = System.Drawing.Color.LightGray;

            table.Rows[1].Cells[1].RowSpan = 2;
            table.Rows[6].Cells[0].ColSpan = 2;

            //Render the text
            render.Render(p1, table);

            //Save the result
            doc.Save(result);

            return null;
        }

        private void CreateTableRow(AcmTable table, params object[] values)
        {
            AcmTableRow row = new AcmTableRow();

            for (int i = 0; i < values.Length; i++)
            {
                AcmTableCell cell = new AcmTableCell();

                AcmText text = new AcmText(values[i].ToString());

                cell.Children.Add(text);

                row.Cells.Add(cell);
            }

            table.Rows.Add(row);
        }


        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='kwd'>public override string</span> RunDemo(Stream result, IDemoArgs args)
{
    <span class='cmt'>//Create a new PdfDocument</span>
    PdfDocument doc = <span class='kwd'>new</span> PdfDocument();

    <span class='cmt'>//Create a new AcmRender object</span>
    AcmRender render = <span class='kwd'>new</span> AcmRender(doc);

    AcmParagraph p1 = <span class='kwd'>new</span> AcmParagraph(
        <span class='kwd'>new</span> AcmText(<span class='st'>&quot;2010 Box Office Top 5&quot;</span>));
    p1.Style.FontSize = 15f;
    p1.Style.FontStyle = System.Drawing.FontStyle.Bold;

    <span class='cmt'>//Create the root paragraph</span>
    AcmTable table = <span class='kwd'>new</span> AcmTable(-1, 2, 2);

    table.CellPadding = 0.05f;
    table.GridLineType = AcmGridLineType.All;
    table.GridLineInfo = <span class='kwd'>new</span> AcmLineInfo(0.01f);

    CreateTableRow(table, <span class='st'>&quot;Movie Title&quot;</span>, <span class='st'>&quot;Studio&quot;</span>, <span class='st'>&quot;Total Gross&quot;</span>);
    CreateTableRow(table, <span class='st'>&quot;Toy Story 3&quot;</span>, <span class='st'>&quot;BV&quot;</span>, <span class='st'>&quot;$412,844,168&quot;</span>);
    CreateTableRow(table, <span class='st'>&quot;Alice in Wonderland (2010)&quot;</span>, <span class='st'>&quot;$334,191,110&quot;</span>);
    CreateTableRow(table, <span class='st'>&quot;Iron Man 2&quot;</span>, <span class='st'>&quot;Par.&quot;</span>, <span class='st'>&quot;$312,128,345&quot;</span>);
    CreateTableRow(table, <span class='st'>&quot;The Twilight Saga: Eclipse&quot;</span>, <span class='st'>&quot;Sum.&quot;</span>, <span class='st'>&quot;$300,523,113&quot;</span>);
    CreateTableRow(table, <span class='st'>&quot;Inception&quot;</span>, <span class='st'>&quot;WB&quot;</span>, <span class='st'>&quot;$289,751,947&quot;</span>);
    CreateTableRow(table, <span class='st'>&quot;Total&quot;</span>, <span class='st'>&quot;$1,649,438,683&quot;</span>);

    <span class='kwd'>foreach</span> (AcmTableCell cell <span class='kwd'>in</span> table.Rows[0].Cells)
        cell.Style.BackgroundColor = System.Drawing.Color.LightGray;

    table.Rows[1].Cells[1].RowSpan = 2;
    table.Rows[6].Cells[0].ColSpan = 2;

    <span class='cmt'>//Render the text</span>
    render.Render(p1, table);

    <span class='cmt'>//Save the result</span>
    doc.Save(result);

    <span class='kwd'>return null</span>;
}

<span class='kwd'>private void</span> CreateTableRow(AcmTable table, <span class='kwd'>params object</span>[] values)
{
    AcmTableRow row = <span class='kwd'>new</span> AcmTableRow();

    <span class='kwd'>for</span> (<span class='kwd'>int</span> i = 0; i < values.Length; i++)
    {
        AcmTableCell cell = <span class='kwd'>new</span> AcmTableCell();

        AcmText text = <span class='kwd'>new</span> AcmText(values[i].ToString());

        cell.Children.Add(text);

        row.Cells.Add(cell);
    }

    table.Rows.Add(row);
}</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='kwd'>Public Overrides Function</span> RunDemo(result <span class='kwd'>As</span> Stream, args <span class='kwd'>As</span> IDemoArgs) <span class='kwd'>As String</span>
    <span class='cmt'>'Create a new PdfDocument</span>
    <span class='kwd'>Dim</span> doc <span class='kwd'>As New</span> PdfDocument()

    <span class='cmt'>'Create a new AcmRender object</span>
    <span class='kwd'>Dim</span> render <span class='kwd'>As New</span> AcmRender(doc)

    <span class='kwd'>Dim</span> p1 <span class='kwd'>As New</span> AcmParagraph(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;2010 Box Office Top 5&quot;</span>))
    p1.Style.FontSize = 15F
    p1.Style.FontStyle = System.Drawing.FontStyle.Bold

    <span class='cmt'>'Create the root paragraph</span>
    <span class='kwd'>Dim</span> table <span class='kwd'>As New</span> AcmTable(-1, 2, 2)

    table.CellPadding = 0.05F
    table.GridLineType = AcmGridLineType.All
    table.GridLineInfo = <span class='kwd'>New</span> AcmLineInfo(0.01F)

    CreateTableRow(table, <span class='st'>&quot;Movie Title&quot;</span>, <span class='st'>&quot;Studio&quot;</span>, <span class='st'>&quot;Total Gross&quot;</span>)
    CreateTableRow(table, <span class='st'>&quot;Toy Story 3&quot;</span>, <span class='st'>&quot;BV&quot;</span>, <span class='st'>&quot;$412,844,168&quot;</span>)
    CreateTableRow(table, <span class='st'>&quot;Alice in Wonderland (2010)&quot;</span>, <span class='st'>&quot;$334,191,110&quot;</span>)
    CreateTableRow(table, <span class='st'>&quot;Iron Man 2&quot;</span>, <span class='st'>&quot;Par.&quot;</span>, <span class='st'>&quot;$312,128,345&quot;</span>)
    CreateTableRow(table, <span class='st'>&quot;The Twilight Saga: Eclipse&quot;</span>, <span class='st'>&quot;Sum.&quot;</span>, <span class='st'>&quot;$300,523,113&quot;</span>)
    CreateTableRow(table, <span class='st'>&quot;Inception&quot;</span>, <span class='st'>&quot;WB&quot;</span>, <span class='st'>&quot;$289,751,947&quot;</span>)
    CreateTableRow(table, <span class='st'>&quot;Total&quot;</span>, <span class='st'>&quot;$1,649,438,683&quot;</span>)

    <span class='kwd'>For Each</span> cell <span class='kwd'>As</span> AcmTableCell <span class='kwd'>In</span> table.Rows(0).Cells
        cell.Style.BackgroundColor = System.Drawing.Color.LightGray
    <span class='kwd'>Next</span>

    table.Rows(1).Cells(1).RowSpan = 2
    table.Rows(6).Cells(0).ColSpan = 2

    <span class='cmt'>'Render the text</span>
    render.Render(p1, table)

    <span class='cmt'>'Save the result</span>
    doc.Save(result)

    <span class='kwd'>Return Nothing
End Function

Private Sub</span> CreateTableRow(table <span class='kwd'>As</span> AcmTable, <span class='kwd'>ParamArray</span> values <span class='kwd'>As Object</span>())
    <span class='kwd'>Dim</span> row <span class='kwd'>As New</span> AcmTableRow()

    <span class='kwd'>For</span> i <span class='kwd'>As Integer</span> = 0 <span class='kwd'>To</span> values.Length - 1
        <span class='kwd'>Dim</span> cell <span class='kwd'>As New</span> AcmTableCell()

        <span class='kwd'>Dim</span> text <span class='kwd'>As New</span> AcmText(values(i).ToString())

        cell.Children.Add(text)

        row.Cells.Add(cell)
    <span class='kwd'>Next</span>

    table.Rows.Add(row)
<span class='kwd'>End Sub</span></pre>";

        }

        public override string GetInstructions()
        {
            return @"
<p>
This sample demonstrates how to use <b>ColSpan</b> and
<b>RowSpan</b> on a table cell. The <b>RowSpan</b> property
for cell ""BV"" is set to 2 so that it spans into two
rows. The <b>ColSpan</b> property for cell ""Total""
is set to 2 so that it spans two columns.
</p>
";
        }
    }
}