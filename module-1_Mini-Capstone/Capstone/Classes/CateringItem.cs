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
        public string Type { get { return ItemInfo[3]; } }
        public int InStock { get; set; }

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
                return true;
            }
        }
    }
}
