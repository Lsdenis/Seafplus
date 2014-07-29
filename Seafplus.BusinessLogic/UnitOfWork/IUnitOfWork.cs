using System;
using Seafplus.BusinessLogic.DataModel;

namespace Seafplus.BusinessLogic.UnitOfWork
{    
    public interface IUnitOfWork : IDisposable
    {
		EntityContainer Context { get; }
        void Commit();        
    }
}
