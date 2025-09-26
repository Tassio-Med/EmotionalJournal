using JournalAnalyzer.API.Models;
using System.Text;
using System.Text.Json;

namespace JournalAnalyzer.API.Services;

public class GeminiService : IGeminiService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public GeminiService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["MinhaApiKey"];
    }

    public async Task<AnalysisResponse> AnalyzeTextAsync(string text)
    {
        await Task.Delay(1000); 
        
        return new AnalysisResponse
        {
            Emotion = "feliz",
            Emoji = "😊",
            Suggestion = "Continue com essa energia positiva!",
            MotivationalMessage = "Seu otimismo é contagiante!"
        };
    }
}