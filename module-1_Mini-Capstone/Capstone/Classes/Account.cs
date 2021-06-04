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
    }
}
