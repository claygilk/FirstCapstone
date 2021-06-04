using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class handles the current balance and order information for each customer
    /// </summary>
    public class Account
    {
        /// <summary>
        /// the Catering object for this customer's current order
        /// </summary>
        public Catering Order { get; set; }
        
        /// <summary>
        /// The customer's current account balance.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// The customer's current 'shopping cart' (aka the list of items they have already purchased).
        /// </summary>
        public List<CateringItem> Cart { get; set; } = new List<CateringItem>();

        /// <summary>
        /// Derived Propety. The total cost of all the items in the customer's shopping cart. 
        /// </summary>
        public decimal totalBill 
        { 
            get
            {
                // totalBill is derived by looping over all the items in the cart and...
                decimal runningTotal = 0;
                foreach (CateringItem item in this.Cart)
                {
                    // ...adding the combined cost for all the items of that type to the running total
                    runningTotal += item.Price * item.InCart;
                }
                // Once the price of all the items have been summed together the total is returned
                return runningTotal;
            } 
        }

        /// <summary>
        /// This method attempts to withdraw money from the customer's account.
        /// </summary>
        /// <param name="amountToWithdraw">The amount the user is attempting to withdraw. Must be less than or equal to account balance and not a negative number.</param>
        /// <returns></returns>
        public decimal Withdraw(decimal amountToWithdraw)
        {
            // If the user attempts to withdraw a negative amount the withdraw fails, and the balance remains the same
            if (amountToWithdraw < 0)
            {
                return this.Balance;
            }
            // If the user attempts to withdraw more money than their is in the account, the withdraw fails and the balance remains the same
            else if (amountToWithdraw > this.Balance)
            {
                return this.Balance;
            }
            // If the user attempts to withdraw a valid amount of money, the withdraw succeds and the balance is updated
            else
            {
                this.Balance -= amountToWithdraw;
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
        /// This method resets the customer's account balance to zero. And logs the end of the transaction.
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
        /// This method calcualtes the denominations of change that is due back to the customer at the end of a transaction.
        /// </summary>
        /// <returns>Returns a string that lists out how much of each denomination the customer is due</returns>
        public string GetChangeBack()
        {
            // Create a decimal variable 'changeDue' that is equal to the remaining balance in the account
            decimal changeDue = this.Balance;
            
            // Convert the change due to a decimal and change the unit from dollars to cents
            int currentChange = Convert.ToInt32(changeDue * 100);

            // Create a variable for each denomination of change 
            int nickels = 0;
            int dimes = 0;
            int quarters = 0;
            int ones = 0;
            int fives = 0;
            int tens = 0;
            int twenties = 0;

            // This chain of while loops repeats the same process for each denomination of change
            // First it checks if the current change is more than the value of the current denomination
            // if it is, then the current change is decreased by the value of that denomination
            // At the same time the counter for that denomination is increased by one
            // this process is repeated until the value of the current still due is less than the value of the denomination
            // This process is then repeated for each denomination until the current change due is equal to zero
            while (currentChange >= 2000)
            {
                twenties++;
                currentChange -= 2000;
            }
            while (currentChange >= 1000)
            {
                tens++;
                currentChange -= 1000;
            }
            while (currentChange >= 500)
            {
                fives++;
                currentChange -= 500;
            }
            while (currentChange >= 100)
            {
                ones++;
                currentChange -= 100;
            }
            while (currentChange >= 25)
            {
                quarters++;
                currentChange -= 25;
            }
            while (currentChange >= 10)
            {
                dimes++;
                currentChange -= 10;
            }
            while (currentChange >= 5)
            {
                nickels++;
                currentChange -= 5;
            }
            return $"Change Due: {twenties} - Twenties | {tens} - Tens | {fives} - Fives | {ones} - Ones | {quarters} - Quarters | {dimes} - Dimes | {nickels} - Nickels";
        }
    }
}
