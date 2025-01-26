using InvoiceRegister.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.Models
{
    internal class Subject : BaseNotifyPropertyChange
    {
        public string Nip {  get; }
        public string Name { get; set; }

        public bool IsIssuer { get; set; }
        public string PostalCode {  get; set; }

        public string Street { get; set; }

        public string BuildingNumber { get; set; }

        public string ApartmentNumber { get; set; }

        public string City { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? AccountNumber {  get; set; } 

        

        public Subject(string nip, string name, bool isIssuer, string postalCode, string street, string buildingNumber, string apartmentNumber, string city)
        {
            Nip = nip;
            Name = name;
            IsIssuer = isIssuer;
            PostalCode = postalCode;
            Street = street;
            BuildingNumber = buildingNumber;
            ApartmentNumber = apartmentNumber;
            City = city;
        }

        public Subject(string nip, string name, bool isIssuer, string postalCode, string street, string buildingNumber,
            string apartmentNumber, string city, string? phoneNumber, string? email, string? accountNumber)
        {
            Nip = nip;
            Name = name;
            IsIssuer = isIssuer;
            PostalCode = postalCode;
            Street = street;
            BuildingNumber = buildingNumber;
            ApartmentNumber = apartmentNumber;
            City = city;
            PhoneNumber = phoneNumber;
            Email = email;
            AccountNumber = accountNumber;
            
        }
    }
}
