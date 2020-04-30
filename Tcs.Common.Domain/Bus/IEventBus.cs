using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tcs.Common.Domain.Commands;
using Tcs.Common.Domain.Events;

namespace Tcs.Common.Domain.Bus
{
    public interface IEventBus
    {
        Task<bool> SendCommand<T>(T command) where T : Command;

        void Publish<T>(T @event) where T : Event;

        void Subscribe<T, TH>() 
            where T : Event 
            where TH : IEventHandler<T>;
    }
}
