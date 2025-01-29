using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InvoiceRegister.Command
{
    public class CancelCommand : BaseCommand
    {
        private object element;
        public CancelCommand(object element) 
        {
            this.element = element;
        }
        public override void Execute(object? parameter)
        {
            if (element is UserControl control) 
            {
                control.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
    }
}
