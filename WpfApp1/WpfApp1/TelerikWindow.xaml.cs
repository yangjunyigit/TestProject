using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// TelerikWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TelerikWindow : RadWindow
    {

        public string ThemeName
        {
            get { return (string)GetValue(ThemeNameProperty); }
            set
            {
                SetValue(ThemeNameProperty, value);
            }
        }



        // Using a DependencyProperty as the backing store for ThemeName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ThemeNameProperty =
            DependencyProperty.Register("ThemeName", typeof(string), typeof(TelerikWindow), new PropertyMetadata("Windows8"));




        public List<string> ThemeNameList
        {
            get { return (List<string>)GetValue(ThemeNameListProperty); }
            set { SetValue(ThemeNameListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ThemeNameList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ThemeNameListProperty =
            DependencyProperty.Register("ThemeNameList", typeof(List<string>), typeof(TelerikWindow), new PropertyMetadata(null));



        public bool IsPopupOpen
        {
            get { return (bool)GetValue(IsPopupOpenProperty); }
            set { SetValue(IsPopupOpenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsPopupOpen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPopupOpenProperty =
            DependencyProperty.Register("IsPopupOpen", typeof(bool), typeof(TelerikWindow), new PropertyMetadata(true));



        public string HeaderMessage
        {
            get { return (string)GetValue(HeaderMessageProperty); }
            set { SetValue(HeaderMessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderMessage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderMessageProperty =
            DependencyProperty.Register("HeaderMessage", typeof(string), typeof(TelerikWindow), new PropertyMetadata("message"));



        public TelerikWindow()
        {
            InitializeComponent();

            IEnumerable<Theme> themes = ThemeManager.StandardThemes.Select(a => a.Value);
            //this.close
            //object applicationTheme = ThemeManager.;
            //StyleManager.ApplicationTheme = ThemeManager.StandardThemes.Select(m=>m.Key=="").First();
            this.DataContext = this;
            string abc = "";

            ThemeNameList = new List<string> {
                        "Office_Black",
                        "Office_Blue",
                        "Office_Silver",
                        "Summer",
                        "Vista",
                        "Windows7",
                        "Transparent",
                        "Expression_Dark",
                        "Windows8",
                        "Windows8Touch",
                        "VisualStudio2013",
                        "Office2013",
                        "Office2016",
                        "Office2016Touch",
                        "Green",
                        "Material",
                        "Fluent",
            };
            ThemeName = "Transparent";
            //this.Header
            //Telerik.Windows.Controls.WindowCommands.Minimize
            //RadRibbonWindow window = new RadRibbonWindow();
        }
        private void RadComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeTheme(ThemeName);
        }

        private void ReminderButton_Click(object sender, RoutedEventArgs e)
        {
            //Storyboard reminderAnim = this.Resources["ReminderAnimation"] as Storyboard;
            //reminderAnim.Begin();
            //Telerik.Windows.Controls.Navigation.RadWindowInteropHelper.
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Configuration cfg = ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            string setKey = "TestKey";
            if (cfg.AppSettings.Settings.AllKeys.Contains(setKey))
            {
                cfg.AppSettings.Settings[setKey].Value = "11111";
            }
            else
            {
                cfg.AppSettings.Settings.Add(setKey, "22222");
            }
            cfg.Save();
            ConfigurationManager.RefreshSection("appSettings");

            //Random rand = new Random(DateTime.Now.GetHashCode());
            //int no = rand.Next(0, ThemeManager.StandardThemeNames.Count);
            //string selectedThemeName = ThemeManager.StandardThemeNames[no];
            ////StyleManager.ApplicationTheme = ThemeManager.StandardThemes[key];

            //ChangeTheme(selectedThemeName);

            ////StyleManager.SetTheme(Application.Current., ThemeManager.StandardThemes[key]);

            //EventTrigger et = new EventTrigger();

            //Popup
            //et.Actions.Add()
            //TriggerAction ta = TriggerAction.

        }
        private void ChangeTheme(string themeName)
        {
            if (themeName == "Windows8Touch")
            {
                return;
            }
            App.Current.Resources.MergedDictionaries.Clear();

            setStyle(this, themeName);

            return;

            //Telerik.Windows.Controls.IconSources
            //StyleManager.ApplicationTheme = new Windows7Theme();

            //var resources = App.Current.Resources.MergedDictionaries;

            App.Current.Resources.MergedDictionaries.Clear();

            //App.Current.Resources.MergedDictionaries.AddRange(resources);


            // XAML

            App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + themeName + ";component/Themes/System.Windows.xaml", UriKind.RelativeOrAbsolute)
            });
            App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + themeName + ";component/Themes/Telerik.Windows.Controls.xaml", UriKind.RelativeOrAbsolute)
            });
            App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + themeName + ";component/Themes/Telerik.Windows.Controls.Input.xaml", UriKind.RelativeOrAbsolute)
            });
            App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + themeName + ";component/Themes/Telerik.Windows.Controls.Navigation.xaml", UriKind.RelativeOrAbsolute)
            });
            App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + themeName + ";component/Themes/Telerik.Windows.Controls.Data.xaml", UriKind.RelativeOrAbsolute)
            });
            App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + themeName + ";component/Themes/Telerik.Windows.Controls.DataVisualization.xaml", UriKind.RelativeOrAbsolute)
            });
            App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + themeName + ";component/Themes/Telerik.Windows.Controls.Docking.xaml", UriKind.RelativeOrAbsolute)
            });
            App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + themeName + ";component/Themes/Telerik.Windows.Controls.GridView.xaml", UriKind.RelativeOrAbsolute)
            });
            App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + themeName + ";component/Themes/Telerik.Windows.Controls.Pivot.xaml", UriKind.RelativeOrAbsolute)
            });
            App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + themeName + ";component/Themes/Telerik.Windows.Controls.PivotFieldList.xaml", UriKind.RelativeOrAbsolute)
            });
            App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Telerik.Windows.Themes." + themeName + ";component/Themes/Telerik.Windows.Controls.VirtualGrid.xaml", UriKind.RelativeOrAbsolute)
            });
        }

        private void setStyle(DependencyObject depObj, string themeName)
        {
            if (depObj is RadButton)
            {

            }
            int count = VisualTreeHelper.GetChildrenCount(depObj);
            for (int i = 0; i < count; i++)
            {
                var dep = VisualTreeHelper.GetChild(depObj, i);
                //LogicalTreeHelper.get
                setStyle(dep, themeName);
            }
            StyleManager.SetTheme(depObj, ThemeManager.StandardThemes[themeName]);

        }

        private void ResetRootVisual()
        {
            //System.Configuration.ConfigurationManager
        }

        private void ThemeBtn_Click(object sender, RoutedEventArgs e)
        {
            IsPopupOpen = !IsPopupOpen;
            App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/RedWindowHeaderTemplate.xaml")
            });
        }

        private void RadButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private int n = 0;
        private void RadListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            n++;
            HeaderMessage = n.ToString();
            ChangeTheme(ThemeName);//A1ADB8
        }
    }
}
