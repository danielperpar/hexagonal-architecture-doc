using System;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface for the MongoDB persistence context.
    /// </summary>
    public interface IMongoContext : IDisposable
    {
        /// <summary>
        /// Add command to the list of commands to be executed.
        /// </summary>
        /// <param name="func">command to be executed.</param>
        void AddCommand(Func<Task> func);

        /// <summary>
        /// Commit changes.
        /// </summary>
        /// <returns>The number of applied changes to the DB.</returns>
        Task<int> SaveChanges();

        /// <summary>
        /// Get the collection of documents.
        /// </summary>
        /// <typeparam name="T">Type of the document.</typeparam>
        /// <param name="name">Name of the collection of documents.</param>
        /// <returns>Collection of documents.</returns>
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
