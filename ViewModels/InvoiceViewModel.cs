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
        private InvoiceWindow invoiceView;

        private Subject subject;
        public Subject Subject
        {
            get => subject;
            set
            {
                if (subject != null)
                {
                    subject = value;
                    OnPropertyChange(nameof(subject));
                }
            }
        }

        public ICommand SaveInvoiceCommand { get; }

        public ICommand CancelInvoiceCommand { get; }
        public InvoiceViewModel(InvoiceWindow invoiceView) 
        {
            this.invoiceView = invoiceView;
            CancelInvoiceCommand = new CancelCommand(invoiceView);
            SaveInvoiceCommand = new SaveCommand(invoiceView, new SaveInvoiceCommand());
        }
    }
}
