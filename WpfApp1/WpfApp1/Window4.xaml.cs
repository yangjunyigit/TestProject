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
using Telerik.Windows.Controls;
using System.Windows.Media.Animation;

namespace Telerik.Windows.Examples.Window.Customization
{
	/// <summary>
	/// Interaction logic for CustomizationWindow.xaml
	/// </summary>
	public partial class CustomizationWindow : RadWindow
	{
		public CustomizationWindow()
		{
			InitializeComponent(); 
			this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			this.Owner = Application.Current.MainWindow;
			this.ResizeMode = ResizeMode.CanMinimize;
			this.Style = this.Resources["RadWindowStyle"] as Style;
			this.Closed += new EventHandler<WindowClosedEventArgs>(window_Closed);
		}

		private void ReminderButton_Click(object sender, RoutedEventArgs e)
		{
			Storyboard reminderAnim = this.Resources["ReminderAnimation"] as Storyboard;
			reminderAnim.Begin();
		}
		private void window_Closed(object sender, EventArgs e)
		{
			//this.reopen.Visibility = Visibility.Visible;
			//dispatcherTimer.Start();
		}
	}
}