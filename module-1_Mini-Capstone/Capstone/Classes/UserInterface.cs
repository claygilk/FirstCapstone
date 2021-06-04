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
        private Account customer = new Account();
        public Account Customer { get { return this.customer; } set { customer = value; } }

        // TODO: Create public property for catering class

        public void RunInterface()
        {
            FileAccess file = new FileAccess();
            this.Customer.Order = file.LoadInventory();


            bool done = false;

            while (!done)
            {
                // This method should write the following options to the console:
                Console.WriteLine("\n1. Display Catering Items\n2. Order\n3. Quit\n");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        this.DisplayCateringItems(this.Customer);
                        break;
                    case "2":
                        this.OrderMenu(this.Customer);
                        break;
                    case "3":
                        done = true;
                        break;
                }

            }
        }

        /// <summary>
        /// This method displays each item in the current inventory and how much stock is left
        /// </summary>
        /// <param name="currentInventory">The current Catering object for this instance of the program.</param>
        public void DisplayCateringItems(Account customer)
        {
            // Loop over each item in inventory...
            foreach (CateringItem item in customer.Order.AvailableItems)
            {
                // ...displays the code, name, price, type and quantity in stock
                Console.Write($"{item.Code}   ${item.Price}   Stock:{item.InStock}   {item.Type}    {item.Name}\n");
            }
            if (customer.Order.AvailableItems.Count == 0)
            {
                Console.WriteLine("No items in stock, please load inventory file");
            }
        }

        public void OrderMenu(Account customer)
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("\n1. Add Money\n2. Select Products\n3. Complete Transaction\n");
                Console.WriteLine("Current Account Balance: $" + customer.Balance);

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        this.AddMoneyMenu(customer);
                        break;
                    case "2":
                        this.SelectProductsMenu(customer);
                        break;
                    case "3":
                        this.CompleteTransactionScreen(customer);
                        return;
                }
            }
        }
        /// <summary>
        /// This method displays all the items in the customers cart and their total bill, when the transaction is complete
        /// </summary>
        /// <param name="inventory">The current Catering object for this instance of the program.</param>
        private void CompleteTransactionScreen(Account customer)
        {
            // Blank line for spacing/readbility
            Console.WriteLine("\nQuantity | Type | Name | Price | Line Total");

            // Loop over each item in the customer's cart...
            foreach (CateringItem item in customer.Cart)
            {
                // ... and displace the number of items in the cart, the type, name, price and total cost of these items
                Console.WriteLine($"{item.InCart} {item.Type} {item.Name} ${item.Price} ${item.Price * item.InCart}");
            }
            // Display total bill or total cost of all items in cart
            Console.WriteLine("Total: $" + customer.totalBill);

            // Call the GetChangeBack() to display how much changed is due to the customer and in what denominations
            Console.WriteLine(customer.GetChangeBack());

            // Resets the account balance to 0 and logs the transaction
            customer.CompleteTransaction();
            return;
        }
        /// <summary>
        /// This menu allows the user to (attempt to) add money to the customer's account balance
        /// </summary>
        /// <param name="inventory">The current Catering object for this instance of the program.</param>
        public void AddMoneyMenu(Account customer)
        {

            // Displays current customer balance to the user
            Console.WriteLine("\nCurrent Balance: " + customer.Balance);

            // Prompts the user for how much money they want to deposit
            Console.WriteLine("Enter amount to deposit: ");
            try
            {
            // Converts input into a decimal
            decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
            // Attempts to update customer balance by passing the deposit amount to the Account.Deposit() method
            customer.Balance = customer.Deposit(depositAmount);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input");
            }
            // Displays new balance to user. This balance will be the same as before if the deposit was unsucessful
            Console.WriteLine("New Balance: " + customer.Balance);

        }

        /// <summary>
        /// This menu allows the user to purchase items by entering a item code and the amount they wish to purchase
        /// </summary>
        /// <param name="inventory">The current Catering object for this instance of the program.</param>
        public void SelectProductsMenu(Account customer)
        {
            bool done = false;

            while (!done)
            {
                // Asks the user to enter the product code
                Console.WriteLine("Enter product code: ");
                string productChoice = Console.ReadLine();

                // Set the variable currentItem equal to the Catering item whose code matches the user's input (if it exists)
                CateringItem currentItem = customer.Order.LookUpByCode(productChoice);

                // If the item cannot be found, currentItem will be null
                if (currentItem == null)
                {
                    // And the user will be notified
                    Console.WriteLine("Item not found");
                    break;
                }
                // If the item is out of stock...
                if (currentItem.InStock == 0)
                {
                    // ...the user will be notified
                    Console.WriteLine("Out of Stock");
                }

                // If the item is exists and is in stock, ask the user how many items they wish to purchase
                Console.WriteLine("How many items do you want to buy? ");

                // Convert user input to an integer
                int itemsToBuy = Convert.ToInt32(Console.ReadLine());

                // If the user tries to buy more items then are in stock the sale is unsucessful...
                if (itemsToBuy > currentItem.InStock)
                {
                    // ...and the user is notified
                    Console.WriteLine("Insufficient Stock");
                    break;
                }
                else
                {
                    // If the user has sufficent funds in their account the sale is succesfull
                    if (customer.Balance > itemsToBuy * currentItem.Price)
                    {
                        // The desired item is added to the customer's cart
                        customer.Cart.Add(currentItem);

                        // The SellItem() method is called to change the amount of item in stock vs in cart
                        currentItem.SellItem(itemsToBuy);

                        // Money is withdrawn form the customer's balance equal to the total price of all the items sold
                        customer.Withdraw(itemsToBuy * currentItem.Price);

                        // This sale transaction is logged in "Log.txt"
                        Logger log = new Logger();
                        log.LogSale(currentItem, itemsToBuy, customer.Balance);
                    }
                    // If the user does not have enough money in their account, the sale is unsuccesfull...
                    else
                    {
                        // ...and the user is notified
                        Console.WriteLine("Insufficient Funds");
                    }
                    break;
                }
            }
            return;
        }
    }
}
