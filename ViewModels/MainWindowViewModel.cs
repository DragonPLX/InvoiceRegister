using InvoiceRegister.Command;
using InvoiceRegister.Entities;
using InvoiceRegister.Models;
using InvoiceRegister.Services;
using InvoiceRegister.Services.Mappers;
using InvoiceRegister.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace InvoiceRegister.ViewModels
{
    public class MainWindowViewModel : BaseNotifyPropertyChange
    {



        private ObservableCollection<Invoice> invoices { get; } = [];

        public ObservableCollection<Subject> Subjects { get; } = [];
        public ICollectionView InvoicesView { get; private set; }

        public InvoiceTypeEnum InvoiceTypeView { get; set; }


        private int dayToDeadLine = 7;
        public int DayToDeadLine
        {
            get => dayToDeadLine;
            set
            {
                if (dayToDeadLine != value)
                {
                    dayToDeadLine = value;
                    OnPropertyChange(nameof(DayToDeadLine));
                }
            }
        }

        private Subject issue = new Subject("987654321", "FranekMaPsa", true, "05-220", "Łąkowa", "2", "Warszawa");

        
        public static MainWindowViewModel Instance { get; } = new();

        private MainWindow mainWindow;
        public MainWindow MainWindow 
        { 
            get => mainWindow;
            set
            {
                if(mainWindow == null)
                {
                    mainWindow = value;
                    SetCommands();
                }
            }
        }

        public ICommand SaleCommand { get; private set; } 
        public ICommand PurchaseCommand { get; private set; }
        public ICommand AddNewInvoiceCommand { get; }
        public ICommand OptionCommand { get; private set; }

        public ICommand OwnSubjectCommand { get; private set; }
        private MainWindowViewModel() 
        {
            
            AddNewInvoiceCommand = new AddNewInvoiceCommand();

            invoices.Add(new Invoice(InvoiceTypeEnum.Sale, DateTime.Today, new Subject("2222222222", "AlaMaKota", false, "05-200", "Polna", "1", "Warszawa"),
                issue, DocumentTypeEnum.Invoice, DateTime.Today, PaymentTypeEnum.Cash, true));
            invoices.Add(new Invoice(InvoiceTypeEnum.Purchase, new DateTime(2025, 1, 16), issue,
                new Subject("3333333333", "Jan Kowalski", false, "05-200", "Polna", "1", "Warszawa"), DocumentTypeEnum.Invoice, DateTime.Today, PaymentTypeEnum.Transfer, false, new DateTime(2025, 2, 1)));
            invoices.Add(new Invoice(InvoiceTypeEnum.Sale, new DateTime(2025, 1, 20), new Subject("5555555555", "Bob Sp z.o.o.", false, "05-400", "Krakowska", "1", "Katowice"),
                issue, DocumentTypeEnum.Invoice, DateTime.Today, PaymentTypeEnum.Transfer, false, new DateTime(2025, 3, 1)));
            invoices.Add(new Invoice(InvoiceTypeEnum.Sale, new DateTime(2025, 1, 24), new Subject("4444444444", "Bob&bob Sp z.o.o.", false, "05-410", "Kurkowa", "8", "Poznań"),
                issue, DocumentTypeEnum.Correction, DateTime.Today, PaymentTypeEnum.Transfer, false, new DateTime(2025, 1, 11)));
            
            InvoicesView = CollectionViewSource.GetDefaultView(invoices);
            InvoiceTypeView = InvoiceTypeEnum.Sale;
            InvoiceTypeFilter();

        }

        private void SetCommands()
        {
            SaleCommand = new SaleCommand(mainWindow.Mainview);
            PurchaseCommand = new PurchaseCommand(mainWindow.Mainview);
            OptionCommand = new OptionCommand(mainWindow);
            OwnSubjectCommand = new OwnSubjectCommand();
        }

        public void InvoiceTypeFilter()
        {
            InvoicesView.Filter = invoice =>
            {
                if (invoice is Invoice i)
                    return i.InvoiceType == InvoiceTypeView;
                return false;

            };
            InvoicesView.Refresh();
        }

        public void SearchFilter(string searchText)
        {
            if (InvoicesView != null)
            {
                InvoicesView.Filter = element =>
                {
                    if (string.IsNullOrWhiteSpace(searchText) || searchText == "Wyszukaj (Nazwa, NIP, Numer faktury, Kwota)")
                    {
                        if (element is Invoice i)
                        {
                            return i.InvoiceType == InvoiceTypeView;
                        }
                    }


                    if (element is Invoice invoice)
                    {

                        if (InvoiceTypeView == InvoiceTypeEnum.Sale)
                        {
                            return (invoice.InvoiceType == InvoiceTypeEnum.Sale &&
                                   (
                                       (invoice.InvoiceNumber != null && invoice.InvoiceNumber.Contains(searchText)) ||
                                       (invoice.Purchaser.Name != null && invoice.Purchaser.Name.Contains(searchText)) ||
                                       (invoice.Purchaser.Nip != null && invoice.Purchaser.Nip.Contains(searchText)) ||
                                       (invoice.TotalSumOfGrossValue.ToString() != null && invoice.TotalSumOfGrossValue.ToString().Contains(searchText))
                                   )
                                   );

                        }
                        else if (InvoiceTypeView == InvoiceTypeEnum.Purchase)
                        {
                            return (invoice.InvoiceType == InvoiceTypeEnum.Purchase &&
                                   (
                                       (invoice.InvoiceNumber != null && invoice.InvoiceNumber.Contains(searchText)) ||
                                       (invoice.Issuer.Name != null && invoice.Issuer.Name.Contains(searchText)) ||
                                       (invoice.Issuer.Nip != null && invoice.Issuer.Nip.Contains(searchText)) ||
                                       (invoice.TotalSumOfGrossValue.ToString() != null && invoice.TotalSumOfGrossValue.ToString().Contains(searchText))
                                   )
                                   );

                        }
                    }


                    return false;

                };

                InvoicesView.Refresh();
            }
        }


        private async Task<List<Invoice>> GetInvoicesFromDatabaseAsync()
        {
            try
            {
                using (var scope = App.ServiceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<InvoiceDbContext>();

                    var invoicesEntities = await context.Invoices.ToListAsync();


                    List<Invoice> invoices = [];

                    if (invoicesEntities != null)
                    {
                        foreach (var invoiceEntity in invoicesEntities)
                        {
                            invoices.Add(InvoiceMapper.ToModel(invoiceEntity));

                        }

                    }

                    return invoices;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd połączenia z bazą danych");
                return new List<Invoice>();
            }

        }
    }
}
