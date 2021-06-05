using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain any and all details of access to files
    /// </summary>
    /// <remarks>
    /// NO Console statements are allowed in this class
    /// </remarks>
    public class FileAccess
    {
        // All external data files for this application should live in this directory.
        // You will likely need to create this directory and copy / paste any needed files.
        private string filePath = @"C:\Catering\cateringsystem.csv";

        /// <summary>
        /// Public property that returns the private field, filePath. A hardcoded file path to the data input file.
        /// </summary>
        public string FilePath
        {
            get { return this.filePath; }
        }

        /// <summary>
        /// This boolean property is true if the cateringsystem.csv file was formatted corrently
        /// </summary>
        public bool InputFileIsInvalid { get; private set; }

        /// <summary>
        /// This method reads the file at the path specified in the filePath field, and splits each line on pipes.
        /// </summary>
        /// <returns>Returns a list of string array. Each item in the list is one catering item. Each item in the array is the info about that catering item.</returns>
        public List<string[]> ReadFileToList(string fileToRead)
        {
            // Instantites list of string arrays to be added to later
            List<string[]> itemList = new List<string[]>();

            // try-catch block to handle file exceptions
            try
            {
                // Open and reads the file specified in the filePath field
                using (StreamReader read = new StreamReader(fileToRead))
                {
                    // Reads every line from start to finish
                    while (!read.EndOfStream)
                    {
                        // Splits each line into an array of strings whever there is a "|" in the original file
                        string[] items = read.ReadLine().Split("|");

                        // Adds this array of string to the list 'itemList'
                        itemList.Add(items);
                    }

                }
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine(@"Could not find the directory: C:\Catering\");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(@"Could not find the file: C:\Catering\cateringsystem.csv");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine(@"Do not have permission to access: C:\Catering\cateringsystem.csv" + "\nPlease update file permissions");
            }
            catch (IOException e)
            {
                Console.WriteLine(@"Encountered an error: " + e.Message);
            }

            // If this method is reading in the input file, it checks to make sure that the file was formatted correctly
            if (fileToRead == @"C:\Catering\cateringsystem.csv")
            {
                // If the file was fromatted incorrectly a message will be displayed to the user and the program will quit out
                this.InputFileIsInvalid = CheckInputFileFormat(itemList);
            }

            // Once all lines have been read, and all string arrays have been added, returns the list of items
            return itemList;
        }

        /// <summary>
        /// This method checks to makse sure the input file is formatted correctly.
        /// </summary>
        /// <param name="itemList"></param>
        public bool CheckInputFileFormat(List<string[]> itemList)
        {
            int lineNumber = 0;
            // Custom "exceptions" to ensure the cateringsystem.csv file is formatted correctly
            // Note: actual exceptions were not used because creating 4 Exceptions classes that simply just printed out an error message seemed overkill
            foreach (string[] item in itemList)
            {
                lineNumber++;
                // if any line does not contain three pipes to delimit the 4 different values, stop the program and inform the user
                if (item.Length != 4)
                {
                    Console.WriteLine($"cateringsystem.csv does not appear to be pipe delimited correctly.\nPlease update Line {lineNumber} before continuing.");
                    return true;
                }
                // if the first value, which should be the item code, is not two characters long, stop the program and inform the user
                if (item[0].Length != 2)
                {
                    Console.WriteLine($"cateringsystem.csv item codes are not formated correctly.\nPlease update Line {lineNumber} before continuing.");
                    return true;
                }
                // if the item code is not A,B,E or D stop the program and inform the user
                if (item[3] != "A" && item[3] != "B" && item[3] != "E" && item[3] != "D")
                {
                    Console.WriteLine($"cateringsystem.csv item types are not formated correctly.\nPlease update Line {lineNumber} before continuing.");
                    return true;
                }
                // if the item price is not formatted correctly stop the program and inform the user
                // the program is also stopped if the price has any digit in the 10,000s place because the user can only spend $5000 dollars per order
                Regex price = new Regex(@"^\d?\,?\d?\d?\d\.\d\d$");
                if (!price.IsMatch(item[2], 0))
                {
                    Console.WriteLine($"cateringsystem.csv item prices are not formated correctly.\nPlease update Line {lineNumber} before continuing.");
                    return true;
                }
            }
                return false;
        }

        /// <summary>
        /// This method creates a CateringItem object for each entry in the list of string arrays that is passed to it.
        /// </summary>
        /// <param name="itemList">A list of string arrays. On list item for each Catering item.</param>
        /// <returns>Returns an array of Catering items and initializes their ItemInfo property.</returns>
        public CateringItem[] CreateCateringItemsFromList(List<string[]> itemList)
        {
            // Creates an array of Catering items whose length equal the length of the list being passed in
            CateringItem[] cateringItemArray = new CateringItem[itemList.Count];

            // For each item in the list passed into this method...
            for (int i = 0; i < itemList.Count; i++)
            {
                // ... it creates a new catering item and adds it to the array
                cateringItemArray[i] = new CateringItem()
                {
                    // It then initializes the values of that CateringItem's ItemInfo property with the string array from the list
                    ItemInfo = itemList[i]
                };
            }
            // Once the array has been fully populated it is returned
            return cateringItemArray;
        }

        /// <summary>
        /// This method creates and returns a Catering object and populates its' Item property with the CateringItems from the array passed into it.
        /// </summary>
        /// <param name="cateringItemArray">An array of CateringItem objects</param>
        /// <returns>Returns a Catering object whose Items property corresponds to the items in the input file.</returns>
        public Catering LoadCateringItemsIntoCatering(CateringItem[] cateringItemArray)
        {
            // Creates a new Catering object
            Catering inventory = new Catering();

            // Loops over each element in the catering item Array and...
            for (int i = 0; i < cateringItemArray.Length; i++)
            {
                // ...adds that object to the list of available items for this order
                inventory.AvailableItems.Add(cateringItemArray[i]);
            }

            // The now "fully stocked" Catering object is returned
            return inventory;
        }

        /// <summary>
        /// This parameterless method can be called on a FileAccess object to do all the work necessary to build and return a Catering object.
        /// </summary>
        /// <returns>Returns a Catering object whose Items property corresponds to the items in the input file.</returns>
        public Catering LoadInventory()
        {
            // Reads the file and converts each item to a string array, puts those arrays into a list.
            List<string[]> itemList = this.ReadFileToList(this.FilePath);

            // Takes that list and converts each item into a Catering item. Returns an array containing all those CateringItems.
            CateringItem[] cateringItemArray = this.CreateCateringItemsFromList(itemList);

            // Returns a Catering object that contains all the CateringItems from the Array
            return this.LoadCateringItemsIntoCatering(cateringItemArray);
        }

        /// <summary>
        /// This method reads the current Log.txt files and generates from it a Sales Report. The report is written to the file: TotalSales.rpt
        /// </summary>
        public List<SalesRecord> CreateSalesRecordObjects(string logFileToRead)
        {
            // Read the long file using the ReadFileToList() method from the main program
            // but because the Log.txt is not pipe delimitied all arrays are of lenth 1
            List<string[]> rawLogFile = this.ReadFileToList(logFileToRead);

            // Create a list of strings that will hold only the lines in the log file that were for sales
            List<string> allSaleRecords = new List<string>();

            // loop over each line that was read in from the file
            foreach (string[] line in rawLogFile)
            {
                // if the line was for a deposit or finished transaction then the line is ignored
                if (!line[0].Contains("ADD") && !line[0].Contains("GIVE"))
                {
                    // otherwise create a new string that is just the line with the date/time info cut off
                    string lineWithoutDate = line[0].Substring(line[0].IndexOf("M") + 2);

                    // add this new string to the list of strings created above
                    allSaleRecords.Add(lineWithoutDate);
                }
            }

            // Create a list for SalesRecord that will be filled out by the list of strings from the previous step
            List<SalesRecord> listOfSales = new List<SalesRecord>();

            // loop over each string in the list and...
            for (int i = 0; i < allSaleRecords.Count; i++)
            {
                // ...creat a new SalesRecord object for that line
                listOfSales.Add(new SalesRecord());

                // Assign the value of the current string to the "SaleInfo" property of the new SalesRecord
                // The other SalesRecord properties will all be derived from this string
                listOfSales[i].SaleInfo = allSaleRecords[i];
            }

            // Return the list of SalesRecord objects
            return listOfSales;
        }


    }
}
