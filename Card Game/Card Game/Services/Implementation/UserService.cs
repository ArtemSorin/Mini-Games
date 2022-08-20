using Card_Game.Models;
using Card_Game.Services.Interface;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Game.Services.Implementation
{
    public class UserService : IEUserService
    {
        FirebaseClient firebase = new FirebaseClient(Settings.FireBaseDatabaseUrl, new FirebaseOptions
        {
            AuthTokenAsyncFactory = () => Task.FromResult(Settings.FireBaseSeceret)
        });

        public async Task<bool> AddOrUpdateUser(User user)
        {
            if(!string.IsNullOrWhiteSpace(user.Key))
            {
                try
                {
                    await firebase.Child(nameof(User)).Child(user.Key).PutAsync(user);
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
            else
            {
                var responce = await firebase.Child(nameof(User)).PostAsync(user);
                if(responce.Key != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<bool> DeleteUser(string key)
        {
            try
            {
                await firebase.Child(nameof(User)).Child(key).DeleteAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<List<User>> GetAllUser()
        {
            return (await firebase.Child(nameof(User)).OnceAsync<User>()).Select(f => new User
            {
                Name = f.Object.Name,
                Progress = f.Object.Progress,
                Key = f.Key
            }).ToList();
        }
    }
}
