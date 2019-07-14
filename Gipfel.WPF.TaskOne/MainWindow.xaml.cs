using System.Collections.Generic;
using System.Windows;
using Gipfel.WPF.TaskOne.Models;

namespace Gipfel.WPF.TaskOne
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			OrderEditor.ItemsSource = DatesHelper.GetOrdersView();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var saveOrders = DatesHelper.SaveOrderView((List<OrderViewModel>) OrderEditor.ItemsSource);
			if (saveOrders)
			{
				OrderEditor.ItemsSource = DatesHelper.GetOrdersView();
			}
			else
			{
				MessageBox.Show("Update Error");
				OrderEditor.ItemsSource = DatesHelper.GetOrdersView();
			}
			
		}
	}
}
