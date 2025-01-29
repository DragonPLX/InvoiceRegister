using InvoiceRegister.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace InvoiceRegister.Services
{
    public class InvoiceClientConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Invoice invoice && parameter is string parm)
            {
                if (invoice.InvoiceType == InvoiceTypeEnum.Sale)
                {
                    return parm switch
                    {
                        "Name" => invoice.Purchaser.Name,
                        "NIP" => invoice.Purchaser.NIP,
                        _ => throw new Exception()
                    };

                } else if (invoice.InvoiceType == InvoiceTypeEnum.Purchase)
                {
                    return parm switch
                    {
                        "Name" => invoice.Issuer.Name,
                        "NIP" => invoice.Issuer.NIP,
                        _ => throw new Exception()
                    };
                } 
            }

            throw new Exception();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
