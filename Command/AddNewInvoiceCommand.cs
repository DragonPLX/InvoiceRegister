﻿using InvoiceRegister.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.Command
{
    public class AddNewInvoiceCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            InvoiceWindow invoiceView = new();
            invoiceView.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            invoiceView.Show();
        }
    }
}
