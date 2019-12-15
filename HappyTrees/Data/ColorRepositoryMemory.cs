using System.Collections.Generic;
using System.Linq;
using HappyTrees.Models;

namespace HappyTrees.Data
{
    public class ColorRepositoryMemory : IColorRepository
    {
        public void AddColor(Color color)
        {
            colors.Add(color);
        }

        public bool DeleteColor(Color color)
        {
            try
            {
                colors.Remove(color);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public List<Color> GetAllColors()
        {
            return colors;
        }

        public Color GetColor(string colorValue)
        {
            return colors.Where(c => c.ColorValue == colorValue).FirstOrDefault();
        }

        public void UpdateColor(Color color)
        {
            var colorToUpdate = colors.FirstOrDefault(c => c.ColorValue == color.ColorValue);
            if (colorToUpdate != null) colorToUpdate = color;
        }

        // Single Source of Truth
        private static List<Color> colors = new List<Color>
        {
            new Color
            {
                ColorName = "Sap Green", ColorValue = "sapGreen",
                BuyLink = "http://amzn.to/2y271WV", HexColor = "0A3410"
            },
            new Color
            {
                ColorName = "Alizarin Crimson", ColorValue = "alizarinCrimson",
                BuyLink = "http://amzn.to/2hc4nuv", HexColor = "4E1500"
            },
            new Color
            {
                ColorName = "Van Dyke Brown", ColorValue = "vanDykeBrown",
                BuyLink = "http://amzn.to/2ivJmI1", HexColor = "221B15"
            },
            new Color
            {
                ColorName = "Dark Sienna", ColorValue = "darkSienna",
                BuyLink = "https://amzn.to/36vnapu", HexColor = "3C1414"
            },
            new Color
            {
                ColorName = "Midnight Black", ColorValue = "midnightBlack",
                BuyLink = "https://amzn.to/2qaLgoZ", HexColor = "000000"
            },
            new Color
            {
                ColorName = "Prussian Blue", ColorValue = "prussianBlue",
                BuyLink = "http://amzn.to/2zlo7CD", HexColor = "021E44"
            },
            new Color
            {
                ColorName = "Phthalo Blue", ColorValue = "phthaloBlue",
                BuyLink = "https://amzn.to/2MkysU8", HexColor = "000F89"
            },
            new Color
            {
                ColorName = "Phthalo Green", ColorValue = "phthaloGreen",
                BuyLink = "http://amzn.to/2iwCBW5", HexColor = "102E3C"
            },
            new Color
            {
                ColorName = "Cadmium Yellow", ColorValue = "cadmiumYellow",
                BuyLink = "http://amzn.to/2hJgoF0", HexColor = "FFEC00"
            },
            new Color
            {
                ColorName = "Yellow Ochre", ColorValue = "yellowOchre",
                BuyLink = "https://amzn.to/30N3xFh", HexColor = "CC7722"
            },
            new Color
            {
                ColorName = "Indian Yellow", ColorValue = "indianYellow",
                BuyLink = "https://amzn.to/31P0DkR", HexColor = "E3A857"
            },
            new Color
            {
                ColorName = "Bright Red", ColorValue = "brightRed",
                BuyLink = "http://amzn.to/2ix8eif", HexColor = "DB0000"
            },
            new Color
            {
                ColorName = "Titanium White", ColorValue = "titaniumWhite",
                BuyLink = "http://amzn.to/2zfjiJ7", HexColor = "FFFFFF"
            },
            new Color
            {
                ColorName = "Burnt Umber", ColorValue = "burntUmber",
                BuyLink = "https://amzn.to/2LRAr3w", HexColor = "8A3324"
            },
            new Color
            {
                ColorName = "Black Gesso", ColorValue = "blackGesso",
                BuyLink = "http://amzn.to/2iwS9cF", HexColor = "000000"
            },
            new Color
            {
                ColorName = "Liquid Black", ColorValue = "liquidBlack",
                BuyLink = "https://amzn.to/2OEFs13", HexColor = "000000"
            },
            new Color
            {
                ColorName = "Liquid Clear", ColorValue = "liquidClear",
                BuyLink = "https://amzn.to/35wlMCm", HexColor = "FFFFFF"
            }
        };
    }
}
