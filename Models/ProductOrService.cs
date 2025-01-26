using InvoiceRegister.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.Models
{
    internal class ProductOrService : BaseNotifyPropertyChange
    {
        public string NameOfTheProductOrService { get; set { NameOfTheProductOrService = value; OnPropertyChange(nameof(NameOfTheProductOrService)); } }
        public string Unit { get; set { Unit = value; OnPropertyChange(nameof(Unit)); } }
        public int CountOfProductsOrServices { get; set { CountOfProductsOrServices = value; OnPropertyChange(nameof(CountOfProductsOrServices)); } }

        public int UnitPriceOfProductOrService { get; set { UnitPriceOfProductOrService = value; OnPropertyChange(nameof(UnitPriceOfProductOrService)); } }

        public int DiscountOfPrice { get; set { DiscountOfPrice = value; } }

        public bool IsPercentDiscount { get; set { IsPercentDiscount = value; OnPropertyChange(nameof(IsPercentDiscount)); } }

        public int NetValueOfProductsOrServices { get; private set; }

        public int TaxRate { get; set { TaxRate = value; CountTaxValue(); } }


        public int TaxValue { get; private set; }

        public int GrossSumOfValueProductsOrServices { get; private set; }

        public ProductOrService(string nameOfTheProductOrService, string unit, int countOfProductsOrServices, int unitPriceOfProductOrService, int discountsOfPrice, bool isPercentDiscount, int netValueOfProductsOrServices, int taxRate)
        {
            NameOfTheProductOrService = nameOfTheProductOrService;
            Unit = unit;
            CountOfProductsOrServices = countOfProductsOrServices;
            UnitPriceOfProductOrService = unitPriceOfProductOrService;
            DiscountOfPrice = discountsOfPrice;
            IsPercentDiscount = isPercentDiscount;
            TaxRate = taxRate;
            CountNetSumOfValueProductsOrServices();
            CountTaxValue();
            CountGrossSumOfValueProductsOrServices();
        
        }

        public void CountNetSumOfValueProductsOrServices()
        {
            if (IsPercentDiscount) {
                NetValueOfProductsOrServices = CountOfProductsOrServices * UnitPriceOfProductOrService * ((100 - DiscountOfPrice) / 100);
                OnPropertyChange(nameof(NetValueOfProductsOrServices));
            }
            else 
            {
                NetValueOfProductsOrServices = CountOfProductsOrServices * (UnitPriceOfProductOrService - DiscountOfPrice);
                OnPropertyChange(nameof(NetValueOfProductsOrServices));
            }
        }

        public void CountTaxValue()
        {
            TaxValue = NetValueOfProductsOrServices * TaxRate;
            OnPropertyChange(nameof(TaxValue));
        }

        public void CountGrossSumOfValueProductsOrServices()
        {
            GrossSumOfValueProductsOrServices = NetValueOfProductsOrServices + TaxValue;
            OnPropertyChange(nameof(GrossSumOfValueProductsOrServices));
        }
    }
}
