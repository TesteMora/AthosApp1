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
using Newtonsoft.Json;

namespace AthosApp.Tests.Controllers
{
    [TestClass]
    public class AssuntoControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            AssuntoController controller = new AssuntoController();
            
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

 
        [TestMethod]
        public void ListarAssunto()
        {
            AssuntoController controller = new AssuntoController();

            var result = controller.ListarAssuntos();

            var expected = JsonConvert.SerializeObject(LiteDBClass.ListarTodosAssunto());

            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void CriarEDeletarAssunto()
        {
            AssuntoController controller = new AssuntoController();

            var assuntos = LiteDBClass.ListarTodosAssunto();

            var result = controller.Create(1);

            var assuntosComNovo = LiteDBClass.ListarTodosAssunto();

            if (assuntos.Count() + 1 != assuntosComNovo.Count())
                Assert.Fail();

            Assert.IsTrue(result);

            var assunto = assuntosComNovo.Last();

            result = controller.Delete(assunto.Id);

            if (LiteDBClass.ListarTodosAssunto().Count != assuntos.Count())
                Assert.Fail();

            Assert.IsTrue(result);
        }


    }
}
