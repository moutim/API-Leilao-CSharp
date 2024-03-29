﻿namespace Auction.API.Repositories;

using Auction.API.Entities;
using Microsoft.EntityFrameworkCore;

public class AuctionDbContext : DbContext
{
    public DbSet<Auction> Auctions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\vitorugo\\Documents\\API-Leilao-CSharp\\leilaoDbNLW.db");
    }
}
