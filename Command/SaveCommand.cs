using InvoiceRegister.Command.Interfaces;
using InvoiceRegister.ViewModels;
using InvoiceRegister.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace InvoiceRegister.Command
{
    public class SaveCommand : BaseCommand
    {
        private object element;

        private ISaveCommand saveCommand;
        public SaveCommand(object element, ISaveCommand saveCommand)
        {
            this.element = element;
            this.saveCommand = saveCommand;
        }
        public override bool CanExecute(object? parameter)
        {
            return saveCommand.CanSaveExcute(element,parameter);            
        }
        public override void Execute(object? parameter)
        {
            saveCommand.SaveExecute(element,parameter);    
        }

       

      
    }
}
