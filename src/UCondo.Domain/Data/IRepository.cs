using System;
using UCondo.Domain.Domain;

namespace UCondo.Domain.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}