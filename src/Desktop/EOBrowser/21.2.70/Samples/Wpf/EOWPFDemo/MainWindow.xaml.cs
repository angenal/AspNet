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

namespace EO.Wpf.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class DemoItem
        {
            private string m_szName;
            private string m_szPath;
            private DemoItem[] m_ChildItems;

            public DemoItem(string name, string path)
            {
                m_szName = name;
                m_szPath = path;
            }

            public DemoItem(string name, DemoItem[] childItems)
            {
                m_szName = name;
                m_ChildItems = childItems;
            }

            public string Name
            {
                get { return m_szName; }
                set { m_szName = value; }
            }

            public string Path
            {
                get { return m_szPath; }
                set { m_szPath = value; }
            }

            public DemoItem[] ChildItems
            {
                get { return m_ChildItems; }
                set { m_ChildItems = value; }
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            //Initialize theme menu items
            foreach (EO.Wpf.MenuItem item in mnuThemes.Items)
            {
                item.IsCheckable = true;
                item.CheckGroup = "Theme";
                item.Checked += new RoutedEventHandler(ThemeItem_Checked);
            }
            
            //Initialize demos
            tvDemos.ItemsSource = new DemoItem[]
            {
                new DemoItem("Services", new DemoItem[]
                {
                    new DemoItem("Theme Manager", new DemoItem[]
                    {
                        new DemoItem("Switching App Themes", @"Demos\Theme\SwitchTheme.xaml"),
                        new DemoItem("Switching Control Skins", @"Demos\Theme\SwitchSkin.xaml"),
                        new DemoItem("Custom Skins for EO.Wpf Controls", @"Demos\Theme\CustomSkin1.xaml"),
                        new DemoItem("Custom Skins for Your Controls", @"Demos\Theme\CustomSkin2.xaml"),
                        new DemoItem("Monitor Theme/Skin Changes", @"Demos\Theme\MonitorTheme.xaml"),
                    })
                }),
                new DemoItem("Controls", new DemoItem[]
                {
                    new DemoItem("Buttons", new DemoItem[]
                    {
                        new DemoItem("Button", @"Demos\Buttons\Button.xaml"),
                        new DemoItem("BareButton", @"Demos\Buttons\BareButton.xaml"),
                        new DemoItem("BitmapButton", @"Demos\Buttons\BitmapButton.xaml"),
                        new DemoItem("DropDownButton", @"Demos\Buttons\DropDownButton.xaml"),
                        new DemoItem("SplitButton", @"Demos\Buttons\SplitButton.xaml"),
                        new DemoItem("LinkButton", @"Demos\Buttons\LinkButton.xaml"),
                        new DemoItem("CheckBox", @"Demos\Buttons\CheckBox.xaml"),
                        new DemoItem("RadioButton", @"Demos\Buttons\RadioButton.xaml"),
                    }),
                    new DemoItem("Calendar", new DemoItem[]
                    {
                        new DemoItem("Year Picker", @"Demos\Calendar\YearPicker.xaml"),
                        new DemoItem("Month Picker", @"Demos\Calendar\MonthPicker.xaml"),
                        new DemoItem("Calendar", @"Demos\Calendar\Calendar.xaml"),
                        new DemoItem("Disabled Dates", @"Demos\Calendar\DisabledDates.xaml"),
                        new DemoItem("Multi-Selection", @"Demos\Calendar\MultiSelect.xaml"),
                        new DemoItem("Multi Month View", @"Demos\Calendar\MultiMonthView.xaml"),
                        new DemoItem("Date Picker", @"Demos\Calendar\DatePicker.xaml"),
                    }),
                    new DemoItem("ComboBox", new DemoItem[]
                    {
                        new DemoItem("Static ComboBox", @"Demos\ComboBox\Static.xaml"),
                        new DemoItem("Dynamic ComboBox", @"Demos\ComboBox\Dynamic.xaml"),
                        new DemoItem("Drop Down Header & Footer", @"Demos\ComboBox\HeaderFooter.xaml"),
                        new DemoItem("Multi-Selection", @"Demos\ComboBox\MultiSelect.xaml"),
                        new DemoItem("Multi-Selection with Custom SelectionBoxItemTemplate", @"Demos\ComboBox\MultiSelect2.xaml"),
                        new DemoItem("Multi-Selection with Custom MoreItemsButtonTemplate", @"Demos\ComboBox\MultiSelect3.xaml"),
                        new DemoItem("Multi-Selection with Custom Drop Down Header/Footer Template", @"Demos\ComboBox\MultiSelect4.xaml"),
                        new DemoItem("Clear Button", @"Demos\ComboBox\ClearButton.xaml"),
                        new DemoItem("Empty Prompt", @"Demos\ComboBox\EmptyPrompt.xaml"),
                        new DemoItem("Disabled Item", @"Demos\ComboBox\DisabledItem.xaml"),
                        new DemoItem("Item Template Selector", @"Demos\ComboBox\ItemTemplateSelector.xaml"),
                    }),
                    new DemoItem("DockView", new DemoItem[]
                    {
                        new DemoItem("Visual Studio 2008 Style", @"Demos\DockView\VS2008.xaml"),
                        new DemoItem("Visual Studio 2010 Style", @"Demos\DockView\VS2010.xaml"),
                        new DemoItem("Visual Studio 2012 Style", @"Demos\DockView\VS2012.xaml"),
                        new DemoItem("Dynamic Layout", @"Demos\DockView\Dynamic.xaml"),
                    }),
                    new DemoItem("Expander", new DemoItem[]
                    {
                        new DemoItem("Basic", @"Demos\Expander\Basic.xaml"),
                        new DemoItem("Multiple Expanders", @"Demos\Expander\Multiple.xaml"),
                    }),
                    new DemoItem("Gauge", new DemoItem[]
                    {
                        new DemoItem("Built-in Skins", new DemoItem[]
                        {
                            new DemoItem("Linear", @"Demos\Gauge\BuiltinLinearSkin.xaml"), 
                            new DemoItem("Rolling", @"Demos\Gauge\BuiltinRollingSkin.xaml"), 
                            new DemoItem("Circular", @"Demos\Gauge\BuiltinCircularSkin.xaml"), 
                        }), 
                        new DemoItem("Scales", new DemoItem[]
                        {
                            new DemoItem("Linear", new DemoItem[]
                            {
                                new DemoItem("Basic", @"Demos\Gauge\BasicLinearScale.xaml"), 
                                new DemoItem("With Custom Ticks and Labels", @"Demos\Gauge\LinearScaleCustomTicks.xaml"), 
                                new DemoItem("With Markers", @"Demos\Gauge\LinearScaleMarkers.xaml"), 
                                new DemoItem("With Ranges", @"Demos\Gauge\LinearScaleRanges.xaml"), 
                            }), 
                            new DemoItem("Rolling", @"Demos\Gauge\RollingScale.xaml"), 
                            new DemoItem("Circular", new DemoItem[]
                            {
                                new DemoItem("Basic", @"Demos\Gauge\BasicCircularScale.xaml"), 
                                new DemoItem("Customize Rings", @"Demos\Gauge\CircularScaleCustomRings.xaml"), 
                                new DemoItem("With Markers", @"Demos\Gauge\CircularScaleMarkers.xaml"), 
                                new DemoItem("With RangeBar", @"Demos\Gauge\CircularScaleRangeBar.xaml"), 
                                new DemoItem("With Needle", @"Demos\Gauge\CircularScaleNeedles.xaml"), 
                            }), 
                        }),
                        new DemoItem("Advanced Samples", new DemoItem[]
                        {
                            new DemoItem("Car Dashboard", @"Demos\Gauge\CarDashboard.xaml"),
                            new DemoItem("Sport Watch", @"Demos\Gauge\SportsWatch.xaml"),
                            new DemoItem("Gauge with Custom Frame", @"Demos\Gauge\GaugeCustomFrame.xaml"),
                            new DemoItem("Clock", @"Demos\Gauge\ClockGauge.xaml"),
                        }), 
                    }), 
                    new DemoItem("MaskedEdit", new DemoItem[]
                    {
                        new DemoItem("Multi Segments", @"Demos\MaskedEdit\MultiSegments.xaml"),
                        new DemoItem("Numeric Segment", @"Demos\MaskedEdit\NumericSegment.xaml"),
                        new DemoItem("Mask Segment", @"Demos\MaskedEdit\MaskSegment.xaml"),
                        new DemoItem("Choice Segment", @"Demos\MaskedEdit\ChoiceSegment.xaml"),
                        new DemoItem("Case Conversion", @"Demos\MaskedEdit\CaseConversion.xaml"),
                        new DemoItem("Empty Prompt", @"Demos\MaskedEdit\EmptyPrompt.xaml"),
                        new DemoItem("Verification", @"Demos\MaskedEdit\Verification.xaml"),
                    }),
                    new DemoItem("Menu", new DemoItem[]
                    {
                        new DemoItem("Static Menu", @"Demos\Menu\Static.xaml"),
                        new DemoItem("Dynamic Menu with HierarchicalDataTemplate", @"Demos\Menu\Dynamic1.xaml"),
                        new DemoItem("Dynamic Menu with ItemContainerStyle", @"Demos\Menu\Dynamic2.xaml"),
                        new DemoItem("Vertical Menu", @"Demos\Menu\VerticalMenu.xaml"),
                        new DemoItem("Drop Down Menu", @"Demos\Menu\DropDownMenu.xaml"),
                        new DemoItem("Spacer Item", @"Demos\Menu\SpacerItem.xaml"),
                        new DemoItem("Menu Item Icon 1", @"Demos\Menu\MenuIcon1.xaml"),
                        new DemoItem("Menu Item Icon 2", @"Demos\Menu\MenuIcon2.xaml"),
                        new DemoItem("Check Item", @"Demos\Menu\CheckItem.xaml"),
                        new DemoItem("Sub Menu Indicator", @"Demos\Menu\SubMenuIndicator.xaml"),
                        new DemoItem("Multi-Column Sub Menu", @"Demos\Menu\MultiColumn.xaml"),
                        new DemoItem("Custom Template", @"Demos\Menu\CustomTemplate.xaml"),
                    }),
                    new DemoItem("ListBox", new DemoItem[]
                    {
                        new DemoItem("Static ListBox", @"Demos\ListBox\Static.xaml"),
                        new DemoItem("Dynamic ListBox", @"Demos\ListBox\Dynamic.xaml"),
                        new DemoItem("Header & Footer", @"Demos\ListBox\HeaderFooter.xaml"),
                        new DemoItem("Multi Selection", @"Demos\ListBox\MultiSelect.xaml"),
                        new DemoItem("CheckBox", @"Demos\ListBox\CheckBox.xaml"),
                        new DemoItem("Drag Drop In the Same ListBox", @"Demos\ListBox\DragDrop1.xaml"),
                        new DemoItem("Drag Drop In the Different ListBoxes", @"Demos\ListBox\DragDrop2.xaml"),
                        new DemoItem("Drag Drop From TreeView To ListBox", @"Demos\ListBox\DragDrop3.xaml"),
                    }),
                    new DemoItem("ProgressBar", new DemoItem[]
                    {
                        new DemoItem("Basic ProgressBar", @"Demos\ProgressBar\Basic.xaml"),
                        new DemoItem("Displaying Values", @"Demos\ProgressBar\ShowValue.xaml"),
                        new DemoItem("Content Template", @"Demos\ProgressBar\ContentTemplate.xaml"),
                    }),
                    new DemoItem("Slider", new DemoItem[]
                    {
                        new DemoItem("Basic Slider & RangeSlider", @"Demos\Slider\Basic.xaml"),
                        new DemoItem("Vertical Slider & RangeSlider", @"Demos\Slider\Vertical.xaml"),
                        new DemoItem("Range Indicators", @"Demos\Slider\RangeIndicators.xaml"),
                        new DemoItem("Tick Template", @"Demos\Slider\TickTemplate.xaml"),
                        new DemoItem("Custom Thumb", @"Demos\Slider\CustomThumb.xaml"),
                    }),
                    new DemoItem("SpinEdit", new DemoItem[]
                    {
                        new DemoItem("Basic SpinEdit", @"Demos\SpinEdit\Basic.xaml"),
                        new DemoItem("Advanced Format", @"Demos\SpinEdit\AdvanceFormat.xaml"),
                        new DemoItem("Range Indicator", @"Demos\SpinEdit\RangeIndicator.xaml"),
                    }),
                    new DemoItem("SplitView", new DemoItem[]
                    {
                        new DemoItem("Basic SplitView", @"Demos\SplitView\Basic.xaml"),
                        new DemoItem("Advanced SplitView", @"Demos\SplitView\Advanced.xaml"),
                        new DemoItem("Custom Splitter", @"Demos\SplitView\CustomSplitter.xaml"),
                    }),
                    new DemoItem("TabControl", new DemoItem[]
                    {
                        new DemoItem("Static TabControl", @"Demos\TabControl\Static.xaml"),
                        new DemoItem("Dynamic TabControl", @"Demos\TabControl\Dynamic.xaml"),
                        new DemoItem("Scrolling TabControl", @"Demos\TabControl\Scroll.xaml"),
                        new DemoItem("Scroll Button Style", @"Demos\TabControl\ScrollButtonStyle.xaml"),
                        new DemoItem("Item Overflow Strategy", @"Demos\TabControl\Overflow.xaml"),
                        new DemoItem("Drop Down Menu", @"Demos\TabControl\DropDownMenu.xaml"),
                        new DemoItem("New Tab Button", @"Demos\TabControl\NewTabButton.xaml"),
                        new DemoItem("New Tab Button Style", @"Demos\TabControl\NewTabButtonStyle.xaml"),
                        new DemoItem("Close Tab Button", @"Demos\TabControl\CloseTabButton.xaml"),
                        new DemoItem("Close Tab Button Style", @"Demos\TabControl\CloseTabButtonStyle.xaml"),
                        new DemoItem("Custom Tab Item", @"Demos\TabControl\CustomItem.xaml"),
                    }),
                    new DemoItem("TreeView", new DemoItem[]
                    {
                        new DemoItem("Static TreeView", @"Demos\TreeView\Static.xaml"),
                        new DemoItem("Dynamic TreeView", @"Demos\TreeView\Dynamic.xaml"),
                        new DemoItem("Hierarchical TreeView", @"Demos\TreeView\Hierarchical.xaml"),
                        new DemoItem("Drag Drop In the Same TreeView", @"Demos\TreeView\DragDrop1.xaml"),
                        new DemoItem("Drag Drop In Different TreeViews", @"Demos\TreeView\DragDrop2.xaml"),
                        new DemoItem("Drag Drop From ListBox To TreeViews", @"Demos\TreeView\DragDrop3.xaml"),
                        new DemoItem("Checkbox", @"Demos\TreeView\Checkbox.xaml"),
                        new DemoItem("In Place Editing", @"Demos\TreeView\EditItem.xaml"),
                        new DemoItem("Item Icon", @"Demos\TreeView\ItemIcon.xaml"),
                    }),
                    new DemoItem("Misc", new DemoItem[]
                    {
                        new DemoItem("Bitmap", @"Demos\Misc\Bitmap.xaml"),
                        new DemoItem("DropDown", @"Demos\Misc\DropDown.xaml"),
                        new DemoItem("Window Chrome", @"Demos\Misc\WindowChrome.xaml"),
                    }),
                }),
            };
        }

        private void File_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void tvDemos_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            DemoItem item = (DemoItem)e.NewValue;
            if ((item != null) && (item.Path != null))
            {
                object demo = Application.LoadComponent(new Uri(@"EOWpfDemo;component\" + item.Path, UriKind.RelativeOrAbsolute));
                UIElement demoUI = demo as UIElement;
                if (demoUI != null)
                    splitView.View2 = demoUI;
            }
        }

        private void OnEffectiveAppThemeNameChanged(object sender, RoutedEventArgs e)
        {
            CheckCurrentThemeItem();
        }

        void ThemeItem_Checked(object sender, RoutedEventArgs e)
        {
            EO.Wpf.MenuItem menuItem = (EO.Wpf.MenuItem)sender;
            ThemeManager.AppTheme = (string)menuItem.Header;
        }

        private void CheckCurrentThemeItem()
        {
            string appTheme = ThemeManager.AppTheme;
            foreach (EO.Wpf.MenuItem item in mnuThemes.Items)
            {
                if ((string)item.Header == appTheme)
                {
                    item.IsChecked = true;
                    break;
                }
            }
        }

        private void OnAbout(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Owner = this;
            about.ShowDialog();
        }
    }
}
