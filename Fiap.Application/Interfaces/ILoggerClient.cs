using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Application.Interfaces
{
    public interface ILoggerClient
    {
        public void Log(string request);
    }
}
