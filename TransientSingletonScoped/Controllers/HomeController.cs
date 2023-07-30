using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TransientSingletonScoped.Interfaces;
using TransientSingletonScoped.Models;

namespace TransientSingletonScoped.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITransient _transient;
        private readonly ITransient _transient2;
        private readonly IScoped _scoped;
        private readonly IScoped _scoped2;
        private readonly ISingleton _singleton;
        private readonly ISingleton _singleton2;

        public HomeController(ITransient transient, ITransient transient2, 
            IScoped scoped, IScoped scoped2, 
            ISingleton singleton, ISingleton singleton2)
        {
            _transient = transient;
            _transient2 = transient2;
            _scoped2 = scoped2;
            _scoped = scoped;
            _singleton2 = singleton2;
            _singleton = singleton;
        }

        public IActionResult Index()
        {
            ViewBag.transient1 = _transient.GetOperationID().ToString();
            ViewBag.transient2 = _transient2.GetOperationID().ToString();
            ViewBag.scoped1 = _scoped.GetOperationID().ToString();
            ViewBag.scoped2 = _scoped2.GetOperationID().ToString();
            ViewBag.singleton1 = _singleton.GetOperationID().ToString();
            ViewBag.singleton2 = _singleton2.GetOperationID().ToString();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}