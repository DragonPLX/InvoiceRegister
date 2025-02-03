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
    public class DocumentTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DocumentTypeEnum document)
            {
                if (document == DocumentTypeEnum.Invoice)
                {
                    return "FV";
                }
                else if (document == DocumentTypeEnum.Correction)
                {
                    return "Kor";
                }
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
