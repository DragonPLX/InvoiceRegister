using InvoiceRegister.Command;
using InvoiceRegister.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InvoiceRegister.Views
{
    /// <summary>
    /// Interaction logic for OwnSubject.xaml
    /// </summary>
    public partial class OwnSubjectWindow : Window
    {
        public OwnSubjectWindow()
        {
            InitializeComponent();
            OwnSubjectViewModel.Instance.CancelCommand = new CancelCommand(this);
            DataContext = OwnSubjectViewModel.Instance;

        }
    }
}
