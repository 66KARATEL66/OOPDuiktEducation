using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsyncDataLibrary.Interfaces;
using AsyncDataLibrary.Infrastructure;
using System.Diagnostics.CodeAnalysis;
using System.Data;

namespace AsyncDataLibrary.Repositories
{
    public class Repository<T> : IRepository<T> where T : class 
    {
        private string _path;
        private IDataSerializer _serializer;

        public Repository(string path, IDataSerializer serializer)
        {
            _path = path;
            _serializer = serializer;
        }

        public async Task AddAsync(T entity)
        {
            var data = (await GetAllAsync()).ToList();
            var id = typeof(T).GetProperty("id");
            id.SetValue(entity, data.Count + 1);
            data.Add(entity);
            _serializer.Serialize(data, _path);
        }

        public async Task DeleteAsync(int id)
        {
            var data = (await GetAllAsync()).Where(e => GetId(e) != id).ToList();
            _serializer.Serialize(data, _path);
        }

        public async Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate)
        {
            var data = await GetAllAsync();
            return data.Where(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _serializer.Deserialize<List<T>>(_path);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var data = await GetAllAsync();
            return data.FirstOrDefault(e => GetId(e) == id);
        }

        public async Task UpdateAsync(T entity)
        {
            var data = (await GetAllAsync()).ToList();

            var index = data.FindIndex(e => GetId(e) == GetId(entity));
            if(index >= 0)
            {
                data[index] = entity;
                await _serializer.Serialize(data, _path);
            }
        }

        private int GetId(T entity)
        {
            var prop = typeof(T).GetProperty("id");
            if (prop == null)
                throw new Exception("I must have Id property");

            return (int)prop.GetValue(entity);
        }
    }
}
