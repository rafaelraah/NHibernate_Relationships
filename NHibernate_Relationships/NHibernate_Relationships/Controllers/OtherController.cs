using NHibernate_Relationships.Models;
using NHibernate_Relationships.Models.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NHibernate_Relationships.Controllers
{
    public class OtherController : Controller
    {
        // GET: Other
        public JsonResult TesteData()
        {
            string dataAtual = DateTime.Now.ToString();
            return Json(dataAtual);
        }

        public JsonResult PessoaAleatoria()
        {
            using(var sessao = NHibernateHelper.OpenSession())
            {
                List<Pessoa> pessoas = sessao.Query<Pessoa>().ToList();
                int quantidade = pessoas.Count();
                Random random = new Random();
                int aleatorio = random.Next(quantidade-1);
                Pessoa pessoaAleatoria = pessoas[aleatorio];
                Object resultado = new { Nome = pessoaAleatoria.Nome };
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }

    }
}