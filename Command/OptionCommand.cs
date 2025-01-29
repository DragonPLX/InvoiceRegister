using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.Command
{
    internal class OptionCommand : BaseCommand
    {
        private MainWindow mainWindow;
        public OptionCommand(MainWindow mainWindow) 
        {
            this.mainWindow = mainWindow;
        }
        public override void Execute(object? parameter)
        {
            mainWindow.Options.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
