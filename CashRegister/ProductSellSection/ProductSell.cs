using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.ProductSellSection
{
    public abstract class ProductSell: Product, ISell
    {
        public ProductSell() : base()
        {

        }
        public ProductSell(int productId, string productName, decimal unitPrice) : base(productId, productName, unitPrice)
        {

        }
        public virtual decimal getPrice()
        {
            return 0;
        }
    }
}
