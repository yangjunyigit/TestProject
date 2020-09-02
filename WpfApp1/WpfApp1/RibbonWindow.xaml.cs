using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// RibbonWindow.xaml 的交互逻辑
    /// </summary>
    public partial class RibbonWindow : RadRibbonWindow
    {
        public RibbonWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random(DateTime.Now.GetHashCode());
            int no = rand.Next(0, ThemeManager.StandardThemeNames.Count);
            string selectedThemeName = ThemeManager.StandardThemeNames[no];
            //StyleManager.ApplicationTheme = ThemeManager.StandardThemes[key];

            ChangeTheme(selectedThemeName);

            //StyleManager.SetTheme(Application.Current., ThemeManager.StandardThemes[key]);

            EventTrigger et = new EventTrigger();
            //et.Actions.Add()
            //TriggerAction ta = TriggerAction.

        }
        private void ChangeTheme(string themeName)
        {
            if (themeName == "Windows8Touch")
            {
                return;
            }
            StyleManager.SetTheme(this, ThemeManager.StandardThemes[themeName]);
            Application.Current.Resources.MergedDictionaries.Clear();

            // XAML

            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + themeName + ";component/Themes/System.Windows.xaml", UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + themeName + ";component/Themes/Telerik.Windows.Controls.xaml", UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + themeName + ";component/Themes/Telerik.Windows.Controls.Input.xaml", UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + themeName + ";component/Themes/Telerik.Windows.Controls.Navigation.xaml", UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + themeName + ";component/Themes/Telerik.Windows.Controls.Data.xaml", UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + themeName + ";component/Themes/Telerik.Windows.Controls.DataVisualization.xaml", UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + themeName + ";component/Themes/Telerik.Windows.Controls.Docking.xaml", UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + themeName + ";component/Themes/Telerik.Windows.Controls.GridView.xaml", UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + themeName + ";component/Themes/Telerik.Windows.Controls.Pivot.xaml", UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + themeName + ";component/Themes/Telerik.Windows.Controls.PivotFieldList.xaml", UriKind.RelativeOrAbsolute)
            });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + themeName + ";component/Themes/Telerik.Windows.Controls.VirtualGrid.xaml", UriKind.RelativeOrAbsolute)
            });
        }
    }
}
