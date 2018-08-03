using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UsuarioAPI.DAO;
using UsuarioAPI.Models;

namespace UsuarioAPI.Controllers
{
    public class UsuarioController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get([FromUri]int id)
        {
            try
            {
                var DAO = new UsuarioDAO();
                var model = new UsuarioModel
                {
                    IdUsuario = id
                };

                return Request.CreateResponse(HttpStatusCode.OK, DAO.Busca(model));

            }catch(Exception Ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage Post(UsuarioModel model)
        {
            try
            {
                var DAO = new UsuarioDAO();
                DAO.Cadastro(model);

                return Request.CreateResponse(HttpStatusCode.OK);

            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage Pesquisa(UsuarioModel model)
        {
            try
            {
                var DAO = new UsuarioDAO();
                
                return Request.CreateResponse(HttpStatusCode.OK, DAO.Busca(model));

            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, Ex.Message);
            }
        }


    }
}
