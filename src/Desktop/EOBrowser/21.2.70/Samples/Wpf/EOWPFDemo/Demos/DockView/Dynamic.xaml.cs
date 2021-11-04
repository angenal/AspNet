using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace EO.Wpf.Demo.Demos.DockView
{
    /// <summary>
    /// Interaction logic for Dynamic.xaml
    /// </summary>
    public partial class Dynamic : UserControl
    {
        private const string FilePrefix = "file://";
        private string m_szLayoutXML;
        private TextBlock m_tbFilePath;

        public Dynamic()
        {
            InitializeComponent();

            //Initialize DockItem "PropertyWindow". This will raises DockViewNeeded event
            //first, then DockItemNeeded event. These two event handler works together to
            //create the "PropertyWindow" DockItem and the DockView object that hosts the
            //"PropertyWindow" DockItem
            DockContainer1.LoadItem("PropertyWindow");
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text Files|*.txt";
            Window window = Window.GetWindow(this);
            if (dlg.ShowDialog(window).Value)
            {
                DockContainer1.ActivateItem(FilePrefix + dlg.FileName);
            }
        }

        private void DockContainer1_DockViewNeeded(object sender, DockViewNeededEventArgs e)
        {
            EO.Wpf.DockView view;
            if (e.ItemId.StartsWith(FilePrefix))
            {
                //Create the DocumentView if we do not already have one
                view = DockContainer1.GetDocumentView();
                if (view == null)
                {
                    view = new Wpf.DockView();
                    view.Dock = Dock.Top;
                    view.IsDocumentView = true;
                }
            }
            else
            {
                //Create a new DockView and dock it to the bottom
                view = new EO.Wpf.DockView();
                view.Dock = Dock.Bottom;
                view.Height = 100;
            }
            e.DockView = view;
        }

        private void DockContainer1_DockItemNeeded(object sender, DockItemNeededEventArgs e)
        {
            //Create the DockItem object based on the ItemId
            if (e.ItemId.StartsWith(FilePrefix))
                e.Item = CreateFileDockItem(e.ItemId);
            else if (e.ItemId == "PropertyWindow")
                e.Item = CreatePropertyWindow();
        }

        private DockItem CreateFileDockItem(string itemId)
        {
            string fileName = itemId.Substring(FilePrefix.Length);
            DocumentItem item = new DocumentItem();
            TextBox textBox = new TextBox();
            textBox.AcceptsReturn = true;
            textBox.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;

            string text = null;
            try
            {
                text = File.ReadAllText(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Fail to load file", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            textBox.Text = text;
            item.Content = textBox;
            item.Content = textBox;
            item.Title = System.IO.Path.GetFileName(fileName);

            return item;
        }

        private DockItem CreatePropertyWindow()
        {
            DockItem item = new DockItem();
            item.Title = "Properties";
            TextBlock filePath = new TextBlock();
            item.Content = filePath;
            m_tbFilePath = filePath;
            return item;
        }

        private void DockView_SelectedItemChanged(object sender, RoutedEventArgs e)
        {
            UpdatePropertyWindow();
        }

        private void UpdatePropertyWindow()
        {
            if (m_tbFilePath == null)
                return;

            EO.Wpf.DockView view = DockContainer1.GetDocumentView();
            DockItem item = view.SelectedItem;
            if (item != null)
                m_tbFilePath.Text = item.ItemId;
            else
                m_tbFilePath.Text = "";
        }

        private void btnSaveLayout_Click(object sender, RoutedEventArgs e)
        {
            m_szLayoutXML = DockContainer1.SaveLayoutXml();
        }

        private void btnLoadLayout_Click(object sender, RoutedEventArgs e)
        {
            if (m_szLayoutXML == null)
            {
                MessageBox.Show(
                    "Please click \"Save Layout\" button to save the layout first.",
                    "Load Layout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DockContainer1.LoadLayoutXml(m_szLayoutXML);
            UpdatePropertyWindow();
        }
    }
}
