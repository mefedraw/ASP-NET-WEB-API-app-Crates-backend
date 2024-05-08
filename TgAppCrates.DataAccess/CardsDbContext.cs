﻿using Microsoft.EntityFrameworkCore;
using TgAppCrates.Core.models;
public class CardsDbContext : DbContext
{
    public CardsDbContext(DbContextOptions<CardsDbContext> options) : base(options)
    {
    }
    
    public DbSet<Card> Cards { get; set; }
    public DbSet<CardData> CardsData { get; set; }
    
    public DbSet<UserFunds> UserFunds { get; set; }
}