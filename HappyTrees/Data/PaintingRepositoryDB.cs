using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HappyTrees.Models;
using HappyTrees.Data;
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

        public Painting GetPainting(string title)
        {
            Painting painting = context.Paintings.FirstOrDefault(p => p.Title == title);
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

            if (painting.Colors.Count > 0)
            {
                foreach (var color in painting.Colors)
                {
                    // Cannot insert explicit value for identity column error for Color
                    // Not sure how to turn ON IDENTITY_INSERT
                    // Better fix would be to prevent Id for Color being set multiple times
                    context.Colors.Add(color);
                }
                context.SaveChanges();
            }
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
            }
        };

        private void InitializePaintings()
        {
            if (context.Paintings.Count() < defaultPaintings.Count)
            {
                for (int i = context.Paintings.Count(); i < defaultPaintings.Count; i++)
                {
                    AddPainting(defaultPaintings[i]);
                }
            }
        }
    }
}
