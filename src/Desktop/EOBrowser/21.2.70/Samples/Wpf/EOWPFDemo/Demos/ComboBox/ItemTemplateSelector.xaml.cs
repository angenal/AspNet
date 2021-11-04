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

namespace EO.Wpf.Demo.Demos.ComboBox
{
    /// <summary>
    /// Interaction logic for ItemTemplateSelector.xaml
    /// </summary>
    public partial class ItemTemplateSelector : UserControl
    {
        /// <summary>
        /// A simple list item that has a name and a flag indicating
        /// whether it's a category or a product
        /// </summary>
        private class ListItem
        {
            private string m_szName;
            private bool m_bIsCategory;

            public ListItem(string name, bool isCategory)
            {
                m_szName = name;
                m_bIsCategory = isCategory;
            }

            public string Name { get { return m_szName; } }

            public bool IsCategory { get { return m_bIsCategory; } }
        }

        private class TemplateSelector : DataTemplateSelector
        {
            private UserControl m_Owner;

            public TemplateSelector(UserControl owner)
            {
                m_Owner = owner;
            }

            public override DataTemplate SelectTemplate(object item, DependencyObject container)
            {
                ListItem listItem = item as ListItem;
                if (listItem != null)
                {
                    if (listItem.IsCategory)
                        return m_Owner.FindResource("CategoryTemplate") as DataTemplate;
                    else
                        return m_Owner.FindResource("ProductTemplate") as DataTemplate;
                }

                return null;
            }
        }

        public ItemTemplateSelector()
        {
            InitializeComponent();

            ListItem[] items = new ListItem[]
            {
                new ListItem("Hardwares", true),
                    new ListItem("The New iPad", false),
                    new ListItem("Windows Surface", false),
                    new ListItem("Kindle Fire", false),
                    new ListItem("Chromebook", false),
                new ListItem("Softwares", true),
                    new ListItem("Windows 8", false),
                    new ListItem("Adobe Photoshop 11", false),
                    new ListItem("QuickBooks 2013", false),
            };

            cbProducts.ItemTemplateSelector = new TemplateSelector(this);
            cbProducts.ItemsSource = items;
        }
    }
}
