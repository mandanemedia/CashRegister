using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashRegister;
using CashRegister.ProductSellSection;

namespace CashRegisterTest.ProductSellTests
{

    [TestClass]
    public class ProductSellByQuantityInGroupSellTests
    {
        [TestMethod]
        public void ProductSellByQuantityInGroupSell_EmptyTest()
        {
            // arrange
            ProductSellByQuantityInGroupSell p = new ProductSellByQuantityInGroupSell(new ProductSellByQuantity(), 1);

            //act
            decimal price = p.getPrice();

            // assert
            Assert.AreEqual(0, price);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "DiscountThreshold does not contain a valid value.")]
        public void ProductSellByQuantity_GiveZeroTo_DiscountThreshold()
        {
            // arrange
            ProductSellByQuantity p1 = new ProductSellByQuantity
            {
                productId = 276,
                productName = "Boxes of Cheerios",
                unitPrice = 3m,
            };
            p1.addQuantity(2);
            ProductSellByQuantityInGroupSell p2 = new ProductSellByQuantityInGroupSell(p1, 0);

            //act
            decimal price = p2.getPrice();

            // assert
            //Must throw ArgumentOutOfRangeException : DiscountThreshold does not contain a valid value.
        }

        [TestMethod]
        public void ProductSellByQuantity_DiscountPriceTest_Buy2Get1Free_2items()
        {
            // arrange
            ProductSellByQuantity p1 = new ProductSellByQuantity
            {
                productId = 276,
                productName = "Boxes of Cheerios",
                unitPrice = 3m
            };
            p1.addQuantity(2);
            ProductSellByQuantityInGroupSell p2 = new ProductSellByQuantityInGroupSell(p1, 3); 
            
            //act
            decimal price = p2.getPrice();

            // assert
            const decimal expectedPrice = 3m * 2;
            Assert.AreEqual(expectedPrice, price);
        }

        [TestMethod]
        public void ProductSellByQuantity_DiscountPriceTest_Buy2Get1Free_3items()
        {
            // arrange
            ProductSellByQuantity p1 = new ProductSellByQuantity
            {
                productId = 276,
                productName = "Boxes of Cheerios",
                unitPrice = 3m
            };
            p1.addQuantity(3);
            ProductSellByQuantityInGroupSell p2 = new ProductSellByQuantityInGroupSell(p1, 3);

            //act
            decimal price = p2.getPrice();

            // assert
            const decimal expectedPrice = 3m * 2;
            Assert.AreEqual(expectedPrice, price);
        }


        [TestMethod]
        public void ProductSellByQuantity_DiscountPriceTest_Buy2Get1Free_4items()
        {
            // arrange
            ProductSellByQuantity p1 = new ProductSellByQuantity
            {
                productId = 276,
                productName = "Boxes of Cheerios",
                unitPrice = 3m
            };
            p1.addQuantity(4);
            ProductSellByQuantityInGroupSell p2 = new ProductSellByQuantityInGroupSell(p1, 3);

            //act
            decimal price = p2.getPrice();

            // assert
            const decimal expectedPrice = 3m * 3;
            Assert.AreEqual(expectedPrice, price);
        }
        [TestMethod]
        public void ProductSellByQuantity_DiscountPriceTest_Buy2Get1Free_7items()
        {
            // arrange
            ProductSellByQuantity p1 = new ProductSellByQuantity
            {
                productId = 276,
                productName = "Boxes of Cheerios",
                unitPrice = 3m
            };
            p1.addQuantity(7);
            ProductSellByQuantityInGroupSell p2 = new ProductSellByQuantityInGroupSell(p1, 3);

            //act
            decimal price = p2.getPrice();

            // assert
            const decimal expectedPrice = 3m * 5;
            Assert.AreEqual(expectedPrice, price);
        }

        [TestMethod]
        public void ProductSellByQuantityInGroupSell_SettersAndGetterTest()
        {
            // arrange
            ProductSellByQuantity productSellByQuantity = new ProductSellByQuantity
            {
                productId = 276,
                productName = "Boxes of Cheerios",
                unitPrice = 3m
            };
            productSellByQuantity.addQuantity(7);
            int actualDiscountThreshold = 3;
            ProductSellByQuantityInGroupSell productSellByQuantityInGroupSell = new ProductSellByQuantityInGroupSell(productSellByQuantity, actualDiscountThreshold);
            
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
            const int expectedDiscountThreshold = 3;
            Assert.AreEqual(expectedProductId, actualProductId);
            Assert.AreEqual(expectedProductName, actualProductName);
            Assert.AreEqual(expectedUnitPrice, actualUnitPrice);
            Assert.AreEqual(expectedQuantity, actualQuantity);
            Assert.AreEqual(expectedDiscountThreshold, actualDiscountThreshold);
        }
    }
}
