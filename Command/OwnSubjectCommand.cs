using InvoiceRegister.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.Command
{
    public class OwnSubjectCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            OwnSubjectWindow window = new();
            window.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            window.ShowDialog();
        }
    }
}
