using AsyncDataLibrary.Interfaces;
using AsyncDataLibrary.Models;
using AsyncDataLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDataLibrary.Services
{
    public class OrderService
    {
        private IRepository<Order> _repo;

        public OrderService(IDataSerializer repo, string path)
        {
            _repo = new Repository<Order>(path, repo);
        }

        public async Task<Result> Add(Book book, User user)
        {
            try
            {
                await _repo.AddAsync(new Order
                {
                    books = new List<Book>() { book },
                    user = user
                });
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _repo.GetAllAsync();
        }
    }
}
