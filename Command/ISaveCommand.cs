using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.Command
{
    public interface ISaveCommand
    {
        bool CanExcute(object element, object parametr);
        void Execute(object element, object parametr);
    }
}
