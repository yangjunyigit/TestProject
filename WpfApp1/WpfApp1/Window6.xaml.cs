using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Telerik.Windows.Controls.Charting;
using Telerik.Windows.Controls.ColorPicker;
using Telerik.Windows.Controls.TreeMap;

namespace WpfApp1
{
    /// <summary>
    /// Window6.xaml 的交互逻辑
    /// </summary>
    public partial class Window6 : RadWindow
    {
        public Window6()
        {
            InitializeComponent();

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
            ComboSource = new ObservableCollection<string>();
            for (int i = 0; i < 50000; i++)
            {
                ComboSource.Add(i.ToString());
            }
        }
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
            DependencyProperty.Register("ThemeName", typeof(string), typeof(Window6), new PropertyMetadata("Windows8"));




        public List<string> ThemeNameList
        {
            get { return (List<string>)GetValue(ThemeNameListProperty); }
            set { SetValue(ThemeNameListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ThemeNameList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ThemeNameListProperty =
            DependencyProperty.Register("ThemeNameList", typeof(List<string>), typeof(Window6), new PropertyMetadata(null));



        public bool IsPopupOpen
        {
            get { return (bool)GetValue(IsPopupOpenProperty); }
            set { SetValue(IsPopupOpenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsPopupOpen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPopupOpenProperty =
            DependencyProperty.Register("IsPopupOpen", typeof(bool), typeof(Window6), new PropertyMetadata(true));



        public string HeaderMessage
        {
            get { return (string)GetValue(HeaderMessageProperty); }
            set { SetValue(HeaderMessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderMessage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderMessageProperty =
            DependencyProperty.Register("HeaderMessage", typeof(string), typeof(Window6), new PropertyMetadata("message"));




        public ObservableCollection<string> ComboSource
        {
            get { return (ObservableCollection<string>)GetValue(ComboSourceProperty); }
            set { SetValue(ComboSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ComboSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ComboSourceProperty =
            DependencyProperty.Register("ComboSource", typeof(ObservableCollection<string>), typeof(Window6), new PropertyMetadata(null));




        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(Window6), new PropertyMetadata(""));




        private void ThemeBtn_Click(object sender, RoutedEventArgs e)
        {
            IsPopupOpen = !IsPopupOpen;
            //App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            //{
            //    Source = new Uri("pack://application:,,,/RedWindowHeaderTemplate.xaml")
            //});
        }
        int n = 0;
        private void RadListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            n++;
            HeaderMessage = n.ToString();
            ChangeTheme(ThemeName);//A1ADB8

            //Office2013Palette.Palette.AccentMainColor
            //Office2016Palette.Palette.
            //Windows8Palette.Palette.Freeze();

            Telerik.Windows.Controls.OfficeColorPalette tp;

            //App.Current.Resources.MergedDictionaries.

            //Telerik.Windows.Controls.OfficeColorPalette
        }

        private void ChangeTheme(string themeName)
        {
            //throw new NotImplementedException();
            App.Current.Resources.MergedDictionaries.Clear();
            StyleManager.SetTheme(this, ThemeManager.StandardThemes[themeName]);
            setStyle(this, themeName);
        }
        private void setStyle(DependencyObject depObj, string themeName)
        {
            //if (depObj is RadButton)sldkf
            //{

            //}
            //int count = VisualTreeHelper.GetChildrenCount(depObj);
            //for (int i = 0; i < count; i++)
            //{
            //    var dep = VisualTreeHelper.GetChild(depObj, i);
            //    //LogicalTreeHelper.get
            //    setStyle(dep, themeName);
            //}
            //StyleManager.SetTheme(depObj, ThemeManager.StandardThemes[themeName]);

            //Telerik.Windows.Controls.mater

            MaterialDesignColors.Hue h;

            var children = LogicalTreeHelper.GetChildren(depObj);
            foreach (var item in children)
            {
                if (item is DependencyObject)
                {
                    setStyle(item as DependencyObject, themeName);
                }
            }
            StyleManager.SetTheme(depObj, ThemeManager.StandardThemes[themeName]);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //OfficeColorPalette ocp = new OfficePalette(); 
            // var colors = ocp.GetColors();
            //ComboSource.Clear();
            //foreach (var item in colors)
            //{
            //    ComboSource.Add(item.ToString());
            //}


            //OfficeColorPalette ocp = new OfficePalette();
            //var colors = ocp.GetColors();
            //ComboSource.Clear();

            //foreach (var item in App.Current.Resources.MergedDictionaries)
            //{
            //    ComboSource.Add(item.ToString());
            //}
            
            //Message = MEFTest.Test.Get();
        }
    }
}
