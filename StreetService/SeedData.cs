using StreetService.ModelDTO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace StreetService
{
    public class SeedData
    {
        public SeedData()
        {
            RunSeedData();
        }

        public List<GroupDTO>? Groups { get; set; }

        private List<GroupDTO> RunSeedData()
        {
            var userdata = System.IO.File.ReadAllText("C:/Development/Street/CoreStreet/seedData.json");
            var groups = JsonSerializer.Deserialize<List<GroupDTO>>(userdata);

            groups.ForEach(gr =>
            {
                gr.Id = System.Guid.NewGuid();
               
                gr.Users.ForEach(u =>
                {
                    using var hmac = new HMACSHA512();

                    u.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Password"));
                    u.PasswordSalt = hmac.Key;

                });
            });

            Groups = groups;

            return groups;

        }
    }
}
