using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaksimApp.Business.Excepton
{
    public class FileContentException : Exception
    {
        public string PropertyName { get; set; }
        public FileContentException( string propertyName,string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
