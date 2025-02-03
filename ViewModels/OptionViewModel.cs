using InvoiceRegister.Command;
using InvoiceRegister.Services;
using InvoiceRegister.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace InvoiceRegister.ViewModels
{
    public class OptionViewModel : BaseNotifyPropertyChange
    {
        public ICommand CancelOptionCommand { get; }
        public ICommand SaveOptionCommand { get; }

        
        public int DayToDeadLineOption
        {
            get => MainWindowViewModel.Instance.DayToDeadLine;
            set
            {
                if (MainWindowViewModel.Instance.DayToDeadLine != value)
                {
                    MainWindowViewModel.Instance.DayToDeadLine = value;
                    OnPropertyChange(nameof(DayToDeadLineOption));
                }
            }
        }
        public OptionViewModel(OptionView userControl) 
        {
            CancelOptionCommand = new CancelCommand(userControl);
            SaveOptionCommand = new SaveCommand(userControl, new SaveOptionCommand());
        }
    }
}
