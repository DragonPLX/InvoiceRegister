using InvoiceRegister.Command.Interfaces;
using InvoiceRegister.ViewModels;
using InvoiceRegister.Views;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InvoiceRegister.Command
{
    public class SaveOptionCommand : ISaveCommand
    {
        OptionView optionView;
        public bool CanSaveExcute(object element, object parameter)
        {
            if (element is OptionView option && parameter != null)
            {
                optionView = option;
                return true;
            }
            return false;
        }

        public void SaveExecute(object element, object parameter)
        {
            
            if (int.TryParse(optionView.DayNumber.Text.Trim(), out int dayNumber))
            {
                
                    MainWindowViewModel.Instance.DayToDeadLine = dayNumber;
                    MainWindowViewModel.Instance.InvoicesView.Refresh();
                
                 if (parameter.ToString() == "SaveAndClose")
                    optionView.Visibility = Visibility.Collapsed;
                
            }
            else
            {
                optionView.DayNumber.Text = MainWindowViewModel.Instance.DayToDeadLine.ToString();
                MessageBox.Show("Nieprawidłowy typ danych", "Wprowadzona wartość nie jest liczbą!", MessageBoxButton.OK, MessageBoxImage.Error);
            }   
        }
    }
}
