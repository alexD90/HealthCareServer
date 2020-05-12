using HealthCare.API.Domain.Models;
using HealthCare.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace HealthCare.API.Domain.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        User GenerateToken(User user);
        string GetHash(HashAlgorithm hashAlgorithm, string input);
        bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash);
      /*  Task<IEnumerable<User>> ListAsync(int pageSize, int pageFirstIndex, string searchVal, string sortCol, int sortOrd, bool paging);
        Task<UserResponse> SaveAsync(User user);
        Task<UserResponse> UpdateAsync(int id, User user);
        Task<UserResponse> DeleteAsync(int id);*/

    }
}
