using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Implementations
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoContext _context;

        public UnitOfWork(IMongoContext context)
        {
            _context = context;
        }

        public async Task<int> Save()
        {
            var changeAmount = await _context.SaveChanges();

            return changeAmount;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
