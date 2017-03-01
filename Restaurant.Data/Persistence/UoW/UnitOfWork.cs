using Restaurant.Data.Persistence.DataContexts;

namespace Restaurant.Data.Persistence.UoW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private RestaurantDataContext _context;

        public UnitOfWork(RestaurantDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
