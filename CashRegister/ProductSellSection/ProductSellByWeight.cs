using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.ProductSellSection
{
    public class ProductSellByWeight : ProductSell, ISellByWeight
    {
        protected decimal _weight { get; set; }
        public decimal weight { get { return _weight; } }
        public ProductSellByWeight() : base()
        {
            _weight = 0;
        }
        public ProductSellByWeight(int productId, string productName, decimal unitPrice, decimal weight) : base(productId, productName, unitPrice)
        {
            this._weight = weight;
        }
        public override decimal getPrice()
        {
            return unitPrice*weight;
        }

        public void addWeight(decimal weight)
        {
            this._weight += weight;
        }

        public void deductWeight(decimal weight)
        {
            this._weight -= weight;
        }

        public void resetWeight()
        {
            this._weight = 0;
        }
    }
}
