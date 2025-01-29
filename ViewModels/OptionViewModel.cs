using InvoiceRegister.Command;
using InvoiceRegister.Services;
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
            get => InvoiceViewModel.Instance.DayToDeadLine;
            set
            {
                if (InvoiceViewModel.Instance.DayToDeadLine != value)
                {
                    InvoiceViewModel.Instance.DayToDeadLine = value;
                    OnPropertyChange(nameof(DayToDeadLineOption));
                }
            }
        }
        public OptionViewModel(UserControl userControl) 
        {
            CancelOptionCommand = new CancelCommand(userControl);
            SaveOptionCommand = new SaveOptionCommand(userControl);
        }
    }
}
