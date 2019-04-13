using Ecommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories
{
    public class UserDetailsRepository : IRepository<UserDetails>
    {
        private EcommerceContext _context;
        public UserDetailsRepository(EcommerceContext context)
        {
            _context = context;
        }

        public UserDetails Add(UserDetails entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserDetails entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserDetails> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserDetails GetById(int id)
        {
            return _context.UserDetails.Find(id);
        }

        public UserDetails GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserDetails> GetByName()
        {
            throw new NotImplementedException();
        }

        public UserDetails GetSingle(Func<UserDetails, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public UserDetails Update(UserDetails entity)
        {
            throw new NotImplementedException();
        }
    }
}
