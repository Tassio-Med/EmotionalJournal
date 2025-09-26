using JournalAnalyzer.API.Models;
using JournalAnalyzer.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JournalAnalyzer.API.Data;

namespace JournalAnalyzer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JournalController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IGeminiService _geminiService;

    public JournalController(ApplicationDbContext context, IGeminiService geminiService)
    {
        _context = context;
        _geminiService = geminiService;
    }

    [HttpPost("analyze")]
    public async Task<ActionResult<AnalysisResponse>> AnalyzeText([FromBody] AnalysisRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Text))
            return BadRequest("Texto não pode estar vazio");

        var analysis = await _geminiService.AnalyzeTextAsync(request.Text);

        var entry = new JournalEntry
        {
            Text = request.Text,
            Analysis = $"{analysis.Emotion} - {analysis.Suggestion}",
            Emotion = analysis.Emotion,
            CreatedAt = DateTime.UtcNow
        };

        _context.JournalEntries.Add(entry);
        await _context.SaveChangesAsync();

        return Ok(analysis);
    }

    [HttpGet("history")]
    public async Task<ActionResult<List<JournalEntry>>> GetHistory()
    {
        var entries = await _context.JournalEntries
            .OrderByDescending(e => e.CreatedAt)
            .Take(10)
            .ToListAsync();

        return Ok(entries);
    }

    [HttpGet("cvv")]
    public ActionResult<string> GetCVVContact()
    {
        return Ok("188");
    }
}