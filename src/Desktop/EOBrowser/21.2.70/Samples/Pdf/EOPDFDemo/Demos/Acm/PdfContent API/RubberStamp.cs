using System;
using System.IO;
using System.Drawing;
using EOPDFDemo;
using EO.Pdf;
using EO.Pdf.Acm;
using EO.Pdf.Contents;
using EO.Pdf.Drawing;

namespace EOPDFDemo.Acm.PdfContentAPI
{
    public class RubberStamp : Demo
    {
        public RubberStamp(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            PdfDocument doc = new PdfDocument();

            //Create the render
            AcmRender render = new AcmRender(doc);

            //Handle AfterRenderPage event
            render.AfterRenderPage += new AcmPageEventHandler(render_AfterRenderPage);

            AcmContent content = new AcmContent(
                //header
                new AcmTable(1, -1, 2)
                .SetProperty("Rows", new AcmTableRow[]
                    {
                    new AcmTableRow(
                        new AcmTableCell(new AcmImage(LoadImage("SampleLogo.gif"))),
                        new AcmTableCell(
                            new AcmText("Your Company Name")
                                .SetProperty("Style.FontSize", 15f)
                                .SetProperty("Style.FontStyle", FontStyle.Bold),
                            new AcmLineBreak(),
                            new AcmText("Street Address"),
                            new AcmLineBreak(),
                            new AcmText("City, State, Zip Code"),
                            new AcmLineBreak(),
                            new AcmText("Phone Number, WebSite, Etc.")),
                        new AcmTableCell(
                            new AcmText("INVOICE")
                                .SetProperty("Style.FontSize", 25f)
                                .SetProperty("Style.ForegroundColor", Color.FromArgb(216, 228, 232))
                                .SetProperty("Style.OffsetY", -0.05f),
                            new AcmLineBreak(),
                            new AcmContent(
                                new AcmText("Date:"),
                                new AcmText(DateTime.Today.ToString("MM/dd/yyyy")),
                                new AcmLineBreak(),
                                new AcmText("Invoice #: 12345"))
                                .SetProperty("Style.OffsetY", -0.04f)))

                    }),

                //header line
                new AcmBlock()
                    .SetProperty("Style.Margin.Top", 0.2f)
                    .SetProperty("Style.Margin.Bottom", 0.1f)
                    .SetProperty("Style.Border.Top", new AcmLineInfo(Color.FromArgb(216, 228, 232), 0.01f))
                    .SetProperty("Style.Border.Bottom", new AcmLineInfo(Color.FromArgb(216, 228, 232), 0.01f)),

                //Addresses
                new AcmTable(1, 2.25f, 1, 2.25f)
                    .SetProperty("Rows", new AcmTableRow[]
                    {
                        new AcmTableRow(
                            new AcmTableCell(
                                new AcmText("Bill To:")
                                    .SetProperty("Style.FontStyle", FontStyle.Bold)),
                            new AcmTableCell(
                                new AcmText("Test Customer"),
                                new AcmLineBreak(),
                                new AcmText("12345 ABC Road"),
                                new AcmLineBreak(),
                                new AcmText("New York, 33221")),
                            new AcmTableCell(
                                new AcmText("Ship To:")
                                    .SetProperty("Style.FontStyle", FontStyle.Bold)),
                            new AcmTableCell(
                                new AcmText("Test Customer"),
                                new AcmLineBreak(),
                                new AcmText("12345 ABC Road"),
                                new AcmLineBreak(),
                                new AcmText("New York, 33221")))
                    }),

                //Items
                new AcmTable(3.5f, 1, 1, 1)
                    .SetProperty("Rows", new AcmTableRow[]
                    {
                        (AcmTableRow)new AcmTableRow(
                            new AcmTableCell(new AcmText("Description")),
                            new AcmTableCell(new AcmText("Quantity")),
                            new AcmTableCell(new AcmText("Unit Price")),
                            new AcmTableCell(new AcmText("Total")))
                            .SetProperty("Style.BackgroundColor", Color.FromArgb(216, 228, 232))
                            .SetProperty("Style.Border.Bottom", new AcmLineInfo(0.01f)),
                        (AcmTableRow)new AcmTableRow(
                            new AcmTableCell(new AcmText("Cool product item 1")),
                            new AcmTableCell(new AcmText("1")),
                            new AcmTableCell(new AcmText("$99")),
                            new AcmTableCell(new AcmText("$99"))),
                        (AcmTableRow)new AcmTableRow(
                            new AcmTableCell(new AcmText("Cool product item 2")),
                            new AcmTableCell(new AcmText("2")),
                            new AcmTableCell(new AcmText("$39")),
                            new AcmTableCell(new AcmText("$78")))
                            .SetProperty("Style.BackgroundColor", Color.FromArgb(233, 233, 233)),
                        (AcmTableRow)new AcmTableRow(
                            new AcmTableCell(new AcmBlock().SetProperty("Style.Height", 1f))),
                    })
                    .SetProperty("Style.Margin.Top", 0.2f)
                    .SetProperty("CellPadding", 0.05f)
                    .SetProperty("GridLineType", AcmGridLineType.Frame | AcmGridLineType.GridV)
                    .SetProperty("GridLines", new AcmLineInfo(0.01f)),

                //Total table
                new AcmTable(1, 1)
                    .SetProperty("Rows", new AcmTableRow[]
                    {
                        new AcmTableRow(
                            new AcmTableCell(new AcmText("Subtotal")),
                            new AcmTableCell(new AcmText("$177"))),
                        new AcmTableRow(
                            new AcmTableCell(new AcmText("Tax (6%)")),
                            new AcmTableCell(new AcmText("$10.62"))),
                        new AcmTableRow(
                            new AcmTableCell(new AcmBold(new AcmText("Total Due"))),
                            new AcmTableCell(new AcmText("$187.62")))
                    })
                    .SetProperty("Style.Margin.Left", 4.5f)
                    .SetProperty("Style.OffsetY", -0.01f)
                    .SetProperty("CellPadding", 0.05f)
                    .SetProperty("GridLineType", AcmGridLineType.All)
                    .SetProperty("GridLines", new AcmLineInfo(0.01f)),

                new AcmBlock(
                    new AcmItalic(new AcmText("Thank you for your business!")))
                    .SetProperty("Style.Margin.Top", 0.5f)
            )
            .SetProperty("Style.FontSize", 10f);

            render.Render(content);

            //Save the result
            doc.Save(result);


            return null;
        }

        void render_AfterRenderPage(object sender, AcmPageEventArgs e)
        {
            PdfImage image = new PdfImage(LoadImage("Paid.png"));

            PdfImageContent content = new PdfImageContent();
            content.Image = image;
            content.GfxMatrix.Translate(350, 600);
            content.AutoScale();

            e.Page.Contents.Add(content);
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'>PdfDocument doc = <span class='kwd'>new</span> PdfDocument();

<span class='cmt'>//Create the render</span>
AcmRender render = <span class='kwd'>new</span> AcmRender(doc);

<span class='cmt'>//Handle AfterRenderPage event</span>
render.AfterRenderPage += <span class='kwd'>new</span> AcmPageEventHandler(render_AfterRenderPage);

AcmContent content = <span class='kwd'>new</span> AcmContent(
    <span class='cmt'>//header</span>
    <span class='kwd'>new</span> AcmTable(1, -1, 2)
    .SetProperty(<span class='st'>&quot;Rows&quot;</span>, <span class='kwd'>new</span> AcmTableRow[]
        {
        <span class='kwd'>new</span> AcmTableRow(
            <span class='kwd'>new</span> AcmTableCell(<span class='kwd'>new</span> AcmImage(LoadImage(<span class='st'>&quot;SampleLogo.gif&quot;</span>))),
            <span class='kwd'>new</span> AcmTableCell(
                <span class='kwd'>new</span> AcmText(<span class='st'>&quot;Your Company Name&quot;</span>)
                    .SetProperty(<span class='st'>&quot;Style.FontSize&quot;</span>, 15f)
                    .SetProperty(<span class='st'>&quot;Style.FontStyle&quot;</span>, FontStyle.Bold),
                <span class='kwd'>new</span> AcmLineBreak(),
                <span class='kwd'>new</span> AcmText(<span class='st'>&quot;Street Address&quot;</span>),
                <span class='kwd'>new</span> AcmLineBreak(),
                <span class='kwd'>new</span> AcmText(<span class='st'>&quot;City, State, Zip Code&quot;</span>),
                <span class='kwd'>new</span> AcmLineBreak(),
                <span class='kwd'>new</span> AcmText(<span class='st'>&quot;Phone Number, WebSite, Etc.&quot;</span>)),
            <span class='kwd'>new</span> AcmTableCell(
                <span class='kwd'>new</span> AcmText(<span class='st'>&quot;INVOICE&quot;</span>)
                    .SetProperty(<span class='st'>&quot;Style.FontSize&quot;</span>, 25f)
                    .SetProperty(<span class='st'>&quot;Style.ForegroundColor&quot;</span>, Color.FromArgb(216, 228, 232))
                    .SetProperty(<span class='st'>&quot;Style.OffsetY&quot;</span>, -0.05f),
                <span class='kwd'>new</span> AcmLineBreak(),
                <span class='kwd'>new</span> AcmContent(
                    <span class='kwd'>new</span> AcmText(<span class='st'>&quot;Date:&quot;</span>),
                    <span class='kwd'>new</span> AcmText(DateTime.Today.ToString(<span class='st'>&quot;MM/dd/yyyy&quot;</span>)),
                    <span class='kwd'>new</span> AcmLineBreak(),
                    <span class='kwd'>new</span> AcmText(<span class='st'>&quot;Invoice #: 12345&quot;</span>))
                    .SetProperty(<span class='st'>&quot;Style.OffsetY&quot;</span>, -0.04f)))

        }),

    <span class='cmt'>//header line</span>
    <span class='kwd'>new</span> AcmBlock()
        .SetProperty(<span class='st'>&quot;Style.Margin.Top&quot;</span>, 0.2f)
        .SetProperty(<span class='st'>&quot;Style.Margin.Bottom&quot;</span>, 0.1f)
        .SetProperty(<span class='st'>&quot;Style.Border.Top&quot;</span>, <span class='kwd'>new</span> AcmLineInfo(Color.FromArgb(216, 228, 232), 0.01f))
        .SetProperty(<span class='st'>&quot;Style.Border.Bottom&quot;</span>, <span class='kwd'>new</span> AcmLineInfo(Color.FromArgb(216, 228, 232), 0.01f)),

    <span class='cmt'>//Addresses</span>
    <span class='kwd'>new</span> AcmTable(1, 2.25f, 1, 2.25f)
        .SetProperty(<span class='st'>&quot;Rows&quot;</span>, <span class='kwd'>new</span> AcmTableRow[]
        {
            <span class='kwd'>new</span> AcmTableRow(
                <span class='kwd'>new</span> AcmTableCell(
                    <span class='kwd'>new</span> AcmText(<span class='st'>&quot;Bill To:&quot;</span>)
                        .SetProperty(<span class='st'>&quot;Style.FontStyle&quot;</span>, FontStyle.Bold)),
                <span class='kwd'>new</span> AcmTableCell(
                    <span class='kwd'>new</span> AcmText(<span class='st'>&quot;Test Customer&quot;</span>),
                    <span class='kwd'>new</span> AcmLineBreak(),
                    <span class='kwd'>new</span> AcmText(<span class='st'>&quot;12345 ABC Road&quot;</span>),
                    <span class='kwd'>new</span> AcmLineBreak(),
                    <span class='kwd'>new</span> AcmText(<span class='st'>&quot;New York, 33221&quot;</span>)),
                <span class='kwd'>new</span> AcmTableCell(
                    <span class='kwd'>new</span> AcmText(<span class='st'>&quot;Ship To:&quot;</span>)
                        .SetProperty(<span class='st'>&quot;Style.FontStyle&quot;</span>, FontStyle.Bold)),
                <span class='kwd'>new</span> AcmTableCell(
                    <span class='kwd'>new</span> AcmText(<span class='st'>&quot;Test Customer&quot;</span>),
                    <span class='kwd'>new</span> AcmLineBreak(),
                    <span class='kwd'>new</span> AcmText(<span class='st'>&quot;12345 ABC Road&quot;</span>),
                    <span class='kwd'>new</span> AcmLineBreak(),
                    <span class='kwd'>new</span> AcmText(<span class='st'>&quot;New York, 33221&quot;</span>)))
        }),

    <span class='cmt'>//Items</span>
    <span class='kwd'>new</span> AcmTable(3.5f, 1, 1, 1)
        .SetProperty(<span class='st'>&quot;Rows&quot;</span>, <span class='kwd'>new</span> AcmTableRow[]
        {
            (AcmTableRow)<span class='kwd'>new</span> AcmTableRow(
                <span class='kwd'>new</span> AcmTableCell(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;Description&quot;</span>)),
                <span class='kwd'>new</span> AcmTableCell(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;Quantity&quot;</span>)),
                <span class='kwd'>new</span> AcmTableCell(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;Unit Price&quot;</span>)),
                <span class='kwd'>new</span> AcmTableCell(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;Total&quot;</span>)))
                .SetProperty(<span class='st'>&quot;Style.BackgroundColor&quot;</span>, Color.FromArgb(216, 228, 232))
                .SetProperty(<span class='st'>&quot;Style.Border.Bottom&quot;</span>, <span class='kwd'>new</span> AcmLineInfo(0.01f)),
            (AcmTableRow)<span class='kwd'>new</span> AcmTableRow(
                <span class='kwd'>new</span> AcmTableCell(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;Cool product item 1&quot;</span>)),
                <span class='kwd'>new</span> AcmTableCell(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;1&quot;</span>)),
                <span class='kwd'>new</span> AcmTableCell(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;$99&quot;</span>)),
                <span class='kwd'>new</span> AcmTableCell(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;$99&quot;</span>))),
            (AcmTableRow)<span class='kwd'>new</span> AcmTableRow(
                <span class='kwd'>new</span> AcmTableCell(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;Cool product item 2&quot;</span>)),
                <span class='kwd'>new</span> AcmTableCell(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;2&quot;</span>)),
                <span class='kwd'>new</span> AcmTableCell(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;$39&quot;</span>)),
                <span class='kwd'>new</span> AcmTableCell(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;$78&quot;</span>)))
                .SetProperty(<span class='st'>&quot;Style.BackgroundColor&quot;</span>, Color.FromArgb(233, 233, 233)),
            (AcmTableRow)<span class='kwd'>new</span> AcmTableRow(
                <span class='kwd'>new</span> AcmTableCell(<span class='kwd'>new</span> AcmBlock().SetProperty(<span class='st'>&quot;Style.Height&quot;</span>, 1f))),
        })
        .SetProperty(<span class='st'>&quot;Style.Margin.Top&quot;</span>, 0.2f)
        .SetProperty(<span class='st'>&quot;CellPadding&quot;</span>, 0.05f)
        .SetProperty(<span class='st'>&quot;GridLineType&quot;</span>, AcmGridLineType.Frame | AcmGridLineType.GridV)
        .SetProperty(<span class='st'>&quot;GridLines&quot;</span>, <span class='kwd'>new</span> AcmLineInfo(0.01f)),

    <span class='cmt'>//Total table</span>
    <span class='kwd'>new</span> AcmTable(1, 1)
        .SetProperty(<span class='st'>&quot;Rows&quot;</span>, <span class='kwd'>new</span> AcmTableRow[]
        {
            <span class='kwd'>new</span> AcmTableRow(
                <span class='kwd'>new</span> AcmTableCell(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;Subtotal&quot;</span>)),
                <span class='kwd'>new</span> AcmTableCell(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;$177&quot;</span>))),
            <span class='kwd'>new</span> AcmTableRow(
                <span class='kwd'>new</span> AcmTableCell(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;Tax (6%)&quot;</span>)),
                <span class='kwd'>new</span> AcmTableCell(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;$10.62&quot;</span>))),
            <span class='kwd'>new</span> AcmTableRow(
                <span class='kwd'>new</span> AcmTableCell(<span class='kwd'>new</span> AcmBold(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;Total Due&quot;</span>))),
                <span class='kwd'>new</span> AcmTableCell(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;$187.62&quot;</span>)))
        })
        .SetProperty(<span class='st'>&quot;Style.Margin.Left&quot;</span>, 4.5f)
        .SetProperty(<span class='st'>&quot;Style.OffsetY&quot;</span>, -0.01f)
        .SetProperty(<span class='st'>&quot;CellPadding&quot;</span>, 0.05f)
        .SetProperty(<span class='st'>&quot;GridLineType&quot;</span>, AcmGridLineType.All)
        .SetProperty(<span class='st'>&quot;GridLines&quot;</span>, <span class='kwd'>new</span> AcmLineInfo(0.01f)),

    <span class='kwd'>new</span> AcmBlock(
        <span class='kwd'>new</span> AcmItalic(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;Thank you for your business!&quot;</span>)))
        .SetProperty(<span class='st'>&quot;Style.Margin.Top&quot;</span>, 0.5f)
)
.SetProperty(<span class='st'>&quot;Style.FontSize&quot;</span>, 10f);

render.Render(content);

<span class='cmt'>//Save the result</span>
doc.Save(result);</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='kwd'>Dim</span> doc <span class='kwd'>As New</span> PdfDocument()

<span class='cmt'>'Create the render</span>
<span class='kwd'>Dim</span> render <span class='kwd'>As New</span> AcmRender(doc)

<span class='cmt'>'Handle AfterRenderPage event</span>
<span class='kwd'>AddHandler</span> render.AfterRenderPage, <span class='kwd'>New</span> AcmPageEventHandler(<span class='kwd'>AddressOf</span>  render_AfterRenderPage)

<span class='cmt'>'header


'header line

'Addresses

'Items

'Total table</span>

<span class='kwd'>Dim</span> content <span class='kwd'>As</span> AcmContent = <span class='kwd'>New</span> AcmContent(<span class='kwd'>New</span> AcmTable(1, -1, 2) _
     .SetProperty(<span class='st'>&quot;Rows&quot;</span>, <span class='kwd'>New</span> AcmTableRow() {<span class='kwd'>New</span> AcmTableRow(<span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmImage(LoadImage(<span class='st'>&quot;SampleLogo.gif&quot;</span>))), _
             <span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Your Company Name&quot;</span>) _
                     .SetProperty(<span class='st'>&quot;Style.FontSize&quot;</span>, 15F) _
                     .SetProperty(<span class='st'>&quot;Style.FontStyle&quot;</span>, FontStyle.Bold), _
                 <span class='kwd'>New</span> AcmLineBreak(), _
                 <span class='kwd'>New</span> AcmText(<span class='st'>&quot;Street Address&quot;</span>), _
                 <span class='kwd'>New</span> AcmLineBreak(), _
                 <span class='kwd'>New</span> AcmText(<span class='st'>&quot;City, State, Zip Code&quot;</span>), _
                 <span class='kwd'>New</span> AcmLineBreak(), _
                 <span class='kwd'>New</span> AcmText(<span class='st'>&quot;Phone Number, WebSite, Etc.&quot;</span>)), _
             <span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;INVOICE&quot;</span>) _
                     .SetProperty(<span class='st'>&quot;Style.FontSize&quot;</span>, 25F) _
                     .SetProperty(<span class='st'>&quot;Style.ForegroundColor&quot;</span>, Color.FromArgb(216, 228, 232)) _
                     .SetProperty(<span class='st'>&quot;Style.OffsetY&quot;</span>, -0.05F), _
                 <span class='kwd'>New</span> AcmLineBreak(), _
                                 <span class='kwd'>New</span> AcmContent(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Date:&quot;</span>), _
                     <span class='kwd'>New</span> AcmText(DateTime.Today.ToString(<span class='st'>&quot;MM/dd/yyyy&quot;</span>)), _
                     <span class='kwd'>New</span> AcmLineBreak(), _
                     <span class='kwd'>New</span> AcmText(<span class='st'>&quot;Invoice #: 12345&quot;</span>)) _
                     .SetProperty(<span class='st'>&quot;Style.OffsetY&quot;</span>, -0.04F)))}), _
                     <span class='kwd'>New</span> AcmBlock() _
         .SetProperty(<span class='st'>&quot;Style.Margin.Top&quot;</span>, 0.2F) _
         .SetProperty(<span class='st'>&quot;Style.Margin.Bottom&quot;</span>, 0.1F) _
         .SetProperty(<span class='st'>&quot;Style.Border.Top&quot;</span>, <span class='kwd'>New</span> AcmLineInfo(Color.FromArgb(216, 228, 232), 0.01F)) _
         .SetProperty(<span class='st'>&quot;Style.Border.Bottom&quot;</span>, <span class='kwd'>New</span> AcmLineInfo(Color.FromArgb(216, 228, 232), 0.01F)), _
                     <span class='kwd'>New</span> AcmTable(1, 2.25F, 1, 2.25F) _
         .SetProperty(<span class='st'>&quot;Rows&quot;</span>, <span class='kwd'>New</span> AcmTableRow() {<span class='kwd'>New</span> AcmTableRow(<span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Bill To:&quot;</span>) _
                         .SetProperty(<span class='st'>&quot;Style.FontStyle&quot;</span>, FontStyle.Bold)), _
                 <span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Test Customer&quot;</span>), _
                     <span class='kwd'>New</span> AcmLineBreak(), _
                     <span class='kwd'>New</span> AcmText(<span class='st'>&quot;12345 ABC Road&quot;</span>), _
                     <span class='kwd'>New</span> AcmLineBreak(), _
                     <span class='kwd'>New</span> AcmText(<span class='st'>&quot;New York, 33221&quot;</span>)), _
                 <span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Ship To:&quot;</span>) _
                         .SetProperty(<span class='st'>&quot;Style.FontStyle&quot;</span>, FontStyle.Bold)), _
                 <span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Test Customer&quot;</span>), _
                     <span class='kwd'>New</span> AcmLineBreak(), _
                     <span class='kwd'>New</span> AcmText(<span class='st'>&quot;12345 ABC Road&quot;</span>), _
                     <span class='kwd'>New</span> AcmLineBreak(), _
                     <span class='kwd'>New</span> AcmText(<span class='st'>&quot;New York, 33221&quot;</span>)))}), _
                     <span class='kwd'>New</span> AcmTable(3.5F, 1, 1, 1) _
         .SetProperty(<span class='st'>&quot;Rows&quot;</span>, <span class='kwd'>New</span> AcmTableRow() {<span class='kwd'>DirectCast</span>(<span class='kwd'>New</span> AcmTableRow(<span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Description&quot;</span>)), _
                 <span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Quantity&quot;</span>)), _
                 <span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Unit Price&quot;</span>)), _
                 <span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Total&quot;</span>))) _
                 .SetProperty(<span class='st'>&quot;Style.BackgroundColor&quot;</span>, Color.FromArgb(216, 228, 232)) _
                 .SetProperty(<span class='st'>&quot;Style.Border.Bottom&quot;</span>, <span class='kwd'>New</span> AcmLineInfo(0.01F)), AcmTableRow), _
                         <span class='kwd'>DirectCast</span>(<span class='kwd'>New</span> AcmTableRow(<span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Cool product item 1&quot;</span>)), _
                 <span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;1&quot;</span>)), _
                 <span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;$99&quot;</span>)), _
                 <span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;$99&quot;</span>))), AcmTableRow), _
                         <span class='kwd'>DirectCast</span>(<span class='kwd'>New</span> AcmTableRow(<span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Cool product item 2&quot;</span>)), _
                 <span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;2&quot;</span>)), _
                 <span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;$39&quot;</span>)), _
                 <span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;$78&quot;</span>))) _
                 .SetProperty(<span class='st'>&quot;Style.BackgroundColor&quot;</span>, Color.FromArgb(233, 233, 233)), AcmTableRow), _
                         <span class='kwd'>DirectCast</span>(<span class='kwd'>New</span> AcmTableRow(<span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmBlock().SetProperty(<span class='st'>&quot;Style.Height&quot;</span>, 1F))), AcmTableRow)}) _
         .SetProperty(<span class='st'>&quot;Style.Margin.Top&quot;</span>, 0.2F) _
         .SetProperty(<span class='st'>&quot;CellPadding&quot;</span>, 0.05F) _
         .SetProperty(<span class='st'>&quot;GridLineType&quot;</span>, AcmGridLineType.Frame <span class='kwd'>Or</span> AcmGridLineType.GridV) _
         .SetProperty(<span class='st'>&quot;GridLines&quot;</span>, <span class='kwd'>New</span> AcmLineInfo(0.01F)), _
                     <span class='kwd'>New</span> AcmTable(1, 1) _
         .SetProperty(<span class='st'>&quot;Rows&quot;</span>, <span class='kwd'>New</span> AcmTableRow() {<span class='kwd'>New</span> AcmTableRow(<span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Subtotal&quot;</span>)), _
                 <span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;$177&quot;</span>))), _
             <span class='kwd'>New</span> AcmTableRow(<span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Tax (6%)&quot;</span>)), _
                 <span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;$10.62&quot;</span>))), _
             <span class='kwd'>New</span> AcmTableRow(<span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmBold(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Total Due&quot;</span>))), _
                 <span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;$187.62&quot;</span>)))}) _
         .SetProperty(<span class='st'>&quot;Style.Margin.Left&quot;</span>, 4.5F) _
         .SetProperty(<span class='st'>&quot;Style.OffsetY&quot;</span>, -0.01F) _
         .SetProperty(<span class='st'>&quot;CellPadding&quot;</span>, 0.05F) _
         .SetProperty(<span class='st'>&quot;GridLineType&quot;</span>, AcmGridLineType.All) _
         .SetProperty(<span class='st'>&quot;GridLines&quot;</span>, <span class='kwd'>New</span> AcmLineInfo(0.01F)), _
                     <span class='kwd'>New</span> AcmBlock(<span class='kwd'>New</span> AcmItalic(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Thank you for your business!&quot;</span>))) _
         .SetProperty(<span class='st'>&quot;Style.Margin.Top&quot;</span>, 0.5F)) _
 .SetProperty(<span class='st'>&quot;Style.FontSize&quot;</span>, 10F)

render.Render(content)

<span class='cmt'>'Save the result</span>
doc.Save(result)</pre>";

        }

        public override string GetInstructions()
        {
            return @"
<p>
This sample demonstrates how to create a rubber stamp
with low level content API.
</p>
<p>
The sample handles the <b>AcmRender</b> object's
<b>AfterPageRender</b> event and places a 
<b>PdfImageContent</b> on the page in that handler.
The image is then placed on top of the regular 
contents when rendered. Note that the image must
have an alpha channel (to support transparency) so
that it does not completely obscure the content below.
</p>
";
        }
    }
}