using MaksimApp.Core.Models;
using MaksimApp.Core.RepositoryAbstracts;
using MaksimApp.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaksimApp.Data.RepositoryConcretes
{
    public class ServicesRepository : GenericRepository<Services>, IServicesRepository
    {
        public ServicesRepository(AppDbContext context) : base(context)
        {
        }
    }
}
