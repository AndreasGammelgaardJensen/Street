using AutoMapper;
using CoreStreet.ModelDTO;
using EFDataAcces.DataAccess;
using EFDataAcces.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoreStreet.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly StreetContext _dbContext;
        private readonly IMapper _mapper;
        private string _secretKey;

        public UserRepository(StreetContext db, IConfiguration config, IMapper mapper)
        {
            _dbContext = db;
            _secretKey = config.GetSection("ApiSettings")["Secret"];
            _mapper = mapper;
        }

        public void DeleteUser()
        {
            throw new NotImplementedException();
        }

        public User GetUser()
        {
            throw new NotImplementedException();
        }

        public ICollection<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public bool IsUserUnique(string username)
        {
            var user = _dbContext.User.FirstOrDefault(x => x.Username == username);

            if (user == null)
                return false;
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _dbContext.User.FirstOrDefault(x => x.Username.ToLower() == loginRequestDTO.UserName.ToLower() && x.PasswordHash == loginRequestDTO.Password);

            if(user == null)
            {

                return new LoginResponseDTO()
                {
                    User = null, 
                    Token = ""
                };
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            LoginResponseDTO loginRespDTO = new LoginResponseDTO()
            {
                User = _mapper.Map<UserDTO>(user),
                Token = tokenHandler.WriteToken(token),
            };

            return loginRespDTO;

        }

        public async Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            
            User user = new()
            {
                Username = registrationRequestDTO.Username,
                Id = new Guid(),
                Name = registrationRequestDTO.Name,
                PasswordHash = registrationRequestDTO.Password,
                Email = registrationRequestDTO.Email,
                Posts = 0,
            };

            _dbContext.User.Add(user);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<UserDTO>(user);
        }
    }
}
