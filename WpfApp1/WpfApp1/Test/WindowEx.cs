using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    public class WindowEx : Window,INotifyPropertyChanged
    {
        public event EventHandler<WindowExFixEventArgs> FixEvent;

        private ResourceDictionary _resource;

        private ICommand _WindowBtnCommand;
        /// <summary>
        /// 窗体按钮命令
        /// </summary>
        public ICommand WindowBtnCommand
        {
            get
            {
                return _WindowBtnCommand;
            }
            set
            {
                _WindowBtnCommand = value;
                OnPropertyChanged("WindowBtnCommand");
            }
        }

        private Thickness _BorderMargin = new Thickness(0, 0, 0, 0);
        public Thickness BorderMargin
        {
            get
            {
                return _BorderMargin;
            }
            set
            {
                _BorderMargin = value;
                OnPropertyChanged("BorderMargin");
            }
        }

        private HorizontalAlignment _BtnPanelHorizontalAlignment = HorizontalAlignment.Right;
        /// <summary>
        /// 窗体按钮的Panel位置
        /// </summary>
        public HorizontalAlignment BtnPanelHorizontalAlignment
        {
            get
            {
                return _BtnPanelHorizontalAlignment;
            }
            set
            {
                _BtnPanelHorizontalAlignment = value;
                OnPropertyChanged("BtnPanelHorizontalAlignment");
            }
        }

        private Visibility _BtnMinimizeVisibility = Visibility.Visible;
        /// <summary>
        /// 窗体最小化按钮的显示状态
        /// </summary>
        public Visibility BtnMinimizeVisibility
        {
            get
            {
                return _BtnMinimizeVisibility;
            }
            set
            {
                _BtnMinimizeVisibility = value;
                OnPropertyChanged("BtnMinimizeVisibility");
            }
        }

        private Visibility _BtnMaximizeVisibility = Visibility.Visible;
        /// <summary>
        /// 窗体最大化按钮的显示状态
        /// </summary>
        public Visibility BtnMaximizeVisibility
        {
            get
            {
                return _BtnMaximizeVisibility;
            }
            set
            {
                _BtnMaximizeVisibility = value;
                OnPropertyChanged("BtnMaximizeVisibility");
            }
        }

        private Geometry _BtnMaximizePathData;
        /// <summary>
        /// 窗体最大化按钮的样式
        /// </summary>
        public Geometry BtnMaximizePathData
        {
            get
            {
                return _BtnMaximizePathData;
            }
            set
            {
                _BtnMaximizePathData = value;
                OnPropertyChanged("BtnMaximizePathData");
            }
        }

        private Visibility _TitleVisibility = Visibility.Visible;
        /// <summary>
        /// 是否显示标题
        /// </summary>
        public Visibility TitleVisibility
        {
            get
            {
                return _TitleVisibility;
            }
            set
            {
                _TitleVisibility = value;
                OnPropertyChanged("TitleVisibility");
            }
        }

        private WindowExTheme _Theme = WindowExTheme.Default;
        /// <summary>
        /// 窗体主题
        /// </summary>
        public WindowExTheme Theme
        {
            get
            {
                return _Theme;
            }
            set
            {
                _Theme = value;
                OnPropertyChanged("Theme");
            }
        }

        /// <summary>
        /// 窗体 构造函数
        /// </summary>
        public WindowEx()
        {
            this.Loaded += WindowEx_Loaded;
            this.DataContext = this;

            #region 窗体样式设置
            //this.AllowsTransparency = true; //AllowsTransparency会导致视频播放不显示
            this.WindowStyle = WindowStyle.None;
            #endregion

            #region 窗体按钮事件
            WindowBtnCommand windowBtnCommand = new WindowBtnCommand();
            windowBtnCommand.DoAction = (parameter) =>
            {
                if (parameter == 1) //最小化
                {
                    MinimizedSet();
                    this.WindowState = WindowState.Minimized;
                }
                if (parameter == 2) //窗口还原、最大化
                {
                    if (this.WindowState == WindowState.Normal)
                    {
                        MaximizedSet();
                        this.WindowState = WindowState.Maximized;
                    }
                    else if (this.WindowState == WindowState.Maximized)
                    {
                        RestoredSet();
                        this.WindowState = WindowState.Normal;
                    }
                    else if (this.WindowState == WindowState.Minimized)
                    {
                        RestoredSet();
                        this.WindowState = WindowState.Normal;
                    }
                }
                if (parameter == 3) //关闭窗口
                {
                    this.Close();
                }
                if (parameter == 4) //固定窗口
                {
                    if (FixEvent != null)
                    {
                        WindowExFixEventArgs args = new WindowExFixEventArgs(this.Content);
                        FixEvent(this, args);
                    }
                }
            };
            this.WindowBtnCommand = windowBtnCommand;
            this.StateChanged += (s, e) =>
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    MaximizedSet();
                }
                if (this.WindowState == WindowState.Normal)
                {
                    RestoredSet();
                }
                if (this.WindowState == WindowState.Minimized)
                {
                    MinimizedSet();
                }
            };
            #endregion

        }

        /// <summary>
        /// 窗体Loaded
        /// </summary>
        private void WindowEx_Loaded(object sender, RoutedEventArgs e)
        {
            #region 窗体样式设置
            Uri uri = null;
            switch (Theme)
            {
                case WindowExTheme.Default:
                    uri = new Uri("WindowExResource.xaml", UriKind.Relative);
                    break;
                case WindowExTheme.MessageBox:
                    uri = new Uri("/SunCreate.Common.Controls;Component/WindowEx/MessageBoxExResource.xaml", UriKind.Relative);
                    break;
                case WindowExTheme.TabContainer:
                    uri = new Uri("/SunCreate.Common.Controls;Component/WindowEx/TabContainerResource.xaml", UriKind.Relative);
                    break;
            }
            _resource = new ResourceDictionary();
            _resource.Source = uri;
            this.Style = _resource["stlWindowEx"] as Style;
            if (this.WindowState == WindowState.Maximized)
            {
                this.BtnMaximizePathData = _resource["pathRestore"] as PathGeometry;
            }
            else
            {
                this.BtnMaximizePathData = _resource["pathMaximize"] as PathGeometry;
            }
            #endregion

            #region 最大化设置
            if (this.WindowState == WindowState.Maximized)
            {
                this.BorderMargin = CalculateWinMargin(true);
            }
            #endregion

        }

        #region 最小化设置
        private void MinimizedSet()
        {
            this.BorderMargin = new Thickness(0, 0, 0, 0);
            BtnPanelHorizontalAlignment = HorizontalAlignment.Left;
            BtnMinimizeVisibility = Visibility.Collapsed;
            if (this.Content != null) (this.Content as FrameworkElement).Visibility = Visibility.Collapsed; //最小化时隐藏Content
            if (this.Theme == WindowExTheme.TabContainer) TitleVisibility = Visibility.Visible;
            this.BtnMaximizePathData = _resource["pathRestore"] as PathGeometry;
        }
        #endregion

        #region 还原设置
        private void RestoredSet()
        {
            this.BorderMargin = new Thickness(0, 0, 0, 0);
            BtnPanelHorizontalAlignment = HorizontalAlignment.Right;
            BtnMinimizeVisibility = Visibility.Visible;
            if (this.Content != null) (this.Content as FrameworkElement).Visibility = Visibility.Visible; //最大化或还原时显示Content
            this.BtnMaximizePathData = _resource["pathMaximize"] as PathGeometry;
            if (this.Theme == WindowExTheme.TabContainer) TitleVisibility = Visibility.Collapsed;
        }
        #endregion

        #region 最大化设置
        private void MaximizedSet()
        {
            this.BorderMargin = CalculateWinMargin(false);
            BtnPanelHorizontalAlignment = HorizontalAlignment.Right;
            BtnMinimizeVisibility = Visibility.Visible;
            if (this.Content != null) (this.Content as FrameworkElement).Visibility = Visibility.Visible; //最大化或还原时显示Content
            this.BtnMaximizePathData = _resource["pathRestore"] as PathGeometry;
            if (this.Theme == WindowExTheme.TabContainer) TitleVisibility = Visibility.Collapsed;
        }
        #endregion

        #region 计算窗体Margin大小
        /// <summary>
        /// 计算窗体Margin大小
        /// </summary>
        private Thickness CalculateWinMargin(bool firstLoad = false)
        {
            double taskBarHeight = SystemParameters.PrimaryScreenHeight - SystemParameters.WorkArea.Height;
            double taskBarWidth = SystemParameters.PrimaryScreenWidth - SystemParameters.WorkArea.Width;
            if (this.Theme == WindowExTheme.TabContainer || firstLoad)
            {
                if (taskBarWidth > 0)
                {
                    return new Thickness(7, 7, taskBarWidth + 7, 7);
                }
                if (taskBarHeight > 0)
                {
                    return new Thickness(7, 7, 7, taskBarHeight + 7);
                }
                return new Thickness(7, 7, 7, 7);
            }
            else
            {
                if (taskBarWidth > 0)
                {
                    return new Thickness(0, 0, taskBarWidth, 0);
                }
                if (taskBarHeight > 0)
                {
                    return new Thickness(0, 0, 0, taskBarHeight);
                }
                return new Thickness(0, 0, 0, 0);
            }
        }
        #endregion

        #region 实现INotifyPropertyChanged接口
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}
