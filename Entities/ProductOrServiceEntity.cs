using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.Entities
{
    public class ProductOrServiceEntity
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Entities.InvoiceEntity))]
        public int InvoiceId { get; set; }
        public InvoiceEntity Invoice { get; set; }
        public string Name { get; set; }
        public string Unit {  get; set; }
        public int Count { get; set; }
        public float UnitPrice { get; set; }
        public float Discount { get; set; }
        public bool IsPercentDiscount { get; set; }
        public float NetValue { get; set; }
        public float TaxRate { get; set; }
        public float TaxValue { get; set; }
        public float GrossValue { get; set; }


    }
}
