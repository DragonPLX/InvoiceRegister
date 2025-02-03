using InvoiceRegister.Command.Interfaces;
using InvoiceRegister.Entities;
using InvoiceRegister.Services.Mappers;
using InvoiceRegister.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace InvoiceRegister.Command
{
    public class SaveInvoiceCommand : ISaveCommand
    {
        InvoiceWindow invoiceWindow;
        string parm;
        bool canExecute = false;
        float totalSumOfNetValue;
        float totalSumOfTaxValue;
        float totalSumOfGrossValue;
        public bool CanSaveExcute(object element, object parameter)
        {
            if (element is InvoiceWindow invoiceView && parameter is string)
            {
                invoiceWindow = invoiceView;
                parm = (string)parameter;

                if (!string.IsNullOrWhiteSpace(invoiceView.InvoiceNumber.Text))
                {
                    canExecute = true;
                }
                else
                {
                    MessageBox.Show("Numer faktury jest nieprawidłowy!", "Błądne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                    canExecute = false;
                }

                if (invoiceView.SaleButton.IsChecked == true || invoiceView.PurchaseButton.IsChecked == true)
                    canExecute = true;
                else
                {
                    MessageBox.Show("Brak wskazania typu faktury! Proszę zaznaczenie opcji Sprzedaż lub Zakup", "Błądne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                    canExecute = false;
                }


                if (invoiceView.DateOfIssue.SelectedDate != null || invoiceView.DateOfIssue.SelectedDate != DateTime.MinValue)
                    canExecute = true;
                else
                {
                    MessageBox.Show("Brak wskazania daty wystawienia! Proszę uzupełnić datę wystawienia", "Błądne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                    canExecute = false;
                }

                if (!string.IsNullOrWhiteSpace(invoiceView.DocumentType.SelectedValue.ToString()))
                    canExecute = true;
                else
                {
                    MessageBox.Show("Brak wskazania rodzaju dokumentu! Proszę uzupełnić rodzaj", "Błądne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                    canExecute = false;
                }

                if (!string.IsNullOrWhiteSpace(invoiceView.PaymentComboBox.SelectedValue.ToString()))
                    canExecute = true;
                else
                {
                    MessageBox.Show("Brak wskazania formy płatności! Proszę uzupełnić forme", "Błądne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                    canExecute = false;
                }

                if (!string.IsNullOrWhiteSpace(invoiceView.StatusComboBox.SelectedValue.ToString())) 
                    canExecute = true;
                else
                {
                    MessageBox.Show("Brak wskazania statusu płatności! Proszę uzupełnić status", "Błądne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                    canExecute = false;
                }

                if (!string.IsNullOrWhiteSpace(invoiceView.StatusComboBox.SelectedValue.ToString()))
                    canExecute = true;
                else
                {
                    MessageBox.Show("Brak wskazania statusu płatności! Proszę uzupełnić status", "Błądne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                    canExecute = false;
                }

                if (!string.IsNullOrWhiteSpace(invoiceView.SubjectView.Nip.SelectedValue.ToString()) && invoiceView.SubjectView.Nip.Text.Length == 10)
                    canExecute = true;
                else
                {
                    MessageBox.Show("Brak wskazania Nip lub jest on nieprawidłowy! Proszę uzupełnić/poprawić Nip", "Błądne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                    canExecute = false;
                }

                if (!string.IsNullOrWhiteSpace(invoiceView.SubjectView.Name.Text))
                    canExecute = true;
                else
                {
                    MessageBox.Show("Brak wskazania nazwy! Proszę uzupełnić nazwę", "Błądne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                    canExecute = false;
                }

                if(!string.IsNullOrWhiteSpace(invoiceView.SubjectView.Street.Text))
                    canExecute = true;
                else 
                {
                    MessageBox.Show("Brak wskazania nazwy! Proszę uzupełnić nazwę", "Błądne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                    canExecute = false;
                }


                if (!string.IsNullOrWhiteSpace(invoiceView.SubjectView.BuildingNumber.Text))
                    canExecute = true;
                else
                {
                    MessageBox.Show("Brak wskazania nr budynku! Proszę uzupełnić nr budynku", "Błądne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                    canExecute = false;
                }


                if (!string.IsNullOrWhiteSpace(invoiceView.SubjectView.PostalCode.Text))
                    canExecute = true;
                else
                {
                    MessageBox.Show("Brak wskazania kodu pocztowego! Proszę uzupełnić kod pocztowy", "Błądne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                    canExecute = false;
                }

                if (!string.IsNullOrWhiteSpace(invoiceView.SubjectView.City.Text))
                    canExecute = true;
                else
                {
                    MessageBox.Show("Brak wskazania miejscowości! Proszę uzupełnić miejscowość", "Błądne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                    canExecute = false;
                }

                if (!float.TryParse(invoiceWindow.TotalSumOfNetValue.Text, out totalSumOfNetValue))
                    MessageBox.Show("Nieprawidłowa wartość w sumie wartości netto! Sprawdz wartość", "Błędna wartość", MessageBoxButton.OK, MessageBoxImage.Error);


                if (!float.TryParse(invoiceWindow.TotalSumOfTaxValue.Text, out totalSumOfTaxValue))
                    MessageBox.Show("Nieprawidłowa wartość w sumie wartości Vat! Sprawdz wartość", "Błędna wartość", MessageBoxButton.OK, MessageBoxImage.Error);

                if (!float.TryParse(invoiceWindow.TotalSumOfGrossValue.Text, out totalSumOfGrossValue))
                    MessageBox.Show("Nieprawidłowa wartość w sumie wartości brutto! Sprawdz wartość", "Błędna wartość", MessageBoxButton.OK, MessageBoxImage.Error);
            }  

            return canExecute;
        }

        public void SaveExecute(object element, object parameter)
        {
            _ = SaveExecuteAsync();

            if(parm == "SaveAndClose")
                invoiceWindow.Close();
            
        }

        private async Task SaveExecuteAsync()
        {
            try
            {
                using (var scope = App.ServiceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<InvoiceDbContext>();

                    var exist = await context.Invoices
                        .AnyAsync(
                        i => i.InvoiceNumber == invoiceWindow.InvoiceNumber.Text.Trim()
                        && i.InvoiceType.Name == InvoiceTypeMapper.SaleOrPurchaseToEntity(invoiceWindow)
                        );

                    if (!exist)
                    {
                        await AddNewInvoiceAsync(context);
                    }
                    else
                    {
                        await ChangeDataInInvoiceAsync(context);
                    }


                }


            }
            catch (Exception)
            {
                MessageBox.Show("Błąd połaczenia z bazą danych! Sprawdź połączenie", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task AddNewInvoiceAsync(InvoiceDbContext context)
        {
            var newInvoice = new InvoiceEntity()
            {
                InvoiceNumber = invoiceWindow.InvoiceNumber.Text.Trim(),
                DateOfIssue = invoiceWindow.DateOfIssue.SelectedDate.GetValueOrDefault(),
                DateOfVat = invoiceWindow.DateOfVat.SelectedDate.GetValueOrDefault(),
                DateOfThePerformance = invoiceWindow.DateOfThePerformance.SelectedDate.GetValueOrDefault(),
                DateOfPayment = invoiceWindow.DateOfPayment.SelectedDate.GetValueOrDefault(),
                TotalSumOfNetValue = totalSumOfNetValue,
                TotalSumOfTaxValue = totalSumOfTaxValue,
                TotalSumOfGrossValue = totalSumOfGrossValue,
                Notes = invoiceWindow.Notes.Text.Trim()
            };

            newInvoice.InvoiceType.Name = InvoiceTypeMapper.SaleOrPurchaseToEntity(invoiceWindow);


        }
        
        

        private async Task ChangeDataInInvoiceAsync(InvoiceDbContext context)
        {

        }
    }
}
