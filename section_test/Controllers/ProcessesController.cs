using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using section_test.Models;

namespace section_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessesController : ControllerBase
    {
        private readonly TestApiContext _context;

        public ProcessesController(TestApiContext context)
        {
            _context = context;
        }

        // GET: api/Processes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Process>>> GetProcesses()
        {
            return await _context.Processes.ToListAsync();
        }

        // GET: api/Processes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Process>> GetProcess(int id)
        {
            var process = await _context.Processes.FindAsync(id);

            if (process == null)
            {
                return NotFound();
            }

            return process;
        }
        // GET: api/Processes/5
        [HttpGet("{id}/Next")]
        public async Task<ActionResult<Process>> GetNextProcess(int id)
        {
            var process = await _context.Processes.FindAsync(id);
            process.InspCount++;
            if (process == null)
            {
                return NotFound();
            }

            return process;
        }

        // PUT: api/Processes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcess(int id, Process process)
        {
            if (id != process.Id)
            {
                return BadRequest();
            }

            _context.Entry(process).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcessExists(id))
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

        // POST: api/Processes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Process>> PostProcess(Process process)
        {
            _context.Processes.Add(process);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProcess", new { id = process.Id }, process);
        }

        // DELETE: api/Processes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcess(int id)
        {
            var process = await _context.Processes.FindAsync(id);
            if (process == null)
            {
                return NotFound();
            }

            _context.Processes.Remove(process);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProcessExists(int id)
        {
            return _context.Processes.Any(e => e.Id == id);
        }
    }
}
