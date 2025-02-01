using InvoiceRegister.Command;
using InvoiceRegister.Models;
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
    public class OwnSubjectViewModel : BaseNotifyPropertyChange
    {
        public static OwnSubjectViewModel Instance { get; } = new();

        private Subject subject;
        public Subject Subject
        {
            get => subject;
            set
            {
                subject = value;
                OnPropertyChange(nameof(subject));
            }
        }

        public ICommand CancelCommand { get; set; }
        private OwnSubjectViewModel() 
        {
            subject = new Subject("1234567890", "Kubuś Puchatek Sp z.o.o", true, "05-400", "Krzysiowa", "8a", "Warszawa");
            
        }
    }
}
