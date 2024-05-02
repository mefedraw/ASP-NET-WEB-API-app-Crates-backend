using Microsoft.EntityFrameworkCore;
using TgAppCrates.Core.models;
public class CardsDbContext : DbContext
{
    //protected readonly IConfiguration Configuration;
    private string connectionString = "Host=localhost; Database=tgAppUsers; Username=ted; Password=ted";

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // in memory database used for simplicity, change to a real db for production applications
        options.UseNpgsql(connectionString);
    }
    
    public DbSet<Card> Cards { get; set; }
}