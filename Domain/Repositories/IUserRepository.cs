using HealthCare.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync(int pageSize, int pageFirstIndex, string searchVal, string sortCol, int sortOrd, bool paging);
        Task AddAsync(User user);
        Task<User> FindByIdAsync(int id);
        User FindByUsername(string username);
        void Update(User user);
        void Remove(User user);
    }
}
