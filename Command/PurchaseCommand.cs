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
    public class PurchaseCommand : BaseCommand
    {
        MainView userControl;
       public PurchaseCommand(MainView userControl) 
        {
            this.userControl = userControl;
        }
        public override void Execute(object? parameter)
        {
            InvoiceViewModel.Instance.InvoiceTypeView = Models.InvoiceTypeEnum.Purchase;
            userControl.Seacher.Text = "Wyszukaj (Nazwa, NIP, Numer faktury, Kwota)";
            InvoiceViewModel.Instance.InvoiceTypeFilter();
        }
    }
}
