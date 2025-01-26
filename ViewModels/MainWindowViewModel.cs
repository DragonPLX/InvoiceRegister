using InvoiceRegister.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.ViewModels
{
    public class MainWindowViewModel : BaseNotifyPropertyChange
    {
        public InvoiceViewModel InvoiceViewModel { get; }

        public MainWindowViewModel() 
        {
            InvoiceViewModel = new InvoiceViewModel();
        }

    }
}
