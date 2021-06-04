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
        public string[] ItemInfo { get; set; }
        public string Code { get { return ItemInfo[0]; } }
        public string Name { get { return ItemInfo[1]; } }
        public decimal Price { get { return Convert.ToDecimal(ItemInfo[2]); } }
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
        public int InStock { get; set; }
        public int InCart { get; set; }

        public CateringItem()
        {
            this.InStock = 50;
        }

        public bool SellItem(int itemsToSell)
        {
            if (itemsToSell > this.InStock)
            {
                return false;
            }
            else
            {
                InStock -= itemsToSell;
                InCart += itemsToSell;
                return true;
            }
        }

    }
}
