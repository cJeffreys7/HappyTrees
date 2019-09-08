using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTrees.Models
{
    public class Color
    {
        public string ColorName { get; set; }

        public string BuyLink { get; set; }

        public string HexColor { get; set; }

        public static Color TitaniumWhite = new Color { ColorName = "Titanium White", BuyLink = "http://amzn.to/2zfjiJ7", HexColor = "FFFFFF" };

        public static Color SapGreen = new Color { ColorName = "Sap Green", BuyLink = "http://amzn.to/2y271WV", HexColor = "0A3410" };

        public static Color AlizarinCrimson = new Color { ColorName = "Alizarin Crimson", BuyLink = "http://amzn.to/2hc4nuv", HexColor = "4E1500" };

        public static Color VanDykeBrown = new Color { ColorName = "Van Dyke Brown", BuyLink = "http://amzn.to/2ivJmI1", HexColor = "221B15" };

        public static Color PrussianBlue = new Color { ColorName = "Prussian Blue", BuyLink = "http://amzn.to/2zlo7CD", HexColor = "021E44" };

        public static Color PhthaloGreen = new Color { ColorName = "Phthalo Green", BuyLink = "http://amzn.to/2iwCBW5", HexColor = "102E3C" };

        public static Color CadmiumYellow = new Color { ColorName = "Cadmium Yellow", BuyLink = "http://amzn.to/2hJgoF0", HexColor = "FFEC00" };

        public static Color BrightRed = new Color { ColorName = "Bright Red", BuyLink = "http://amzn.to/2ix8eif", HexColor = "DB0000" };

        public static Color BlackGesso = new Color { ColorName = "Black Gesso", BuyLink = "http://amzn.to/2iwS9cF", HexColor = "000000" };

    }
}
