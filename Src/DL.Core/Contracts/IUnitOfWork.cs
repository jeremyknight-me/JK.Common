using System;

namespace DL.Core.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
