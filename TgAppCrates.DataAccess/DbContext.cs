using Microsoft.EntityFrameworkCore;
using TgAppCrates.Core.models;
public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbContext(DbContextOptions<DbContext> options) : base(options)
    {
    }
    
    public DbSet<Card> Cards { get; set; }
    public DbSet<CardData> CardsData { get; set; }
    
    public DbSet<UserFunds> UserFunds { get; set; }
}