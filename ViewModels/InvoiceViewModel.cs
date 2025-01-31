using InvoiceRegister.Command;
using InvoiceRegister.Models;
using InvoiceRegister.Services;
using InvoiceRegister.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace InvoiceRegister.ViewModels
{
    public class InvoiceViewModel : BaseNotifyPropertyChange
    {
        private InvoiceView invoiceView;

        public ICommand SaveInvoiceCommand { get; set; }

        public ICommand CancelInvoiceCommand { get; }
        public InvoiceViewModel(InvoiceView invoiceView) 
        {
            this.invoiceView = invoiceView;
            CancelInvoiceCommand = new CancelCommand(invoiceView);

        }
    }
}
