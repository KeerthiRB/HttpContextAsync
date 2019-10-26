using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.interfaceaccess
{
    public interface IMessages
    {
        Task<IEnumerable<string>> GetMessages();
        Task<string> GetMessage(int id);
    }
}

