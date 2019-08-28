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

        public static Color TitaniumWhite = new Color { ColorName = "Titanium White", BuyLink = "https://tinyurl.com/y58s5xad", HexColor = "b4b2a7" };

        public static Color SapGreen = new Color { ColorName = "Sap Green", BuyLink = "https://tinyurl.com/y5zp9uqk", HexColor = "507d2a" };

        public static Color AlizarinCrimson = new Color { ColorName = "Alizarin Crimson", BuyLink = "https://tinyurl.com/y2oembq2", HexColor = "e32636" };

        public static Color VanDykeBrown = new Color { ColorName = "Van Dyke Brown", BuyLink = "https://tinyurl.com/y49ppoa4", HexColor = "584630" };

        public static Color PrussianBlue = new Color { ColorName = "Prussian Blue", BuyLink = "https://tinyurl.com/y37apno9", HexColor = "003153" };

        public static Color PhthaloGreen = new Color { ColorName = "Phthalo Green", BuyLink = "https://tinyurl.com/yxvmeass", HexColor = "123524" };

        public static Color CadmiumYellow = new Color { ColorName = "Cadmium Yellow", BuyLink = "https://tinyurl.com/y53aqxcd", HexColor = "fff600" };

        public static Color BrightRed = new Color { ColorName = "Bright Red", BuyLink = "https://tinyurl.com/y6h7wwof", HexColor = "ff0000" };

        public static Color BlackGesso = new Color { ColorName = "Black Gesso", BuyLink = "https://tinyurl.com/y35c7nh2", HexColor = "000000" };

    }
}
