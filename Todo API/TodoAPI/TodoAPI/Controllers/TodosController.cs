using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        /// <summary>
        /// Returning todos list.
        /// </summary>
        private static List<Todo> _todos = new List<Todo> { };

        /// <summary>
        /// Data context object
        /// </summary>
        private readonly DataContext _context;

        /// <summary>
        /// Const.
        /// </summary>
        /// <param name="context"></param>
        public TodosController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This methos is get all todos belonging to a category.
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public List<Todo> Get(int id)
        {
            _todos.Clear();

            foreach (var t in _context.Todos)
            {
                if (t.CategoryId == id)
                {
                    _todos.Add(t);
                }
            }

            _context.SaveChanges();

            return _todos;
        }

    }
}
