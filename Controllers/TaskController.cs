using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagementSystem.Data;
using Task = TaskManagementSystem.Models.Task; // Add this alias
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> CreateTask([FromBody] Task task) // Use alias here
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            task.UserId = userId;
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return Ok(task);
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var tasks = _context.Tasks.Where(t => t.UserId == userId).ToList();
            return Ok(tasks);
        }

        [HttpPut("{id}")]
        public async System.Threading.Tasks.Task<IActionResult> UpdateTask(Guid id, [FromBody] Task updatedTask) // Use alias here
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null || task.UserId != Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)))
                return Unauthorized();

            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.DueDate = updatedTask.DueDate;
            task.Status = updatedTask.Status;
            task.Priority = updatedTask.Priority;

            await _context.SaveChangesAsync();
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async System.Threading.Tasks.Task<IActionResult> DeleteTask(Guid id) // Use alias here
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null || task.UserId != Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)))
                return Unauthorized();

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
