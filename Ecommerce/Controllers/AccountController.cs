using Ecommerce.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ecommerce.Controllers
{
    public class AccountController : ApiController
    {
        private AccountService accountService = new AccountService();

        [HttpGet]
        public IHttpActionResult GetUser()
        {
            var parameters = Request.Headers.Authorization.Parameter;

            var account = accountService.GetUser(parameters);

            return Ok(account);
        }
    }
}
