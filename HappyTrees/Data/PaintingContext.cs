using HappyTrees.Models;
using Microsoft.EntityFrameworkCore;

namespace HappyTrees.Data
{
    public partial class PaintingContext : DbContext
    {
        public PaintingContext()
        {
        }

        public PaintingContext(DbContextOptions<PaintingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Painting> Paintings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server = (localdb)\\mssqllocaldb; Database = happytreesdb; Trusted_Connection = True;" +
                    " MultipleActiveResultSets = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}