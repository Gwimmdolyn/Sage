using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sage
{
    public class Logs : ISubscriber
    {
        public void Update(string message)
        {
            Console.WriteLine("[LOG] " + message);
        }
    }
}
