using InvoiceRegister.Models;
using InvoiceRegister.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InvoiceRegister.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {

        
        public MainView()
        {
            InitializeComponent();
            
        }

        private void Seacher_GotFocus(object sender, RoutedEventArgs e)
        {
            if(Seacher.Text == "Wyszukaj (Nazwa, NIP, Numer faktury, Kwota)")
            {
                Seacher.Text = string.Empty;

            }

        }

        private void Seacher_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Seacher.Text)) 
            {
                Seacher.Text = "Wyszukaj (Nazwa, NIP, Numer faktury, Kwota)";
            }

        }

        private void Seacher_TextChanged(object sender, TextChangedEventArgs e)
        {
            InvoiceViewModel.Instance.SearchFilter(Seacher.Text);
        }
    }
}
