using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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

        public enum PaintingType
        {
            Other,
            Building,
            Mountain,
            Portrait,
            Water,
            Winter,
            Woods
        }

        public int PaintingTypes { get; set; }

        public string VideoUrl { get; set; }

        public virtual ICollection<Color> Colors { get; set; }

        public bool Validate()
        {
            var isValid = true;

            if (Season <= 0) isValid = false;
            if (Episode <= 0) isValid = false;

            return isValid;
        }

        public bool[] SelectedColors(List<Color> totalColors)
        {
            // TO DO: Simplify either using queries or loop logic
            string[] colorNames = new string[Colors.Count];
            for (int i = 0; i < Colors.Count; i++)
            {
                colorNames[i] = Colors.ElementAt(i).ColorName;
            }
            bool[] selectedColors = new bool[totalColors.Count];
            int colorCount = 0;
            foreach (var color in totalColors)
            {
                selectedColors[colorCount] = colorNames.Contains(color.ColorName);
                colorCount++;
            }

            return selectedColors;
        }
    }

}
