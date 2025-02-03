using InvoiceRegister.Command;
using InvoiceRegister.Entities;
using InvoiceRegister.Models;
using InvoiceRegister.Services;
using InvoiceRegister.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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

        public ICommand SaveOwnCommand { get; set; }
        public OwnSubjectViewModel(OwnSubjectWindow window) 
        {
            subject = App.OwnSubject;
            CancelCommand = new CancelCommand(window);
            SaveOwnCommand = new SaveCommand(window, new SaveOwnSubjectCommand());
            
        }

    }
}
