using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class provides all user communications, but not much else.
    /// All the "work" of the application should be done elsewhere
    /// </summary>
    /// <remarks>
    /// ALL instances of Console.ReadLine and Console.WriteLine in your application should be in this class
    /// </remarks>
    public class UserInterface
    {
        private Catering catering = new Catering();

        // TODO: Create public property for catering class

        public void RunInterface()
        {
            // TODO: At the start of the program this method should create a FileAccess Object
            //       and call the LoadInventory() method.
            //       the Catering object returned by this method should then be assigned to "catering" field/property
            //       Also, we should probably rename this property bc its confusing.

            bool done = false;

            while (!done)
            {
                // This method should write the following options to the console:

                // 1. Display Catering Items
                // Calls the DisplayCateringItems() Method


                // 2. Order
                // Calls the OrderMenu() method

                // 3. Quier
                // Exits Program

            }
        }

        // Should also display number of items in stock
        public void DisplayCateringItems(Catering currentInventory)
        {
            foreach (CateringItem item in currentInventory.Items)
            {
                Console.Write($"{item.ItemInfo[0]}   {item.ItemInfo[1]}   ${item.ItemInfo[2]}   {item.ItemInfo[3]}\n");
            }
        }

        public void OrderMenu(Catering catering)
        {

        }

        public void AddMoney()
        {

        }

        public void SelectProducts(Catering inventory)
        {
            bool done = false;

            while (!done)
            {
                    Console.WriteLine("Enter product code: ");
                    string productChoice = Console.ReadLine();

                    CateringItem currentItem = inventory.LookUpByCode(productChoice);
                    if (currentItem == null)
                    {
                        Console.WriteLine("Item not found");
                        break;
                    }

                    Console.WriteLine("How many items do you want to buy? ");
                    int itemsToBuy = Convert.ToInt32(Console.ReadLine());

                    if (itemsToBuy > currentItem.InStock)
                    {
                        Console.WriteLine("Out of Stock");
                        break;
                    }
                    else
                    {
                        currentItem.SellItem(itemsToBuy);
                        break;
                    }
            }
            return;
        }
    }
}
