using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister.ProductSellSection;

namespace CashRegister.ShoppingCartSection
{
    public interface IShoppingCart
    {
        void add(ProductSell productSell);

        void remove(ProductSell productSell);

        int getTotalItemNumber();

        decimal getTotalPrice();
    }

    public interface IShoppingCartByCoupon : IShoppingCart
    {
        decimal totalPriceDiscountThreshold { get; set; }
        decimal discountCouponValue { get; set; }
    }
}
