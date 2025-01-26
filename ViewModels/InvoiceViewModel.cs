using InvoiceRegister.Models;
using InvoiceRegister.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.ViewModels
{
    public class InvoiceViewModel : BaseNotifyPropertyChange
    {
        public ObservableCollection<Invoice> Invoices { get; } = [];

        private Subject issue = new Subject("987654321", "FranekMaPsa", true, "05-220", "Łąkowa", "2", "Warszawa");
        public InvoiceViewModel() 
        {
            Invoices.Add(new Invoice(InvoiceTypeEnum.Sale, DateTime.Today, new Subject("123456789", "AlaMaKota", false, "05-200", "Polna", "1", "Warszawa"),
                issue, DateTime.Today, PaymentTypeEnum.Gotowka,true));
            Invoices.Add(new Invoice(InvoiceTypeEnum.Purchase, new DateTime(2025,1,16), issue,
                new Subject("123456789", "AlaMaKota", false, "05-200", "Polna", "1", "Warszawa"), DateTime.Today, PaymentTypeEnum.Przelew, false, new DateTime(2025,2,1)));
            Invoices.Add(new Invoice(InvoiceTypeEnum.Sale, new DateTime(2025,1,20), new Subject("666666666", "Bob Sp z.o.o.", false, "05-400", "Krakowska", "1", "Katowice"),
                issue, DateTime.Today, PaymentTypeEnum.Przelew, false, new DateTime(2025, 3, 1)));
            Invoices.Add(new Invoice(InvoiceTypeEnum.Sale, new DateTime(2025, 1, 24), new Subject("6969696969", "Bob&bob Sp z.o.o.", false, "05-410", "Kurkowa", "8", "Zielonka"),
                issue, DateTime.Today, PaymentTypeEnum.Przelew, false, new DateTime(2025, 2, 11)));



        }

    }
}
