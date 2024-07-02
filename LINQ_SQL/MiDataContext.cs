using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LINQ_SQL{
    public class MiDataContext : DbContext{
        public DbSet<Producto> Producto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ROBERT;Initial Catalog=Tienda;User ID=unab;Password=unab;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18,2)");

            // O alternativamente, especifica precisión y escala
            // modelBuilder.Entity<Producto>()
            //     .Property(p => p.Precio)
            //     .HasPrecision(18, 2);
        }
    }
}
