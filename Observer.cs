using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SageNew
{
    public interface IObserver
    {
        void AddSubscriber(ISubscriber subscriber);
        void RemoveSubscriber(ISubscriber subscriber);
        void NotifySubscribers(string message);
    }
}
