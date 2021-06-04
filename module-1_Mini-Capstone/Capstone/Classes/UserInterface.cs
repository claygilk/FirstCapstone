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
        private Catering inventory = new Catering();
        public Catering Inventory { get { return this.inventory; } set { inventory = value; } }

        // TODO: Create public property for catering class

        public void RunInterface()
        {
            FileAccess file = new FileAccess();
            this.Inventory = file.LoadInventory();


            bool done = false;

            while (!done)
            {
                // This method should write the following options to the console:
                Console.WriteLine("1. Display Catering Items\n 2. Order\n 3. Quit\n");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        this.DisplayCateringItems(this.Inventory);
                        break;
                    case "2":
                        this.OrderMenu(this.Inventory);
                        break;
                    case "3":
                        done = true;
                        break;
                }

            }
        }

        // Should also display number of items in stock
        public void DisplayCateringItems(Catering currentInventory)
        {
            foreach (CateringItem item in currentInventory.Items)
            {
                Console.Write($"{item.ItemInfo[0]}   {item.ItemInfo[1]}   ${item.ItemInfo[2]}   {item.ItemInfo[3]} {item.InStock}\n");
            }
        }

        public void OrderMenu(Catering catering)
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("1. Add Money\n 2. Select Products\n 3. Complete Transaction\n");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        this.AddMoneyMenu(this.Inventory);
                        break;
                    case "2":
                        this.SelectProductsMenu(this.Inventory);
                        break;
                    case "3":
                        this.CompleteTransactionScreen(this.inventory);
                        break;
                }
            }
        }
        //loop over each item in cart-print out quantity,type, name, cost, total cost
        private void CompleteTransactionScreen(Catering inventory)
        {
            foreach (CateringItem item in inventory.Customer.Cart)
            {
                Console.WriteLine($"{item.InCart} {item.Type} {item.Name} ${item.Price} ${item.Price * item.InCart}");
            }
            Console.WriteLine("Total: " + inventory.Customer.totalBill);
        }

        public void AddMoneyMenu(Catering inventory)
        {
            Console.WriteLine("Current Balance: " + inventory.Customer.Balance);
            Console.WriteLine("Enter amount to deposit: ");
            decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
            inventory.Customer.Balance = inventory.Customer.Deposit(depositAmount);
            Console.WriteLine("New Balance: " + inventory.Customer.Balance);

        }

        public void SelectProductsMenu(Catering inventory)
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
                if (currentItem.InStock == 0)
                {
                    Console.WriteLine("Out of Stock");
                }
                Console.WriteLine("How many items do you want to buy? ");
                int itemsToBuy = Convert.ToInt32(Console.ReadLine());

                if (itemsToBuy > currentItem.InStock)
                {
                    Console.WriteLine("Insufficient Stock");
                    break;
                }
                else
                {
                    inventory.Customer.Cart.Add(currentItem);
                    currentItem.SellItem(itemsToBuy);
                    break;
                }
            }
            return;
        }
    }
}
