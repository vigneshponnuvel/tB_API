using NUnit.Framework;
using shopBridge.DataProvider;
using shopBridge.Controllers;

namespace NUnit_shopBridge
{
    //Unit Test Cases
    public class Tests
    {
        ItemController itemController;
        IItemDataProvider itemDataProvider;

        [SetUp]
        public void Setup()
        {
            itemDataProvider = new ItemServiceFake();
            itemController = new ItemController(itemDataProvider);
        }

        public Tests()
        {

        }

        //Test to check Get One action
        [Test]
        public void TestGetOneItem()
        {
            var result = itemController.GetOne(150);
            Assert.Pass();
        }
    }
}