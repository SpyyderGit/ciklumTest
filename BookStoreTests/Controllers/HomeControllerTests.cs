using BookStore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests 
    {
        [TestMethod()]
        public void IndexTest()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result); 
        }


        [TestMethod]
        public void IndexViewTest()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }




        [TestMethod()]
        public void BuyTest()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Buy(1) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void ViewEqualIndexTest()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Buy(1) as ViewResult;
            Assert.AreEqual("Buy", result.ViewName);
        }
     }
}