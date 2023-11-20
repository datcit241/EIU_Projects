using Domain;
using Domain.MockDomain;
using Domain.School;
using Domain.Student;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Persistence;

public class DataContext : IdentityDbContext<User>
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Student> Students { get; set; }
    public DbSet<School> Schools { get; set; }


    public DbSet<MockDomain> MockDomains { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}