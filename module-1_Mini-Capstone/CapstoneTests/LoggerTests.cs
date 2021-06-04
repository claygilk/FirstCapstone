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
            actual = actual.Substring(actual.IndexOf("M")+ 2);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void LogSale()
        {
            //Arrange
            string expected = "1 Tropical Fruit Bowl A1 $3.50 $46.50";
            Logger testLogger = new Logger();
            CateringItem fruitBowl = new CateringItem();
            string[] itemInfo = { "A1", "Tropical Fruit Bowl", "3.50", "A" };
            fruitBowl.ItemInfo = itemInfo;


            //Act
            string actual = testLogger.LogSale(fruitBowl, 1, 46.50M);
            actual = actual.Substring(actual.IndexOf("M") + 2);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void LogTransaction()
        {
            //Arrange
            Logger testLog = new Logger();
            string expected = "GIVE CHANGE: $46 $0";
            //Act
            string actual = testLog.LogTransaction(46M, 0M);
            actual = actual.Substring(actual.IndexOf("M") + 2);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
