using InvoiceRegister.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.Models
{
    public class Invoice : BaseNotifyPropertyChange
    {

        private InvoiceTypeEnum invoiceType;

        public InvoiceTypeEnum InvoiceType
        {
            get => invoiceType;
            set
            {
                if (invoiceType != value) 
                {
                    invoiceType = value;
                    OnPropertyChange(nameof(invoiceType));
                }
            }
        }

        private DateTime dateOfIssue;
        public DateTime DateOfIssue
        {
            get => dateOfIssue;
            set
            {
                if (dateOfIssue != value)
                {
                    dateOfIssue = value;
                    OnPropertyChange(nameof(DateOfIssue));
                }
            }
        }

        private DateTime? dateOfVAT;

        public DateTime? DateOfVAT
        {
            get => dateOfVAT;
            set
            {
                if (dateOfVAT != value)
                {
                    dateOfVAT = value;
                    OnPropertyChange(nameof(DateOfVAT));
                }
            }
        }

        private Subject purchaser;
        public Subject Purchaser
        {
            get => purchaser;
            private set
            {
                if (purchaser != value)
                {
                    purchaser = value;
                    OnPropertyChange(nameof(Purchaser));
                }
            }
        }

        private Subject issuer;
        public Subject Issuer
        {
            get => issuer;
            private set
            {
                if (issuer != value)
                {
                    issuer = value;
                    OnPropertyChange(nameof(Issuer));
                }
            }
        }

        private string invoiceNumber;
        public string InvoiceNumber
        {
            get => invoiceNumber;
            set
            {
                if (invoiceNumber != value)
                {
                    invoiceNumber = value;
                    OnPropertyChange(nameof(InvoiceNumber));
                }
            }
        }

        private DocumentTypeEnum documentType;
        public DocumentTypeEnum DocumentType
        {
            get => documentType;
            set
            {
                if(documentType != value)
                {
                    documentType = value;
                    OnPropertyChange(nameof(DocumentType));
                }
            }
        }

        private DateTime dateOfThePerformance;
        public DateTime DateOfThePerformance
        {
            get => dateOfThePerformance;
            set
            {
                if (dateOfThePerformance != value)
                {
                    dateOfThePerformance = value;
                    OnPropertyChange(nameof(DateOfThePerformance));
                }
            }
        }

        private ObservableCollection<ProductOrService> productsOrServices = [];
        public ObservableCollection<ProductOrService> ProductsOrServices
        {
            get => productsOrServices;
        }

        private int totalSumOfNetValueProductsOrServices;
        public int TotalSumOfNetValueProductsOrServices
        {
            get => totalSumOfNetValueProductsOrServices;
            set
            {
                if (totalSumOfNetValueProductsOrServices != value)
                {
                    totalSumOfNetValueProductsOrServices = value;
                    OnPropertyChange(nameof(TotalSumOfNetValueProductsOrServices));
                }
            }
        }

        private int totalSumOfTaxValue;
        public int TotalSumOfTaxValue
        {
            get => totalSumOfTaxValue;
            set
            {
                if (totalSumOfTaxValue != value)
                {
                    totalSumOfTaxValue = value;
                    OnPropertyChange(nameof(TotalSumOfTaxValue));
                }
            }
        }

        private int totalSumOfValueProductsOrServices;
        public int TotalSumOfValueProductsOrServices
        {
            get => totalSumOfValueProductsOrServices;
            set
            {
                if (totalSumOfValueProductsOrServices != value)
                {
                    totalSumOfValueProductsOrServices = value;
                    OnPropertyChange(nameof(TotalSumOfValueProductsOrServices));
                }
            }
        }

        private PaymentTypeEnum payment;
        public PaymentTypeEnum Payment
        {
            get => payment;
            set
            {
                if (payment != value)
                {
                    payment = value;
                    OnPropertyChange(nameof(Payment));
                }
            }
        }

        private bool status;
        public bool Status { 
            get => status;
            set 
            {
                if (status != value)
                {
                    status = value;
                    OnPropertyChange(nameof(Status));
                }
            }
        }

        private DateTime? dateOfPayment;
        public DateTime? DateOfPayment
        {
            get => dateOfPayment;
            set
            {
                if (dateOfPayment != value)
                {
                    dateOfPayment = value;
                    OnPropertyChange(nameof(DateOfPayment));
                }
            }
        }

        private string? notes;
        public string? Notes
        {
            get => notes;
            set
            {
                if (notes != value)
                {
                    notes = value;
                    OnPropertyChange(nameof(Notes));
                }
            }
        }

        

        public Invoice(InvoiceTypeEnum invoiceType, DateTime dateOfIssue, Subject purchaser, Subject issuer, DocumentTypeEnum documentTypeEnum, DateTime dateOfThePerformance, PaymentTypeEnum payment, bool status)
        {
            InvoiceType = invoiceType;
            DateOfIssue = dateOfIssue;
            Purchaser = purchaser;
            Issuer = issuer;
            DocumentType = documentTypeEnum;
            DateOfThePerformance = dateOfThePerformance;
            Payment = payment;
            Status = status;
            ProductsOrServices.CollectionChanged += ProductsOrServices_CollectionChanged;
        }

        public Invoice(InvoiceTypeEnum invoiceType, DateTime dateOfIssue, Subject purchaser, Subject issuer, DocumentTypeEnum documentTypeEnum, DateTime dateOfThePerformance, PaymentTypeEnum payment, bool status, DateTime dateOfPayment)
        {
            InvoiceType = invoiceType;
            DateOfIssue = dateOfIssue;
            Purchaser = purchaser;
            Issuer = issuer;
            DocumentType = documentTypeEnum;
            DateOfThePerformance = dateOfThePerformance;
            Payment = payment;
            Status = status;
            DateOfPayment = dateOfPayment;
            ProductsOrServices.CollectionChanged += ProductsOrServices_CollectionChanged;
        }


        private void ProductsOrServices_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (ProductOrService item in e.NewItems)
                {
                    item.PropertyChanged += ProductsOrServicesPropertyChanged;
                }
            }

            if (e.OldItems != null)
            {
                foreach (ProductOrService item in e.OldItems)
                {
                    item.PropertyChanged -= ProductsOrServicesPropertyChanged;
                }
            }
        }
        private void ProductsOrServicesPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(ProductOrService.NetValueOfProductsOrServices) || e.PropertyName == nameof(ProductOrService.TaxValue) || e.PropertyName == nameof(ProductOrService.GrossSumOfValueProductsOrServices))
            {
                CountTotalValue();
            }
        }

        public void CountTotalValue() 
        {
            TotalSumOfNetValueProductsOrServices = 0;
            TotalSumOfTaxValue = 0;
            TotalSumOfValueProductsOrServices = 0;
            foreach (var item in ProductsOrServices)
            {
                TotalSumOfNetValueProductsOrServices += item.NetValueOfProductsOrServices;
                TotalSumOfTaxValue += item.TaxValue;
                TotalSumOfValueProductsOrServices += item.GrossSumOfValueProductsOrServices;
            }
        }
    }
}
