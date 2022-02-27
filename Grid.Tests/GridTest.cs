using grid;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Grid.Tests
{
    [TestClass]
    public class GridTest
    {
        private List<Product> prList;
        private Product pr;

        [TestInitialize]
        public void TestsInitialize()
        {
            Debug.WriteLine("Initialize");

            pr.Name = "Test";
            pr.Description = "Test";
            pr.MinCostForAgent = 111;

            prList.Add(pr);
        }

        [TestMethod]
        public void CheckOut_Product()
        {
            CollectionAssert.Contains(prList, pr);
        }

        [TestMethod]
        public void Delete_Product()
        {
            int exp = 0;

            prList.Remove(pr);

            Assert.AreEqual(exp, prList.Count);
        }

        [TestMethod]
        public void AllItemsAreNotNull_Product()
        {
            CollectionAssert.AllItemsAreNotNull(prList);
        }

        [TestMethod]
        public void AllItemsAreUnique_Product()
        {
            CollectionAssert.AllItemsAreUnique(prList);
        }
    }
}
