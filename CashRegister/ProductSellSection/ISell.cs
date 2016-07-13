using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.ProductSellSection
{
    //Decorator for Product
    public interface ISell
    {
        decimal getPrice();
    }
    public interface ISellByWeight : ISell
    {
        void resetWeight();
        void addWeight(decimal weight);
        void deductWeight(decimal weight);
        
    }
    public interface ISellByQuantity: ISell
    {
        void resetQuantity();
        void addQuantity(int quantity);
        void deductQuantity(int quantity);
    }
    public interface ISellByQuantityInGroupSale : ISellByQuantity
    {
        int discountThreshold { get; set; }
        decimal getDiscountedAmount();
    }

}
