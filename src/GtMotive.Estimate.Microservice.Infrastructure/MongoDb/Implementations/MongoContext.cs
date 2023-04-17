using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Implementations
{
    public sealed class MongoContext : IMongoContext
    {
        private readonly List<Func<Task>> _commands;

        private readonly MongoServiceConfig _mongoService;

        public MongoContext(MongoServiceConfig mongoService)
        {
            _mongoService = mongoService;

            // Every command will be stored and it'll be processed at SaveChanges
            _commands = new List<Func<Task>>();
        }

        public IClientSessionHandle Session { get; set; }

        public MongoClient MongoClient { get; set; }

        private IMongoDatabase Database { get; set; }

        public async Task<int> SaveChanges()
        {
            ConfigureMongo();

            var commandTasks = _commands.Select(c => c());

            await Task.WhenAll(commandTasks);

            var count = _commands.Count;
            _commands.Clear();

            return count;
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            ConfigureMongo();

            return Database.GetCollection<T>(name);
        }

        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }

        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }

        private void ConfigureMongo()
        {
            if (MongoClient != null)
            {
                return;
            }

            MongoClient = _mongoService.MongoClient;

            Database = _mongoService.Database;
        }
    }
}
