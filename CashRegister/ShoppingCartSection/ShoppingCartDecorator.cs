using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.ShoppingCartSection
{
    public class ShoppingCartDecorator : ShoppingCart
    {
        protected ShoppingCart _shoppingCart;
        public ShoppingCartDecorator(ShoppingCart shoppingCart)
        {
            this._shoppingCart = shoppingCart;
        }

        public override decimal getTotalPrice() => this._shoppingCart.getTotalPrice();
        
    }
}
