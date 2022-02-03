using Microsoft.EntityFrameworkCore;
using WhatsCookin.Models;

namespace WhatsCookin.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}