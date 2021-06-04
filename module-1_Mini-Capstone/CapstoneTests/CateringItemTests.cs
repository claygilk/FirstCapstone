using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class CateringItemTests
    {
        [TestMethod]
        public void SellItem_InsufficientStock_ReturnsFalse()
        {
            //Arrange
            CateringItem item = new CateringItem();
            item.InStock = 10;
            //Act
            bool actual = item.SellItem(11);
            //Assert
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void SellItem_NegativeQuantity_ReturnsFalse()
        {
            //Arrange
            CateringItem item = new CateringItem();
            item.InStock = 10;
            //Act
            bool actual = item.SellItem(-5);
            //Assert
            Assert.IsFalse(actual);
        }
    }
}
