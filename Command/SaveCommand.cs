using InvoiceRegister.ViewModels;
using InvoiceRegister.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace InvoiceRegister.Command
{
    public class SaveCommand : BaseCommand
    {
        private object element;
        public SaveCommand(object element)
        {
            this.element = element;
        }


        public override bool CanExecute(object? parameter)
        {
            if (element is OptionView && parameter != null)
            {
                return true;
            }
            if (element is InvoiceWindow invoiceView && parameter != null)
            {
                if (invoiceView.SaleButton.IsChecked == true || invoiceView.PurchaseButton.IsChecked == true) 
                    return true;
                
                
                if(invoiceView.DateOfIssue.SelectedDate != null || invoiceView.DateOfIssue.SelectedDate != DateTime.MinValue)
                    return true;

                


                if(string.IsNullOrWhiteSpace(invoiceView.InvoiceNumber.Text))
                {
                    MessageBox.Show("Numer faktury jest nieprawidłowy!", "Błądne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                    return true;
                    
            }

            return false;
        }
        public override void Execute(object? parameter)
        {
            if(element is OptionView option && parameter != null) { 
                SaveOptionView(option, parameter);
            }
            if (element is InvoiceWindow invoiceView && parameter != null) 
            {
                SaveInvoiceView(invoiceView, parameter);
            }
            
        }

        private void SaveOptionView(OptionView option , object parameter)
        {
            int dayNumber;

            if (parameter.ToString() == "Save")
            {
                if (int.TryParse(option.DayNumber.Text.Trim(), out dayNumber))
                {
                    MainWindowViewModel.Instance.DayToDeadLine = dayNumber;
                    MainWindowViewModel.Instance.InvoicesView.Refresh();
                }
                else
                    MessageBox.Show("Nieprawidłowy typ danych", "Wprowadzona wartość nie jest liczbą!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (parameter.ToString() == "SaveAndClose")
            {
                if (int.TryParse(option.DayNumber.Text.Trim(), out dayNumber))
                {
                    MainWindowViewModel.Instance.DayToDeadLine = dayNumber;
                    MainWindowViewModel.Instance.InvoicesView.Refresh();
                    option.Visibility = Visibility.Collapsed;
                }
                else
                    MessageBox.Show("Nieprawidłowy typ danych", "Wprowadzona wartość nie jest liczbą!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void SaveInvoiceView(InvoiceWindow invoiceView, object parameter) 
        {
            
        }
    }
}
