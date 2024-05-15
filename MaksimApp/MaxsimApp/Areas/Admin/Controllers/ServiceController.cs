using MaksimApp.Business.Excepton;
using MaksimApp.Business.Service.Abstracts;
using MaksimApp.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace MaxsimApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceServices _services;
       
        public ServiceController(IServiceServices services)
        {
            _services = services;
           
        }

        public IActionResult Index()
        {
            var services=_services.GetAllServices();
            return View(services);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Services services)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _services.AddServices(services);
            }
            catch (FileContentException ex)
            {
                ModelState.AddModelError(ex.PropertyName,ex.Message);
                return View();
            }
            catch(FileSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName,ex.Message);
                return View();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        { 
            var existservices= _services.GetServices(x=>x.Id==id);
            if(existservices==null)return NotFound();
            _services.RemoveServices(existservices.Id);

            return RedirectToAction("Index");
        }
  //      [HttpPost]
		//public IActionResult DeleteService(int id)
		//{
		//	var existservices = _services.GetServices(x => x.Id == id);
		//	if (existservices == null) return NotFound();
  //          _services.RemoveServices(id);
		//	return RedirectToAction("Index");
		//}
        public IActionResult Update(int id)
        {
			var existservices = _services.GetServices(x => x.Id == id);
			if (existservices == null) return NotFound();
            return View(existservices);
		}
        [HttpPost]
        public IActionResult Update(Services services)
        {
            if(!ModelState.IsValid) return View();
            _services.UpdateServices(services.Id, services);
            return RedirectToAction("Index");
        }
	}
}
