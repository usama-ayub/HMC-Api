
using API.DTOs;
using API.Model;
using API.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _user;
        private readonly string key;
        private readonly IDBConnection dbconnection;
        public UserService(DataBaseSetting settings, IConfiguration configuration, IDBConnection _dbconnection)
        {
            dbconnection = _dbconnection;
            _user = dbconnection.DataBase.GetCollection<User>(settings.UserCollectionName);
            // this.key = configuration.GetSection("JwtKey").ToString();
        }



        public async Task<User> Get()
        {
            var user = await _user.Find(user => true).FirstOrDefaultAsync();
            return user;
        }
        public async Task<ActionResult<User>> Register(RegisterDto payload)
        {
            using var hmac = new HMACSHA512();
            if(await UserExit(payload.UserName)){
                
            }
            var user = new User();
            user.UserName = payload.UserName.ToLower();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload.Password));
            user.PasswordSalt = hmac.Key;
            user.Email = payload.Email;
            await _user.InsertOneAsync(user);
            return user;
        }

        private async Task<bool> UserExit(string username)
        {
            var user = (await _user.FindAsync(user => user.UserName == username)).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }




        // public string Authenticate(string email, string password)
        // {
        //     var user = Get(email, password);
        //     if (user == null)
        //     {
        //         return null;
        //     }
        //     var tokenHandler = new JwtSecurityTokenHandler();
        //     var tokenKey = Encoding.ASCII.GetBytes(this.key);

        //     var tokenDescriptor = new SecurityTokenDescriptor()
        //     {
        //         Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]{
        //             new Claim(ClaimTypes.Email,email),
        //             }),
        //         Expires = DateTime.UtcNow.AddHours(1),
        //         SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        //     };

        //     var token = tokenHandler.CreateToken(tokenDescriptor);
        //     return tokenHandler.WriteToken(token);
        // }
    }
}
