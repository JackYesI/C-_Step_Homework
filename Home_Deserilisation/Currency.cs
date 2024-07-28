using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serilization
{
    public class Currency
    {
        public string Ccy { get; set; }    
        public string Base_ccy { get; set; }     
        public decimal Buy { get; set; }
        public decimal Sale { get; set; }


        public Currency(string ccy, string base_ccy, decimal buy, decimal sale)
        {
            Ccy = ccy;
            Base_ccy = base_ccy;
            Buy = buy;
            Sale = sale;
        }

  
        public decimal Buy_(decimal amount)
        {
            
            return amount / Buy;
        }

        public decimal Sale_(decimal amount)
        {

            return amount * Sale;
        }
        public override string ToString()
        {
            return $"{Ccy} - {Base_ccy}";
        }
    }
}
