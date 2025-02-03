using InvoiceRegister.Entities;
using InvoiceRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.Services.Mappers
{
    public static class SubjectMapper
    {
        public static SubjectEntity ToEntity(Subject subject)
        {
            return new SubjectEntity()
            {
                Nip = subject.Nip,
                Name = subject.Name,
                IsOwn = subject.IsOwn,
                PostalCode = subject.PostalCode,
                Street = subject.Street,
                BuildingNumber = subject.BuildingNumber,
                ApartmentNumber = subject.ApartmentNumber,
                City = subject.City,
                PhoneNumber = subject.PhoneNumber,
                Email = subject.Email,
                AccountNumber = subject.AccountNumber
            };
        }

        public static Subject ToModel(SubjectEntity subjectEntity)
        {
            return new Subject(
                subjectEntity.Nip,
                subjectEntity.Name,
                subjectEntity.IsOwn,
                subjectEntity.PostalCode,
                subjectEntity.Street,
                subjectEntity.BuildingNumber,
                subjectEntity.City
                )
            {
                ApartmentNumber = subjectEntity.ApartmentNumber,
                PhoneNumber = subjectEntity.PhoneNumber,
                Email = subjectEntity.Email,
                AccountNumber = subjectEntity.AccountNumber
            };
        }

    }
}
