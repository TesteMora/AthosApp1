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
    public class CondominioControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            CondominioController controller = new CondominioController();
            
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AbrirCriar()
        {
            // Arrange
            CondominioController controller = new CondominioController();

            // Act
            ViewResult result = controller.Criar() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AbrirEditar()
        {
            // Arrange
            CondominioController controller = new CondominioController();
            
            // Act
            ViewResult result = controller.Editar(0) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ListarCondos()
        {
            // Arrange
            CondominioController controller = new CondominioController();

            var result = controller.ListarCondos();

            var expected = JsonConvert.SerializeObject(LiteDBClass.ListarTodosCondominio());

            // Assert
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void CriarEditarDeletarCondominio()
        {
            // Arrange
            CondominioController controller = new CondominioController();

            var condominios = LiteDBClass.ListarTodosCondominio();

            // Act
            var result = controller.CriarCondominio(-1, "NomeCondominio", 2, 1);
            
            var condominiosComNovo = LiteDBClass.ListarTodosCondominio();

            if (condominios.Count() + 1 != condominiosComNovo.Count())
                Assert.Fail();
            
            // Assert
            Assert.IsTrue(result);

            var condominio = condominiosComNovo.Last();

            result = controller.Edit(condominio.Id, "NomeCondominio2", 4, 2);

            var condominioEditado = (Condominio)LiteDBClass.GetObject(condominio.Id, Objetos.Condominio);

            if(condominioEditado.NomeCondominio == condominio.NomeCondominio || condominioEditado.Responsavel == condominio.Responsavel || condominioEditado.IdAdministradora == condominio.IdAdministradora)
            {
                Assert.Fail();
            }

            Assert.IsTrue(result);

            result = controller.Delete(condominioEditado.Id);

            if (LiteDBClass.ListarTodosCondominio().Count != condominios.Count())
                Assert.Fail();

            Assert.IsTrue(result);
        }

    }
}
