using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AthosApp;
using AthosApp.Controllers;
using AthosApp.Areas;
using AthosApp.Database;
using AthosApp.Models;

namespace AthosApp.Tests.Controllers
{
    [TestClass]
    public class EnvioControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            EnvioController controller = new EnvioController();
            
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EnviarEmail()
        {
            // Arrange
            EnvioController controller = new EnvioController();

            var result = controller.Enviar(1, 1, "CorpoTeste");

            Assert.IsTrue(result);

        }

    }
}
