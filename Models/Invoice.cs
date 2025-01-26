using InvoiceRegister.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.Models
{
    internal class Invoice : BaseNotifyPropertyChange
    {
        public DateTime DateOfIssue { get; set; }
        public Subject Purcharer { get; set; }
        public Subject Issuer { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime DateOfThePerformance { get; set; }

        public List<ProductOrService> ProductsOrServices { get; } 
        public int TotalSumOfNetValueProductsOrServices { get; set; }

        public int TotalSumOfTaxValue {  get; set; }
        public int TotalSumOfValueProductsOrServices { get; set; }

        public PaymentTypeEnum Payment {  get; set; } 
        public DateTime DateOfPayment {  get; set; }
        public string? Notes {  get; set; }


        public Invoice(DateTime dateOfIssue, Subject purcharer, Subject issuer, DateTime dateOfThePerformance, PaymentTypeEnum payment)
        {
            DateOfIssue = dateOfIssue;
            Purcharer = purcharer;
            Issuer = issuer;
            DateOfThePerformance = dateOfThePerformance;
            Payment = payment;
        }
        public Invoice(DateTime dateOfIssue, Subject purcharer, Subject issuer, DateTime dateOfThePerformance, PaymentTypeEnum payment, DateTime dateOfPayment)
        {
            DateOfIssue = dateOfIssue;
            Purcharer = purcharer;
            Issuer = issuer;
            DateOfThePerformance = dateOfThePerformance;
            Payment = payment;
            DateOfPayment = dateOfPayment;
        }
    }
}
