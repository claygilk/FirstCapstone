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
        public void AttemptToBuy_InsufficientFunds_ReturnsFalse()
        {
            // Arrange 
            Account customer = new Account();

            CateringItem item = new CateringItem();
            string[] testInfo = { "B1", "Soda", "1.50", "B" };
            item.ItemInfo = testInfo;

            // Act 
            bool actual = customer.AttemptToBuy(item, 1);

            // Assert
            Assert.IsFalse(actual);
        }

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
        public void Withdraw_CannotWithdrawMoreThanCurrentBalance()
        {
            //Arrange
            Account account = new Account();
            account.Deposit(99);
            decimal testWithdraw = 100;
            //Act
            decimal result = account.Withdraw(testWithdraw);
            //Assert
            Assert.AreEqual(99, result);
        }
        [TestMethod]
        public void Deposit_CannotDepositNegativeNumber()
        {
            //Arrange
            Account account = new Account();
            decimal testDeposit = -1;
            //Act
            decimal result = account.Deposit(testDeposit);
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
        public void CompleteTransaction_ResetsAccountBalanceToZero()
        {
            //Arrange
            Account account = new Account();
            account.Deposit(100M);
            //Act
            account.CompleteTransaction();
            //Assert
            Assert.AreEqual(0, account.Balance);
        }
        
        [DataRow(1, 0.95 ,"Change Due: 0 - Twenties | 0 - Tens | 0 - Fives | 0 - Ones | 0 - Quarters | 0 - Dimes | 1 - Nickels")]
        [DataRow(1, 0.90 ,"Change Due: 0 - Twenties | 0 - Tens | 0 - Fives | 0 - Ones | 0 - Quarters | 1 - Dimes | 0 - Nickels")]
        [DataRow(1, 0.75 ,"Change Due: 0 - Twenties | 0 - Tens | 0 - Fives | 0 - Ones | 1 - Quarters | 0 - Dimes | 0 - Nickels")]
        [DataRow(2, 1.00 ,"Change Due: 0 - Twenties | 0 - Tens | 0 - Fives | 1 - Ones | 0 - Quarters | 0 - Dimes | 0 - Nickels")]
        [DataRow(10, 5.00 ,"Change Due: 0 - Twenties | 0 - Tens | 1 - Fives | 0 - Ones | 0 - Quarters | 0 - Dimes | 0 - Nickels")]
        [DataRow(20, 10.00 ,"Change Due: 0 - Twenties | 1 - Tens | 0 - Fives | 0 - Ones | 0 - Quarters | 0 - Dimes | 0 - Nickels")]
        [DataRow(40, 20.00 ,"Change Due: 1 - Twenties | 0 - Tens | 0 - Fives | 0 - Ones | 0 - Quarters | 0 - Dimes | 0 - Nickels")]
        [DataTestMethod]
        public void GetChangeBack_ReturnsCorrectAmountOfEachDenomination(double deposit, double withdraw, string expected)
        {
            //Arrange
            Account account = new Account();
            account.Deposit((decimal)deposit);
            account.Withdraw((decimal)withdraw);
            
            //Act
            string result = account.GetChangeBack();
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
