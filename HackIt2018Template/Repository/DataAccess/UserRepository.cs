using Models.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private static string baseUrl = "https://sportfinderapi.azurewebsites.net/api/";

        public async Task<User> GetUserAsync(int userId)
        {
            var userString = await GetStringAsync(baseUrl + "Users/GetById?id=" + userId);
            var user = JsonConvert.DeserializeObject<User>(userString);
            return user;
        }

        private static async Task<string> GetStringAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync(url);
            }
        }
    }
}
