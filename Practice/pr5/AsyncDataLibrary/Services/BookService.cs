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
    public class BookService
    {
        private IRepository<Book> _repo;

        public BookService(IDataSerializer repo, string path)
        {
            _repo = new Repository<Book>(path, repo);
        }

        public async Task<Result> Add(string name, string authorName)
        {
            try
            {
                await _repo.AddAsync(new Book
                {
                    name = name,
                    author = authorName
                });
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result> Delete(int id)
        {
            try
            {
                await _repo.DeleteAsync(id);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _repo.GetAllAsync();
        }
    }
}
