﻿using Ecommerce.Business;
using Ecommerce.Common;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Ecommerce.Controllers
{
    [IdentityBasicAuthentication]
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/category")]
    public class CategoryController : ApiController
    {
        private CategoryService _service;

        public CategoryController()
        {
            _service = new CategoryService();
        }

        // GET: api/Category
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_service.GetCategoryHierarchy());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAll()
        {

            return Ok(_service.GetAllCategories());
        }

        // GET: api/Category/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(_service.GetCategoryById(id));
        }

        // POST: api/Category
        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post([FromBody]CategoryModel category)
        {
            return Ok(_service.CreateCategory(category));
        }

        // PUT: api/Category/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut]
        [Route("{id}")]
        public void Put(int id, [FromBody]CategoryModel value)
        {
        }

        // DELETE: api/Category/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _service.DeleteCategory(id);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            
            return Ok();
        }
    }
}
