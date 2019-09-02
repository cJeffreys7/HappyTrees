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

        public static Color TitaniumWhite = new Color { ColorName = "Titanium White", BuyLink = "http://amzn.to/2zfjiJ7", HexColor = "b4b2a7" };

        public static Color SapGreen = new Color { ColorName = "Sap Green", BuyLink = "http://amzn.to/2y271WV", HexColor = "507d2a" };

        public static Color AlizarinCrimson = new Color { ColorName = "Alizarin Crimson", BuyLink = "http://amzn.to/2hc4nuv", HexColor = "e32636" };

        public static Color VanDykeBrown = new Color { ColorName = "Van Dyke Brown", BuyLink = "http://amzn.to/2ivJmI1", HexColor = "584630" };

        public static Color PrussianBlue = new Color { ColorName = "Prussian Blue", BuyLink = "http://amzn.to/2zlo7CD", HexColor = "003153" };

        public static Color PhthaloGreen = new Color { ColorName = "Phthalo Green", BuyLink = "http://amzn.to/2iwCBW5", HexColor = "123524" };

        public static Color CadmiumYellow = new Color { ColorName = "Cadmium Yellow", BuyLink = "http://amzn.to/2hJgoF0", HexColor = "fff600" };

        public static Color BrightRed = new Color { ColorName = "Bright Red", BuyLink = "http://amzn.to/2ix8eif", HexColor = "ff0000" };

        public static Color BlackGesso = new Color { ColorName = "Black Gesso", BuyLink = "http://amzn.to/2iwS9cF", HexColor = "000000" };

    }
}
