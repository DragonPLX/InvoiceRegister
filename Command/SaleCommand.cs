using InvoiceRegister.ViewModels;
using InvoiceRegister.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InvoiceRegister.Command
{
    public class SaleCommand : BaseCommand
    {
        MainView userControl;
        public SaleCommand(MainView userControl)
        {
            this.userControl = userControl;
        }
        public override void Execute(object? parameter)
        {
            MainWindowViewModel.Instance.InvoiceTypeView = Models.InvoiceTypeEnum.Sale;
            userControl.Seacher.Text = "Wyszukaj (Nazwa, NIP, Numer faktury, Kwota)";
            MainWindowViewModel.Instance.InvoiceTypeFilter();
            
        }
    }
}
