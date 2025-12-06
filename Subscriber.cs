using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sage
{
    public interface Subscriber
    {
        void Update(string message);
    }
}
