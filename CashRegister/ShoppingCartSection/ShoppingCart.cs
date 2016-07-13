using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister.ProductSellSection;

namespace CashRegister.ShoppingCartSection
{
    public class ShoppingCart: IShoppingCart
    {
        protected List<ProductSell> productSellList = new List<ProductSell>();
        public ShoppingCart()
        {

        }

        #region public methods
        public virtual void add(ProductSell productSell)
        {
            if (productSell != null)
            {
                if (verifyProductSell(productSell))
                    if (productSell is ProductSellByQuantity)
                        add(productSell as ProductSellByQuantity);
                    else if (productSell is ProductSellByWeight)
                        add(productSell as ProductSellByWeight);
                    else
                        throw new InvalidOperationException();
                else 
                    throw new ArgumentOutOfRangeException("productSell does not contain valid attributes");
            }
            else
                throw new ArgumentNullException("productSell");
        }

        public virtual void remove(ProductSell giveProductSell)
        {
            if (giveProductSell != null)
            {
                if (verifyProductSell(giveProductSell))
                {
                    ProductSell existingProductSell = productSellList.SingleOrDefault(productSell => productSell.productId == giveProductSell.productId);
                    if (existingProductSell != null)
                        productSellList.Remove(existingProductSell);
                }
                else
                    throw new ArgumentOutOfRangeException("productSell does not contain valid attributes");
            }
            else
                throw new ArgumentNullException("productSell");

        }

        public virtual int getTotalItemNumber()
        {
            return this.productSellList.Count;
        }

        public virtual decimal getTotalPrice()
        {
            decimal totalPrice = 0;
            for(int i=0; i< this.productSellList.Count; i++)
                totalPrice += this.productSellList[i].getPrice();
            return totalPrice;
        }
        #endregion

        #region private methods
        private bool verifyProductSell(ProductSell productSell)
        {
            if (productSell.productId < 1)
                return false;
            else if (!(productSell.unitPrice > 0))
                return false;
            else if (!(productSell.getPrice() > 0))
                return false;
            else
                return true;
        }
        private void add(ProductSellByQuantity productSellByQuantity)
        {
            if (productSellByQuantity != null)
            {
                ProductSell existingProductSell = productSellList.SingleOrDefault( productSell => productSell.productId == productSellByQuantity.productId);
                if(existingProductSell == null)
                    productSellList.Add(productSellByQuantity as ProductSell);
                else
                {
                    if (!existingProductSell.productName.Equals(productSellByQuantity.productName))
                        throw new ArgumentException("There is a conflict on the given productName");
                    else if (existingProductSell.unitPrice != productSellByQuantity.unitPrice)
                        throw new ArgumentException("There is a conflict on the given unitPrice");
                    else
                        ((ProductSellByQuantity)existingProductSell).addQuantity(productSellByQuantity.quantity);
                }
            }
            else
                throw new ArgumentNullException("ProductSellByQuantity");
        }
        
        private void add(ProductSellByWeight productSellByWeight)
        {
            if (productSellByWeight != null)
            {
                ProductSell existingProductSell = productSellList.SingleOrDefault(productSell => productSell.productId == productSellByWeight.productId);
                if (existingProductSell == null)
                    productSellList.Add(productSellByWeight as ProductSell);
                else
                {
                    if (!existingProductSell.productName.Equals(productSellByWeight.productName))
                        throw new ArgumentException("There is a conflict on the given productName");
                    else if (existingProductSell.unitPrice != productSellByWeight.unitPrice)
                        throw new ArgumentException("There is a conflict on the given unitPrice");
                    else
                        ((ProductSellByWeight)existingProductSell).addWeight(productSellByWeight.weight);
                }
            }
            else
                throw new ArgumentNullException("ProductSellByWeight");
        }
        #endregion

    }
}
