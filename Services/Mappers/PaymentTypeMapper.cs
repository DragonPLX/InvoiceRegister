using InvoiceRegister.Entities;
using InvoiceRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.Services.Mappers
{
    public static class PaymentTypeMapper
    {
        public static PaymentTypeEnum ToModel(PaymentTypeEnumEntity entity)
        {
            if (entity != null)
            {
                if (entity.Name == "Cash")
                    return PaymentTypeEnum.Cash;
                if (entity.Name == "Card")
                    return PaymentTypeEnum.Card;
                if (entity.Name == "Transfer")
                    return PaymentTypeEnum.Transfer;
                if (entity.Name == "Prepayment")
                    return PaymentTypeEnum.Prepayment;
            }

            return default;
        }
    }
}
