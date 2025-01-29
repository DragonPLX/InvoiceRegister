using InvoiceRegister.Command;
using InvoiceRegister.Services;
using InvoiceRegister.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InvoiceRegister.ViewModels
{
    public class MainWindowViewModel : BaseNotifyPropertyChange
    {
        public InvoiceViewModel InvoiceViewModel { get; }
        public ICommand SaleCommand { get; } 
        public ICommand PurchaseCommand { get; }
        public ICommand AddNewInvoiceCommand { get; }
        public ICommand OptionCommand { get; }
        public MainWindowViewModel(MainWindow mainWindow) 
        {
            InvoiceViewModel = InvoiceViewModel.Instance;
            SaleCommand = new SaleCommand(mainWindow.Mainview);
            PurchaseCommand = new PurchaseCommand(mainWindow.Mainview);
            OptionCommand = new OptionCommand(mainWindow);
            AddNewInvoiceCommand = new AddNewInvoiceCommand();
        }

    }
}
