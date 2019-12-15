using System.Collections.Generic;
using System.Linq;
using HappyTrees.Models;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;

namespace HappyTrees.Data
{
    public class PaintingRepositoryDB : IPaintingRepository
    {
        private readonly PaintingContext context;

        public PaintingRepositoryDB(PaintingContext context)
        {
            this.context = context;
            InitializePaintings();
        }
        public void AddPainting(Painting painting)
        {
            context.Paintings.Add(painting);
            context.SaveChanges();
        }

        public List<Painting> GetAllPaintings()
        {
            return context.Paintings.ToList();
        }

        public List<Painting> GetPaintingsOfSeason(int season)
        {
            return context.Paintings.Where(p => p.Season == season).ToList();
        }

        public Painting GetPainting(int id)
        {
            Painting painting = context.Paintings.FirstOrDefault(p => p.Id == id);
            painting.Colors = GetColors(painting.Id);
            return painting;
        }

        public ICollection<Color> GetColors(int paintingId)
        {

            List<Color> colors = context.Colors.Where(c => c.PaintingId == paintingId).ToList();
            return colors;
        }

        public void UpdatePainting(Painting painting)
        {
            List<Color> removedColors = GetColors(painting.Id).Except(painting.Colors).ToList();
            context.Colors.RemoveRange(removedColors);

            // TODO: Exception when updating colors of the same painting a second time
            context.Update(painting);
            context.SaveChanges();
        }

        public bool DeletePainting(int id)
        {
            Painting painting = context.Paintings.FirstOrDefault(p => p.Id == id);
            context.Paintings.Remove(painting);
            context.SaveChanges();

            return true;
        }

        private static List<Painting> defaultPaintings = new List<Painting>
        {
            new Painting
            {
                Title = "A Walk in the Woods",
                Season = 1,
                Episode = 1,
                Description = "The very first episode of 'The Joy of Painting' with Bob Ross.",
                ThumbnailFile = "~/Images/Thumbnails/S01E01.png",
                VideoUrl = "https://www.youtube.com/embed/oh5p5f5_-7A",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloGreen, Color.CadmiumYellow, Color.BrightRed, Color.TitaniumWhite,
                        Color.BlackGesso
                    }
            },
            new Painting
            {
                Title = "Mt. McKinley",
                Season = 1,
                Episode = 2,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S01E02.png",
                VideoUrl = "https://www.youtube.com/embed/RInDWhYceLU",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloGreen, Color.CadmiumYellow, Color.BrightRed, Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Ebony Sunset",
                Season = 1,
                Episode = 3,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S01E03.png",
                VideoUrl = "https://www.youtube.com/embed/UOziR7PoVco",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloGreen, Color.CadmiumYellow, Color.BrightRed, Color.TitaniumWhite,
                        Color.BlackGesso
                    }
            },
            new Painting
            {
                Title = "Winter Mist",
                Season = 1,
                Episode = 4,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S01E04.png",
                VideoUrl = "https://www.youtube.com/embed/0pwoixRikn4",
                Colors = new List<Color>
                    {
                        Color.VanDykeBrown, Color.PrussianBlue, Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Quiet Stream",
                Season = 1,
                Episode = 5,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S01E05.png",
                VideoUrl = "https://www.youtube.com/embed/DFSIQNjKRfk",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloGreen, Color.CadmiumYellow, Color.BrightRed, Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Winter Moon",
                Season = 1,
                Episode = 6,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S01E06.png",
                VideoUrl = "https://www.youtube.com/embed/loAzRUzx1wI",
                Colors = new List<Color>
                    {
                        Color.VanDykeBrown, Color.PrussianBlue, Color.TitaniumWhite, Color.BlackGesso
                    }
            },
            new Painting
            {
                Title = "Autumn Mountain",
                Season = 1,
                Episode = 7,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S01E07.png",
                VideoUrl = "https://www.youtube.com/embed/sDdpc8uisD0",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloGreen, Color.CadmiumYellow, Color.BrightRed, Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Peaceful Valley",
                Season = 1,
                Episode = 8,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S01E08.png",
                VideoUrl = "https://www.youtube.com/embed/kQlFwTOkYzg",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloGreen, Color.CadmiumYellow, Color.BrightRed, Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Seascape",
                Season = 1,
                Episode = 9,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S01E09.png",
                VideoUrl = "https://www.youtube.com/embed/QxcS7p1VHyQ",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloGreen, Color.CadmiumYellow, Color.BrightRed, Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Mountain Lake",
                Season = 1,
                Episode = 10,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S01E10.png",
                VideoUrl = "https://www.youtube.com/embed/wDnLlywAL5I",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloGreen, Color.CadmiumYellow, Color.BrightRed, Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Winter Glow",
                Season = 1,
                Episode = 11,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S01E11.png",
                VideoUrl = "https://www.youtube.com/embed/Q03YvknOVe0",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloGreen, Color.CadmiumYellow, Color.BrightRed, Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Snow Fall",
                Season = 1,
                Episode = 12,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S01E12.png",
                VideoUrl = "https://www.youtube.com/embed/4E35-8x_y04",
                Colors = new List<Color>
                    {
                        Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue, Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Final Reflections",
                Season = 1,
                Episode = 13,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S01E13.png",
                VideoUrl = "https://www.youtube.com/embed/IEQWfszfRlA",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloGreen, Color.CadmiumYellow, Color.BrightRed, Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Meadow Lake",
                Season = 2,
                Episode = 1,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S02E01.png",
                VideoUrl = "https://www.youtube.com/embed/GARWowi0QXI",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre,
                        Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Winter Sun",
                Season = 2,
                Episode = 2,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S02E02.png",
                VideoUrl = "https://www.youtube.com/embed/VPfYRj4DDco",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre,
                        Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Ebony Sea",
                Season = 2,
                Episode = 3,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S02E03.png",
                VideoUrl = "https://www.youtube.com/embed/aOJsKNzO3i8",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre,
                        Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite, Color.BlackGesso,
                        Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Shades of Grey",
                Season = 2,
                Episode = 4,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S02E04.png",
                VideoUrl = "https://www.youtube.com/embed/I-ousb8-SD0",
                Colors = new List<Color>
                    {
                        Color.VanDykeBrown, Color.PrussianBlue, Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Autumn Splendor",
                Season = 2,
                Episode = 5,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S02E05.png",
                VideoUrl = "https://www.youtube.com/embed/rTTWw5Gd79I",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre,
                        Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Black River",
                Season = 2,
                Episode = 6,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S02E06.png",
                VideoUrl = "https://www.youtube.com/embed/6O4sfJd8G_M",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre,
                        Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Brown Mountain",
                Season = 2,
                Episode = 7,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S02E07.png",
                VideoUrl = "https://www.youtube.com/embed/Vx6v47gHBWM",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre,
                        Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Reflections",
                Season = 2,
                Episode = 8,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S02E08.png",
                VideoUrl = "https://www.youtube.com/embed/0FYfo94qefg",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre,
                        Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Black and White Seascape",
                Season = 2,
                Episode = 9,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S02E09.png",
                VideoUrl = "https://www.youtube.com/embed/PMDyPrE0puo",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre,
                        Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite, Color.BlackGesso
                    }
            },
            new Painting
            {
                Title = "Lazy River",
                Season = 2,
                Episode = 10,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S02E10.png",
                VideoUrl = "https://www.youtube.com/embed/BW2wKKFvH1g",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre,
                        Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Black Waterfall",
                Season = 2,
                Episode = 11,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S02E11.png",
                VideoUrl = "https://www.youtube.com/embed/GzSqjyQUPZQ",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre,
                        Color.IndianYellow, Color.TitaniumWhite, Color.BlackGesso, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Mountain Waterfall",
                Season = 2,
                Episode = 12,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S02E12.png",
                VideoUrl = "https://www.youtube.com/embed/9jIt95PCFAA",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre,
                        Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Final Grace",
                Season = 2,
                Episode = 13,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S02E13.png",
                VideoUrl = "https://www.youtube.com/embed/miJ19Kz_i3Y",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre,
                        Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Mountain Retreat",
                Season = 3,
                Episode = 1,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S03E01.png",
                VideoUrl = "https://www.youtube.com/embed/hoimk4s8JoQ",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre,
                        Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Blue Moon",
                Season = 3,
                Episode = 2,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S03E02.png",
                VideoUrl = "https://www.youtube.com/embed/loit61vLUMc",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre,
                        Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Bubbling Stream",
                Season = 3,
                Episode = 3,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S03E03.png",
                VideoUrl = "https://www.youtube.com/embed/fuFalEXVN0k",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre,
                        Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Winter Night",
                Season = 3,
                Episode = 4,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S03E04.png",
                VideoUrl = "https://www.youtube.com/embed/fuFalEXVN0k",
                Colors = new List<Color>
                    {
                        Color.AlizarinCrimson, Color.VanDykeBrown, Color.PhthaloGreen, Color.CadmiumYellow,
                        Color.YellowOchre, Color.BrightRed, Color.TitaniumWhite, Color.LiquidBlack
                    }
            },
            new Painting
            {
                Title = "Distant Hills",
                Season = 3,
                Episode = 5,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S03E05.png",
                VideoUrl = "https://www.youtube.com/embed/8Zge88tVwjE",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.CadmiumYellow,
                        Color.YellowOchre, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Covered Bridge",
                Season = 3,
                Episode = 6,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S03E06.png",
                VideoUrl = "https://www.youtube.com/embed/OHSm8kLE7js",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.MidnightBlack,
                        Color.PrussianBlue, Color.CadmiumYellow, Color.YellowOchre, Color.BrightRed,
                        Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Quiet Inlet",
                Season = 3,
                Episode = 7,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S03E07.png",
                VideoUrl = "https://www.youtube.com/embed/9N5IWKzYIyU",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre,
                        Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Night Light",
                Season = 3,
                Episode = 8,
                Description = "Bob does the opening painting of season 3: a beautiful lighthouse in the night.",
                ThumbnailFile = "~/Images/Thumbnails/S03E08.png",
                VideoUrl = "https://www.youtube.com/embed/l141Y0x8om0",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PhthaloGreen,
                        Color.CadmiumYellow, Color.YellowOchre, Color.TitaniumWhite, Color.BlackGesso,
                        Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "The Old Mill",
                Season = 3,
                Episode = 9,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S03E09.png",
                VideoUrl = "https://www.youtube.com/embed/OFKFUJ9eDNs",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.CadmiumYellow, Color.YellowOchre, Color.BrightRed,
                        Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Campfire",
                Season = 3,
                Episode = 10,
                Description = "Bob has a crazy day and does a crazy painting.",
                ThumbnailFile = "~/Images/Thumbnails/S03E10.png",
                VideoUrl = "https://www.youtube.com/embed/L5bXkI0-pEg",
                Colors = new List<Color>
                    {
                        Color.AlizarinCrimson, Color.VanDykeBrown, Color.CadmiumYellow, Color.YellowOchre,
                        Color.IndianYellow, Color.BrightRed, Color.BlackGesso, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Rustic Barn",
                Season = 3,
                Episode = 11,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S03E11.png",
                VideoUrl = "https://www.youtube.com/embed/WJJwrnFhUUg",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre,
                        Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Hidden Lake",
                Season = 3,
                Episode = 12,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S03E12.png",
                VideoUrl = "https://www.youtube.com/embed/P_DaqkFbnac",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.CadmiumYellow, Color.YellowOchre, Color.BrightRed,
                        Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Peaceful Waters",
                Season = 3,
                Episode = 13,
                Description = "Bob does a little Q&A session with his the help of his son Steve.",
                ThumbnailFile = "~/Images/Thumbnails/S03E13.png",
                VideoUrl = "https://www.youtube.com/embed/Z0vtjRLqXcQ",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre,
                        Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Purple Splendor",
                Season = 4,
                Episode = 1,
                Description = "With only four colors Bob shows us how to do a great winter scene.",
                ThumbnailFile = "~/Images/Thumbnails/S04E01.png",
                VideoUrl = "https://www.youtube.com/embed/hP4GfMgsNVE",
                Colors = new List<Color>
                    {
                        Color.AlizarinCrimson, Color.VanDykeBrown, Color.PhthaloBlue, Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Tranquil Valley",
                Season = 4,
                Episode = 2,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S04E02.png",
                VideoUrl = "https://www.youtube.com/embed/PbchoOWWCZs",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PhthaloBlue,
                        Color.CadmiumYellow, Color.YellowOchre, Color.IndianYellow, Color.BrightRed,
                        Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Majestic Mountains",
                Season = 4,
                Episode = 3,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S04E03.png",
                VideoUrl = "https://www.youtube.com/embed/NcVeRlPu_5w",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre,
                        Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Winter Sawscape",
                Season = 4,
                Episode = 4,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S04E04.png",
                VideoUrl = "https://www.youtube.com/embed/lmKAwKrONmE",
                Colors = new List<Color>
                    {
                        Color.MidnightBlack, Color.PrussianBlue, Color.CadmiumYellow, Color.BrightRed,
                        Color.TitaniumWhite, Color.BlackGesso, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Evening Seascape",
                Season = 4,
                Episode = 5,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S04E05.png",
                VideoUrl = "https://www.youtube.com/embed/y5k4GXw_-yI",
                Colors = new List<Color>
                    {
                        Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue, Color.PhthaloBlue,
                        Color.PhthaloGreen, Color.CadmiumYellow, Color.BrightRed, Color.TitaniumWhite,
                        Color.BlackGesso, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Warm Summer Day",
                Season = 4,
                Episode = 6,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S04E06.png",
                VideoUrl = "https://www.youtube.com/embed/GBN9AIw3Ao4",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre,
                        Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Cabin in the Woods",
                Season = 4,
                Episode = 7,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S04E07.png",
                VideoUrl = "https://www.youtube.com/embed/81QKellPA70",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre,
                        Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Wetlands",
                Season = 4,
                Episode = 8,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S04E08.png",
                VideoUrl = "https://www.youtube.com/embed/2FpVyGanPwM",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.CadmiumYellow, Color.YellowOchre, Color.IndianYellow, Color.BrightRed,
                        Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Cool Waters",
                Season = 4,
                Episode = 9,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S04E09.png",
                VideoUrl = "https://www.youtube.com/embed/tJRvBcqQd5A",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre,
                        Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Quiet Woods",
                Season = 4,
                Episode = 10,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S04E10.png",
                VideoUrl = "https://www.youtube.com/embed/wIZX57I4aDs",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PhthaloBlue,
                        Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre, Color.IndianYellow,
                        Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Northwest Majesty",
                Season = 4,
                Episode = 11,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S04E11.png",
                VideoUrl = "https://www.youtube.com/embed/9DU6bunvD_g",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.CadmiumYellow, Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite,
                        Color.LiquidBlack, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Autumn Days",
                Season = 4,
                Episode = 12,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S04E12.png",
                VideoUrl = "https://www.youtube.com/embed/VAdMkf-AAPM",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre,
                        Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Mountain Challenge",
                Season = 4,
                Episode = 13,
                Description = "In this episode Bob works on a dry canvas and creates some beautiful mountains using only his knife.",
                ThumbnailFile = "~/Images/Thumbnails/S04E13.png",
                VideoUrl = "https://www.youtube.com/embed/o2cjLA_wgIk",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre,
                        Color.IndianYellow, Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Mountain Waterfall",
                Season = 5,
                Episode = 1,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S05E01.png",
                VideoUrl = "https://www.youtube.com/embed/DqhzxdkdQS0",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PhthaloBlue,
                        Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre, Color.IndianYellow,
                        Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Twilight Meadow",
                Season = 5,
                Episode = 2,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S05E02.png",
                VideoUrl = "https://www.youtube.com/embed/6evqNlOO7Bw",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PhthaloBlue,
                        Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre, Color.IndianYellow,
                        Color.BrightRed, Color.TitaniumWhite, Color.BlackGesso, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Mountain Blossoms",
                Season = 5,
                Episode = 3,
                Description = "Bob has invited his friend Dana Jester to paint a beautiful winter scene with us.",
                ThumbnailFile = "~/Images/Thumbnails/S05E03.png",
                VideoUrl = "https://www.youtube.com/embed/UVhhStJAJZc",
                Colors = new List<Color>
                    {
                        Color.AlizarinCrimson, Color.PhthaloBlue, Color.PhthaloGreen, Color.TitaniumWhite,
                        Color.LiquidBlack
                    }
            },
            new Painting
            {
                Title = "Winter Stillness",
                Season = 5,
                Episode = 4,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S05E04.png",
                VideoUrl = "https://www.youtube.com/embed/qg9c1SqdRko",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PhthaloBlue,
                        Color.PhthaloGreen, Color.IndianYellow, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Quiet Pond",
                Season = 5,
                Episode = 5,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S05E05.png",
                VideoUrl = "https://www.youtube.com/embed/aiK9xOIJtV8",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PhthaloBlue,
                        Color.CadmiumYellow, Color.YellowOchre, Color.IndianYellow, Color.BrightRed,
                        Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Ocean Sunrise",
                Season = 5,
                Episode = 6,
                Description = "Bob has his friend Audrey Golden visit us in his studio and paint a fantastic seascape with us.",
                ThumbnailFile = "~/Images/Thumbnails/S05E06.png",
                VideoUrl = "https://www.youtube.com/embed/u0Bz6TNUK1Q",
                Colors = new List<Color>
                    {
                        Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue, Color.IndianYellow,
                        Color.TitaniumWhite, Color.LiquidBlack
                    }
            },
            new Painting
            {
                Title = "Bubbling Brook",
                Season = 5,
                Episode = 7,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S05E07.png",
                VideoUrl = "https://www.youtube.com/embed/LiKCzeqn-kg",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PhthaloBlue,
                        Color.CadmiumYellow, Color.YellowOchre, Color.IndianYellow, Color.BrightRed,
                        Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Arizona Splendor",
                Season = 5,
                Episode = 8,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S05E08.png",
                VideoUrl = "https://www.youtube.com/embed/spFwCh2616s",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PhthaloBlue,
                        Color.CadmiumYellow, Color.YellowOchre, Color.IndianYellow, Color.TitaniumWhite,
                        Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Anatomy of a Wave",
                Season = 5,
                Episode = 9,
                Description = "Bob's good friend Joyce Ortner shows us how to paint a beautiful seascape.",
                ThumbnailFile = "~/Images/Thumbnails/S05E09.png",
                VideoUrl = "https://www.youtube.com/embed/DFQlu6eqrBo",
                Colors = new List<Color>
                    {
                        Color.AlizarinCrimson, Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow,
                        Color.TitaniumWhite, Color.LiquidClear
                    }
            },
            new Painting
            {
                Title = "The Windmill",
                Season = 5,
                Episode = 10,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S05E10.png",
                VideoUrl = "https://www.youtube.com/embed/xj8xsTSkbUk",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.YellowOchre, Color.BrightRed,
                        Color.TitaniumWhite, Color.BlackGesso, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Autumn Glory",
                Season = 5,
                Episode = 11,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S05E11.png",
                VideoUrl = "https://www.youtube.com/embed/yTzlm_t0RmY",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.CadmiumYellow, Color.IndianYellow, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Indian Girl",
                Season = 5,
                Episode = 12,
                Description = "Bob asked his friend Ferne Serois to show us how to do a basic portrait.",
                ThumbnailFile = "~/Images/Thumbnails/S05E12.png",
                VideoUrl = "https://www.youtube.com/embed/2uXMx8Kjs8I",
                Colors = new List<Color>
                    {
                        Color.PrussianBlue, Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite,
                        Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Meadow Stream",
                Season = 5,
                Episode = 13,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S05E13.png",
                VideoUrl = "https://www.youtube.com/embed/87MMbN1bQCs",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PhthaloBlue,
                        Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre, Color.IndianYellow,
                        Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Blue River",
                Season = 6,
                Episode = 1,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S06E01.png",
                VideoUrl = "https://www.youtube.com/embed/LygUyAb78oY",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.CadmiumYellow, Color.YellowOchre, Color.IndianYellow,
                        Color.BrightRed, Color.TitaniumWhite, Color.BlackGesso, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Nature's Edge",
                Season = 6,
                Episode = 2,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S06E02.png",
                VideoUrl = "https://www.youtube.com/embed/Bcqyzo85A1o",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.CadmiumYellow, Color.YellowOchre, Color.IndianYellow,
                        Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Morning Mist",
                Season = 6,
                Episode = 3,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S06E03.png",
                VideoUrl = "https://www.youtube.com/embed/wbZreRaE74k",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PhthaloBlue,
                        Color.CadmiumYellow, Color.YellowOchre, Color.IndianYellow, Color.BrightRed,
                        Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Whispering Stream",
                Season = 6,
                Episode = 4,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S06E04.png",
                VideoUrl = "https://www.youtube.com/embed/QglIjlqsUdU",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.CadmiumYellow, Color.YellowOchre, Color.IndianYellow,
                        Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Secluded Forest",
                Season = 6,
                Episode = 5,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S06E05.png",
                VideoUrl = "https://www.youtube.com/embed/USkduOfwJok",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PhthaloBlue,
                        Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre, Color.IndianYellow,
                        Color.BrightRed, Color.TitaniumWhite, Color.BlackGesso, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Snow Trail",
                Season = 6,
                Episode = 6,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S06E06.png",
                VideoUrl = "https://www.youtube.com/embed/n9EsFFtwZnE",
                Colors = new List<Color>
                    {
                        Color.AlizarinCrimson, Color.VanDykeBrown, Color.PhthaloBlue, Color.PhthaloGreen,
                        Color.CadmiumYellow, Color.YellowOchre, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Arctic Beauty",
                Season = 6,
                Episode = 7,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S06E07.png",
                VideoUrl = "https://www.youtube.com/embed/UQ-RTZCOQn0",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PhthaloBlue,
                        Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre, Color.IndianYellow,
                        Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Horizons West",
                Season = 6,
                Episode = 8,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S06E08.png",
                VideoUrl = "https://www.youtube.com/embed/m6UM-rN2D6s",
                Colors = new List<Color>
                    {
                        Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue, Color.CadmiumYellow,
                        Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "High Chateau",
                Season = 6,
                Episode = 9,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S06E09.png",
                VideoUrl = "https://www.youtube.com/embed/dafH8ks9Zww",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PhthaloBlue,
                        Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre, Color.IndianYellow,
                        Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Country Life",
                Season = 6,
                Episode = 10,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S06E10.png",
                VideoUrl = "https://www.youtube.com/embed/j8Jf7QVKLgQ",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.CadmiumYellow, Color.YellowOchre, Color.IndianYellow, Color.BrightRed,
                        Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Western Expanse",
                Season = 6,
                Episode = 11,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S06E11.png",
                VideoUrl = "https://www.youtube.com/embed/MTInkV5ODjk",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PhthaloBlue,
                        Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre, Color.IndianYellow,
                        Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Marshlands",
                Season = 6,
                Episode = 12,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S06E12.png",
                VideoUrl = "https://www.youtube.com/embed/Ugiwi8uizpg",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PhthaloBlue,
                        Color.CadmiumYellow, Color.YellowOchre, Color.IndianYellow, Color.BrightRed,
                        Color.TitaniumWhite, Color.BlackGesso, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Blaze of Color",
                Season = 6,
                Episode = 13,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S06E13.png",
                VideoUrl = "https://www.youtube.com/embed/se7wOprxRGs",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PhthaloBlue,
                        Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre, Color.IndianYellow,
                        Color.BrightRed, Color.TitaniumWhite, Color.BurntUmber
                    }
            },
            new Painting
            {
                Title = "Winter Cabin",
                Season = 7,
                Episode = 1,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S07E01.png",
                VideoUrl = "https://www.youtube.com/embed/kdlHV6ceI_g",
                Colors = new List<Color>
                    {
                        Color.VanDykeBrown, Color.DarkSienna, Color.PrussianBlue, Color.YellowOchre,
                        Color.BrightRed, Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Secluded Lake",
                Season = 7,
                Episode = 2,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S07E02.png",
                VideoUrl = "https://www.youtube.com/embed/2OxSJcFvpoU",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.DarkSienna,
                        Color.MidnightBlack, Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow,
                        Color.YellowOchre, Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Evergreens at Sunset",
                Season = 7,
                Episode = 3,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S07E03.png",
                VideoUrl = "https://www.youtube.com/embed/YQPEy3hYGo8",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.MidnightBlack, Color.CadmiumYellow,
                        Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Mountain Cabin",
                Season = 7,
                Episode = 4,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S07E04.png",
                VideoUrl = "https://www.youtube.com/embed/E3IAMvO8GyM",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.DarkSienna,
                        Color.MidnightBlack, Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow,
                        Color.YellowOchre, Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Portrait of Sally",
                Season = 7,
                Episode = 5,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S07E05.png",
                VideoUrl = "https://www.youtube.com/embed/MHJB0IBnuD4",
                Colors = new List<Color>
                    {
                        Color.AlizarinCrimson, Color.DarkSienna, Color.PhthaloBlue, Color.CadmiumYellow,
                        Color.YellowOchre, Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Misty Waterfall",
                Season = 7,
                Episode = 6,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S07E06.png",
                VideoUrl = "https://www.youtube.com/embed/530_cVmexiI",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.DarkSienna,
                        Color.MidnightBlack, Color.PhthaloBlue, Color.PhthaloGreen, Color.YellowOchre,
                        Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Barn at Sunset",
                Season = 7,
                Episode = 7,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S07E07.png",
                VideoUrl = "https://www.youtube.com/embed/WT6n0K2zGnA",
                Colors = new List<Color>
                    {
                        Color.AlizarinCrimson, Color.VanDykeBrown, Color.DarkSienna, Color.MidnightBlack,
                        Color.PhthaloBlue, Color.CadmiumYellow, Color.YellowOchre, Color.IndianYellow,
                        Color.BrightRed, Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Mountain Splendor",
                Season = 7,
                Episode = 8,
                Description = "Bob shows us how to do the opening painting of season 7.",
                ThumbnailFile = "~/Images/Thumbnails/S07E08.png",
                VideoUrl = "https://www.youtube.com/embed/GhOGZMpPUSE",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.DarkSienna,
                        Color.MidnightBlack, Color.PrussianBlue, Color.CadmiumYellow, Color.YellowOchre,
                        Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Lake by Mountain",
                Season = 7,
                Episode = 9,
                Description = "Bob's son Steve Ross show us how to paint a fantastic landscape painting.",
                ThumbnailFile = "~/Images/Thumbnails/S07E09.png",
                VideoUrl = "https://www.youtube.com/embed/yAiYirlcq7o",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloBlue, Color.PhthaloGreen, Color.CadmiumYellow, Color.YellowOchre,
                        Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Mountain Glory",
                Season = 7,
                Episode = 10,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S07E10.png",
                VideoUrl = "https://www.youtube.com/embed/0M9pwLHRR2c",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.VanDykeBrown, Color.DarkSienna, Color.MidnightBlack,
                        Color.PrussianBlue, Color.PhthaloBlue, Color.CadmiumYellow, Color.YellowOchre,
                        Color.IndianYellow, Color.BrightRed, Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Grey Winter",
                Season = 7,
                Episode = 11,
                Description = "Using only three colors Bob shows us how to paint a fantastic winter scene.",
                ThumbnailFile = "~/Images/Thumbnails/S07E11.png",
                VideoUrl = "https://www.youtube.com/embed/sS-hNYgDUak",
                Colors = new List<Color>
                    {
                        Color.AlizarinCrimson, Color.MidnightBlack, Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Dock Scene",
                Season = 7,
                Episode = 12,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S07E12.png",
                VideoUrl = "https://www.youtube.com/embed/4KYxkqlzyqM",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.VanDykeBrown, Color.DarkSienna, Color.MidnightBlack,
                        Color.PhthaloBlue, Color.CadmiumYellow, Color.YellowOchre, Color.BrightRed,
                        Color.TitaniumWhite
                    }
            },
            new Painting
            {
                Title = "Dark Waterfall",
                Season = 7,
                Episode = 13,
                Description = "",
                ThumbnailFile = "~/Images/Thumbnails/S07E13.png",
                VideoUrl = "https://www.youtube.com/embed/VqMbL00eZqw",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.DarkSienna,
                        Color.PhthaloBlue, Color.CadmiumYellow, Color.YellowOchre, Color.BrightRed,
                        Color.TitaniumWhite, Color.LiquidBlack
                    }
            }
        };

        private void InitializePaintings()
        {
            if (context.Paintings.Count() < defaultPaintings.Count)
            {
                context.Database.OpenConnection();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Colors ON");
                for (int i = context.Paintings.Count(); i < defaultPaintings.Count; i++)
                {
                    // Add each painting without colors to allow for manual insert of colors
                    var paintingNoColors = new Painting
                    {
                        Id = defaultPaintings[i].Id,
                        Season = defaultPaintings[i].Season,
                        Episode = defaultPaintings[i].Episode,
                        Title = defaultPaintings[i].Title,
                        Description = defaultPaintings[i].Description,
                        ThumbnailFile = defaultPaintings[i].ThumbnailFile,
                        VideoUrl = defaultPaintings[i].VideoUrl
                    };
                    context.Paintings.Add(paintingNoColors);
                    context.SaveChanges();

                    foreach (var color in defaultPaintings[i].Colors)
                    {
                        if (context.Colors.Any<Color>())
                        {
                            color.Id = context.Colors.Last().Id + 1;
                        }
                        else
                        {
                            color.Id = 1;
                        }
                        if (context.Paintings.Any<Painting>())
                        {
                            color.PaintingId = context.Paintings.Last().Id;
                        }
                        else
                        {
                            color.PaintingId = 1;
                        }
                        // Insert each color manually to prevent overriding with non-unique Color Id's
                        context.Database.ExecuteSqlCommand(
                            $@"INSERT INTO [dbo].[Colors] ( [Id], [ColorName], [BuyLink], [HexColor], [PaintingId] ) 
                               VALUES ( {color.Id}, {color.ColorName}, {color.BuyLink}, {color.HexColor}, {color.PaintingId} )");
                    }
                    context.SaveChanges();
                }
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Colors OFF");
                context.Database.CloseConnection();
            }
        }
    }
}
