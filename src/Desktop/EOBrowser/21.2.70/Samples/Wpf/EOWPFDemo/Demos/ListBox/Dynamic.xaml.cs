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
    /// Interaction logic for Dynamic.xaml
    /// </summary>
    public partial class Dynamic : UserControl
    {
        public Dynamic()
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

            ListBox1.ItemsSource = popularSingers;
        }
    }
}
