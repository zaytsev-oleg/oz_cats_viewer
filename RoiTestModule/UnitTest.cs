using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReturnOnIntelligence.Helpers;
using ReturnOnIntelligence.Models;

namespace RoiTestModule
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void RequestHelper_GetImages_WithoutCategory()
        {
            var requestHelper = new RequestHelper();
            var images = requestHelper.GetImages(new RequestParameters
            {
                PageIndex = 1
            }).Result;
            
            Assert.AreEqual(images.Length, 0);
        }

        [TestMethod]
        public void RequestHelper_GetImages_WithWrongCategory()
        {
            var requestHelper = new RequestHelper();
            var images = requestHelper.GetImages(new RequestParameters
            {
                Category = "xyz"
            }).Result;

            Assert.IsTrue(images.Length == 0);
        }

        [TestMethod]
        public void RequestHelper_GetImages_WithCategory()
        {
            var requestHelper = new RequestHelper();
            var images = requestHelper.GetImages(new RequestParameters
            {
                Category = "space"
            }).Result;

            Assert.IsTrue(images.Length > 0);
        }

        [TestMethod]
        public void RequestHelper_GetCategories()
        {
            var requestHelper = new RequestHelper();
            var categories = requestHelper.GetCategories().Result;

            Assert.IsTrue(categories.Length > 0);
        }
    }
}
