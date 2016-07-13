using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashRegister.ShoppingCartSection;
using CashRegister.ProductSellSection;

namespace CashRegisterTest.ShoppingCartTests
{
    /* 
        All ProductItems are added of type ProductSellByWeight
    */
    [TestClass]
    public class ShoppingCart_ProductSellByWeightTests
    {
        [TestMethod]
        public void ShoppingCart_AddingSingle()
        {
            // arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            ProductSellFactory productSellFactory = new ProductSellFactory();
            ProductSellByWeight p = (ProductSellByWeight)productSellFactory.GetProductSell(ProductSellType.byWeight);
            p.productId = 124;
            p.productName = "Apple";
            p.unitPrice = 2.49m;
            p.addWeight(2.4m);

            //act
            shoppingCart.add((ProductSell)p);
            decimal totalPrice = shoppingCart.getTotalPrice();

            // assert
            const decimal expectedTotalPrice = 2.49m * 2.4m;
            Assert.AreEqual(expectedTotalPrice, totalPrice);
        }

        [TestMethod]
        public void ShoppingCart_AddingTwoIdentical()
        {
            // arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            ProductSellFactory productSellFactory = new ProductSellFactory();
            ProductSellByWeight p1 = (ProductSellByWeight)productSellFactory.GetProductSell(ProductSellType.byWeight);
            p1.productId = 124;
            p1.productName = "Apple";
            p1.unitPrice = 2.49m;
            p1.addWeight(2.4m);
            ProductSellByWeight p2 = (ProductSellByWeight)productSellFactory.GetProductSell(ProductSellType.byWeight);
            p2.productId = 124;
            p2.productName = "Apple";
            p2.unitPrice = 2.49m;
            p2.addWeight(1.3m);

            //act
            shoppingCart.add((ProductSell)p1);
            shoppingCart.add((ProductSell)p2);
            decimal totalPrice = shoppingCart.getTotalPrice();
            int totalItemNumber = shoppingCart.getTotalItemNumber();

            // assert
            const decimal expectedTotalPrice = 2.49m * 3.7m;
            const int expectedTotalItemNumber = 1;
            Assert.AreEqual(expectedTotalPrice, totalPrice);
            Assert.AreEqual(expectedTotalItemNumber, totalItemNumber);
        }

        [TestMethod]
        public void ShoppingCart_AddingTwoIdentical_PlusOneDiffrentOne()
        {
            // arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            ProductSellFactory productSellFactory = new ProductSellFactory();
            ProductSellByWeight p1 = (ProductSellByWeight)productSellFactory.GetProductSell(ProductSellType.byWeight);
            p1.productId = 124;
            p1.productName = "Apple";
            p1.unitPrice = 2.49m;
            p1.addWeight(2.4m);
            ProductSellByWeight p2 = (ProductSellByWeight)productSellFactory.GetProductSell(ProductSellType.byWeight);
            p2.productId = 124;
            p2.productName = "Apple";
            p2.unitPrice = 2.49m;
            p2.addWeight(1.3m);
            ProductSellByWeight p3 = (ProductSellByWeight)productSellFactory.GetProductSell(ProductSellType.byWeight);
            p3.productId = 126;
            p3.productName = "Orange";
            p3.unitPrice = 1.88m;
            p3.addWeight(2.7m);

            //act
            shoppingCart.add((ProductSell)p1);
            shoppingCart.add((ProductSell)p2);
            shoppingCart.add((ProductSell)p3);
            decimal totalPrice = shoppingCart.getTotalPrice();
            int totalItemNumber = shoppingCart.getTotalItemNumber();

            // assert
            const decimal expectedTotalPrice = (2.49m * 3.7m) + (1.88m * 2.7m);
            const int expectedTotalItemNumber = 2;
            Assert.AreEqual(expectedTotalPrice, totalPrice);
            Assert.AreEqual(expectedTotalItemNumber, totalItemNumber);
        }


        /// <summary>
        /// Give a ShoppingCart and add two product with same productID and different productNames, it is expected to return an exception
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "There is a conflict on the given ProductName.")]
        public void ShoppingCart_AddingTwoIdenticalProductID_WithConflictedProductName()
        {
            // arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            ProductSellFactory productSellFactory = new ProductSellFactory();
            ProductSellByWeight p1 = (ProductSellByWeight)productSellFactory.GetProductSell(ProductSellType.byWeight);
            p1.productId = 124;
            p1.productName = "xxxx";
            p1.unitPrice = 2.49m;
            p1.addWeight(2.4m);
            ProductSellByWeight p2 = (ProductSellByWeight)productSellFactory.GetProductSell(ProductSellType.byWeight);
            p2.productId = 124;
            p2.productName = "yyyy";
            p2.unitPrice = 2.49m;
            p2.addWeight(1.3m);

            //act
            shoppingCart.add((ProductSell)p1);
            shoppingCart.add((ProductSell)p2);

            // assert
            //Must throw ArgumentOutOfRangeException : There is a conflict on the given ProductName.
        }
    }
}
