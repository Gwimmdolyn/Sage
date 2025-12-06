using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sage
{
    public interface Observer
    {
        void AddSubscriber(Subscriber subscriber);
        void RemoveSubscriber(Subscriber subscriber);
        void NotifySubscribers(string message);
    }
}
