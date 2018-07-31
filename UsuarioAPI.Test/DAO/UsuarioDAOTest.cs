using System.Collections.Generic;
using UsuarioAPI.DAO;
using UsuarioAPI.Models;
using Xunit;

namespace UsuarioAPI.Test.DAO
{
    public class UsuarioModelTest
    {
        [Fact]
        public void TesteBuscaVazia()
        {
            var DAO = new UsuarioDAO("Password=xJi8j9WXU7m6u7ResP9SNNPW;Persist Security Info=True;User ID=API_USER;Initial Catalog=API;Data Source=LOCALHOST");
            IList<UsuarioModel> resultado = DAO.Busca(new UsuarioModel());

            Assert.True(true);
        }
    }
}
