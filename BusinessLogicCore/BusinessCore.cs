using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicCore
{
    public class BusinessCore
    {
        public long DoSomeWork(string payload)
        {
            return payload.Length * DateTime.Now.Ticks;
        }
    }
}
