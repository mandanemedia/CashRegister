using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashRegister.ShoppingCartSection;
using CashRegister.ProductSellSection;

namespace CashRegisterTest.ShoppingCartTests
{
    /* 
        All ProductItems are added of type ProductSellByQuantityInGroupSell
    */
    [TestClass]
    public class ShoppingCart_ProductSellByQuantityInGroupSellTests
    {
        [TestMethod]
        public void ShoppingCart_AddingSingle()
        {
            // arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            ProductSellFactory productSellFactory = new ProductSellFactory();
            ProductSellByQuantityInGroupSell p = (ProductSellByQuantityInGroupSell)productSellFactory.GetProductSell(ProductSellType.byQuantityInGroupSell);
            p.productId = 276;
            p.productName = "Boxes of Cheerios";
            p.unitPrice = 6.99m;
            p.addQuantity(3);
            p.discountThreshold = 3;

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
            ProductSellByQuantityInGroupSell p1 = (ProductSellByQuantityInGroupSell)productSellFactory.GetProductSell(ProductSellType.byQuantityInGroupSell);
            p1.productId = 276;
            p1.productName = "Boxes of Cheerios";
            p1.unitPrice = 6.99m;
            p1.addQuantity(3);
            p1.discountThreshold = 3;
            ProductSellByQuantityInGroupSell p2 = (ProductSellByQuantityInGroupSell)productSellFactory.GetProductSell(ProductSellType.byQuantityInGroupSell);
            p2.productId = 276;
            p2.productName = "Boxes of Cheerios";
            p2.unitPrice = 6.99m;
            p2.addQuantity(4);
            p2.discountThreshold = 3;

            //act
            shoppingCart.add((ProductSell)p1);
            shoppingCart.add((ProductSell)p2);
            decimal totalPrice = shoppingCart.getTotalPrice();
            int totalItemNumber = shoppingCart.getTotalItemNumber();

            // assert
            const decimal expectedTotalPrice = 6.99m * 5;
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
            ProductSellByQuantityInGroupSell p1 = (ProductSellByQuantityInGroupSell)productSellFactory.GetProductSell(ProductSellType.byQuantityInGroupSell);
            p1.productId = 276;
            p1.productName = "Boxes of Cheerios";
            p1.unitPrice = 6.99m;
            p1.addQuantity(3);
            p1.discountThreshold = 3;
            ProductSellByQuantityInGroupSell p2 = (ProductSellByQuantityInGroupSell)productSellFactory.GetProductSell(ProductSellType.byQuantityInGroupSell);
            p2.productId = 276;
            p2.productName = "Boxes of Cheerios";
            p2.unitPrice = 6.99m;
            p2.addQuantity(4);
            p2.discountThreshold = 3;
            ProductSellByQuantityInGroupSell p3 = (ProductSellByQuantityInGroupSell)productSellFactory.GetProductSell(ProductSellType.byQuantityInGroupSell);
            p3.productId = 312;
            p3.productName = "Body Shampoo";
            p3.unitPrice = 12.99m;
            p3.addQuantity(3);
            p3.discountThreshold = 3;

            //act
            shoppingCart.add((ProductSell)p1);
            shoppingCart.add((ProductSell)p2);
            shoppingCart.add((ProductSell)p3);
            decimal totalPrice = shoppingCart.getTotalPrice();
            int totalItemNumber = shoppingCart.getTotalItemNumber();

            // assert
            const decimal expectedTotalPrice = 6.99m * 5 + 12.99m * 2;
            const int expectedTotalItemNumber = 2;
            Assert.AreEqual(expectedTotalPrice, totalPrice);
            Assert.AreEqual(expectedTotalItemNumber, totalItemNumber);
        }
    }
}
