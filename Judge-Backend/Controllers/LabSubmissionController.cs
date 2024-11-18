using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Judge_Backend.Data;
using Judge_Backend.DTOs;
using Judge_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Judge_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LabSubmissionController : ControllerBase
    {
        private readonly JudgeDbContext _context;
        public LabSubmissionController(JudgeDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SubmitLab([FromBody] LabSubmissionRequest request)
        {
            // Validate Lab ID
            var lab = await _context.Labs.FindAsync(request.LabID);
            if (lab == null)
                return NotFound(new { Message = "Lab not found" });

            // Ensure user exists
            var userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value ?? "0");
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return Unauthorized(new { Message = "User not found or unauthorized" });

            // Create and save the submission
            var labSubmission = new LabSubmission
            {
                UserID = userId,
                LabID = request.LabID,
                source_code = request.SourceCode,
                ExecutedCorrectly = false, // This will be updated after processing
                Result = null // Placeholder until Judge0 processes the submission
            };

            _context.LabSubmissions.Add(labSubmission);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Submission received", SubmissionID = labSubmission.ID });
        }
    }
}