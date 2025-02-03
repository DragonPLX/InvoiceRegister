using InvoiceRegister.Command.Interfaces;
using InvoiceRegister.Entities;
using InvoiceRegister.Models;
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

namespace InvoiceRegister.Command
{
    public class SaveOwnSubjectCommand : ISaveCommand
    {
        private OwnSubjectWindow window;
        private string parm;
        public bool CanSaveExcute(object element, object parameter)
        {
            if (element is OwnSubjectWindow window && parameter is string parm)
            {
                this.window = window;
                this.parm = parm; 
                return true;
            }
            return false;
        }

        public void SaveExecute(object element, object parameter)
        {
            _ = SaveExecuteAsync();
        }

        private async Task SaveExecuteAsync()
        {
            try
            {
                using (var scope = App.ServiceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<InvoiceDbContext>();

                    bool exists = await IsExistsOwnSubjectInDatabaseAsync(context);
                    if (exists)
                    {
                        await ChangeDataInOwnSubjectAsync(context);
                    }
                    else
                    {
                        await AddOwnSubjectToDatabaseAsync(context);
                    }

                    await RefreshDataAsync(context);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd sprawdzania w bazie danych! Sprawdź połączenie");
            }


            if (parm == "SaveAndClose")
                window.Close();
        }

        private async Task RefreshDataAsync(InvoiceDbContext context)
        {
            var ownSubject = await context.Subjects.SingleOrDefaultAsync(s=> s.IsOwn == true);
            if (ownSubject != null) 
            {
                if(window.Subject.Nip.Text != ownSubject.Nip)
                    window.Subject.Nip.Text = ownSubject.Nip;
                if(window.Subject.Name.Text != ownSubject.Name)
                    window.Subject.Name.Text = ownSubject.Name;
                if (window.Subject.PostalCode.Text != ownSubject.PostalCode)
                    window.Subject.PostalCode.Text = ownSubject.PostalCode;
                if (window.Subject.Street.Text != ownSubject.Street)
                    window.Subject.Street.Text = ownSubject.Street;
                if(window.Subject.BuildingNumber.Text != ownSubject.BuildingNumber)
                    window.Subject.BuildingNumber.Text = ownSubject.BuildingNumber;
                if(window.Subject.ApartmentNumber.Text != ownSubject.ApartmentNumber)
                    window.Subject.ApartmentNumber.Text = ownSubject.ApartmentNumber;
                if(window.Subject.City.Text != ownSubject.City)
                    window.Subject.City.Text = ownSubject.City;
                if(window.Subject.PhoneNumber.Text !=  ownSubject.PhoneNumber)
                    window.Subject.PhoneNumber.Text = ownSubject.PhoneNumber;
                if (window.Subject.Email.Text != ownSubject.Email)
                    window.Subject.Email.Text = ownSubject.Email;
                if(window.Subject.AccountNumber.Text != ownSubject.AccountNumber)
                    window.Subject.AccountNumber.Text = ownSubject.AccountNumber;


                App.OwnSubject = SubjectMapper.ToModel(ownSubject);
            }

            

        }
        private async Task<bool> IsExistsOwnSubjectInDatabaseAsync(InvoiceDbContext context)
        {
                var ownSubject = await context.Subjects.SingleOrDefaultAsync(e => e.IsOwn == true);
                if(ownSubject != null) { 
                    if(ownSubject.Nip == window.Subject.Nip.Text.Trim())
                    {
                        return true;
                    }
                    else
                    {
                        var result = MessageBox.Show("Nip jest podmiotu uległ zmianie, czy utworzyć nowy podmiot?", "Uwaga!", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                        if(result == MessageBoxResult.Yes)
                            return false;
                        else
                            return true;
                    }
                }
                else
                {
                    return false;
                }
                
            
        }

        private async Task AddOwnSubjectToDatabaseAsync(InvoiceDbContext context)
        {
            var subject = new SubjectEntity()
            {
                Nip = window.Subject.Nip.Text.Trim(),
                Name = window.Subject.Name.Text,
                IsOwn = true,
                PostalCode = window.Subject.PostalCode.Text,
                Street = window.Subject.Street.Text,
                BuildingNumber = window.Subject.BuildingNumber.Text,
                ApartmentNumber = window.Subject.ApartmentNumber.Text,
                City = window.Subject.City.Text,
                PhoneNumber = window.Subject.PhoneNumber.Text,
                Email = window.Subject.Email.Text,
                AccountNumber = window.Subject.AccountNumber.Text
            };

            bool exist = await context.Subjects.AnyAsync(p => p.Nip == subject.Nip);

            if (!exist)
            {
                await context.Subjects.Where(p => p.IsOwn == true)
                .ExecuteUpdateAsync(setter => setter
                .SetProperty(p => p.IsOwn, false));
                await context.SaveChangesAsync();

                await context.Subjects.AddAsync(subject);
                await context.SaveChangesAsync();

                MessageBox.Show("Został dodany nowy podmiot!");
            }
            else
            {
                var result = MessageBox.Show("Podmiot o takim Nip znajduję się w bazie danych! Czy ustawić nowy podmiot?","Duplikat",MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes) 
                {
                    await context.Subjects.Where(s => s.IsOwn == true)
                        .ExecuteUpdateAsync(set => set
                        .SetProperty(p => p.IsOwn, false));
                    await context.SaveChangesAsync();

                    await context.Subjects.Where(s => s.Nip == subject.Nip)
                        .ExecuteUpdateAsync(set => set
                        .SetProperty(p => p.IsOwn, true));
                    await context.SaveChangesAsync();
                    MessageBox.Show("Podmiot został zmieniony","Zmiana podmiotu",MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            
        }

        private async Task ChangeDataInOwnSubjectAsync(InvoiceDbContext context)
        {
            
            var ownSubject = await context.Subjects.SingleOrDefaultAsync(e => e.IsOwn == true && e.Nip == window.Subject.Nip.Text.Trim());
            if (ownSubject != null) 
            {
                if(ownSubject.Name != window.Subject.Name.Text.Trim())
                    ownSubject.Name = window.Subject.Name.Text.Trim();
                if(ownSubject.PostalCode != window.Subject.PostalCode.Text)
                    ownSubject.PostalCode = window.Subject.PostalCode.Text;
                if(ownSubject.Street != window.Subject.Street.Text)
                    ownSubject.Street = window.Subject.Street.Text;
                if(ownSubject.BuildingNumber != window.Subject.BuildingNumber.Text)
                    ownSubject.BuildingNumber = window.Subject.BuildingNumber.Text;
                if(ownSubject.ApartmentNumber != window.Subject.ApartmentNumber.Text)
                    ownSubject.ApartmentNumber = window.Subject.ApartmentNumber.Text;
                if(ownSubject.City != window.Subject.City.Text)
                    ownSubject.City = window.Subject.City.Text;
                if(ownSubject.PhoneNumber != window.Subject.PhoneNumber.Text)
                    ownSubject.PhoneNumber = window.Subject.PhoneNumber.Text;
                if(ownSubject.Email != window.Subject.Email.Text)
                    ownSubject.Email = window.Subject.Email.Text;
                if(ownSubject.AccountNumber != window.Subject.AccountNumber.Text)
                    ownSubject.AccountNumber = window.Subject.AccountNumber.Text;

                if (context.ChangeTracker.HasChanges()) 
                {
                    await context.SaveChangesAsync();
                    MessageBox.Show("Dane zostały zapisane");
                }
                 
            }
        }
    }
}
