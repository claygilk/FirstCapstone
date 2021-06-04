using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    class Logger
    {
        public void LogDeposit(decimal deposit, decimal balance)
        {
            try
            {
                using (StreamWriter write = new StreamWriter(@"C:\Catering\Log.txt", true))
                {
                    write.WriteLine($"{DateTime.Now} ADD MONEY: ${deposit} ${balance}");
                }
            }
            catch (IOException)
            {
                Console.WriteLine("ERROR");
            }
        }

        public void LogSale(CateringItem itemSold, int quantitySold, decimal newBalance)
        {
            try
            {
                using (StreamWriter write = new StreamWriter(@"C:\Catering\Log.txt", true))
                {
                    write.WriteLine($"{DateTime.Now} {quantitySold} {itemSold.Name} ${itemSold.Price} ${newBalance}");
                }
            }
            catch (IOException)
            {
                Console.WriteLine("ERROR");
            }
        }

        public void LogTransaction(decimal changeDue, decimal balance)
        {
            try
            {
                using (StreamWriter write = new StreamWriter(@"C:\Catering\Log.txt", true))
                {
                    write.WriteLine($"{DateTime.Now} GIVE CHANGE: ${changeDue} ${balance}");
                }
            }
            catch (IOException)
            {
                Console.WriteLine("ERROR");
            }
        }
    }
}
