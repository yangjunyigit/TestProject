using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.RichTextBoxUI.Dialogs;

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
            set { 
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
            set { SetValue(IsPopupOpenProperty, value);}
        }

        // Using a DependencyProperty as the backing store for IsPopupOpen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPopupOpenProperty =
            DependencyProperty.Register("IsPopupOpen", typeof(bool), typeof(TelerikWindow), new PropertyMetadata(true));


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
            ThemeName = "Windows8";
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
            Random rand = new Random(DateTime.Now.GetHashCode());
            int no = rand.Next(0, ThemeManager.StandardThemeNames.Count);
            string selectedThemeName = ThemeManager.StandardThemeNames[no];
            //StyleManager.ApplicationTheme = ThemeManager.StandardThemes[key];

            ChangeTheme(selectedThemeName);

            //StyleManager.SetTheme(Application.Current., ThemeManager.StandardThemes[key]);

            EventTrigger et = new EventTrigger();

            //Popup
            //et.Actions.Add()
            //TriggerAction ta = TriggerAction.

        }
        private void ChangeTheme(string themeName)
        {
            if(themeName == "Windows8Touch")
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
        private void ResetRootVisual()
        {
        }

        private void ThemeBtn_Click(object sender, RoutedEventArgs e)
        {
            IsPopupOpen = !IsPopupOpen;
        }

        private void RadButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void RadListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IsPopupOpen = false;
            ChangeTheme(ThemeName);
        }
    }
}
