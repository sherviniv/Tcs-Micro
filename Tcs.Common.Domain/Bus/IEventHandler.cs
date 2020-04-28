using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tcs.Common.Domain.Events;

namespace Tcs.Common.Domain.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler
        where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {

    }

}
