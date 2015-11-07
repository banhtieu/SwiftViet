using SwiftViet.Data.Models;
using System.Linq;
using MongoDB.Bson;
using System.Collections.Generic;
using MongoDB.Driver;
using System.Linq.Expressions;
using System;

namespace SwiftViet.Data.Repository.Mongo
{

    /// <summary>
    /// The Mongo Repository
    /// </summary>
    public class MongoRepository<T> : IRepository<T> where T : Entity
    {

        /// <summary>
        /// 
        /// </summary>
        private IMongoCollection<T> collection;

        /// <summary>
        /// Start a repository
        /// </summary>
        /// <param name="database"></param>
        public MongoRepository(IMongoDatabase database)
        {
            collection = database.GetCollection<T>(typeof(T).Name);
        }

        /// <summary>
        /// Delete the item
        /// </summary>
        /// <param name="item"></param>
        public void Remove(T item)
        {
            collection.DeleteOneAsync(data => data.Id == item.Id).Wait();
        }


        /// <summary>
        /// Find an object
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public T Find(Expression<Func<T, bool>> filter = null)
        {
            return FindAll(filter, 0, 1).FirstOrDefault();
        }


        /// <summary>
        /// Find All Object
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<T> FindAll(Expression<Func<T, bool>> filter = null, int? start = null, int? count = null)
        {
            if (filter == null)
            {
                filter = item => true;
            }

            var query = collection.Find(filter).Skip(start).Limit(count);
            var task = query.ToListAsync();
            task.Wait();
            return task.Result;
        }


        /// <summary>
        /// Find by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T FindById(ObjectId id)
        {
            var result = Find(item => item.Id == id);
            return result;
        }


        /// <summary>
        /// Save the Item in collection
        /// </summary>
        /// <param name="item"></param>
        public void Save(T item)
        {
            var existingItem = FindById(item.Id);

            if (existingItem != null)
            {
                collection.ReplaceOneAsync(data => data.Id == item.Id, item).Wait();
            }
            else
            {
                collection.InsertOneAsync(item);
            }
        }
    }
}
