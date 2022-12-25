using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        /// <summary>
        /// Data context object
        /// </summary>
        private readonly DataContext _context;

        /// <summary>
        /// Const.
        /// </summary>
        /// <param name="context"></param>
        public CategoryController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This method is get all categories
        /// </summary>
        /// <returns>all categories</returns>
        [HttpGet]
        public List<Category> Get()
        {
            return _context.Categories.ToList();
        }

        /// <summary>
        /// This method is get any category
        /// </summary>
        /// <param name="id"></param>
        /// <returns>any category</returns>
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            Category category= _context.Categories.Find(id);
            return category;
        }

        /// <summary>
        /// This method is add any category
        /// </summary>
        /// <param name="category"></param>
        /// <returns>all categories</returns>
        [HttpPost]
        public List<Category> Add(Category category)
        {
            category.Id = 0;
            _context.Categories.Add(category);
            _context.SaveChanges();
            return _context.Categories.ToList();
        }

        /// <summary>
        /// This method is update any category
        /// </summary>
        /// <param name="category"></param>
        /// <returns>all categories</returns>
        [HttpPut]
        public List<Category> Update(Category category)
        {
            Category fCategory = _context.Categories.Find(category.Id); //// 

            if (fCategory != null)
            {
                _context.Categories.Remove(fCategory);
                _context.SaveChanges();
                category.Id = 0;
                _context.Add(category); // sıkıntı !!!
                _context.SaveChanges();
            }

            return _context.Categories.ToList();
        }

        /// <summary>
        /// This method is all category delete database
        /// </summary>
        /// <returns>all categories</returns>
        [HttpDelete]
        public List<Category> Delete()
        {
            foreach (var c in _context.Categories)
                _context.Categories.Remove(c);
            _context.SaveChanges();

            return _context.Categories.ToList();
        }

        /// <summary>
        /// This method is any category delete database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>all categories</returns>
        [HttpDelete("{id}")]
        public List<Category> Delete(int id)
        {
            Category category = _context.Categories.ToList().Find(c => c.Id == id);

            if(category != null)
                _context.Categories.Remove(category);
                _context.SaveChanges();

            return _context.Categories.ToList();
        }

    }
}
