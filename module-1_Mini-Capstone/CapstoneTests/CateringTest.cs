using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class CateringTest
    {
        [TestMethod]
        public void CateringInstanceShouldBeCreated()
        {
            // Arrange 
            Catering catering = new Catering();
            // Act

            // Assert
            Assert.IsNotNull(catering);
        }
        [TestMethod]
        public void LookUpByCode_()
        {
            // Arrange 
            string testItem = "B1";
            FileAccess inventory = new FileAccess();
            Catering catering = inventory.LoadInventory();
            // Act
            CateringItem result = catering.LookUpByCode(testItem);
            // Assert
            Assert.AreEqual("Soda", result.Name);
        }
        [TestMethod]
        public void LookUpByCode_CodeNotFound()
        {
            // Arrange 
            string testItem = "A5";
            FileAccess inventory = new FileAccess();
            Catering catering = inventory.LoadInventory();
            // Act
            CateringItem result = catering.LookUpByCode(testItem);
            // Assert
            Assert.AreEqual(null, result);
        }
        [TestMethod]
        public void LookUpByCode_EmptyStringReturnsNull()
        {
            // Arrange 
            string testItem = "";
            FileAccess inventory = new FileAccess();
            Catering catering = inventory.LoadInventory();
            // Act
            CateringItem result = catering.LookUpByCode(testItem);
            // Assert
            Assert.AreEqual(null, result);
        }
    }
}
