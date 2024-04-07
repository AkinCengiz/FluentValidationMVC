using Microsoft.EntityFrameworkCore;

namespace FluentVlidationMVC.Models;

public class FluentValidationContext : DbContext
{
    public FluentValidationContext(DbContextOptions<FluentValidationContext> options) : base(options)
    {
        
    }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(@"Data Source=AKINCENGIZ;FluentValidationDb;Integrated Security=True;Trust Server Certificate=True;");
    //}

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Product> Products { get; set; }
}
