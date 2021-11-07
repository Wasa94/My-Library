﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace My_Library.Repository
{
    public interface IRepository<T>
    {
        Task<T> Add(T entity);
        Task<T> Delete(int id);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Update(T entity);
    }
}
