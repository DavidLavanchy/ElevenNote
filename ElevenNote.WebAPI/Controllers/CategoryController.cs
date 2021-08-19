using ElevenNote.Models;
using ElevenNote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote.WebAPI.Controllers
{
    [Authorize]
    public class CategoryController : ApiController
    {
        private CategoryService CreateCategoryService()
        {
            var categoryService = new CategoryService();
            return categoryService;
        }
        public IHttpActionResult Get()
        {
            var cService = CreateCategoryService();
            var categories = cService.GetCategories();
            return Ok(categories);
        }
        public IHttpActionResult Post(CategoryCreate category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cService = CreateCategoryService();
            if (!cService.CreateCategory(category)) 
            return InternalServerError();

            return Ok();
        }

        public IHttpActionResult GetById(int id)
        {
            var cService = CreateCategoryService();

            var category = cService.GetCategoryById(id);

            return Ok(category);
        }

        public IHttpActionResult Put(CategoryEdit category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cService = CreateCategoryService();

            if (!cService.UpdateCategory(category))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var cService = CreateCategoryService();

            cService.DeleteCategory(id);
            return Ok();
        }
    }
}
