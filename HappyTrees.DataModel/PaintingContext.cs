using System.Data.Entity;
using HappyTrees;

namespace HappyTrees.DataModel
{
    public class PaintingContext : DbContext
    {

        public DbSet<Painting> Paintings { get; set; }    
    }
}
