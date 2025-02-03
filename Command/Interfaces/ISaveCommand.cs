using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.Command.Interfaces
{
    public interface ISaveCommand
    {
        bool CanSaveExcute(object element, object parameter);
        void SaveExecute(object element, object parameter);
    }
}
