using MongoDB.Bson;
using SwiftViet.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SwiftViet.Data.Repository
{

    /// <summary>
    /// The General Repository
    /// </summary>
    public interface IRepository<T> where T : Entity
    {
        /// <summary>
        /// Get the Object by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T FindById(ObjectId id);

        /// <summary>
        /// Find first object
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        T Find(Expression<Func<T, bool>> filter = null);

        /// <summary>
        /// Find all object with input filter
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<T> FindAll(Expression<Func<T, bool>> filter = null, int? start = null, int? count = null);


        /// <summary>
        /// Save the item to database
        /// </summary>
        /// <param name="item"></param>
        void Save(T item);

        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="item"></param>
        void Remove(T item);

    }
}
