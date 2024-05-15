using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaksimApp.Business.Excepton
{
    public class DuplicateServiceException : Exception
    {
        public DuplicateServiceException(string? message) : base(message)
        {
        }
    }
}
