using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void Withdraw_CannotWithdrawNegativeNumber()
        {
            //Arrange
            Account account = new Account();
            decimal testWithdraw = -1;
            //Act
            decimal result = account.Withdraw(testWithdraw);
            //Assert
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void Deposit_CannotDepositOver5000()
        {
            //Arrange
            Account account = new Account();
            decimal testDeposit = 50001;
            //Act
            decimal result = account.Deposit(testDeposit);
            //Assert
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void CompleteTransaction_()
        {
            //Arrange
            Account account = new Account();
            //decimal testCompleteTransaction = 5;
            //Act
            //decimal result = account.CompleteTransaction(testCompleteTransaction);
            //Assert
            //Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void GetChangeBack_()
        {
            //Arrange
            Account account = new Account();
            account.Deposit(1M);
            account.Withdraw(0.50M);
            string expected = $"Change Due: 0 - Twenties | 0 - Tens | 0 - Fives | 0 - Ones | 2 - Quarters | 0 - Dimes | 0 - Nickels";
            //Act
            string result = account.GetChangeBack();
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
