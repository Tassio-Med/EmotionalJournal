using JournalAnalyzer.API.Models;

namespace JournalAnalyzer.API.Services;

public interface IGeminiService
{
    Task<AnalysisResponse> AnalyzeTextAsync(string text);
}