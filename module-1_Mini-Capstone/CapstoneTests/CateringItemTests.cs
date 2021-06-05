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
            //Act
            bool actual = item.SellItem(51);
            //Assert
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void SellItem_NegativeQuantity_ReturnsFalse()
        {
            //Arrange
            CateringItem item = new CateringItem();
            //Act
            bool actual = item.SellItem(-5);
            //Assert
            Assert.IsFalse(actual);
        }
       
        [TestMethod]
        public void CateringItemConstructor_StocksItemsTo50()
        {
            // Arrange
            CateringItem item = new CateringItem();
            // Act

            // Assert
            Assert.AreEqual(50, item.InStock);
        }

        [TestMethod]
        public  void ToStringOverride_ReturnsCorrectString()
        {
            // Arrange
            CateringItem item = new CateringItem();
            
            string[] testInfo = { "B1","Soda", "1.50", "B"};
            item.ItemInfo = testInfo;
            
            string expected = "B1   $1.50   Stock:50   Beverage    Soda\n";
            
            // Act
            string actual = item.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
