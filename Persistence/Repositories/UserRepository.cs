using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Repositories;
using HealthCare.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> ListAsync(int pageSize, int pageFirstIndex, string searchVal, string sortCol, int sortOrd, bool paging)
        {
            if (searchVal == null || (searchVal != null) && (searchVal.Trim().Equals("") || searchVal.Equals("null")))
            {
                return await _context.Users.Take(pageSize).ToListAsync();
            }
            else {
                return null;
              //      await _context.Users.Where(p => p.Name.ToLower().Contains(searchVal.ToLower())
            // p.NameLat.ToLower().Contains(searchVal.ToLower()) || p.ExternalCode.ToLower().Contains(searchVal.ToLower())).Take(pageSize).ToListAsync();
        }
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public User FindByUsername(string username)
        {
            User user;
            try
            {
                user = _context.Users.Where(p => p.Username == username).First();
            } catch (Exception ex)
            {
                return null;
            }
            return user;
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }
    }
}
