using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.Entities
{
    public class SubjectEntity
    {
        [Key]
        public string Nip { get; set; }

        public string Name { get; set; }

        public bool IsOwn { get; set; }

        public string PostalCode { get; set; }

        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string? ApartmentNumber { get; set; }
        public string City { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? AccountNumber { get; set; }

    }
}
