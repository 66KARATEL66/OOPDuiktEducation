using AsyncDataLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsyncDataLibrary.Interfaces;
using AsyncDataLibrary.Repositories;
using AsyncDataLibrary.Models;
using AsyncDataLibrary.Infrastructure;

namespace AsyncDataLibrary.Services
{
    public class UserService
    { 
        private IRepository<User> _repo;

        public UserService(IDataSerializer repo, string path)
        {
            _repo = new Repository<User>(path, repo);
        }

        public async Task<Result> Add(string username, string password, string email)
        {
            if ((await _repo.FindAsync(e => e.email == email)).Any())
            {
                return Result.Failure("Email already exists");
            }

            await _repo.AddAsync(new User
            {
                createdAt = DateTime.UtcNow,
                email = email,
                password = password,
                username = username
            });

            return Result.Success();
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

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _repo.GetAllAsync();
        }
    }
}
