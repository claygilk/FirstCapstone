using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Account
    {
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
            if (Balance > amountToWithdraw)
            {
                this.Balance -= amountToWithdraw;
            }
            else
            {
                return this.Balance;
            }
            return this.Balance;
        }

        public decimal Deposit(decimal amountToDeposit)
        {
            if (amountToDeposit > 5000)
            {
                return this.Balance;
            }
            else if (amountToDeposit + this.Balance > 5000)
            {
                return this.Balance;
            }
            else
            {
                if (amountToDeposit % 1 == 0)
                {
                    this.Balance += amountToDeposit;
                }
                else
                {
                    Console.WriteLine("Not a whole number");
                    return this.Balance;
                }
                return this.Balance;
            }
            
        }
        public void CompleteTransaction()
        {

        }
        public string GetChangeBack(decimal changeDue)
        {
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
            return $"Change Due {twenties} - twenties, {tens} - tens, {fives} - fives, {ones} - ones, {quarters} - quarters, {dimes} - dimes, {nickels} - nickels";
        }
    }
}
