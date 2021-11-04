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
using EO.Wpf.Demo.Data;

namespace EO.Wpf.Demo.Demos.TreeView
{
    /// <summary>
    /// Interaction logic for EditItem.xaml
    /// </summary>
    public partial class EditItem : UserControl
    {
        public EditItem()
        {
            InitializeComponent();

            Celebrity[] popularSingers = new Celebrity[]
            {
                new Celebrity("Carly Rae Jepsen", "Carly_Rae_Jepsen.gif"),
                new Celebrity("Cher Lloyd", "Cher_Lloyd.gif"),
                new Celebrity("Chris Brown", "Chris_Brown.gif"),
                new Celebrity("Flo Rida", "Flo_Rida.gif"),
                new Celebrity("Justin Bieber", "Justin_Bieber.gif"),
                new Celebrity("Katy Perry", "Katy_Perry.gif"),
                new Celebrity("Kelly Clarkson", "Kelly_Clarkson.gif"),
            };

            Celebrity[] popularActors = new Celebrity[]
            {
                new Celebrity("Cate Blanchett", "Cate_Blanchett.gif"),
                new Celebrity("Denzel Washington", "Denzel_Washington.gif"),
                new Celebrity("Julia Roberts", "Julia_Roberts.gif"),
                new Celebrity("Merly Streep", "Meryl_Streep.gif"),
                new Celebrity("Tom Cruise", "Tom_Cruise.gif"),
                new Celebrity("Tom Hanks", "Tom_Hanks.gif"),
            };

            CelebrityCategory[] categories = new CelebrityCategory[]
            {
                new CelebrityCategory("Popular Singers", "music.png", popularSingers),
                new CelebrityCategory("Popular Actors", "movie.png", popularActors),
            };

            TreeView1.ItemsSource = categories;
        }

        private void TreeView_EnterEditMode(object sender, EditItemEventArgs e)
        {
            if (e.Item is CelebrityCategory)
            {
                CelebrityCategory category = (CelebrityCategory)e.Item;
                e.Text = category.Name;
            }
            else if (e.Item is Celebrity)
            {
                Celebrity celebrity = (Celebrity)e.Item;
                e.Text = celebrity.Name;
            }
        }

        private void TreeView_ExitEditMode(object sender, EditItemEventArgs e)
        {
            if (e.Item is CelebrityCategory)
            {
                CelebrityCategory category = (CelebrityCategory)e.Item;
                category.Name = e.Text;
            }
            else if (e.Item is Celebrity)
            {
                Celebrity celebrity = (Celebrity)e.Item;
                celebrity.Name = e.Text;
            }

            //The event must be canceled, otherwise the TreeView will
            //set the TreeViewItem's Header to the new text
            e.Canceled = true;
        }
    }
}
