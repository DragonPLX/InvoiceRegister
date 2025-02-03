using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.Entities
{
    public class InvoiceEntity
    {
        public int Id { get; set; }

        [ForeignKey(nameof(InvoiceType))]
        public int InvoiceTypeId {  get; set; }
        public InvoiceTypeEnumEntity InvoiceType { get; set; }

        public DateTime DateOfIssue { get; set; }

        public DateTime DateOfVat { get; set; }

        public ProductOrServiceEntity ProductOrService { get; set; }

        [ForeignKey(nameof(Purchase))]
        public string PurchaseNip {  get; set; }
        public SubjectEntity Purchase {  get; set; }

        [ForeignKey(nameof(Issuer))]
        public string IssuerNip { get; set; }
        public SubjectEntity Issuer { get; set; }

        public string InvoiceNumber { get; set; }

        [ForeignKey(nameof(DocumentType))]
        public int DocumentTypeId { get; set; }
        public DocumentTypeEnumEntity DocumentType { get; set; }

        public DateTime DateOfThePerformance { get; set; }
        
        public float TotalSumOfNetValue { get; set; }
        public float TotalSumOfTaxValue { get; set; }
        public float TotalSumOfGrossValue { get; set;}
        [ForeignKey(nameof(PaymentType))]
        public int PaymentTypeId { get; set; }

        public PaymentTypeEnumEntity PaymentType { get; set; }


        public bool Status { get; set; }

        public DateTime DateOfPayment { get; set; }
        public string Notes { get; set; }
    }
}
