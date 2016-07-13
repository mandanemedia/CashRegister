using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashRegister;
using CashRegister.ProductSellSection;

namespace CashRegisterTest.ProductSellTests
{
    [TestClass]
    public class ProductSellByQuantityTests
    {
        [TestMethod]
        public void ProductSellByQuantity_EmptyTest()
        {
            // arrange 
            ProductSellByQuantity p = new ProductSellByQuantity();

            // act
            decimal price = p.getPrice();

            // assert
            Assert.AreEqual(0, price);
        }

        [TestMethod]
        public void ProductSellByQuantity_PriceTest()
        {
            // arrange
            ProductSellByQuantity p = new ProductSellByQuantity
            {
                productId = 276,
                productName = "Boxes of Cheerios",
                unitPrice = 6.99m
            };
            p.addQuantity(2);

            //act
            decimal price = p.getPrice();

            // assert
            const decimal expectedPrice = 6.99m * 2;
            Assert.AreEqual(expectedPrice, price);
        }

        [TestMethod]
        public void ProductSellByQuantity_SettersAndGetterTest()
        {
            // arrange
            ProductSellByQuantity productSellByQuantity = new ProductSellByQuantity
            {
                productId = 276,
                productName = "Boxes of Cheerios",
                unitPrice = 3m
            };
            productSellByQuantity.addQuantity(7);

            //act
            int actualProductId = productSellByQuantity.productId;
            string actualProductName = productSellByQuantity.productName;
            decimal actualUnitPrice = productSellByQuantity.unitPrice;
            int actualQuantity = productSellByQuantity.quantity;

            // assert
            const int expectedProductId = 276;
            const string expectedProductName = "Boxes of Cheerios";
            const decimal expectedUnitPrice = 3m;
            const int expectedQuantity = 7;

            Assert.AreEqual(expectedProductId, actualProductId);
            Assert.AreEqual(expectedProductName, actualProductName);
            Assert.AreEqual(expectedUnitPrice, actualUnitPrice);
            Assert.AreEqual(expectedQuantity, actualQuantity);
        }
    }
}
