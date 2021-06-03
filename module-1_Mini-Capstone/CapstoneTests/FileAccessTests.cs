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
            List<string[]> actualItem = fileAccess.ReadFileToList();

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
            Assert.AreEqual("a", actual.Items[0].ItemInfo[0]);
            Assert.AreEqual("b", actual.Items[0].ItemInfo[1]);
            Assert.AreEqual("c", actual.Items[0].ItemInfo[2]);
        }
    }
}
