using Card_Game.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Card_Game.Services.Interface
{
    public interface IEUserService
    {
        Task<bool> AddOrUpdateUser(User user);
        Task<bool> DeleteUser(string key);
        Task<List<User>> GetAllUser();
    }
}
