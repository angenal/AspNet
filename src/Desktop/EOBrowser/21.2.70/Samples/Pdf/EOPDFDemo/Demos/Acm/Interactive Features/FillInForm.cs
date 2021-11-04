using System;
using System.IO;
using EOPDFDemo;
using EO.Pdf;
using EO.Pdf.Acm;

namespace EOPDFDemo.Acm.Interactive
{
    public class FillInForm : Demo
    {
        public FillInForm(string path)
            : base(path)
        {
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            //Create a new PdfDocument
            PdfDocument doc = new PdfDocument();

            //Create a new AcmRender object
            AcmRender render = new AcmRender(doc);

            //Create the root content        
            AcmTable table = new AcmTable(1f, 4f);
            table.CellPadding = 0.02f;

            //Create the "First Name" row
            AcmTableRow row = new AcmTableRow();
            table.Rows.Add(row);

            //Create the "First Name" label
            row.Children.Add(new AcmTableCell(new AcmText("First Name: ")));

            //Create the "First Name" text box
            AcmTextBox tbFirstName = new AcmTextBox();

            //Set the textbox size
            tbFirstName.Style.Width = 2f;
            tbFirstName.Style.Height = 0.3f;

            //Set field name
            tbFirstName.Name = "first_name";

            //Add the textbox into the table row
            row.Children.Add(new AcmTableCell(tbFirstName));

            //Create the "Last Name" row
            row = new AcmTableRow();
            table.Rows.Add(row);

            //Create the "Last Name" paragraph
            row.Children.Add(new AcmTableCell(new AcmText("Last Name: ")));

            //Create the "Last Name" text box
            AcmTextBox tbLastName = new AcmTextBox();

            //Set the textbox size
            tbLastName.Style.Width = 2f;
            tbLastName.Style.Height = 0.3f;

            //Set field name
            tbLastName.Name = "last_name";

            //Add the textbox into the content tree
            row.Children.Add(new AcmTableCell(tbLastName));

            //Create the "Gender" row
            row = new AcmTableRow();
            table.Rows.Add(row);

            //Add "Gender" label
            row.Children.Add(new AcmTableCell(new AcmText("Gender: ")));

            //Create "Male" and "Female" radio button. These
            //two fields are grouped together because they
            //have the same value for their "Name" property
            AcmTableCell cell = new AcmTableCell();
            AcmRadioButton rbMale = new AcmRadioButton();
            rbMale.Name = "gender";
            AcmRadioButton rbFemale = new AcmRadioButton();
            rbFemale.Name = "gender";

            cell.Children.Add(rbMale);
            cell.Children.Add(new AcmText("Male"));
            cell.Children.Add(rbFemale);
            cell.Children.Add(new AcmText("Female"));
            row.Children.Add(cell);

            //Create the "Married" row
            row = new AcmTableRow();
            table.Rows.Add(row);
            row.Children.Add(new AcmTableCell());
            cell = new AcmTableCell();

            //Create the checkbox
            AcmCheckBox cbMarried = new AcmCheckBox();
            cbMarried.Name = "is_married";
            cell.Children.Add(cbMarried);
            cell.Children.Add(new AcmText("Married"));
            row.Children.Add(cell);

            //Create the "Race" row
            row = new AcmTableRow();
            table.Rows.Add(row);
            row.Children.Add(new AcmTableCell(new AcmText("Race: ")));
            cell = new AcmTableCell();

            //Create the race listbox
            AcmListBox lbRace = new AcmListBox();
            lbRace.Style.Width = 3f;
            lbRace.Name = "race";
            lbRace.Items.Add(new PdfListItem("American Indian or Alaskan Native"));
            lbRace.Items.Add(new PdfListItem("Asian"));
            lbRace.Items.Add(new PdfListItem("African American"));
            lbRace.Items.Add(new PdfListItem("White"));
            lbRace.Items.Add(new PdfListItem("Other"));
            cell.Children.Add(lbRace);

            row.Children.Add(cell);

            //Create the "Language" row
            row = new AcmTableRow();
            table.Rows.Add(row);
            row.Children.Add(new AcmTableCell(new AcmText("Language: ")));
            cell = new AcmTableCell();

            //Create the language combobox
            AcmComboBox cbLanguage = new AcmComboBox();
            cbLanguage.Style.Width = 2f;
            cbLanguage.Name = "language";
            cbLanguage.Items.Add(new PdfListItem("English"));
            cbLanguage.Items.Add(new PdfListItem("French"));
            cbLanguage.Items.Add(new PdfListItem("Spanish"));
            cbLanguage.Items.Add(new PdfListItem("Other"));
            cell.Children.Add(cbLanguage);

            row.Children.Add(cell);

            //Render the table
            render.Render(table);

            //Save the result
            doc.Save(result);


            return null;
        }

        public override string GetCSCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>//Create a new PdfDocument</span>
PdfDocument doc = <span class='kwd'>new</span> PdfDocument();

<span class='cmt'>//Create a new AcmRender object</span>
AcmRender render = <span class='kwd'>new</span> AcmRender(doc);

<span class='cmt'>//Create the root content        </span>
AcmTable table = <span class='kwd'>new</span> AcmTable(1f, 4f);
table.CellPadding = 0.02f;

<span class='cmt'>//Create the &quot;First Name&quot; row</span>
AcmTableRow row = <span class='kwd'>new</span> AcmTableRow();
table.Rows.Add(row);

<span class='cmt'>//Create the &quot;First Name&quot; label</span>
row.Children.Add(<span class='kwd'>new</span> AcmTableCell(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;First Name: &quot;</span>)));

<span class='cmt'>//Create the &quot;First Name&quot; text box</span>
AcmTextBox tbFirstName = <span class='kwd'>new</span> AcmTextBox();

<span class='cmt'>//Set the textbox size</span>
tbFirstName.Style.Width = 2f;
tbFirstName.Style.Height = 0.3f;

<span class='cmt'>//Set field name</span>
tbFirstName.Name = <span class='st'>&quot;first_name&quot;</span>;

<span class='cmt'>//Add the textbox into the table row</span>
row.Children.Add(<span class='kwd'>new</span> AcmTableCell(tbFirstName));

<span class='cmt'>//Create the &quot;Last Name&quot; row</span>
row = <span class='kwd'>new</span> AcmTableRow();
table.Rows.Add(row);

<span class='cmt'>//Create the &quot;Last Name&quot; paragraph</span>
row.Children.Add(<span class='kwd'>new</span> AcmTableCell(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;Last Name: &quot;</span>)));

<span class='cmt'>//Create the &quot;Last Name&quot; text box</span>
AcmTextBox tbLastName = <span class='kwd'>new</span> AcmTextBox();

<span class='cmt'>//Set the textbox size</span>
tbLastName.Style.Width = 2f;
tbLastName.Style.Height = 0.3f;

<span class='cmt'>//Set field name</span>
tbLastName.Name = <span class='st'>&quot;last_name&quot;</span>;

<span class='cmt'>//Add the textbox into the content tree</span>
row.Children.Add(<span class='kwd'>new</span> AcmTableCell(tbLastName));

<span class='cmt'>//Create the &quot;Gender&quot; row</span>
row = <span class='kwd'>new</span> AcmTableRow();
table.Rows.Add(row);

<span class='cmt'>//Add &quot;Gender&quot; label</span>
row.Children.Add(<span class='kwd'>new</span> AcmTableCell(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;Gender: &quot;</span>)));

<span class='cmt'>//Create &quot;Male&quot; and &quot;Female&quot; radio button. These
//two fields are grouped together because they
//have the same value for their &quot;Name&quot; property</span>
AcmTableCell cell = <span class='kwd'>new</span> AcmTableCell();
AcmRadioButton rbMale = <span class='kwd'>new</span> AcmRadioButton();
rbMale.Name = <span class='st'>&quot;gender&quot;</span>;
AcmRadioButton rbFemale = <span class='kwd'>new</span> AcmRadioButton();
rbFemale.Name = <span class='st'>&quot;gender&quot;</span>;

cell.Children.Add(rbMale);
cell.Children.Add(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;Male&quot;</span>));
cell.Children.Add(rbFemale);
cell.Children.Add(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;Female&quot;</span>));
row.Children.Add(cell);

<span class='cmt'>//Create the &quot;Married&quot; row</span>
row = <span class='kwd'>new</span> AcmTableRow();
table.Rows.Add(row);
row.Children.Add(<span class='kwd'>new</span> AcmTableCell());
cell = <span class='kwd'>new</span> AcmTableCell();

<span class='cmt'>//Create the checkbox</span>
AcmCheckBox cbMarried = <span class='kwd'>new</span> AcmCheckBox();
cbMarried.Name = <span class='st'>&quot;is_married&quot;</span>;
cell.Children.Add(cbMarried);
cell.Children.Add(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;Married&quot;</span>));
row.Children.Add(cell);

<span class='cmt'>//Create the &quot;Race&quot; row</span>
row = <span class='kwd'>new</span> AcmTableRow();
table.Rows.Add(row);
row.Children.Add(<span class='kwd'>new</span> AcmTableCell(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;Race: &quot;</span>)));
cell = <span class='kwd'>new</span> AcmTableCell();

<span class='cmt'>//Create the race listbox</span>
AcmListBox lbRace = <span class='kwd'>new</span> AcmListBox();
lbRace.Style.Width = 3f;
lbRace.Name = <span class='st'>&quot;race&quot;</span>;
lbRace.Items.Add(<span class='kwd'>new</span> PdfListItem(<span class='st'>&quot;American Indian or Alaskan Native&quot;</span>));
lbRace.Items.Add(<span class='kwd'>new</span> PdfListItem(<span class='st'>&quot;Asian&quot;</span>));
lbRace.Items.Add(<span class='kwd'>new</span> PdfListItem(<span class='st'>&quot;African American&quot;</span>));
lbRace.Items.Add(<span class='kwd'>new</span> PdfListItem(<span class='st'>&quot;White&quot;</span>));
lbRace.Items.Add(<span class='kwd'>new</span> PdfListItem(<span class='st'>&quot;Other&quot;</span>));
cell.Children.Add(lbRace);

row.Children.Add(cell);

<span class='cmt'>//Create the &quot;Language&quot; row</span>
row = <span class='kwd'>new</span> AcmTableRow();
table.Rows.Add(row);
row.Children.Add(<span class='kwd'>new</span> AcmTableCell(<span class='kwd'>new</span> AcmText(<span class='st'>&quot;Language: &quot;</span>)));
cell = <span class='kwd'>new</span> AcmTableCell();

<span class='cmt'>//Create the language combobox</span>
AcmComboBox cbLanguage = <span class='kwd'>new</span> AcmComboBox();
cbLanguage.Style.Width = 2f;
cbLanguage.Name = <span class='st'>&quot;language&quot;</span>;
cbLanguage.Items.Add(<span class='kwd'>new</span> PdfListItem(<span class='st'>&quot;English&quot;</span>));
cbLanguage.Items.Add(<span class='kwd'>new</span> PdfListItem(<span class='st'>&quot;French&quot;</span>));
cbLanguage.Items.Add(<span class='kwd'>new</span> PdfListItem(<span class='st'>&quot;Spanish&quot;</span>));
cbLanguage.Items.Add(<span class='kwd'>new</span> PdfListItem(<span class='st'>&quot;Other&quot;</span>));
cell.Children.Add(cbLanguage);

row.Children.Add(cell);

<span class='cmt'>//Render the table</span>
render.Render(table);

<span class='cmt'>//Save the result</span>
doc.Save(result);</pre>";

        }

        public override string GetVBCode()
        {
            //Generated code, do not modify
            return         @"<pre class='coloredcode'><span class='cmt'>'Create a new PdfDocument</span>
<span class='kwd'>Dim</span> doc <span class='kwd'>As New</span> PdfDocument()

<span class='cmt'>'Create a new AcmRender object</span>
<span class='kwd'>Dim</span> render <span class='kwd'>As New</span> AcmRender(doc)

<span class='cmt'>'Create the root content</span>
<span class='kwd'>Dim</span> table <span class='kwd'>As New</span> AcmTable(1F, 4F)
table.CellPadding = 0.02F

<span class='cmt'>'Create the &quot;First Name&quot; row</span>
<span class='kwd'>Dim</span> row <span class='kwd'>As New</span> AcmTableRow()
table.Rows.Add(row)

<span class='cmt'>'Create the &quot;First Name&quot; label</span>
row.Children.Add(<span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;First Name: &quot;</span>)))

<span class='cmt'>'Create the &quot;First Name&quot; text box</span>
<span class='kwd'>Dim</span> tbFirstName <span class='kwd'>As New</span> AcmTextBox()

<span class='cmt'>'Set the textbox size</span>
tbFirstName.Style.Width = 2F
tbFirstName.Style.Height = 0.3F

<span class='cmt'>'Set field name</span>
tbFirstName.Name = <span class='st'>&quot;first_name&quot;</span>

<span class='cmt'>'Add the textbox into the table row</span>
row.Children.Add(<span class='kwd'>New</span> AcmTableCell(tbFirstName))

<span class='cmt'>'Create the &quot;Last Name&quot; row</span>
row = <span class='kwd'>New</span> AcmTableRow()
table.Rows.Add(row)

<span class='cmt'>'Create the &quot;Last Name&quot; paragraph</span>
row.Children.Add(<span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Last Name: &quot;</span>)))

<span class='cmt'>'Create the &quot;Last Name&quot; text box</span>
<span class='kwd'>Dim</span> tbLastName <span class='kwd'>As New</span> AcmTextBox()

<span class='cmt'>'Set the textbox size</span>
tbLastName.Style.Width = 2F
tbLastName.Style.Height = 0.3F

<span class='cmt'>'Set field name</span>
tbLastName.Name = <span class='st'>&quot;last_name&quot;</span>

<span class='cmt'>'Add the textbox into the content tree</span>
row.Children.Add(<span class='kwd'>New</span> AcmTableCell(tbLastName))

<span class='cmt'>'Create the &quot;Gender&quot; row</span>
row = <span class='kwd'>New</span> AcmTableRow()
table.Rows.Add(row)

<span class='cmt'>'Add &quot;Gender&quot; label</span>
row.Children.Add(<span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Gender: &quot;</span>)))

<span class='cmt'>'Create &quot;Male&quot; and &quot;Female&quot; radio button. These
'two fields are grouped together because they
'have the same value for their &quot;Name&quot; property</span>
<span class='kwd'>Dim</span> cell <span class='kwd'>As New</span> AcmTableCell()
<span class='kwd'>Dim</span> rbMale <span class='kwd'>As New</span> AcmRadioButton()
rbMale.Name = <span class='st'>&quot;gender&quot;</span>
<span class='kwd'>Dim</span> rbFemale <span class='kwd'>As New</span> AcmRadioButton()
rbFemale.Name = <span class='st'>&quot;gender&quot;</span>

cell.Children.Add(rbMale)
cell.Children.Add(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Male&quot;</span>))
cell.Children.Add(rbFemale)
cell.Children.Add(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Female&quot;</span>))
row.Children.Add(cell)

<span class='cmt'>'Create the &quot;Married&quot; row</span>
row = <span class='kwd'>New</span> AcmTableRow()
table.Rows.Add(row)
row.Children.Add(<span class='kwd'>New</span> AcmTableCell())
cell = <span class='kwd'>New</span> AcmTableCell()

<span class='cmt'>'Create the checkbox</span>
<span class='kwd'>Dim</span> cbMarried <span class='kwd'>As New</span> AcmCheckBox()
cbMarried.Name = <span class='st'>&quot;is_married&quot;</span>
cell.Children.Add(cbMarried)
cell.Children.Add(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Married&quot;</span>))
row.Children.Add(cell)

<span class='cmt'>'Create the &quot;Race&quot; row</span>
row = <span class='kwd'>New</span> AcmTableRow()
table.Rows.Add(row)
row.Children.Add(<span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Race: &quot;</span>)))
cell = <span class='kwd'>New</span> AcmTableCell()

<span class='cmt'>'Create the race listbox</span>
<span class='kwd'>Dim</span> lbRace <span class='kwd'>As New</span> AcmListBox()
lbRace.Style.Width = 3F
lbRace.Name = <span class='st'>&quot;race&quot;</span>
lbRace.Items.Add(<span class='kwd'>New</span> PdfListItem(<span class='st'>&quot;American Indian or Alaskan Native&quot;</span>))
lbRace.Items.Add(<span class='kwd'>New</span> PdfListItem(<span class='st'>&quot;Asian&quot;</span>))
lbRace.Items.Add(<span class='kwd'>New</span> PdfListItem(<span class='st'>&quot;African American&quot;</span>))
lbRace.Items.Add(<span class='kwd'>New</span> PdfListItem(<span class='st'>&quot;White&quot;</span>))
lbRace.Items.Add(<span class='kwd'>New</span> PdfListItem(<span class='st'>&quot;Other&quot;</span>))
cell.Children.Add(lbRace)

row.Children.Add(cell)

<span class='cmt'>'Create the &quot;Language&quot; row</span>
row = <span class='kwd'>New</span> AcmTableRow()
table.Rows.Add(row)
row.Children.Add(<span class='kwd'>New</span> AcmTableCell(<span class='kwd'>New</span> AcmText(<span class='st'>&quot;Language: &quot;</span>)))
cell = <span class='kwd'>New</span> AcmTableCell()

<span class='cmt'>'Create the language combobox</span>
<span class='kwd'>Dim</span> cbLanguage <span class='kwd'>As New</span> AcmComboBox()
cbLanguage.Style.Width = 2F
cbLanguage.Name = <span class='st'>&quot;language&quot;</span>
cbLanguage.Items.Add(<span class='kwd'>New</span> PdfListItem(<span class='st'>&quot;English&quot;</span>))
cbLanguage.Items.Add(<span class='kwd'>New</span> PdfListItem(<span class='st'>&quot;French&quot;</span>))
cbLanguage.Items.Add(<span class='kwd'>New</span> PdfListItem(<span class='st'>&quot;Spanish&quot;</span>))
cbLanguage.Items.Add(<span class='kwd'>New</span> PdfListItem(<span class='st'>&quot;Other&quot;</span>))
cell.Children.Add(cbLanguage)

row.Children.Add(cell)

<span class='cmt'>'Render the table</span>
render.Render(table)

<span class='cmt'>'Save the result</span>
doc.Save(result)</pre>";

        }

        public override string GetInstructions()
        {
            return @"
<p>
This sample demonstrates how to create a fill in form
with <b>AcmTextBox</b> -- Just add it into the content
tree as with any other content. See 
<a href=""javascript:eo_OpenHelp('Acm/Interactive/acro_form.html')"">here</a> 
for more details. 

</p>
";
        }
    }
}