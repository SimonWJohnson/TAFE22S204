using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class shopping_cart_calculator : Page
	{
		public shopping_cart_calculator()
		{
			this.InitializeComponent();
		}

		private void caculate_Click(object sender, RoutedEventArgs e)
		{
			double totalTicketsCost;
			double desktopCost;
			double keyboardCost;
			double mouseCost;
			desktopCost = double.Parse(desktopcost.Text) * 1000;
			keyboardCost = double.Parse(keyboard.Text) * 100;
			mouseCost = double.Parse(mousecost.Text) * 80;
			totalTicketsCost = desktopCost + keyboardCost + mouseCost;
			totalticketcost.Text = totalTicketsCost.ToString("C");
		}

		private void exit_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
