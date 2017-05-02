using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ead_Mini_project_3.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using ead_Mini_project_3.Models;


namespace UnitTests
{
    [TestClass]
    public class ShowsControllerTest
    {
        [TestMethod]
        public void TestDetailsView()
        {
            var controller = new ShowsController();
            var result = controller.Details(2) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);

        }
    }
}
