using Microsoft.AspNetCore.Mvc;
using webMVC_thingamabob.Models;

namespace webMVC_thingamabob.Controllers
{
    public class ContatoController : Controller
    {
        public ActionResult Index()
        {
            using (ContatoModel model = new ContatoModel())
                            {
                List<Contato> lista = model.Read();
                return View(lista);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            Contato contato = new Contato();
            contato.Nome = form["Nome"];
            contato.Email = form["Email"];

            using (ContatoModel model = new ContatoModel())
            {
                model.Create(contato);
                return RedirectToAction("Index");
            }
        }
    }
}
