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
        public void CreateCateringItemsFromList()
        {
            // Arrange
            //FileAccess fileAccess = new FileAccess();
            //List<string[]> test = new List<string[]>
            //{

            //}

            // Act

            // Assert
        }
    }
}
