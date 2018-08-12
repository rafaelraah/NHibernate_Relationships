using NHibernate;
using NHibernate_Relationships.Models;
using NHibernate_Relationships.Models.NHibernate;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NHibernate_Relationships.Controllers
{
    public class HomeController : Controller
    {
        //public object ISessionNHibernateHelper { get; private set; }

        // GET: Home
        public ActionResult Index()
        {
            //Testes
            IList<Pessoa> pessoas;
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var carros = session.QueryOver<Carro>().List();
                var TiposInvestimentos = session.QueryOver<TipoInvestimento>().List();
                pessoas = session.QueryOver<Pessoa>().List();
            }

            return View(pessoas);

        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            Pessoa pessoa;
            ISession session = NHibernateHelper.OpenSession();
            pessoa = session.Get<Pessoa>(id);
            return View(pessoa);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(Pessoa pessoa)
        {
            try
            {
                // TODO: Add insert logic here
                using (ISession session = NHibernateHelper.OpenSession()) {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(pessoa);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View(NHibernateHelper.OpenSession().Get<Pessoa>(id));
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Pessoa pessoa)
        {
            try
            {
                // TODO: Add update logic here
                using(var sessao = NHibernateHelper.OpenSession())
                {
                    using(var transacao = sessao.BeginTransaction())
                    {
                        sessao.Update(pessoa);
                        transacao.Commit();
                    }
                }

                return RedirectToAction("Index", new { atualizado = "ok"});
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View(NHibernateHelper.OpenSession().Get<Pessoa>(id));
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (var transacao = session.BeginTransaction())
                    {
                        session.Delete(session.Get<Pessoa>(id));
                        transacao.Commit();
                    }
                    return RedirectToAction("Index", new { excluido = "ok" });
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Investir()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ViewData["pessoas"] = session.QueryOver<Pessoa>().List();
                ViewData["tiposInvestimentos"] = session.QueryOver<TipoInvestimento>().List();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Investir(Investimento investimento)
        {
            var formulario = Request.Form;
            investimento.DataCriacao = DateTime.Now;

            using(ISession session = NHibernateHelper.OpenSession())
            {
                investimento.Pessoa = session.Get<Pessoa>(Convert.ToInt32(formulario["pessoaSelecionada"]));
                investimento.TipoInvestimento = session.Get<TipoInvestimento>(Convert.ToInt32(formulario["tipoInvestimentoSelecionado"]));

                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(investimento);
                    transaction.Commit();
                }
                return RedirectToAction("Index", new { investimento = "ok" });
            }
        }


    }
}
