using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.ProductSellSection
{
    public enum ProductSellType { byWeight, byQuantity, byQuantityInGroupSell };
    
    //Creator
    interface IProductSellFactory
    {
        ProductSell GetProductSell(ProductSellType type);
    }

    // Concrete Creators
    public class ProductSellFactory : IProductSellFactory
    {
        public ProductSell GetProductSell(ProductSellType type)
        {
            if (type == ProductSellType.byWeight)
                return new ProductSellByWeight();
            else if (type == ProductSellType.byQuantity)
                return new ProductSellByQuantity();
            else if (type == ProductSellType.byQuantityInGroupSell)
                return new ProductSellByQuantityInGroupSell(new ProductSellByQuantity(), 1);
            else
                throw new ArgumentException("Invalid ProductSellType");
        }
    }
}
