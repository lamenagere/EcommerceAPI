using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data.Entities;
using Ecommerce.Entities;

namespace Ecommerce.Data.Repositories
{
    public class AccountRepository : IRepository<Account>
    {
        private EcommerceContext _context;
        public AccountRepository(EcommerceContext context)
        {
            _context = context;
        }

        public Account Add(Account entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Account entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Account> GetAll()
        {
            throw new NotImplementedException();
        }

        public Account GetById(int id)
        {
            var account = _context.Accounts.Include("Details").Single(acc => acc.Id == id);

            return account;
        }

        public Account GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Account GetByCredentials(string userName, string password)
        {
            var account = _context.Accounts.SingleOrDefault(acc => acc.UserName == userName && acc.Password == password);

            return account;
        }

        public IQueryable<Account> GetByName()
        {
            throw new NotImplementedException();
        }

        public Account GetSingle(Func<Account, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Account Update(Account entity)
        {
            throw new NotImplementedException();
        }
    }
}
