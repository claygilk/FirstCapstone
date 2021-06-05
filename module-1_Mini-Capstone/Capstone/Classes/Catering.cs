using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain all the "work" for catering
    /// </summary>
    /// <remarks>
    /// NO Console statements are allowed in this class
    /// </remarks>
    public class Catering 
    {
        /// <summary>
        /// The private field that is the list of all available CateringItems. These are items that are "in stock".
        /// </summary>
        private List<CateringItem> availableItems = new List<CateringItem>();

        /// <summary>
        /// The public property that returns the list of all available CateringItems. These are items that are "in stock".
        /// </summary>
        public List<CateringItem> AvailableItems
        {
            get
            {
                return this.availableItems;
            }

        }

        /// <summary>
        /// This method is used to find a CateringItem in invetory given an item code.
        /// </summary>
        /// <param name="codeToCheck">A unique two character item code</param>
        /// <returns>Returns the CateringItem that matches the code being searched for. If the item does not exist returns "null".</returns>
        public CateringItem LookUpByCode(string codeToCheck)
        {
            // Loops through each item in the current inventory
            foreach (CateringItem item in this.AvailableItems)
            {
                // If the code given matches (case insensitive) the code in that item...
                if (item.Code.ToUpper() == codeToCheck.ToUpper())
                {
                    //...Then the method returns that catering item
                    return item;
                }
            }
            // If th item is not found, the method returns "null"
            return null;
        }

        /// <summary>
        /// This method is used to convenently get a string of all the availble item codes to display to the user
        /// </summary>
        /// <returns>returns a string that includes the item code for any item in stock</returns>
        public override string ToString()
        {
            string avaibleItemCodes = "";

            foreach(CateringItem item in this.AvailableItems)
            {
                if (item.InStock > 0)
                {
                avaibleItemCodes += item.Code + " | ";
                }
            }

            return avaibleItemCodes.TrimEnd();
        }

    }
}
