﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Solution.Models;

namespace HairSalon.Solution.Controllers
{
    public class HomeController : Controller
    {

        [TestClass]
        public class HomeControllerTest
        {

          [TestMethod]
          public void Index_ReturnsCorrectView_True()
          {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ActionResult indexView = controller.Index();

            //Assert
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
          }

          [TestMethod]
          public void Index_HasCorrectModelType_ItemList()
          {
            //Arrange
            ViewResult indexView = new HomeController().Index() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<Item>));
          }
        }
    }
}