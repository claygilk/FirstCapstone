using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

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
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine(@"Could not find the directory: C:\Catering\");
            }
            catch (UnauthorizedAccessException)
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
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine(@"Could not find the directory: C:\Catering\");
            }
            catch (UnauthorizedAccessException)
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
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine(@"Could not find the directory: C:\Catering\");
            }
            catch (UnauthorizedAccessException)
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
        /// This method writes a Total Sales Report to a file (TotalSales.rpt) in the /Catering/ folder.
        /// </summary>
        /// <param name="listOfSales">a list of all SalesRecords</param>
        public void WriteSalesReport(List<SalesRecord> listOfSales)
        {
            // Linq query is used to aggregate the units sold and revenue for repeat sales of the same item
            var uniqueSales = listOfSales.GroupBy(s => s.Name).Select(sale => new
            {
                Name = sale.Key,
                amountSold = sale.Sum(qtyTotal => qtyTotal.amountSold),
                perItemRevenue = sale.Sum(revenueTotal => revenueTotal.perItemRevenue),
            }).ToList();

            // try-catch block to handle file exceptions
            try
            {
                // Writes out the following lines to the TotalSales.rpt file
                using (StreamWriter write = new StreamWriter(@"C:\Catering\TotalSales.rpt"))
                {
                    // create a temporary variable for total sales
                    decimal totalSales = 0;

                    // loop over each item in the list of unique sales and...
                    foreach (var sale in uniqueSales)
                    {
                        // ...write the item name, how many were sold, and the total revenue generated
                        write.WriteLine($"{sale.Name}|{sale.amountSold}|${sale.perItemRevenue}");

                        // then add this items revenue to total sales
                        totalSales += sale.perItemRevenue;
                    }
                    // once all sales have been reported, write the total sales at the bottom of the report
                    write.WriteLine($"\n**Total Sales** {totalSales}");

                }
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine(@"Could not find the directory: C:\Catering\");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine(@"Do not have permission to write to: C:\Catering\TotalSales.rpt" + "\nPlease update file permissions");
            }
            catch (IOException e)
            {
                Console.WriteLine(@"Encountered an error: " + e.Message);
            }
        }
    }
}
