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
    public class AdministradorControllerTest
    {
        [TestMethod]
        public void ListarAdm()
        {
            AdministradoraController controller = new AdministradoraController();

            var result = controller.ListarAdm();

            var expected = JsonConvert.SerializeObject(LiteDBClass.ListarTodasAdministradoras());

            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void CriarEDeletarAdm()
        {
            AdministradoraController controller = new AdministradoraController();

            var administradoras = LiteDBClass.ListarTodasAdministradoras();
            
            var result = controller.CreateAdm("NomeAdministradora");

            var adminsComNovo = LiteDBClass.ListarTodasAdministradoras();

            if (administradoras.Count() + 1 != adminsComNovo.Count())
                Assert.Fail();
            
            Assert.IsTrue(result);

            var administradora = adminsComNovo.Last();

            result = controller.Delete(administradora.Id);

            if (LiteDBClass.ListarTodosCondominio().Count != administradoras.Count())
                Assert.Fail();

            Assert.IsTrue(result);
        }




    }
}
