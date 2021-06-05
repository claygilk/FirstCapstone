﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// Each instnace of this class represents the record of a sale
    /// </summary>
    public class SalesRecord
    {
        /// <summary>
        /// raw string pulled from the Log.txt file. Used to derive the other properties
        /// </summary>
        public string SaleInfo { get; set; }

        /// <summary>
        /// the name of each item sold
        /// </summary>
        public string Name
        {
            get
            {
                string[] saleInfoArray = this.SaleInfo.Split(" ");
                string name = "";

                for (int i = 1; i < saleInfoArray.Length - 3; i++)
                {
                    name += $"{saleInfoArray[i]} ";
                }
                return name.Trim();
            }
        }

        /// <summary>
        /// the total number of sales for a given item
        /// </summary>
        public int amountSold
        {
            get
            {
                string[] saleInfoArray = this.SaleInfo.Split(" ");
                return Convert.ToInt32(saleInfoArray[0]);
            }
        }

        /// <summary>
        /// the total revenue generated by one item's sales
        /// </summary>
        public decimal perItemRevenue
        {
            get
            {
                string[] saleInfoArray = this.SaleInfo.Split("$");

                return Convert.ToDecimal(saleInfoArray[1]);
            }
        }


    }
}
