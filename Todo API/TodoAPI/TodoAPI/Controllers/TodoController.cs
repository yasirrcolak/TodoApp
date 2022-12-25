using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        /// <summary>
        /// Data context object
        /// </summary>
        private readonly DataContext _context;

        /// <summary>
        /// Cosnt.
        /// </summary>
        /// <param name="context"></param>
        public TodoController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This method is get all todos
        /// </summary>
        /// <returns>all todos</returns>
        [HttpGet]
        public List<Todo> Get()
        {
            return _context.Todos.ToList();
        }

        /// <summary>
        /// This method is get any todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns>any todo</returns>
        [HttpGet("{id}")]
        public Todo Get(int id)
        {
            Todo todo = _context.Todos.ToList().Find(t => t.Id == id);                
            return todo;
        }

        /// <summary>
        /// This method is any todo add database
        /// </summary>
        /// <param name="todo"></param>
        /// <returns>all todos</returns>
        [HttpPost]
        public List<Todo> Add(Todo todo)
        {
            Category category = _context.Categories.ToList().Find(c => c.Id == todo.CategoryId);

            if (category != null)
            {
                // kategori id check
                _context.Todos.Add(todo);
                _context.SaveChanges();
            }

            return _context.Todos.ToList();
        }

        /// <summary>
        /// This method is any todo update in database
        /// </summary>
        /// <param name="todo"></param>
        /// <returns>all todos</returns>
        [HttpPut]
        public List<Todo> Update(Todo todo)
        {
            /////// kontrol edilmedi
            Todo fTodo = _context.Todos.ToList().Find(t => t.Id == todo.Id);

            if (fTodo != null)
            {
                _context.Todos.Remove(fTodo);
                _context.SaveChanges();
                _context.Todos.Add(todo);
                _context.SaveChanges();
            }
  
            return _context.Todos.ToList();
        }

        /// <summary>
        /// This method is any todo detele in database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>all todos</returns>
        [HttpDelete]
        public List<Todo> Delete(int id)
        {
            Todo todo = _context.Todos.ToList().Find(t => t.Id == id);

            if(todo != null)
                _context.Todos.Remove(todo);
                _context.SaveChanges();

            return _context.Todos.ToList();
        }
    }
}
