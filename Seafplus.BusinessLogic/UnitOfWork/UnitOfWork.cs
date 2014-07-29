using Seafplus.BusinessLogic.DataModel;

namespace Seafplus.BusinessLogic.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
		private readonly EntityContainer _context;

		public UnitOfWork(EntityContainer context)
        {
            _context = context;
        }

		public EntityContainer Context
        {
            get { return _context; }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
       
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }            
        }
    }
}
