using MaksimApp.Business.Service.Abstracts;
using MaxsimApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MaxsimApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceServices _serviceServices;

		public HomeController(IServiceServices serviceServices)
		{
			_serviceServices = serviceServices;
		}

		public IActionResult Index()
        {
            var services=_serviceServices.GetAllServices(); 
            return View(services);
        }

       
    }
}