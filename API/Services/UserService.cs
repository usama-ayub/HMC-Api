
using API.Model;
using API.Shared;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Linq;
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
            /*var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);*/
            dbconnection = _dbconnection;
            _user = dbconnection.DataBase.GetCollection<User>(settings.UserCollectionName);
            // this.key = configuration.GetSection("JwtKey").ToString();
        }



        public async Task<User> Get(){
        var user = await _user.Find(user => true).FirstOrDefaultAsync();
          return user;
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
