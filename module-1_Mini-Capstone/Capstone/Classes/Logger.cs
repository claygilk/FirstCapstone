using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    /// <summary>
    /// This class handles recording transactions to a log file ("Log.txt")
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// This method logs all deposits to the customer's account
        /// </summary>
        /// <param name="deposit">The amount deposited</param>
        /// <param name="balance">the new balance</param>
        public string LogDeposit(decimal deposit, decimal balance)
        {
            string record = $"{DateTime.Now} ADD MONEY: ${deposit} ${balance}";
            // try-catch block is used to hand file exceptions
            try
            {
                // Use a stream writer to append the record to C:\Catering\Log.txt 
                using (StreamWriter write = new StreamWriter(@"C:\Catering\Log.txt", true))
                {
                    // Writes: Date, Time, action taken, deposit amout, new balance
                    write.WriteLine(record);
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
            return record;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemSold"></param>
        /// <param name="quantitySold"></param>
        /// <param name="newBalance"></param>
        public string LogSale(CateringItem itemSold, int quantitySold, decimal newBalance)
        {
            string record = $"{DateTime.Now} {quantitySold} {itemSold.Name} {itemSold.Code} ${itemSold.Price * quantitySold} ${newBalance}";
            // try-catch block is used to hand file exceptions
            try
            {
                // Use a stream writer to append the record to C:\Catering\Log.txt 
                using (StreamWriter write = new StreamWriter(@"C:\Catering\Log.txt", true))
                {
                    // Writes: Date, Time, quantity sold, item name, item code, line item total and new balance
                    write.WriteLine(record);
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
            return record;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="changeDue"></param>
        /// <param name="balance"></param>
        public string LogTransaction(decimal changeDue, decimal balance)
        {
            string record = $"{DateTime.Now} GIVE CHANGE: ${changeDue} ${balance}";
            // try-catch block is used to hand file exceptions
            try
            {
                // Use a stream writer to append the record to C:\Catering\Log.txt 
                using (StreamWriter write = new StreamWriter(@"C:\Catering\Log.txt", true))
                {
                    // Writes: Date, Time, action taken, change due, new balance
                    write.WriteLine(record);
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
            return record;
        }
    }
}
