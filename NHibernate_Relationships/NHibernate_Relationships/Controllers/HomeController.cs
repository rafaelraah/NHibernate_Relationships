using NHibernate;
using NHibernate_Relationships.Models;
using NHibernate_Relationships.Models.NHibernate;
using System.Web.Mvc;

namespace NHibernate_Relationships.Controllers
{
    public class HomeController : Controller
    {
        public object ISessionNHibernateHelper { get; private set; }

        // GET: Home
        public ActionResult Index()
        {
            //Testes
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var carros = session.QueryOver<Carro>().List();
                var pessoas = session.QueryOver<Pessoa>().List();
            }

            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

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
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
