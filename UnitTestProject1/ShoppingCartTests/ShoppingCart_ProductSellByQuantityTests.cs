using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashRegister.ShoppingCartSection;
using CashRegister.ProductSellSection;

namespace CashRegisterTest.ShoppingCartTests
{
    /* 
        All ProductItems are added of type ProductSellByQuantity
    */
    [TestClass]
    public class ShoppingCart_ProductSellByQuantityTests
    {
        [TestMethod]
        public void ShoppingCart_AddingSingle()
        {
            // arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            ProductSellFactory productSellFactory = new ProductSellFactory();
            ProductSellByQuantity p = (ProductSellByQuantity)productSellFactory.GetProductSell(ProductSellType.byQuantity);
            p.productId = 276;
            p.productName = "Boxes of Cheerios";
            p.unitPrice = 6.99m;
            p.addQuantity(2);

            //act
            shoppingCart.add((ProductSell)p);
            decimal totalPrice = shoppingCart.getTotalPrice();

            // assert
            const decimal expectedTotalPrice = 6.99m * 2;
            Assert.AreEqual(expectedTotalPrice, totalPrice);
        }


        [TestMethod]
        public void ShoppingCart_AddingTwoIdentical()
        {
            // arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            ProductSellFactory productSellFactory = new ProductSellFactory();
            ProductSellByQuantity p1 = (ProductSellByQuantity)productSellFactory.GetProductSell(ProductSellType.byQuantity);
            p1.productId = 276;
            p1.productName = "Boxes of Cheerios";
            p1.unitPrice = 6.99m;
            p1.addQuantity(2);
            ProductSellByQuantity p2 = (ProductSellByQuantity)productSellFactory.GetProductSell(ProductSellType.byQuantity);
            p2.productId = 276;
            p2.productName = "Boxes of Cheerios";
            p2.unitPrice = 6.99m;
            p2.addQuantity(1);

            //act
            shoppingCart.add((ProductSell)p1);
            shoppingCart.add((ProductSell)p2);
            decimal totalPrice = shoppingCart.getTotalPrice();
            int totalItemNumber = shoppingCart.getTotalItemNumber();

            // assert
            const decimal expectedTotalPrice = 6.99m * 3;
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
            ProductSellByQuantity p1 = (ProductSellByQuantity)productSellFactory.GetProductSell(ProductSellType.byQuantity);
            p1.productId = 276;
            p1.productName = "Boxes of Cheerios";
            p1.unitPrice = 6.99m;
            p1.addQuantity(2);
            ProductSellByQuantity p2 = (ProductSellByQuantity)productSellFactory.GetProductSell(ProductSellType.byQuantity);
            p2.productId = 276;
            p2.productName = "Boxes of Cheerios";
            p2.unitPrice = 6.99m;
            p2.addQuantity(1);
            ProductSellByQuantity p3 = (ProductSellByQuantity)productSellFactory.GetProductSell(ProductSellType.byQuantity);
            p3.productId = 312;
            p3.productName = "Body Shampoo";
            p3.unitPrice = 12.99m;
            p3.addQuantity(2);

            //act
            shoppingCart.add((ProductSell)p1);
            shoppingCart.add((ProductSell)p2);
            shoppingCart.add((ProductSell)p3);
            decimal totalPrice = shoppingCart.getTotalPrice();
            int totalItemNumber = shoppingCart.getTotalItemNumber();

            // assert
            const decimal expectedTotalPrice = 6.99m * 3 + 12.99m * 2;
            const int expectedTotalItemNumber = 2;
            Assert.AreEqual(expectedTotalPrice, totalPrice);
            Assert.AreEqual(expectedTotalItemNumber, totalItemNumber);
        }
        
        /// <summary>
        /// Give a ShoppingCart and add two product with same productID and different unitPrices, it is expected to return an exception
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "There is a conflict on the given UnitPrice.")]
        public void ShoppingCart_AddingTwoIdenticalProductID_WithConflictedUnitPrice()
        {
            // arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            ProductSellFactory productSellFactory = new ProductSellFactory();
            ProductSellByQuantity p1 = (ProductSellByQuantity)productSellFactory.GetProductSell(ProductSellType.byQuantity);
            p1.productId = 276;
            p1.productName = "Boxes of Cheerios";
            p1.unitPrice = 4.99m;
            p1.addQuantity(2);
            ProductSellByQuantity p2 = (ProductSellByQuantity)productSellFactory.GetProductSell(ProductSellType.byQuantity);
            p2.productId = 276;
            p2.productName = "Boxes of Cheerios";
            p2.unitPrice = 2.99m;
            p2.addQuantity(1);

            //act
            shoppingCart.add((ProductSell)p1);
            shoppingCart.add((ProductSell)p2);

            // assert
            //Must throw ArgumentOutOfRangeException : There is a conflict on the given UnitPrice.
        }

    }
}
