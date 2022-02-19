#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_API01.DBContext;
using WEB_API01.Model;

namespace WEB_API01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentInfoesController : ControllerBase
    {
        private readonly studentdbcontext _context;

        public StudentInfoesController(studentdbcontext context)
        {
            _context = context;
        }

        // GET: api/StudentInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentInfo>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        // GET: api/StudentInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentInfo>> GetStudentInfo(int id)
        {
            var studentInfo = await _context.Students.FindAsync(id);

            if (studentInfo == null)
            {
                return NotFound();
            }

            return studentInfo;
        }

        // PUT: api/StudentInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentInfo(int id, StudentInfo studentInfo)
        {
            if (id != studentInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentInfoExists(id))
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

        // POST: api/StudentInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentInfo>> PostStudentInfo(StudentInfo studentInfo)
        {
            _context.Students.Add(studentInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentInfo", new { id = studentInfo.Id }, studentInfo);
        }

        // DELETE: api/StudentInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentInfo(int id)
        {
            var studentInfo = await _context.Students.FindAsync(id);
            if (studentInfo == null)
            {
                return NotFound();
            }

            _context.Students.Remove(studentInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentInfoExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
