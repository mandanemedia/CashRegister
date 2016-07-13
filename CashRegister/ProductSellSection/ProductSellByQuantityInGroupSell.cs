using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.ProductSellSection
{
    public class ProductSellByQuantityInGroupSell: ProductSellByQuantity, ISellByQuantityInGroupSale
    {
        // Buy two get one free sales: discountThreshold = 3
        public int discountThreshold { get; set; }

        public ProductSellByQuantityInGroupSell(ProductSellByQuantity productSellByQuantity, int discountThreshold) : base(productSellByQuantity.productId, productSellByQuantity.productName, productSellByQuantity.unitPrice, productSellByQuantity.quantity)
        {
            this.discountThreshold = discountThreshold;
        }

        public override decimal getPrice()
        {
            return this.unitPrice * this.getPayableQuantity();
        }
        public decimal getDiscountedAmount()
        {
            return this.unitPrice * (this.quantity - this.getPayableQuantity());
        }

        private int getPayableQuantity()
        {
            int freeQuantity = 0;
            if (discountThreshold > 0)
                freeQuantity = this.quantity / discountThreshold;
            else
                throw new ArgumentOutOfRangeException("DiscountThreshold does not contain a valid value.");

            return (this.quantity - freeQuantity);
        }
    }
}
