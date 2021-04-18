using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ParibuApiServices.Controllers;
using ParibuApiServices.DbOperation;
using ParibuApiServices.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ParibuApiServices.ModelData
{
    public class DbRepository : IUserRepository
    {
        private readonly ApiContext _db;
        private readonly AppSettings _appSettings;
        public DbRepository(ApiContext db,IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _db = db;            
        }
        

        public IQueryable<User> Users => _db.Users;        

        public void Add<EntityType>(EntityType entity) => _db.Add(entity);

        public string Authenticate(User model)
        {
            if (Users == null || Users.Count()<1)
            {
                Add<User>(new User { Email="omrgdk92@gmail.com", Id=1, Password="paribu123", UserName="omer", JwtToken=null });
                SaveChanges();
            }
            var user = Users.SingleOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);

            // return null if user not found
            if (user == null) return string.Empty;

            // authentication successful so generate jwt token            
            user.JwtToken= generateJwtToken(user);
            return user.JwtToken;

        }
        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public User GetUserById(int id)
        {
            return _db.Users.Where(u => u.Id == id).FirstOrDefault();
        }
        public void SaveChanges() => _db.SaveChanges();

    }
}
