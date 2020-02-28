using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Connection
{
    public interface IConnectSQL
    {
        string GetConnectionString();
    }
}
