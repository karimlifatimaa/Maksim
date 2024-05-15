using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaksimApp.Business.Excepton
{

    public class FileNameNotFoundException : Exception
    {
        public string PropertyName { get; set; }
        public FileNameNotFoundException(string? message, string propertyName) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
