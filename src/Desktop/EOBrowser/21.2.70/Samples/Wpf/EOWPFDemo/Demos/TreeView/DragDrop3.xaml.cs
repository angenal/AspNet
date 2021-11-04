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
    /// Interaction logic for DragDrop3.xaml
    /// </summary>
    public partial class DragDrop3 : UserControl
    {
        public DragDrop3()
        {
            InitializeComponent();

            //Populate the TreeView
            string prompt = "Drag a name here";
            Celebrity[] popularSingers = new Celebrity[]
            {
                new Celebrity(prompt, "Carly_Rae_Jepsen.gif"),
                new Celebrity(prompt, "Cher_Lloyd.gif"),
                new Celebrity(prompt, "Chris_Brown.gif"),
                new Celebrity(prompt, "Flo_Rida.gif"),
                new Celebrity(prompt, "Justin_Bieber.gif"),
                new Celebrity(prompt, "Katy_Perry.gif"),
                new Celebrity(prompt, "Kelly_Clarkson.gif"),
            };
            Celebrity[] popularActors = new Celebrity[]
            {
                new Celebrity(prompt, "Cate_Blanchett.gif"),
                new Celebrity(prompt, "Denzel_Washington.gif"),
                new Celebrity(prompt, "Julia_Roberts.gif"),
                new Celebrity(prompt, "Meryl_Streep.gif"),
                new Celebrity(prompt, "Tom_Cruise.gif"),
                new Celebrity(prompt, "Tom_Hanks.gif"),
            };
            CelebrityCategory[] categories = new CelebrityCategory[]
            {
                new CelebrityCategory("Popular Singers", "music.png", popularSingers),
                new CelebrityCategory("Popular Actors", "movie.png", popularActors),
            };
            tvCelebrities.ItemsSource = categories;

            //Populate the ListBox
            string[] names = new string[]
            {
                "Carly Rae Jepsen",
                "Cate Blanchett",
                "Cher Lloyd",
                "Chris Brown",
                "Denzel Washington",
                "Flo Rida",
                "Julia Roberts",
                "Justin Bieber",
                "Katy Perry",
                "Kelly Clarkson",
                "Merly Streep",
                "Tom Cruise",
                "Tom Hanks",
            };
            lstNames.ItemsSource = names;
        }

        private void tvCelebrities_ItemDragOver(object sender, ItemDragOverEventArgs e)
        {
            EO.Wpf.TreeViewItem item = (EO.Wpf.TreeViewItem)e.TargetItemContainer1;

            //Only allow items to be dragged onto the Celebrity items,
            //not CelebrityCategory items
            if (item.Level != 1)
                e.Canceled = true;
        }

        private void tvCelebrities_ItemDrop(object sender, ItemDropEventArgs e)
        {
            //The source data item is the celebrity name
            string source = (string)e.SourceItem;

            //The target data is a Celebrity object
            Celebrity target = (Celebrity)e.TargetItem1;

            //Update the Celebrity object's Name property
            target.Name = source;

            //Cancel the default behavior (The default behavior insert
            //the source as a child item of the target item)
            e.Canceled = true;
        }
    }
}
