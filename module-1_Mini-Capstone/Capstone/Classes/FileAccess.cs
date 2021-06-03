using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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

        public string FilePath
        {
            get { return this.filePath; }
        }

        /// <summary>
        /// This method reads the file at the path specified in the filePath field, and splits each line on pipes.
        /// </summary>
        /// <returns>Returns a list of string array. Each item in the list is one catering item. Each item in the array is the info about that catering item.</returns>
        public List<string[]> ReadFileToList()
        {
            // Instantites list of string arrays to be added to later
            List<string[]> itemList = new List<string[]>();

            // try-catch block to handle file exceptions
            try
            {
                // Open and reads the file specified in the filePath field
                using (StreamReader read = new StreamReader(this.filePath))
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
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            // Once all lines have been read, and all string arrays have been added, returns the list of items
            return itemList;
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
            Catering inventory = new Catering();

            for (int i = 0; i < cateringItemArray.Length; i++)
            {
                inventory.Items.Add(cateringItemArray[i]);
            }

            return inventory;
        }

        /// <summary>
        /// This parameterless method can be called on a FileAccess object to do all the work necessary to build and return a Catering object.
        /// </summary>
        /// <returns>Returns a Catering object whose Items property corresponds to the items in the input file.</returns>
        public Catering LoadInventory()
        {
            // Reads the file and converts each item to a string array, puts those arrays into a list.
            List<string[]> itemList = this.ReadFileToList();

            // Takes that list and converts each item into a Catering item. Returns an array containing all those CateringItems.
            CateringItem[] cateringItemArray = this.CreateCateringItemsFromList(itemList);

            // Returns a Catering object that contains all the CateringItems from the Array
            return this.LoadCateringItemsIntoCatering(cateringItemArray);
        }
    }
}
