﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HappyTrees.Data;
using HappyTrees.Models;
using HappyTrees.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyTrees.Controllers
{
    [Route("[controller]/[action]")]
    public class PaintingController : Controller
    {
        private readonly IPaintingService paintingService;

        public PaintingController(IPaintingService paintingService)
        {
            this.paintingService = paintingService;
        }


        // Show categorized paintings in grid format
        public ActionResult AllPaintings()
        {
            List<Painting> paintings = paintingService.GetAllPaintings();
            return View(paintings);
        }

        // Show selected painting's details
        [HttpGet("{title}")]
        //[Route("this-routes")]
        public ActionResult PaintingDetails(string title)
        {
            title = title.Replace("-", " ");
            Painting painting = paintingService.GetPainting(title);

            return View(painting);
        }

        // GET: Painting/Create
        public ActionResult CreatePainting()
        {
            return View();
        }

        // POST: Painting/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePainting(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Painting painting = new Painting()
                {
                    Title = collection["title"],
                    Season = int.Parse(collection["season"]),
                    Episode = int.Parse(collection["episode"]),
                    Description = collection["description"],
                    ThumbnailFile = collection["thumbnailfile"],
                    VideoUrl = collection["videourl"]
                };
                paintingService.AddPainting(painting);

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