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
        public Account Customer { get; set; }

        private List<CateringItem> items = new List<CateringItem>();

        public Catering()
        {
            this.Customer = new Account();
        }
        public List<CateringItem> Items
        {
            get
            {
                return this.items;
            }
            set
            {
                this.items = value;
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
            foreach (CateringItem item in this.Items)
            {
                // If the code given matches (case insensitive) the code in that item...
                if (item.Code.ToUpper() == codeToCheck.ToUpper())
                {
                    //...Then the method returns that catering item
                    return item;
                }
            }
            return null;
        }
   
    }
}
