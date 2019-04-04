using Ecommerce.Business.Helpers;
using Ecommerce.Data;
using Ecommerce.Data.Entities;
using Ecommerce.Data.Repositories;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Services
{
    public class AccountService
    {
        private AccountRepository _repository;
        private EcommerceContext _context;

        public AccountService()
        {
            _context = new EcommerceContext();
            _repository = new AccountRepository(_context);
        }

        public AccountModel GetUser(string userName, string password)
        {
            var account = _repository.GetByCredentials(userName, password);

            if (account == null) throw new ArgumentException("This user does not exist or the password is incorrect");

            return AccountModelBuilder.Create(account);
        }
    }
}
