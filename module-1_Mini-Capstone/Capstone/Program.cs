﻿using System;
using Capstone.Classes;

namespace Capstone
{
    /// <summary>
    /// The main entry point for this application.
    /// </summary>
    /// <remarks>
    /// You should not need to modify this file. If you believe you do, ask your instructor.
    /// </remarks>
    class Program
    {
        static void Main(string[] args)
        {
            // TEST CODE
            // DELETE LATER
            FileAccess test = new FileAccess();
            Catering testInventory = test.LoadInventory();

            //This is the only code that goes here
            //Do not change this code
            UserInterface userInterface = new UserInterface();

            userInterface.DisplayCateringItems(testInventory);

            userInterface.RunInterface();

        }
    }
}
