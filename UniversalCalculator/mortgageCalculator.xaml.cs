using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
	public sealed partial class mortgageCalculator : Page
	{
		public mortgageCalculator()
		{
			this.InitializeComponent();
		}

		private async void calulateButton_Click(object sender, RoutedEventArgs e)
		{
			double principleLoanAmount;
			double interestRate;
			double monthlyInterestRate;
			double monthlyRepayment;
			int duration;
			int durationInMonths;

			// Principle Loan Amount
			try
			{
				principleLoanAmount = double.Parse(principalBorrowTextBox.Text);
			}
			catch (Exception ex)
			{
				var dialogMessage = new MessageDialog("Error! Please enter an integer number. " + ex.Message);
				await dialogMessage.ShowAsync();
				principalBorrowTextBox.Focus(FocusState.Programmatic);
				principalBorrowTextBox.SelectAll();
				return;
			}
			if (String.IsNullOrEmpty(principalBorrowTextBox.Text)) // Validate that the field is not left blank
			{
				var dialogMessage = new MessageDialog("Field cannot be left blank - Enter loan amount. ");
				await dialogMessage.ShowAsync();
				principalBorrowTextBox.Focus(FocusState.Programmatic);
				principalBorrowTextBox.SelectAll();
				return;
			}

			/// Interest Rate
			try
			{
				interestRate = double.Parse(annulaInterestRateTextBox.Text);
			}
			catch (Exception ex)
			{
				var dialogMessage = new MessageDialog("Error! Please enter an integer number. " + ex.Message);
				await dialogMessage.ShowAsync();
				annulaInterestRateTextBox.Focus(FocusState.Programmatic);
				annulaInterestRateTextBox.SelectAll();
				return;
			}
			if (String.IsNullOrEmpty(annulaInterestRateTextBox.Text)) // Validate that the field is not left blank
			{
				var dialogMessage = new MessageDialog("Field cannot be left blank - Enter interest rate. ");
				await dialogMessage.ShowAsync();
				annulaInterestRateTextBox.Focus(FocusState.Programmatic);
				annulaInterestRateTextBox.SelectAll();
				return;
			}

			/// Loan Duration
			try
			{
				duration = int.Parse(yearsTextBox.Text);
			}
			catch (Exception ex)
			{
				var dialogMessage = new MessageDialog("Error! Please enter an integer number. " + ex.Message);
				await dialogMessage.ShowAsync();
				yearsTextBox.Focus(FocusState.Programmatic);
				yearsTextBox.SelectAll();
				return;
			}
			if (String.IsNullOrEmpty(yearsTextBox.Text)) // Validate that the field is not left blank
			{
				var dialogMessage = new MessageDialog("Field cannot be left blank - Enter loan duration in years. ");
				await dialogMessage.ShowAsync();
				yearsTextBox.Focus(FocusState.Programmatic);
				yearsTextBox.SelectAll();
				return;
			}

			// and Months
			try
			{
				durationInMonths = int.Parse(monthTextBox.Text);
			}
			catch (Exception ex)
			{
				var dialogMessage = new MessageDialog("Error! Please enter an integer number. " + ex.Message);
				await dialogMessage.ShowAsync();
				monthTextBox.Focus(FocusState.Programmatic);
				monthTextBox.SelectAll();
				return;
			}
			if (String.IsNullOrEmpty(monthTextBox.Text)) // Validate that the field is not left blank
			{
				var dialogMessage = new MessageDialog("Field cannot be left blank - Enter months. ");
				await dialogMessage.ShowAsync();
				monthTextBox.Focus(FocusState.Programmatic);
				monthTextBox.SelectAll();
				return;
			}

			durationInMonths = duration * 12;
			monthlyInterestRate = interestRate / 100 / 12;
			//monthlyRepayment = principleLoanAmount * (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, durationInMonths)) / (1 - (Math.Pow(1 + monthlyInterestRate, durationInMonths - 1)));
			monthlyRepayment = principleLoanAmount * monthlyInterestRate / (1 - (Math.Pow(1 + monthlyInterestRate, -durationInMonths)));

			// Output
			monthlyInterestRateTextBox.Text = monthlyInterestRate.ToString();
			monthlyRepaymentTextBox.Text = monthlyRepayment.ToString("C");

		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(mainMenu));
		}
	}
}
