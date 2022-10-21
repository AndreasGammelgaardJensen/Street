using StreetService.DataAccess.ModelDTO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace StreetService.DataAccess
{
    public class SeedData
    {
        public static List<GroupDTO> RunSeedData()
        {
            var userdata = System.IO.File.ReadAllText("DataAccess/seedData.json");
            var groups = JsonSerializer.Deserialize<List<GroupDTO>>(userdata);

            groups.ForEach(gr =>
            {
                gr.Users.ForEach(u =>
                {
                    using var hmac = new HMACSHA512();

                    u.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Password"));
                    u.PasswordSalt = hmac.Key;
                });
            });

            return groups;

        }
    }
}
