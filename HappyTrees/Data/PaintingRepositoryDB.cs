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

        public List<Painting> GetAllPaintings()
        {
            return context.Paintings.ToList();
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

        public void AddPainting(Painting painting)
        {
            context.Paintings.Add(painting);
            context.SaveChanges();
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
