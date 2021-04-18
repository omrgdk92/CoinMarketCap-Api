using ParibuApiServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParibuApiServices.ModelData
{
    public interface IUserRepository
    {
        public IQueryable<User> Users{ get;  }
        User GetUserById(int id);
        void Add<EntityType>(EntityType entity);
        void SaveChanges();
        string Authenticate(User model);        
    }
}
