namespace JournalAnalyzer.API.Models;

public class JournalEntry
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public string Analysis { get; set; } = string.Empty;
    public string Emotion { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}