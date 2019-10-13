using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyTrees.Models
{
    public class Color
    {
        [Key]
        public int Id { get; set; }

        public string ColorName { get; set; }

        public string BuyLink { get; set; }

        public string HexColor { get; set; }

        public int PaintingId { get; set; }

        public virtual Painting Painting { get; set; }

        public static Color SapGreen = new Color { ColorName = "Sap Green", BuyLink = "http://amzn.to/2y271WV", HexColor = "0A3410" };

        public static Color AlizarinCrimson = new Color { ColorName = "Alizarin Crimson", BuyLink = "http://amzn.to/2hc4nuv", HexColor = "4E1500" };

        public static Color VanDykeBrown = new Color { ColorName = "Van Dyke Brown", BuyLink = "http://amzn.to/2ivJmI1", HexColor = "221B15" };

        public static Color MidnightBlack = new Color { ColorName = "Midnight Black", BuyLink = "https://amzn.to/2qaLgoZ", HexColor = "000000" };

        public static Color PrussianBlue = new Color { ColorName = "Prussian Blue", BuyLink = "http://amzn.to/2zlo7CD", HexColor = "021E44" };

        public static Color PhthaloBlue = new Color { ColorName = "Phthalo Blue", BuyLink = "https://amzn.to/2MkysU8", HexColor = "000F89" };

        public static Color PhthaloGreen = new Color { ColorName = "Phthalo Green", BuyLink = "http://amzn.to/2iwCBW5", HexColor = "102E3C" };

        public static Color CadmiumYellow = new Color { ColorName = "Cadmium Yellow", BuyLink = "http://amzn.to/2hJgoF0", HexColor = "FFEC00" };

        public static Color YellowOchre = new Color { ColorName = "Yellow Ochre", BuyLink = "https://amzn.to/30N3xFh", HexColor = "CC7722" };

        public static Color IndianYellow = new Color { ColorName = "Indian Yellow", BuyLink = "https://amzn.to/31P0DkR", HexColor = "E3A857" };

        public static Color BrightRed = new Color { ColorName = "Bright Red", BuyLink = "http://amzn.to/2ix8eif", HexColor = "DB0000" };

        public static Color TitaniumWhite = new Color { ColorName = "Titanium White", BuyLink = "http://amzn.to/2zfjiJ7", HexColor = "FFFFFF" };

        public static Color BurntUmber = new Color { ColorName = "Burnt Umber", BuyLink = "https://amzn.to/2LRAr3w", HexColor = "8A3324" };

        public static Color BlackGesso = new Color { ColorName = "Black Gesso", BuyLink = "http://amzn.to/2iwS9cF", HexColor = "000000" };

        public static Color LiquidBlack = new Color { ColorName = "Liquid Black", BuyLink = "https://amzn.to/2OEFs13", HexColor = "000000" };

        public static Color LiquidClear = new Color { ColorName = "Liquid Black", BuyLink = "https://amzn.to/35wlMCm", HexColor = "FFFFFF" };

    }
}
