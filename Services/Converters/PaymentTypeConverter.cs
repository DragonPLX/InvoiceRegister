using InvoiceRegister.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace InvoiceRegister.Services.Converters
{
    public class PaymentTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is PaymentTypeEnum payment)
            {
                switch (payment)
                {
                    case PaymentTypeEnum.Cash:
                        return "Gotówka";
                    case PaymentTypeEnum.Card:
                        return "Karta";
                    case PaymentTypeEnum.Transfer:
                        return "Przelew";
                    case PaymentTypeEnum.Prepayment:
                        return "Przedpłata";
                    default:
                        return string.Empty;

                };
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
