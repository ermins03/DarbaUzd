using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UzdevumsBackend.Models;

namespace UzdevumsBackend.Context
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public ApplicationDbContext() { }
        public DbSet<Dats> Dati { get; set; }
    }
}
