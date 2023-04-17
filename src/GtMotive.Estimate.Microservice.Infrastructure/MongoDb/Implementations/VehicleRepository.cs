using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Implementations
{
    public sealed class VehicleRepository : IRepository<Vehicle>
    {
        private readonly IMongoContext _context;

        private readonly IMongoCollection<Vehicle> _dbSet;

        public VehicleRepository(IMongoContext context)
        {
            _context = context;
            _dbSet = _context.GetCollection<Vehicle>(nameof(Vehicle));
        }

        public void Add(Vehicle entity)
        {
            _context.AddCommand(() => _dbSet.InsertOneAsync(entity));
        }

        public async Task<Vehicle> GetById(Guid id)
        {
            var data = await _dbSet.FindAsync(Builders<Vehicle>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        public async Task<IEnumerable<Vehicle>> GetAll()
        {
            var all = await _dbSet.FindAsync(Builders<Vehicle>.Filter.Empty);
            return all.ToList();
        }

        public void Update(Vehicle entity)
        {
            _context.AddCommand(() => _dbSet.ReplaceOneAsync(Builders<Vehicle>.Filter.Eq("_id", entity.VehicleId), entity));
        }

        public void Remove(Guid id)
        {
            _context.AddCommand(() => _dbSet.DeleteOneAsync(Builders<Vehicle>.Filter.Eq("_id", id)));
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
