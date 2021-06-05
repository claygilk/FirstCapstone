using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class CateringTest
    {
        [TestMethod]
        public void ToStringOverride_ReturnsCorrectString()
        {
            // Arrange
            Catering order = new Catering();
            CateringItem item = new CateringItem();

            string[] testInfo = { "B1", "Soda", "1.50", "B" };
            item.ItemInfo = testInfo;
            order.AvailableItems.Add(item);

            string expected = "B1 |";

            // Act
            string actual = order.ToString();

            // Assert
            Assert.AreEqual(expected, actual);

        }
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
        public void LookUpByCode_B1_ReturnsSodaItem()
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
        public void LookUpByCode_CodeNotFound_ReturnsNull()
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
        public void LookUpByCode_EmptyString_ReturnsNull()
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
