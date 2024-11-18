using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Judge_Backend.Data;
using Judge_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Judge_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly JudgeDbContext _context;

        public AdminController(ILogger<AdminController> logger, JudgeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // === CRUD Operations for Papers ===

        // Create a new Paper
        [HttpPost("papers")]
        public async Task<IActionResult> CreatePaper([FromBody] PaperRequest request)
        {
            var paper = new Paper
            {
                Name = request.Name,
                TeacherID = request.TeacherID // Ensure the teacher exists in the DB
            };

            _context.Papers.Add(paper);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPaperById), new { id = paper.ID }, paper);
        }

        // Read a specific Paper by ID
        [HttpGet("papers/{id}")]
        public async Task<IActionResult> GetPaperById(int id)
        {
            var paper = await _context.Papers
                .Include(p => p.Labs)
                .Include(p => p.EnrolledStudents)
                .FirstOrDefaultAsync(p => p.ID == id);

            if (paper == null)
                return NotFound(new { Message = "Paper not found" });

            return Ok(paper);
        }

        // Update an existing Paper
        [HttpPut("papers/{id}")]
        public async Task<IActionResult> UpdatePaper(int id, [FromBody] PaperRequest request)
        {
            var paper = await _context.Papers.FindAsync(id);
            if (paper == null)
                return NotFound(new { Message = "Paper not found" });

            paper.Name = request.Name;
            paper.TeacherID = request.TeacherID;

            _context.Papers.Update(paper);
            await _context.SaveChangesAsync();
            return Ok(paper);
        }

        // Delete a Paper
        [HttpDelete("papers/{id}")]
        public async Task<IActionResult> DeletePaper(int id)
        {
            var paper = await _context.Papers.FindAsync(id);
            if (paper == null)
                return NotFound(new { Message = "Paper not found" });

            _context.Papers.Remove(paper);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // === CRUD Operations for Labs ===

        // Create a new Lab
        [HttpPost("labs")]
        public async Task<IActionResult> CreateLab([FromBody] LabRequest request)
        {
            var lab = new Lab
            {
                LabNumber = request.LabNumber,
                LabName = request.LabName,
                LabInput = request.LabInput,
                LabOutput = request.LabOutput,
                ExampleInput = request.ExampleInput,
                ExampleOutput = request.ExampleOutput,
                PaperID = request.PaperID
            };

            _context.Labs.Add(lab);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLabById), new { id = lab.ID }, lab);
        }

        // Read a specific Lab by ID
        [HttpGet("labs/{id}")]
        public async Task<IActionResult> GetLabById(int id)
        {
            var lab = await _context.Labs
                .Include(l => l.Paper)
                .Include(l => l.LabSubmissions)
                .FirstOrDefaultAsync(l => l.ID == id);

            if (lab == null)
                return NotFound(new { Message = "Lab not found" });

            return Ok(lab);
        }

        // Update an existing Lab
        [HttpPut("labs/{id}")]
        public async Task<IActionResult> UpdateLab(int id, [FromBody] LabRequest request)
        {
            var lab = await _context.Labs.FindAsync(id);
            if (lab == null)
                return NotFound(new { Message = "Lab not found" });

            lab.LabNumber = request.LabNumber;
            lab.LabName = request.LabName;
            lab.LabInput = request.LabInput;
            lab.LabOutput = request.LabOutput;
            lab.ExampleInput = request.ExampleInput;
            lab.ExampleOutput = request.ExampleOutput;
            lab.PaperID = request.PaperID;

            _context.Labs.Update(lab);
            await _context.SaveChangesAsync();
            return Ok(lab);
        }

        // Delete a Lab
        [HttpDelete("labs/{id}")]
        public async Task<IActionResult> DeleteLab(int id)
        {
            var lab = await _context.Labs.FindAsync(id);
            if (lab == null)
                return NotFound(new { Message = "Lab not found" });

            _context.Labs.Remove(lab);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

    // === Request Models ===
    public class PaperRequest
    {
        public string Name { get; set; } = string.Empty;
        public int TeacherID { get; set; }
    }

    public class LabRequest
    {
        public int LabNumber { get; set; }
        public string LabName { get; set; } = string.Empty;
        public string LabInput { get; set; } = string.Empty;
        public string LabOutput { get; set; } = string.Empty;
        public string ExampleInput { get; set; } = string.Empty;
        public string ExampleOutput { get; set; } = string.Empty;
        public int PaperID { get; set; }
    }
}