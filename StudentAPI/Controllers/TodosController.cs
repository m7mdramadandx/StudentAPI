using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Models;

namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TodosController : ControllerBase
    {

        private readonly APIDbContext _context;

        public TodosController(APIDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetTodos")]
        public ActionResult GetTodos()
        {
            return Ok(_context.Todo.ToList());
        }

        [HttpGet(Name = "GetTodo")]
        public ActionResult GetTodo(int id)
        {
            var todo = _context.Todo.Find(id);
            if (todo == null) return BadRequest("no todo with this id");
            else return Ok(todo);
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> PostTodo(Todo todo)
        {
            _context.Todo.Add(todo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodo", new { id = todo.ID }, todo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Todo>> UpdateTodo(int id, Todo todo)
        {
            if (id != todo.ID) return BadRequest("wrong id");

            _context.Entry(todo).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            if (TodoExists(id)) return Ok("true");
            else return BadRequest("something went wrong");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var todo = await _context.Todo.FindAsync(id);
            if (todo == null) return BadRequest("no todo with this id");

            _context.Todo.Remove(todo);
            await _context.SaveChangesAsync();

            if (!TodoExists(id)) return Ok("true");
            else return BadRequest("something went wrong");
        }

        private bool TodoExists(int id)
        {
            return _context.Todo.Any(e => e.ID == id);
        }
    }
}
