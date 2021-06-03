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

        public void RunInterface()
        {
            bool done = false;

            while (!done)
            {
                Console.WriteLine("Put details of your user interface here");

                Console.ReadLine();
            }
        }

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
