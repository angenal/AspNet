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

namespace EO.Wpf.Demo.Demos.ListBox
{
    /// <summary>
    /// Interaction logic for DragDrop3.xaml
    /// </summary>
    public partial class DragDrop3 : UserControl
    {
        public DragDrop3()
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

        private void TreeView1_ItemBeginDrag(object sender, ItemDragEventArgs e)
        {
            TreeViewItem item = e.SourceItemContainer as TreeViewItem;
            if (item.Level == 0)
                e.Canceled = true;
        }
    }
}
