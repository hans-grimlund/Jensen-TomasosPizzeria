using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TomasosPizzeria.Domain.Entities;

namespace TomasosPizzeria.Infrastructure.Context;

public class TomasosContext : IdentityDbContext<ApplicationUser>
{
    public TomasosContext(DbContextOptions<TomasosContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("identity");
    }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Order> Orders { get; set; }
}