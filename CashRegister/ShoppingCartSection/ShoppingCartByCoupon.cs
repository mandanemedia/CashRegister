using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister.ProductSellSection;

namespace CashRegister.ShoppingCartSection
{
    public class ShoppingCartByCoupon : ShoppingCartDecorator, IShoppingCartByCoupon
    {
        public decimal discountCouponValue { get; set; }

        public decimal totalPriceDiscountThreshold { get; set; }

        public ShoppingCartByCoupon(ShoppingCart shoppingCart, decimal discountCouponValue, decimal totalPriceDiscountThreshold) : base(shoppingCart)
        {
            this.discountCouponValue = discountCouponValue;
            this.totalPriceDiscountThreshold = totalPriceDiscountThreshold;
        }
        public override void add(ProductSell productSell)
        {
            this._shoppingCart.add(productSell);
        }

        public override void remove(ProductSell productSell)
        {
            this._shoppingCart.remove(productSell);
        }

        public override int getTotalItemNumber()
        {
            return this._shoppingCart.getTotalItemNumber();
        }
        public override decimal getTotalPrice()
        {
            if (!(discountCouponValue > 0))
                throw new ArgumentOutOfRangeException("DiscountCouponValue does not contain a valid value.");
            else if (!(totalPriceDiscountThreshold > discountCouponValue))
                throw new ArgumentOutOfRangeException("TotalPriceDiscountThreshold does not contain a valid value.");
            else
            {
                decimal beforDiscoundTotalPrice = this._shoppingCart.getTotalPrice();
                decimal totalPrice = beforDiscoundTotalPrice;
                if (beforDiscoundTotalPrice >= totalPriceDiscountThreshold)
                    totalPrice -= discountCouponValue;
                return totalPrice;
            }
        }

    }
}
