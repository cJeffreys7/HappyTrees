using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HappyTrees.Models
{
    public class Painting
    {

        public Painting()
        {
            this.Colors = new HashSet<Color>();
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public int Season { get; set; }

        public int Episode { get; set; }

        public string ThumbnailFile { get; set; }

        public string Description { get; set; }

        public string VideoUrl { get; set; }

        public virtual ICollection<Color> Colors { get; set; }
    }

}
