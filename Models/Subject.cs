using InvoiceRegister.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.Models
{
    public class Subject : BaseNotifyPropertyChange
    {

        private string nip;
        public  string Nip
        {
            get => nip;
            set
            {
                if (nip != value)
                {
                    nip = value;
                    OnPropertyChange(nameof(Nip));
                }
            }
        }

        private string name;
        public  string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChange(nameof(Name));
                }
            }
        }

        private bool isOwn;
        public bool IsOwn
        {
            get => isOwn;
            set
            {
                if (isOwn != value)
                {
                    isOwn = value;
                    OnPropertyChange(nameof(IsOwn));
                }
            }
        }

        private string postalCode;
        public string PostalCode
        {
            get => postalCode;
            set
            {
                if (postalCode != value)
                {
                    postalCode = value;
                    OnPropertyChange(nameof(PostalCode));
                }
            }
        }

        private string street;
        public string Street
        {
            get => street;
            set
            {
                if (street != value)
                {
                    street = value;
                    OnPropertyChange(nameof(Street));
                }
            }
        }

        private string buildingNumber;
        public string BuildingNumber
        {
            get => buildingNumber;
            set
            {
                if (buildingNumber != value)
                {
                    buildingNumber = value;
                    OnPropertyChange(nameof(BuildingNumber));
                }
            }
        }

        private string? apartmentNumber;
        public string? ApartmentNumber
        {
            get => apartmentNumber;
            set
            {
                if (apartmentNumber != value)
                {
                    apartmentNumber = value;
                    OnPropertyChange(nameof(ApartmentNumber));
                }
            }
        }

        private string city;
        public  string City
        {
            get => city;
            set
            {
                if (city != value)
                {
                    city = value;
                    OnPropertyChange(nameof(City));
                }
            }
        }

        private string? phoneNumber;
        public string? PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (phoneNumber != value)
                {
                    phoneNumber = value;
                    OnPropertyChange(nameof(PhoneNumber));
                }
            }
        }

        private string? email;
        public string? Email
        {
            get => email;
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChange(nameof(Email));
                }
            }
        }

        private string? accountNumber;
        public string? AccountNumber
        {
            get => accountNumber;
            set
            {
                if (accountNumber != value)
                {
                    accountNumber = value;
                    OnPropertyChange(nameof(AccountNumber));
                }
            }
        }

        public Subject(string nip, string name, bool isIssuer, string postalCode, string street, string buildingNumber, string city)
        {
            Nip = nip;
            Name = name;
            IsOwn = isIssuer;
            PostalCode = postalCode;
            Street = street;
            BuildingNumber = buildingNumber;
            City = city;
        }
        public Subject(string nip, string name, bool isIssuer, string postalCode, string street, string buildingNumber, string apartmentNumber, string city)
        {
            Nip = nip;
            Name = name;
            IsOwn = isIssuer;
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
            IsOwn = isIssuer;
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
