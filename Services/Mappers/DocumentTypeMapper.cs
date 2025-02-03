using InvoiceRegister.Entities;
using InvoiceRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.Services.Mappers
{
    public static class DocumentTypeMapper
    {
        public static DocumentTypeEnum ToModel(DocumentTypeEnumEntity entity)
        {
            if (entity != null)
            {
                if (entity.Name == "Invoice")
                    return DocumentTypeEnum.Invoice;
                if (entity.Name == "Correction")
                    return DocumentTypeEnum.Correction;
            }

            return default;
        }
    }
}
