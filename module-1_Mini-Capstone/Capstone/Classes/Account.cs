using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Account
    {
        public Catering Order { get; set; }
        public decimal Balance { get; set; }
        public List<CateringItem> Cart { get; set; } = new List<CateringItem>();
        public decimal totalBill 
        { 
            get
            {
                decimal runningTotal = 0;
                foreach (CateringItem item in this.Cart)
                {
                    runningTotal += item.Price * item.InCart;
                }
                return runningTotal;
            } 
        }

        public decimal Withdraw(decimal amountToWithdraw)
        {
            //Making sure we can't input a negative number
            if (amountToWithdraw < 0)
            {
                return this.Balance;
            }
            else if (Balance >= amountToWithdraw)
            {
                this.Balance -= amountToWithdraw;
            }
            else
            {
                return this.Balance;
            }
            return this.Balance;
        }

        /// <summary>
        /// This method is used to add money to a customer's account balance
        /// </summary>
        /// <param name="amountToDeposit">The amount of money the user is attempting to deposit. Must be a whole dollar amount less than $5000</param>
        /// <returns>Returns the new balance unless the deposit amount was invalid or the the new balance would be over $5000</returns>
        public decimal Deposit(decimal amountToDeposit)
        {
            // If the user attempts to add more than $5000 at once the Deposit fails...
            if (amountToDeposit > 5000)
            {
                //... and the account balance remains the same
                return this.Balance;
            }
            // If the new balance would be greater than $5000 the Deposit fails...
            else if (amountToDeposit + this.Balance > 5000)
            {
                //... and the account balance remains the same
                return this.Balance;
            }
            else if (amountToDeposit < 0)
            {
                return this.Balance;
            }
            else
            {
                // If the user attempts to deposit a whole dollar amount an the deposit does not exceed the account maximum...
                if (amountToDeposit % 1 == 0)
                {
                    //... The deposit is succesfull and the balance is updated
                    this.Balance += amountToDeposit;

                    // This transaction is also tracked in the Log.txt file
                    Logger log = new Logger();
                    log.LogDeposit(amountToDeposit, this.Balance);
                }
                // If the user attempts to deposit some dollars and change the deposit fails...
                else
                {
                    //... and the balance remains the same
                    Console.WriteLine("Not a whole number");
                    return this.Balance;
                }
                // This is the return statement that is used when the deposit is succesful
                return this.Balance;
            }
            
        }
        /// <summary>
        /// This method resets the customer's account balance to zero. A logs the end of the transaction.
        /// </summary>
        public void CompleteTransaction()
        {
            // Set the remaining balance (or change due bakc) to the current account balance
            decimal remainingBalance = this.Balance;

            // With draw all the remaining money from the customer's balance
            this.Withdraw(remainingBalance);

            // Log this transaction in "Log.txt"
            Logger log = new Logger();
            log.LogTransaction(remainingBalance, this.Balance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="changeDue"></param>
        /// <returns></returns>
        public string GetChangeBack()
        {
            decimal changeDue = this.Balance;
            int nickels = 0;
            int dimes = 0;
            int quarters = 0;
            int ones = 0;
            int fives = 0;
            int tens = 0;
            int twenties = 0;

            int currentChange = Convert.ToInt32(changeDue * 100);
            while (currentChange > 2000)
            {
                twenties++;
                currentChange -= 2000;
            }
            while (currentChange > 1000)
            {
                tens++;
                currentChange -= 1000;
            }
            while (currentChange > 500)
            {
                fives++;
                currentChange -= 500;
            }
            while (currentChange > 100)
            {
                ones++;
                currentChange -= 100;
            }
            while (currentChange > 25)
            {
                quarters++;
                currentChange -= 25;
            }
            while (currentChange > 10)
            {
                dimes++;
                currentChange -= 10;
            }
            while (currentChange > 5)
            {
                nickels++;
                currentChange -= 5;
            }
            return $"Change Due: {twenties} - Twenties | {tens} - Tens | {fives} - Fives | {ones} - Ones | {quarters} - Quarters | {dimes} - Dimes | {nickels} - Nickels";
        }
    }
}
