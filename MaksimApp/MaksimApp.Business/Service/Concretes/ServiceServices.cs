using MaksimApp.Business.Excepton;
using MaksimApp.Business.Service.Abstracts;
using MaksimApp.Core.Models;
using MaksimApp.Core.RepositoryAbstracts;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaksimApp.Business.Service.Concretes
{
    public class ServiceServices : IServiceServices
    {
        private readonly IServicesRepository _servicesRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ServiceServices(IServicesRepository servicesRepository,IWebHostEnvironment webHostEnvironment)
        {
            _servicesRepository = servicesRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public void AddServices(Services services)
        {
            if (!services.PhotoFile.ContentType.Contains("image/")) 
                throw new FileContentException("PhotoFile", "Content type dogru deyil");
            if (services.PhotoFile.Length > 2097152)
                throw new FileSizeException("PhotoFile", "File size error!!!");
            string path=_webHostEnvironment.WebRootPath+@"\Upload\Service\"+services.PhotoFile.FileName;
            using(FileStream stream =new FileStream(path, FileMode.Create))
            {
                services.PhotoFile.CopyTo(stream);
            }
            services.ImageUrl = services.PhotoFile.FileName;
            _servicesRepository.Add(services);
            _servicesRepository.Commit();

        }

        public List<Services> GetAllServices(Func<Services, bool>? func = null)
        {
            return _servicesRepository.GetAll(func);    
        }

        public Services GetServices(Func<Services, bool>? func = null)
        {
            return _servicesRepository.Get(func);
        }

        public void RemoveServices(int id)
        {
            var service= _servicesRepository.Get(x=> x.Id == id);
            if (service == null) throw new NullReferenceException("Bele bir servis yoxdur");
            string path = _webHostEnvironment.WebRootPath + @"\Upload\Service\" + service.ImageUrl;
            if(!File.Exists(path)) throw new FileNameNotFoundException("PhotoFile","Bele bir sey yoxdu");
            File.Delete(path);
            _servicesRepository.Delete(service);
               _servicesRepository.Commit();

        }

        public void UpdateServices(int id, Services services)
        {
            var oldservice = _servicesRepository.Get(x => x.Id == services.Id);
            if(oldservice == null) throw new NullReferenceException();
            if(services.PhotoFile != null)
            {
				if (!services.PhotoFile.ContentType.Contains("image/"))
					throw new FileContentException("PhotoFile", "Content type dogru deyil");
				if (services.PhotoFile.Length > 2097152)
					throw new FileSizeException("PhotoFile", "File size error!!!");
				string path = _webHostEnvironment.WebRootPath + @"\Upload\Service\" + services.PhotoFile.FileName;
				using (FileStream stream = new FileStream(path, FileMode.Create))
				{
					services.PhotoFile.CopyTo(stream);
				}
                oldservice.ImageUrl=services.PhotoFile.FileName;
			}
            oldservice.Title = services.Title;
            oldservice.Description = services.Description;
            _servicesRepository.Commit();
        }
    }
}
