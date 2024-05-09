using Microsoft.EntityFrameworkCore;
using TgAppCrates.Core.models;
public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Card> Cards { get; set; }
    public DbSet<CardData> CardsData { get; set; }
    
    public DbSet<UserFunds> UserFunds { get; set; }
}