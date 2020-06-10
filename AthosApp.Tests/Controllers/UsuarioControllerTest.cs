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
    public class UsuarioControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            UsuarioController controller = new UsuarioController();
            
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AbrirCriar()
        {
            // Arrange
            UsuarioController controller = new UsuarioController();

            // Act
            ViewResult result = controller.Criar() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AbrirEditar()
        {
            // Arrange
            UsuarioController controller = new UsuarioController();
            
            // Act
            ViewResult result = controller.Editar(0) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void ListarUsuarios()
        {
            // Arrange
            UsuarioController controller = new UsuarioController();

            var result = controller.ListarUsuarios();

            var expected = JsonConvert.SerializeObject(LiteDBClass.ListarTodosUsuario());

            // Assert
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void CriarEditarDeletarUsuario()
        {
            // Arrange
            UsuarioController controller = new UsuarioController();

            var usuarios = LiteDBClass.ListarTodosUsuario();

            // Act
            var result = controller.CriarUsuario("NomeUsuario", "usuario@email.com", 1, 1);
            
            var usuariosComNovo = LiteDBClass.ListarTodosUsuario();

            if (usuarios.Count() + 1 != usuariosComNovo.Count())
                Assert.Fail();
            
            // Assert
            Assert.IsTrue(result);

            var usuario = usuariosComNovo.Last();

            result = controller.Atualizar(usuario.Id, "NomeusuarioNovo", "usuario@novoemail.com", 4, 2);

            var usuarioEditado = (Usuario)LiteDBClass.GetObject(usuario.Id, Objetos.Usuario);

            if (usuarioEditado.Nome == usuario.Nome || usuarioEditado.Email == usuario.Email || usuarioEditado.IdCondominio == usuario.IdCondominio || usuarioEditado.TipoUsuario == usuario.TipoUsuario)
            {
                Assert.Fail();
            }

            Assert.IsTrue(result);

            ViewResult resultView = controller.Delete(usuarioEditado.Id) as ViewResult;
            
            Assert.IsNotNull(resultView);

            if (LiteDBClass.ListarTodosUsuario().Count != usuarios.Count())
                Assert.Fail();

            Assert.IsTrue(result);
        }

    }
}
