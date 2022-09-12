using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
	public sealed partial class currencyConverter : Page
	{
		const double USD_RATE = 1, EURO_RATE = 1, GBP_RATE = 1, RUPEE_RATE = 1,
			USD_TO_EURO = 0.85189982, USD_TO_GBP = 0.72872436, USD_TO_RUPEE = 74.257327,
			EURO_TO_USD = 1.1739732, EURO_TO_GBP = 0.8556672, EURO_TO_RUPEE = 87.00755,
			GBP_TO_USD = 1.371907, GBP_TO_EURO = 1.1686692, GBP_TO_RUPEE = 101.68635,
			RUPEE_TO_USD = 0.011492628, RUPEE_TO_EURO = 0.013492774, RUPEE_TO_GBP = 0.0098339397;

		private async void currencyConversionButton_Click(object sender, RoutedEventArgs e)
		{
			double amount;
			try
			{
				amount = double.Parse(amountInputTextBox.Text);
			}
			catch (Exception ex)
			{
				var dialogMessage = new MessageDialog("Error! Please enter an integer number. " + ex.Message);
				await dialogMessage.ShowAsync();
				amountInputTextBox.Focus(FocusState.Programmatic);
				amountInputTextBox.SelectAll();
				return;
			}
			if (String.IsNullOrEmpty(amountInputTextBox.Text)) // Validate that the field is not left blank
			{
				amountInputTextBox.Text = "0";
			}

			calcCurrency(amount);
		}

		private void calcCurrency(double amount)
		{
			double result = 0;

			// Currency Converter for USD
			if (fromComboBox.SelectedIndex == 0 && toComboBox.SelectedIndex == 0)
			{
				result = amount * USD_RATE;
				fromCurrencyTextBlock.Text = amount.ToString() + " US Dollars = ";
				toCurrencyTextBlock.Text = result.ToString("C") + " US Dollars";
				unitToUnitConversionTextBlock.Text = "1 US Dollar = " + USD_RATE.ToString() + " US Dollars";
				invertedUnitToUnitConversionTextBlock.Text = "1 US Dollar = " + USD_RATE.ToString() + " US Dollars";
			}
			else if (fromComboBox.SelectedIndex == 0 && toComboBox.SelectedIndex == 1)
			{
				result = amount * USD_TO_EURO;
				fromCurrencyTextBlock.Text = amount.ToString() + " US Dollars = ";
				toCurrencyTextBlock.Text = result.ToString("C") + " Euros";
				unitToUnitConversionTextBlock.Text = "1 US Dollar = " + USD_TO_EURO.ToString() + " Euros";
				invertedUnitToUnitConversionTextBlock.Text = "1 Euro = " + EURO_TO_USD.ToString() + " US Dollars";
			}
			else if (fromComboBox.SelectedIndex == 0 && toComboBox.SelectedIndex == 2)
			{
				result = amount * USD_TO_GBP;
				fromCurrencyTextBlock.Text = amount.ToString() + " US Dollars = ";
				toCurrencyTextBlock.Text = result.ToString("C") + " British Pounds";
				unitToUnitConversionTextBlock.Text = "1 US Dollar = " + USD_TO_GBP.ToString() + " British Pounds";
				invertedUnitToUnitConversionTextBlock.Text = "1 British Pound = " + GBP_TO_USD.ToString() + " US Dollars";
			}
			else if (fromComboBox.SelectedIndex == 0 && toComboBox.SelectedIndex == 3)
			{
				result = amount * USD_TO_RUPEE;
				fromCurrencyTextBlock.Text = amount.ToString() + " US Dollars = ";
				toCurrencyTextBlock.Text = result.ToString("C") + " Indian Rupees";
				unitToUnitConversionTextBlock.Text = "1 USD = " + USD_TO_RUPEE.ToString() + " Indian Rupees";
				invertedUnitToUnitConversionTextBlock.Text = "1 Indian Rupee = " + RUPEE_TO_USD.ToString() + " US Dollars";
			}

			// Currency converter for Euro
			else if (fromComboBox.SelectedIndex == 1 && toComboBox.SelectedIndex == 1)
			{
				result = amount * EURO_RATE;
				fromCurrencyTextBlock.Text = amount.ToString() + " Euros = ";
				toCurrencyTextBlock.Text = result.ToString("C") + " Euros";
				unitToUnitConversionTextBlock.Text = "1 Euro = " + EURO_RATE.ToString() + " Euros";
				invertedUnitToUnitConversionTextBlock.Text = "1 Euro = " + EURO_RATE.ToString() + " Euro";
			}
			else if (fromComboBox.SelectedIndex == 1 && toComboBox.SelectedIndex == 0)
			{
				result = amount * EURO_TO_USD;
				fromCurrencyTextBlock.Text = amount.ToString() + " Euros = ";
				toCurrencyTextBlock.Text = result.ToString("C") + " US Dollars";
				unitToUnitConversionTextBlock.Text = "1 Euro = " + EURO_TO_USD.ToString() + " US Dollars";
				invertedUnitToUnitConversionTextBlock.Text = "1 US Dollar = " + USD_TO_EURO.ToString() + " Euros";
			}
			else if (fromComboBox.SelectedIndex == 1 && toComboBox.SelectedIndex == 2)
			{
				result = amount * EURO_TO_GBP;
				fromCurrencyTextBlock.Text = amount.ToString() + " Euros = ";
				toCurrencyTextBlock.Text = result.ToString("C") + " British Pounds";
				unitToUnitConversionTextBlock.Text = "1 Euro = " + EURO_TO_GBP.ToString() + " British Pounds";
				invertedUnitToUnitConversionTextBlock.Text = "1 British Pound = " + GBP_TO_EURO.ToString() + " Euros";
			}
			else if (fromComboBox.SelectedIndex == 1 && toComboBox.SelectedIndex == 3)
			{
				result = amount * EURO_TO_RUPEE;
				fromCurrencyTextBlock.Text = amount.ToString() + " Euros = ";
				toCurrencyTextBlock.Text = result.ToString("C") + " Indian Rupees";
				unitToUnitConversionTextBlock.Text = "1 Euro = " + EURO_TO_RUPEE.ToString() + " Indian Rupees";
				invertedUnitToUnitConversionTextBlock.Text = "1 Indian Rupee = " + RUPEE_TO_EURO.ToString() + " Euros";
			}

			// Currency Converter for British pounds
			else if (fromComboBox.SelectedIndex == 2 && toComboBox.SelectedIndex == 2)
			{
				result = amount * GBP_RATE;
				fromCurrencyTextBlock.Text = amount.ToString() + " British Pounds = ";
				toCurrencyTextBlock.Text = result.ToString("C") + " British Pounds";
				unitToUnitConversionTextBlock.Text = "1 British Pound = " + GBP_RATE.ToString() + " British Pounds";
				invertedUnitToUnitConversionTextBlock.Text = "1 British Pound = " + GBP_RATE.ToString() + " British Pounds";
			}
			else if (fromComboBox.SelectedIndex == 2 && toComboBox.SelectedIndex == 0)
			{
				result = amount * GBP_TO_USD;
				fromCurrencyTextBlock.Text = amount.ToString() + " British Pounds = ";
				toCurrencyTextBlock.Text = result.ToString("C") + " US Dollars";
				unitToUnitConversionTextBlock.Text = "1 British Pound = " + GBP_TO_USD.ToString() + " US Dollars";
				invertedUnitToUnitConversionTextBlock.Text = "1 US Dollar = " + USD_TO_GBP.ToString() + " British Pounds";
			}
			else if (fromComboBox.SelectedIndex == 2 && toComboBox.SelectedIndex == 1)
			{
				result = amount * GBP_TO_EURO;
				fromCurrencyTextBlock.Text = amount.ToString() + " British Pounds = ";
				toCurrencyTextBlock.Text = result.ToString("C") + " Euros";
				unitToUnitConversionTextBlock.Text = "1 British Pound = " + GBP_TO_EURO.ToString() + " Euros";
				invertedUnitToUnitConversionTextBlock.Text = "1 Euro = " + EURO_TO_GBP.ToString() + " British Pounds";
			}
			else if (fromComboBox.SelectedIndex == 2 && toComboBox.SelectedIndex == 3)
			{
				result = amount * GBP_TO_RUPEE;
				fromCurrencyTextBlock.Text = amount.ToString() + " British Pounds = ";
				toCurrencyTextBlock.Text = result.ToString("C") + " Indian Rupees";
				unitToUnitConversionTextBlock.Text = "1 British Pound = " + GBP_TO_RUPEE.ToString() + " Indian Ruppes";
				invertedUnitToUnitConversionTextBlock.Text = "1 Indian Rupee = " + RUPEE_TO_GBP.ToString() + " British Pounds";
			}

			// Currency Converter for Indian Rupees
			else if (fromComboBox.SelectedIndex == 3 && toComboBox.SelectedIndex == 3)
			{
				result = amount * RUPEE_RATE;
				fromCurrencyTextBlock.Text = amount.ToString() + " Indian Rupees = ";
				toCurrencyTextBlock.Text = result.ToString("C") + " Indian Rupees";
				unitToUnitConversionTextBlock.Text = "1 Indian Rupee = " + RUPEE_RATE.ToString() + " Indian Rupees";
				invertedUnitToUnitConversionTextBlock.Text = "1 Indian Rupee = " + RUPEE_RATE.ToString() + " Indian Rupees";
			}
			else if (fromComboBox.SelectedIndex == 3 && toComboBox.SelectedIndex == 0)
			{
				result = amount * RUPEE_TO_USD;
				fromCurrencyTextBlock.Text = amount.ToString() + " Indian Rupees = ";
				toCurrencyTextBlock.Text = result.ToString("C") + " US Dollars";
				unitToUnitConversionTextBlock.Text = "1 Indian Rupee = " + RUPEE_TO_USD.ToString() + " US Dollars";
				invertedUnitToUnitConversionTextBlock.Text = "1 US Dollar = " + USD_TO_RUPEE.ToString() + " Indian Rupees";
			}
			else if (fromComboBox.SelectedIndex == 3 && toComboBox.SelectedIndex == 1)
			{
				result = amount * RUPEE_TO_EURO;
				fromCurrencyTextBlock.Text = amount.ToString() + " Indian Rupees = ";
				toCurrencyTextBlock.Text = result.ToString("C") + " Euros";
				unitToUnitConversionTextBlock.Text = "1 Indian Rupee = " + RUPEE_TO_EURO.ToString() + " Euros";
				invertedUnitToUnitConversionTextBlock.Text = "1 Euro = " + EURO_TO_RUPEE.ToString() + " Indian Rupees";
			}
			else if (fromComboBox.SelectedIndex == 3 && toComboBox.SelectedIndex == 2)
			{
				result = amount * RUPEE_TO_GBP;
				fromCurrencyTextBlock.Text = amount.ToString() + " Indian Rupees = ";
				toCurrencyTextBlock.Text = result.ToString("C") + " British Pounds";
				unitToUnitConversionTextBlock.Text = "1 Indian Rupee = " + RUPEE_TO_GBP.ToString() + " British Pounds";
				invertedUnitToUnitConversionTextBlock.Text = "1 British Pound = " + GBP_TO_RUPEE.ToString() + " Indian Rupees";
			}
		}



		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(mainMenu));
		}
		public currencyConverter()
		{
			this.InitializeComponent();
		}
	}
}
