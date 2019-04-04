using Ecommerce.Data.Entities;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Helpers
{
    public static class AccountModelBuilder
    {
        public static AccountModel Create(Account account)
        {
            if (account == null) return null;

            return new AccountModel
            {
                Id = account.Id,
                Login = account.UserName,
                Password = account.Password,
                Role = account.Role
            };
        }

        public static Account Reverse(AccountModel accountModel)
        {
            if (accountModel == null || accountModel.Id == 0) return null;

            return new Account()
            {
                Id = accountModel.Id,
                UserName = accountModel.Login,
                Password = accountModel.Password,
                Role = accountModel.Role
            };
        }
    }
}
