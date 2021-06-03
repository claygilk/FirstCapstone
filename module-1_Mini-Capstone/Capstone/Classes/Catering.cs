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
        private List<CateringItem> items = new List<CateringItem>();

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
        public CateringItem LookUpByCode(string codeToCheck)
        {
            foreach (CateringItem item in this.Items)
            {
                if (item.Code == codeToCheck)
                {
                    return item;
                }
            }
            return null;
        }
   
    }
}
