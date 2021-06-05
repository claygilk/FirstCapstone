using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class LoggerTests
    {
        [TestMethod]
        public void LogDeposit_LogsDepositCorrectly()
        {
            //Arrange
            string expected = "ADD MONEY: $50 $50";
            Logger testLogger = new Logger();
            
            //Act
            string actual = testLogger.LogDeposit(50M, 50M);

            // only the part of the subtring after the Date/Time is checked by the test
            // because the creation of the expected string happens at a different time than the LogDeposit()
            actual = actual.Substring(actual.IndexOf("M")+ 2);
            
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void LogSale_LogsSaleCorrectly()
        {
            //Arrange
            // create test item to sell. intialize it's values
            CateringItem fruitBowl = new CateringItem();
            string[] itemInfo = { "A1", "Tropical Fruit Bowl", "3.50", "A" };
            fruitBowl.ItemInfo = itemInfo;

            string expected = "1 Tropical Fruit Bowl A1 $3.50 $46.50";
            Logger testLogger = new Logger();

            //Act
            string actual = testLogger.LogSale(fruitBowl, 1, 46.50M);

            // only the part of the subtring after the Date/Time is checked by the test
            // because the creation of the expected string happens at a different time than the LogSale()
            actual = actual.Substring(actual.IndexOf("M") + 2);
            
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void LogTransaction_LogsEndOfTransactionCorrectly()
        {
            //Arrange
            Logger testLog = new Logger();
            string expected = "GIVE CHANGE: $46 $0";
            
            //Act
            string actual = testLog.LogTransaction(46M, 0M);

            // only the part of the subtring after the Date/Time is checked by the test
            // because the creation of the expected string happens at a different time than the LogTransaction()
            actual = actual.Substring(actual.IndexOf("M") + 2);
            
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
