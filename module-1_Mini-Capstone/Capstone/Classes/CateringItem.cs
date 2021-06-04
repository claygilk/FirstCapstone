using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This represents a single catering item in your system
    /// </summary>
    /// <remarks>
    /// NO Console statements are allowed in this class
    /// </remarks>
    public class CateringItem
    {
        /// <summary>
        /// An array of strings that stores all of the information about a given CateringItem. The elements correspond to Code, Name, Price and Type in that order.
        /// </summary>
        public string[] ItemInfo { get; set; }

        /// <summary>
        /// The two letter item code.
        /// </summary>
        public string Code { get { return ItemInfo[0]; } }
        
        /// <summary>
        /// The item name.
        /// </summary>
        public string Name { get { return ItemInfo[1]; } }
        
        /// <summary>
        /// The item price. Derived by converting to ItemInfo element to a decimal
        /// </summary>
        public decimal Price { get { return Convert.ToDecimal(ItemInfo[2]); } }
        
        /// <summary>
        /// Item time. Returns a full word based on the initial in the ItemInfo array
        /// </summary>
        public string Type
        {
            get
            {
                if (ItemInfo[3] == "B")
                {
                    return "Beverage";
                }
                if (ItemInfo[3] == "D")
                {
                    return "Dessert";
                }
                if (ItemInfo[3] == "E")
                {
                    return "Entree";
                }
                if (ItemInfo[3] == "A")
                {
                    return "Appetizer";
                }
                else
                {
                    return ItemInfo[3];
                }
            }
        }
        /// <summary>
        /// The number of items that are available for purchase
        /// </summary>
        public int InStock { get; set; }

        /// <summary>
        /// the number of items that the customer has purchased. These items are in the 'shopping cart'
        /// </summary>
        public int InCart { get; set; }

        /// <summary>
        /// When a CateringItem is made it is 'stocked' and the quantity is set to 50
        /// </summary>
        public CateringItem()
        {
            this.InStock = 50;
        }

        /// <summary>
        /// This method handles changing stock amounts for CateringItems
        /// </summary>
        /// <param name="itemsToSell">the number of items the user is attempting to sell</param>
        /// <returns>returns true if the sale is successful. Returns false if the sale cannot be completed.</returns>
        public bool SellItem(int itemsToSell)
        {
            // If the user attempts to sell more items than they have in stock the sale fails, and the method returns false
            if (itemsToSell > this.InStock)
            {
                return false;
            }
            // If the user attempts to sell a negative number of items the sale fails, and the method returns false
            else if (itemsToSell < 0)
            {
                return false;
            }
            // If the user attempts to sell a valid number of items, the sale succeds, counts are updated and the method returns true
            else
            {
                InStock -= itemsToSell;
                InCart += itemsToSell;
                return true;
            }
        }

    }
}
