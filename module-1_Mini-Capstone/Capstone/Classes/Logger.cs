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
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(@"Could not find the directory: C:\Catering\");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(@"Do not have permission to write to: C:\Catering\Log.txt" + "\nPlease update file permissions");
            }
            catch (IOException e)
            {
                Console.WriteLine(@"Encountered an error: " + e.Message);
            }
        }

        public void LogSale(CateringItem itemSold, int quantitySold, decimal newBalance)
        {
            try
            {
                using (StreamWriter write = new StreamWriter(@"C:\Catering\Log.txt", true))
                {
                    write.WriteLine($"{DateTime.Now} {quantitySold} {itemSold.Name} {itemSold.Code} ${itemSold.Price} ${newBalance}");
                }
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(@"Could not find the directory: C:\Catering\");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(@"Do not have permission to write to: C:\Catering\Log.txt" + "\nPlease update file permissions");
            }
            catch (IOException e)
            {
                Console.WriteLine(@"Encountered an error: " + e.Message);
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
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(@"Could not find the directory: C:\Catering\");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(@"Do not have permission to write to: C:\Catering\Log.txt" + "\nPlease update file permissions");
            }
            catch (IOException e)
            {
                Console.WriteLine(@"Encountered an error: " + e.Message);
            }
        }
    }
}
