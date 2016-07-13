using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashRegister;
using CashRegister.ProductSellSection;

namespace CashRegisterTest.ProductSellTests
{
    [TestClass]
    public class ProductSellByWeightTest
    {
        [TestMethod]
        public void ProductSellByWeight_EmptyTest()
        {
            // arrange
            ProductSellByWeight p = new ProductSellByWeight ();

            //act
            decimal price = p.getPrice();

            // assert
            Assert.AreEqual(0, price);
        }

        [TestMethod]
        public void ProductSellByWeight_PriceTest()
        {
            // arrange
            ProductSellByWeight p = new ProductSellByWeight
            {
                productId = 124,
                productName = "Apple",
                unitPrice = 2.49m
            };
            p.addWeight(2.4m);
            //act
            decimal price = p.getPrice();

            // assert
            const decimal expectedPrice = 2.49m* 2.4m;
            Assert.AreEqual(expectedPrice, price);
        }

        [TestMethod]
        public void ProductSellByWeight_SettersAndGetterTest()
        {
            // arrange
            ProductSellByWeight productSellByWeight = new ProductSellByWeight
            {
                productId = 124,
                productName = "Apple",
                unitPrice = 2.49m
            };
            productSellByWeight.addWeight(2.4m);

            //act
            int actualProductId = productSellByWeight.productId;
            string actualProductName = productSellByWeight.productName;
            decimal actualUnitPrice = productSellByWeight.unitPrice;
            decimal actualweight = productSellByWeight.weight;

            // assert
            const int expectedProductId = 124;
            const string expectedProductName = "Apple";
            const decimal expectedUnitPrice = 2.49m;
            const decimal expectedweight = 2.4m;

            Assert.AreEqual(expectedProductId, actualProductId);
            Assert.AreEqual(expectedProductName, actualProductName);
            Assert.AreEqual(expectedUnitPrice, actualUnitPrice);
            Assert.AreEqual(expectedweight, actualweight);
        }
    }
}
