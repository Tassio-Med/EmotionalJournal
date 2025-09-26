namespace JournalAnalyzer.API.Models;

public class AnalysisResponse
{
    public string Emotion { get; set; } = string.Empty;
    public string Suggestion { get; set; } = string.Empty;
    public string MotivationalMessage { get; set; } = string.Empty;
    public string Emoji { get; set; } = string.Empty;
}