using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskAssignmentSystem.Model2;

namespace TaskAssignmentSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskDbContext _context;

        public TasksController(TaskDbContext context)
        {
            _context = context;
        }

        // GET: api/Tasks
        [HttpGet]
        [ActionName("Tasks")]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        [HttpGet]
        [ActionName("Employees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            return await _context.Employee.ToListAsync();
        }

       // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tasks>> GetTasks(int id)
        {
            var tasks = await _context.Tasks.FindAsync(id);

            if (tasks == null)
            {
                return NotFound();
            }

            return tasks;
        }

        //PUT: api/Tasks/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTasks(int id, Tasks tasks)
        {
            if (id != tasks.TaskId)
            {
                return BadRequest();
            }

            _context.Entry(tasks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TasksExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //POST: api/Tasks
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [ActionName("PostTasks")]
        public async Task<ActionResult<Tasks>> PostTasks(Tasks tasks)
        {
            _context.Tasks.Add(tasks);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TasksExists(tasks.TaskId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTasks", new { id = tasks.TaskId }, tasks);
        }

       // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tasks>> DeleteTasks(int id)
        {
            var tasks = await _context.Tasks.FindAsync(id);
            if (tasks == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(tasks);
            await _context.SaveChangesAsync();

            return tasks;
        }

        private bool TasksExists(int id)
        {
            return _context.Tasks.Any(e => e.TaskId == id);
        }
    }
}
