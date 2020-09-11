using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Spreadsheet.Worksheets;

namespace WpfApp1
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //var uri = new Uri("/PresentationFramework.Royale,Version=4.0.0.0,Culture=neutral,PublicKeyToken=31bf3856ad364e35;component/themes/royale.normalcolor.xaml", UriKind.Relative);
            //App.Current.Resources.Source = uri;
            //base.OnStartup(e);


            //Random rand = new Random(DateTime.Now.GetHashCode());
            //int no = rand.Next(0, ThemeManager.StandardThemeNames.Count);
            //string key = ThemeManager.StandardThemeNames[no];
            //StyleManager.ApplicationTheme = ThemeManager.StandardThemes[key];

            //StyleManager.ApplicationTheme = ThemeManager.StandardThemes["Windows8"];
            ////var rootVisual = Application.Current.RootVisual as Grid;



            //ThemeManager.StandardThemes.Add("Default", new Themes.DefaultTheme() { });

            //Telerik.Windows.Controls.StyleManager.ApplicationTheme = ThemeManager.StandardThemes["Default"];

            var window = new Window6();
            window.Show();

            //var window = new Window5();
            //window.Show();

            //var window = new Window6();
            //window.Show();

            //App.Current.Resources.FindName("");
            //MaterialDesignThemes.Wpf.ColorZone
            //Win8（AeroLite）：  / PresentationFramework.AeroLite, Version = 4.0.0.0, Culture = neutral, PublicKeyToken = 31bf3856ad364e35; component / themes / aerolite.normalcolor.xaml
            //Win7 （Aero）：  / PresentationFramework.Aero, Version = 4.0.0.0, Culture = neutral, PublicKeyToken = 31bf3856ad364e35; component / themes / aero.normalcolor.xaml
            //WinXP 亮蓝（Royale）：  / PresentationFramework.Royale, Version = 4.0.0.0, Culture = neutral, PublicKeyToken = 31bf3856ad364e35; component / themes / royale.normalcolor.xaml
            //WinXP蓝色（Luna）：  / PresentationFramework.Luna, Version = 4.0.0.0, Culture = neutral, PublicKeyToken = 31bf3856ad364e35; component / themes / luna.normalcolor.xaml
            //WinXP银色（Luna）：  / PresentationFramework.Luna, Version = 4.0.0.0, Culture = neutral, PublicKeyToken = 31bf3856ad364e35; component / themes / luna.metallic.xaml
            //WinXP橄榄色（Luna）：  / PresentationFramework.Luna, Version = 4.0.0.0, Culture = neutral, PublicKeyToken = 31bf3856ad364e35; component / themes / luna.homestead.xaml
            //Win98（Classic）：  / PresentationFramework.Classic, Version = 4.0.0.0, Culture = neutral, PublicKeyToken = 31bf3856ad364e35; component / themes / classic.xaml

        }

        private void RadComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
