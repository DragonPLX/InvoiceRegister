using InvoiceRegister.Entities;
using InvoiceRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.Services.Mappers
{
    public static class InvoiceMapper
    {
        public static Invoice ToModel(InvoiceEntity entity)
        {
            return new Invoice(
                InvoiceTypeMapper.InvoiceTypeToModel(entity.InvoiceType),
                entity.DateOfIssue,
                SubjectMapper.ToModel(entity.Purchase),
                SubjectMapper.ToModel(entity.Issuer),
                DocumentTypeMapper.ToModel(entity.DocumentType),
                entity.DateOfThePerformance,
                PaymentTypeMapper.ToModel(entity.PaymentType),
                entity.Status
                )
            {
                DateOfVat = entity.DateOfVat,
                DateOfThePerformance = entity.DateOfThePerformance,
                DateOfPayment = entity.DateOfPayment,
                InvoiceNumber = entity.InvoiceNumber,
                TotalSumOfNetValue = entity.TotalSumOfNetValue,
                TotalSumOfTaxValue = entity.TotalSumOfTaxValue,
                TotalSumOfGrossValue = entity.TotalSumOfGrossValue
            };

        }


    }
}
