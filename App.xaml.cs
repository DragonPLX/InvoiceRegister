using InvoiceRegister.Entities;
using InvoiceRegister.Models;
using InvoiceRegister.Services.Mappers;
using InvoiceRegister.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;

namespace InvoiceRegister
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Subject OwnSubject;
        public static ServiceProvider ServiceProvider { get; private set; }
        public App()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<InvoiceDbContext>(options =>
                options.UseSqlServer("Server=DESKTOP-S4PLRCE\\SRVINVOICE;Database=InvoiceDB;User Id=InvoiceUser;Password=InvoiceUser;TrustServerCertificate=True;")
            );
            ServiceProvider = serviceCollection.BuildServiceProvider();
            _ = LoadOwnSubject();
        }

        private async Task LoadOwnSubject()
        {
            if (OwnSubject == null)
            {
                using (var scope = ServiceProvider.CreateScope()) 
                {
                    var context = scope.ServiceProvider.GetRequiredService<InvoiceDbContext>();

                    var subject = await context.Subjects.SingleOrDefaultAsync(s => s.IsOwn == true);
                    if (subject != null)
                    {
                        OwnSubject = SubjectMapper.ToModel(subject);
                    }
                    else
                        OwnSubject = new Subject("", "", true, "", "", "", "");
                }
            }

        }
    }

}
