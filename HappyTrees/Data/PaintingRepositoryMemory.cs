using HappyTrees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTrees.Data
{
    public class PaintingRepositoryMemory : IPaintingRepository
    {

        //CRUD - Create, Read, Update, Delete

        private static List<Painting> paintings = new List<Painting>
        {
            new Painting
            {
                Title = "A Walk in the Woods", Season = 1, Episode = 1,
                Description = "The very first episode of 'The Joy of Painting' with Bob Ross.",
                ThumbnailFile = "~/Images/Thumbnails/S01E01.png",
                VideoURL = "https://www.youtube.com/embed/oh5p5f5_-7A",
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
                VideoURL = "https://www.youtube.com/embed/RInDWhYceLU",
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
                VideoURL = "https://www.youtube.com/embed/UOziR7PoVco",
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
                VideoURL = "https://www.youtube.com/embed/0pwoixRikn4",
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
                VideoURL = "https://www.youtube.com/embed/DFSIQNjKRfk",
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
                VideoURL = "https://www.youtube.com/embed/loAzRUzx1wI",
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
                VideoURL = "https://www.youtube.com/embed/sDdpc8uisD0",
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
                VideoURL = "https://www.youtube.com/embed/kQlFwTOkYzg",
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
                VideoURL = "https://www.youtube.com/embed/QxcS7p1VHyQ",
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
                VideoURL = "https://www.youtube.com/embed/wDnLlywAL5I",
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
                VideoURL = "https://www.youtube.com/embed/Q03YvknOVe0",
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
                VideoURL = "https://www.youtube.com/embed/4E35-8x_y04",
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
                VideoURL = "https://www.youtube.com/embed/IEQWfszfRlA",
                Colors = new List<Color>
                    {
                        Color.SapGreen, Color.AlizarinCrimson, Color.VanDykeBrown, Color.PrussianBlue,
                        Color.PhthaloGreen, Color.CadmiumYellow, Color.BrightRed, Color.TitaniumWhite
                    }
            }
        };

        public List<Painting> GetAllPaintings()
        {
            return paintings;
        }

        public Painting GetPainting(string title)
        {
            Painting painting = paintings.FirstOrDefault(p => p.Title == title);
            return painting;
        }
    }
}
