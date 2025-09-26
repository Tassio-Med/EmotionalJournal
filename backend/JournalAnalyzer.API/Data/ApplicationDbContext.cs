using JournalAnalyzer.API.Models;
using Microsoft.EntityFrameworkCore;

namespace JournalAnalyzer.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<JournalEntry> JournalEntries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<JournalEntry>().ToTable("JournalEntries");
    }
}