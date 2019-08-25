using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HappyTrees.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyTrees.Controllers
{
    public class PaintingController : Controller
    {
        
        
        // Show categorized paintings in grid format
        public ActionResult AllPaintings()
        {
            
            Painting painting1 = new Painting { Title = "A Walk in the Woods", Season = 1, Episode = 1,
                Description = "The very first episode of 'The Joy of Painting' with Bob Ross.",
                ThumbnailFile = "~/css/Thumbnails/S01E01.png",
                VideoURL = "https://www.youtube.com/embed/oh5p5f5_-7A",
                Colors = {}
            };
            Painting painting2 = new Painting { Title = "Mt. McKinley", Season = 1, Episode = 2,
                Description = "", ThumbnailFile = "~/css/Thumbnails/S01E02.png",
                VideoURL = "https://www.youtube.com/embed/RInDWhYceLU"
            };
            Painting painting3 = new Painting { Title = "Ebony Sunset", Season = 1, Episode = 3,
                Description = "", ThumbnailFile = "~/css/Thumbnails/S01E03.png",
                VideoURL = "https://www.youtube.com/embed/UOziR7PoVco"
            };
            Painting painting4 = new Painting { Title = "Winter Mist", Season = 1, Episode = 4,
                Description = "", ThumbnailFile = "~/css/Thumbnails/S01E04.png",
                VideoURL = "https://www.youtube.com/embed/0pwoixRikn4"
            };
            Painting painting5 = new Painting { Title = "Quiet Stream", Season = 1, Episode = 5,
                Description = "", ThumbnailFile = "~/css/Thumbnails/S01E05.png",
                VideoURL = "https://www.youtube.com/embed/DFSIQNjKRfk"
            };
            Painting painting6 = new Painting { Title = "Winter Moon", Season = 1, Episode = 6,
                Description = "", ThumbnailFile = "~/css/Thumbnails/S01E06.png",
                VideoURL = "https://www.youtube.com/embed/loAzRUzx1wI"
            };
            Painting painting7 = new Painting { Title = "Autumn Mountain", Season = 1, Episode = 7,
                Description = "", ThumbnailFile = "~/css/Thumbnails/S01E07.png",
                VideoURL = "https://www.youtube.com/embed/sDdpc8uisD0"
            };
            Painting painting8 = new Painting { Title = "Peaceful Valley", Season = 1, Episode = 8,
                Description = "", ThumbnailFile = "~/css/Thumbnails/S01E08.png",
                VideoURL = "https://www.youtube.com/embed/kQlFwTOkYzg"
            };
            Painting painting9 = new Painting { Title = "Seascape", Season = 1, Episode = 9,
                Description = "", ThumbnailFile = "~/css/Thumbnails/S01E09.png",
                VideoURL = "https://www.youtube.com/embed/QxcS7p1VHyQ"
            };
            Painting painting10 = new Painting { Title = "Mountain Lake", Season = 1, Episode = 10,
                Description = "", ThumbnailFile = "~/css/Thumbnails/S01E10.png",
                VideoURL = "https://www.youtube.com/embed/wDnLlywAL5I"
            };
            Painting painting11 = new Painting { Title = "Winter Glow", Season = 1, Episode = 11
                , Description = "", ThumbnailFile = "~/css/Thumbnails/S01E11.png",
                VideoURL = "https://www.youtube.com/embed/Q03YvknOVe0"
            };
            Painting painting12 = new Painting { Title = "Snow Fall", Season = 1, Episode = 12,
                Description = "", ThumbnailFile = "~/css/Thumbnails/S01E12.png",
                VideoURL = "https://www.youtube.com/embed/4E35-8x_y04"
            };
            Painting painting13 = new Painting { Title = "Final Reflections", Season = 1, Episode = 13,
                Description = "", ThumbnailFile = "~/css/Thumbnails/S01E13.png",
                VideoURL = "https://www.youtube.com/embed/IEQWfszfRlA"
            };
            List<Painting> testPaintings = new List<Painting> { painting1, painting2, painting3, painting4,
                painting5, painting6, painting7, painting8, painting9, painting10, painting11, painting12,
                painting13 };
            return View(testPaintings);
        }

        // Show selected painting's details
        public ActionResult PaintingDetails(Painting painting)
        {
            return View(painting);
        }

        // GET: Painting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Painting/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(AllPaintings));
            }
            catch
            {
                return View();
            }
        }

        // GET: Painting/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Painting/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(AllPaintings));
            }
            catch
            {
                return View();
            }
        }

        // GET: Painting/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Painting/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(AllPaintings));
            }
            catch
            {
                return View();
            }
        }
    }
}