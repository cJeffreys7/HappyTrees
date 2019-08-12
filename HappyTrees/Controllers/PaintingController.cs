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
        
        
        // GET: Painting
        public ActionResult AllPaintings()
        {
            
            Painting painting1 = new Painting { Title = "A Walk in the Woods", Season = 1, Episode = 1, Description = "The very first episode of 'The Joy of Painting' with Bob Ross.", ThumbnailFile = "~/css/Thumbnails/S01E01.png" };
            Painting painting2 = new Painting { Title = "Mt. McKinley", Season = 1, Episode = 2, Description = "", ThumbnailFile = "~/css/Thumbnails/S01E02.png" };
            Painting painting3 = new Painting { Title = "Ebony Sunset", Season = 1, Episode = 3, Description = "", ThumbnailFile = "~/css/Thumbnails/S01E03.png" };
            List<Painting> testPaintings = new List<Painting> { painting1, painting2, painting3 };
            return View(testPaintings);
        }

        // GET: Painting/Details/5
        public ActionResult Details(int id)
        {
            return View();
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