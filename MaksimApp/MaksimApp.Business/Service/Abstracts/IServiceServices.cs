using MaksimApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaksimApp.Business.Service.Abstracts
{
    public interface IServiceServices
    {
        void AddServices(Services services);
        void RemoveServices(int id);
        void UpdateServices(int id, Services services); 
        Services GetServices(Func<Services,bool>? func=null);
        List<Services> GetAllServices(Func<Services, bool>? func = null);

    }
}
