using InvoiceRegister.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.Models
{
    public class ProductOrService : BaseNotifyPropertyChange
    {
        public string Name { get; set {  Name = value; OnPropertyChange(nameof(Name)); } }
        public string Unit { get; set { Unit = value; OnPropertyChange(nameof(Unit)); } }
        public int Count { get; set { Count = value; CountValueProductsOrServices(); } }

        public float UnitPrice { get; set { UnitPrice = value; CountValueProductsOrServices(); } }

        public int DiscountOfPrice { get; set { DiscountOfPrice = value; CountValueProductsOrServices(); } }

        public bool IsPercentDiscount { get; set { IsPercentDiscount = value; CountValueProductsOrServices(); } }

        public float NetValue { get; private set; }

        public float TaxRate { get; set { TaxRate = value; CountValueProductsOrServices(); } }


        public float TaxValue { get; private set; }

        public float GrossValue { get; private set; }

        public ProductOrService(string nameOfTheProductOrService, string unit, int countOfProductsOrServices, int unitPriceOfProductOrService, int discountsOfPrice, bool isPercentDiscount, int netValueOfProductsOrServices, int taxRate)
        {
            Name = nameOfTheProductOrService;
            Unit = unit;
            Count = countOfProductsOrServices;
            UnitPrice = unitPriceOfProductOrService;
            DiscountOfPrice = discountsOfPrice;
            IsPercentDiscount = isPercentDiscount;
            TaxRate = taxRate;
            CountValueProductsOrServices();
            
        
        }

        private void CountValueProductsOrServices()
        {
            if (IsPercentDiscount) {
                NetValue = Count * UnitPrice * ((100 - DiscountOfPrice) / 100);
                OnPropertyChange(nameof(NetValue));
            }
            else 
            {
                NetValue = Count * (UnitPrice - DiscountOfPrice);
                OnPropertyChange(nameof(NetValue));
            }

            TaxValue = NetValue * TaxRate;
            OnPropertyChange(nameof(TaxValue));
            GrossValue = NetValue + TaxValue;
            OnPropertyChange(nameof(GrossValue));
        }

    }
}
