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
        public override void Execute(object? parameter)
        {
            if(element is OptionView option && parameter != null) { 
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
                else if(parameter.ToString() == "SaveAndClose" )
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

        }
    }
}
