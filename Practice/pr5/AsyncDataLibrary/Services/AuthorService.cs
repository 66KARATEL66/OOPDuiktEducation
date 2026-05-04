using AsyncDataLibrary.Interfaces;
using AsyncDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDataLibrary.Services
{
    public class AuthorService
    {
        private string _path;
        private IRepository<Author> _repo;

        public AuthorService(IRepository<Author> repo, string path)
        {
            _repo = repo;
            _path = path;
        }

        /*public async Task<Result> Add()
        {
            try
            {
                await _repo.AddAsync(new Author
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
        }*/
    }
}
