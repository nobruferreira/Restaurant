using System;

namespace Restaurant.SharedKernel.Events.Contracts
{
    public interface IDomainEvent
    {
        DateTime DateOcurred { get; }
    }
}
