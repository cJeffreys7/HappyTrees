using HappyTrees.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HappyTrees.Data
{
    public class PaintingRepositoryMemory : IPaintingRepository
    {

        //CRUD - Create, Read, Update, Delete

        private static List<Painting> paintings = new List<Painting>
        {
            new Painting
            {
                Id = 1,
                Title = "A Walk in the Woods", Season = 1, Episode = 1,
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
                Id = 2,
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
                Id = 3,
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
                Id = 4,
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
                Id = 5,
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
                Id = 6,
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
                Id = 7,
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
                Id = 8,
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
                Id = 9,
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
                Id = 10,
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
                Id = 11,
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
                Id = 12,
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
                Id = 13,
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

        public void AddPainting(Painting painting)
        {
            throw new NotImplementedException();
        }

        public List<Painting> GetAllPaintings()
        {
            return paintings;
        }

        public List<Painting> GetPaintingsOfSeason(int season)
        {
            throw new NotImplementedException();
        }

        public Painting GetPainting(int id)
        {
            Painting painting = paintings.FirstOrDefault(p => p.Id == id);
            return painting;
        }

    }
}
