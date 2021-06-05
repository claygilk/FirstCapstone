using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class FileAccessTests
    {
        //Reads the file and returns
        [TestMethod]
        public void LoadFile_ReturnsNonNullCateringObject()
        {
            // Arrange
            FileAccess fileAccess = new FileAccess();

            // Act
            Catering actual = fileAccess.LoadInventory();
            // Assert
            Assert.IsNotNull(actual);
        }

        //list that's same length as the file
        [TestMethod]
        public void ReadFileToList_ReturnsOneListItemPerLine()
        {
            // Arrange
            FileAccess fileAccess = new FileAccess();
            int expectedItemCount = System.IO.File.ReadAllLines(fileAccess.FilePath).Length;

            // Act
            List<string[]> actualItem = fileAccess.ReadFileToList(fileAccess.FilePath);

            // Assert
            Assert.AreEqual(expectedItemCount, actualItem.Count);
        }

        [TestMethod]
        public void CreateCateringItemsFromList_CreatesCateringItemCorrectly()
        {
            // Arrange
            FileAccess fileAccess = new FileAccess();
            string[] array1 = { "a", "b", "c" };
            string[] array2 = { "a", "b", "c" };
            string[] array3 = { "a", "b", "c" };
            List<string[]> test = new List<string[]>
            {
                array1, array2, array3
            };

            // Act
            CateringItem[] actual = fileAccess.CreateCateringItemsFromList(test);

            // Assert
            Assert.AreEqual("a", actual[0].ItemInfo[0]);
            Assert.AreEqual("b", actual[0].ItemInfo[1]);
            Assert.AreEqual("c", actual[0].ItemInfo[2]);
            Assert.AreEqual("a", actual[1].ItemInfo[0]);
            Assert.AreEqual("b", actual[1].ItemInfo[1]);
            Assert.AreEqual("c", actual[1].ItemInfo[2]);
        }
        [TestMethod]
        public void LoadCateringItemsIntoCatering_CreatesCateringObjectCorrectly()
        {
            //Arrange
            FileAccess fileAccess = new FileAccess();
            CateringItem testItem = new CateringItem();
            string[] array1 = { "a", "b", "c" };
            testItem.ItemInfo = array1;
            CateringItem[] testArray = { testItem };

            //Act
            Catering actual = fileAccess.LoadCateringItemsIntoCatering(testArray);

            //Assert
            Assert.AreEqual("a", actual.AvailableItems[0].ItemInfo[0]);
            Assert.AreEqual("b", actual.AvailableItems[0].ItemInfo[1]);
            Assert.AreEqual("c", actual.AvailableItems[0].ItemInfo[2]);
        }

        [TestMethod]
        public void CreateSalesRecordObjects_ReturnsCorretObjects()
        {
            // Arrange 
            try
            {
                // creates and writes one line of each type to a temporary log file
                using (System.IO.StreamWriter write = new System.IO.StreamWriter(@"C:\Catering\TestLog.txt"))
                {
                    write.WriteLine("6/5/2021 1:06:06 PM ADD MONEY: $100 $100");
                    write.WriteLine("6/5/2021 12:57:32 PM 1 Tropical Fruit Bowl A1 $3.50 $46.50");
                    write.WriteLine("6/5/2021 12:57:32 PM GIVE CHANGE: $46 $0");
                }
                
                // manual create a new SalesRecord object and initialize it's SaleInfo property
                SalesRecord sale = new SalesRecord();
                string saleLogLine = "1 Tropical Fruit Bowl A1 $3.50 $46.50";
                sale.SaleInfo = saleLogLine;

                // create empty list of SalesRecord because method returns this kind of list
                List<SalesRecord> actual = new List<SalesRecord>();

                // create FileAccess object to call method
                FileAccess testFile = new FileAccess();
                
                // Act 
                actual = (testFile.CreateSalesRecordObjects(@"C:\Catering\TestLog.txt"));

                // Assert
                Assert.AreEqual(sale.Name, actual[0].Name);
                Assert.AreEqual(sale.perItemRevenue, actual[0].perItemRevenue);
                Assert.AreEqual(sale.amountSold, actual[0].amountSold);
                
                // delete the test log file when test is done
                System.IO.File.Delete(@"C:\Catering\TestLog.txt");
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        [DataRow ("B21|Soda|1.50|B")]
        [DataRow ("B1|Soda|1050|B")]
        [DataRow ("B1|Soda|10,000|B")]
        [DataRow ("B1|Soda|1.50|R")]
        [DataRow ("B1|Soda|1|R")]
        [DataTestMethod]
        public void CheckInputFileFormat_IncorretFileFormats_ReturnsTrue(string incorrectLine)
        {
            // Arrange 
            try
            {
                // creates and writes one line of each type to a input file
                using (System.IO.StreamWriter write = new System.IO.StreamWriter(@"C:\Catering\testInputFile.csv"))
                {
                    write.WriteLine(incorrectLine);
                }

                // create FileAccess object to call method
                FileAccess testFile = new FileAccess();
                var testList = testFile.ReadFileToList(@"C:\Catering\testInputFile.csv");

                // Act 
                bool actual = testFile.CheckInputFileFormat(testList);

                // Assert
                Assert.IsTrue(actual);


                // delete the test log file when test is done
                System.IO.File.Delete(@"C:\Catering\testInputFile.csv");
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
