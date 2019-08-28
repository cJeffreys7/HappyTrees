using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace HappyTrees.Models
{
    public class Painting
    {
        public string Title { get; set; }

        public int Season { get; set; }

        public int Episode { get; set; }

        public string ThumbnailFile { get; set; }

        public string Description { get; set; }

        public string VideoURL { get; set; }

        public List<Color> Colors { get; set; }
    }

}
