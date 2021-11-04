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
using EO.Wpf;

namespace EO.Wpf.Demo.Demos.Theme
{
    /// <summary>
    /// Interaction logic for CustomSkin1.xaml
    /// </summary>
    public partial class CustomSkin1 : UserControl
    {
        static CustomSkin1()
        {
ThemeManager.RegisterSkinStyles(
    new SkinStyleInfo(typeof(EO.Wpf.Button), "Red", typeof(CustomSkin1).Assembly, "Sample_Button_Red"),
    new SkinStyleInfo(typeof(EO.Wpf.Button), "Blue", typeof(CustomSkin1).Assembly, "Sample_Button_Blue"));

            //Uncomment this to register themes
            //ThemeManager.RegisterThemeStyles(
            //    new ThemeStyleInfo("Red", typeof(EO.Wpf.Button), "Red"),
            //    new ThemeStyleInfo("Blue", typeof(EO.Wpf.Button), "Blue"));
        }

        public CustomSkin1()
        {
            InitializeComponent();
        }
    }
}
