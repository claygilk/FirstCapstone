using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Account
    {
        public decimal Balance { get; private set; }

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
