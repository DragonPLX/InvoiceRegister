using InvoiceRegister.Entities;
using InvoiceRegister.Models;
using InvoiceRegister.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.Services.Mappers
{
    public static class InvoiceTypeMapper
    {
        public static string SaleOrPurchaseToEntity(InvoiceWindow window)
        {
            if (window != null)
            {
                if (window.SaleButton.IsChecked == true)
                    return "Sale";
                if (window.PurchaseButton.IsChecked == true)
                    return "Purchase";

            }
            return string.Empty;
        }

        public static InvoiceTypeEnum InvoiceTypeToModel(InvoiceTypeEnumEntity entity)
        {
            if (entity != null)
            {
                if (entity.Name == "Sale")
                    return InvoiceTypeEnum.Sale;
                if (entity.Name == "Purchase")
                    return InvoiceTypeEnum.Purchase;
            }

            return default;
        }
    }
}
