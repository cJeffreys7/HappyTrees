using System;
using System.Collections.Generic;
using System.Linq;
using HappyTrees.Models;
using HappyTrees.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HappyTrees.Controllers
{
    [Route("[controller]/[action]")]
    public class PaintingController : Controller
    {
        private readonly IPaintingService paintingService;
        private readonly IColorService colorService;

        private int paintingId;
        private int totalSeasons;

        public PaintingController(IPaintingService paintingService, IColorService colorService)
        {
            this.paintingService = paintingService;
            this.colorService = colorService;
        }


        // Show categorized paintings in grid format
        public ActionResult AllPaintings()
        {
            List<Painting> paintings = paintingService.GetAllPaintings(colorService);
            return View(paintings);
        }

        public ActionResult SeasonIn(int season, int totalSeasons)
        {
            TempData["totalSeasons"] = totalSeasons;
            return RedirectToAction("Season", "Painting", new { season = season });
        }

        [HttpGet("{season}")]
        public ActionResult Season(int season)
        {
            totalSeasons = Convert.ToInt32(TempData["totalSeasons"]);
            TempData["totalSeasons"] = totalSeasons;
            List<Painting> paintings = paintingService.GetPaintingsOfSeason(season);
            return View(paintings);
        }

        // Redirect to PaintingDetails without id parameter, store in TempData
        public ActionResult PaintingDetailsIn(int id, string title)
        {
            TempData["id"] = id;
            return RedirectToAction("PaintingDetails", "Painting", new { title = title});
        }

        // Show selected painting's details, retrieve id from TempData, save id in new TempData
        [HttpGet("{title}")]
        public ActionResult PaintingDetails()
        {
            paintingId = Convert.ToInt32(TempData["id"]);
            TempData["id"] = paintingId;
            Painting painting = paintingService.GetPainting(paintingId, colorService);

            return View(painting);
        }

        // GET: Painting/Create
        public ActionResult CreatePainting()
        {
            List<Color> colors = colorService.GetAllColors();
            bool[] selectedColors = new bool[colors.Count];

            ViewBag.itemList = CreateItemList(colors, selectedColors);

            return View();
        }

        // Takes colors from multi select drop down list in View and adds to Painting Model
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePainting(Painting painting, string[] colors)
        {
            try
            {
                List<Color> newColors = CreateColorList(colors);

                if (newColors.Any())
                {
                    painting.Colors = newColors;
                }

                paintingService.AddPainting(painting);

                return RedirectToAction(nameof(AllPaintings));
            }
            catch
            {
                return View();
            }
        }

        // GET: Painting/Update
        public ActionResult UpdatePainting(int id)
        {
            Painting painting = paintingService.GetPainting(id, colorService);
            List<Color> colors = colorService.GetAllColors();
            bool[] selectedColors = painting.SelectedColors(colors);

            ViewBag.itemList = CreateItemList(colors, selectedColors);

            return View(painting);
        }

        // POST: Painting/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePainting(Painting painting, string[] colors)
        {
            try
            {
                List<Color> updatedColors = CreateColorList(colors);

                if (updatedColors.Any())
                {
                    painting.Colors = updatedColors;
                }

                paintingService.UpdatePainting(painting);

                return RedirectToAction(nameof(AllPaintings));
            }
            catch
            {
                List<Color> colorList = colorService.GetAllColors();
                bool[] selectedColors = painting.SelectedColors(colorList);

                ViewBag.itemList = CreateItemList(colorList, selectedColors);

                return View(painting);
            }
        }

        // GET: Painting/Delete/5
        public ActionResult DeletePainting(int id)
        {
            try
            {
                paintingService.DeletePainting(id);

                return RedirectToAction(nameof(AllPaintings));
            }
            catch
            {
                return View();
            }
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

        private List<Color> CreateColorList(string[] colorValues)
        {
            List<Color> colors = new List<Color>();

            if (colorValues.Length > 1)
            {
                foreach (var colorValue in colorValues)
                {
                    var color = colorService.GetColor(colorValue);
                    colors.Add(color);
                }
            }

            return colors;
        }

        private static List<SelectListItem> CreateItemList(List<Color> colors, bool[] selectedColors)
        {
            var itemList = new List<SelectListItem>();

            for (int i = 0; i < colors.Count; i++)
            {
                var itemToAdd = new SelectListItem
                {
                    Text = colors[i].ColorName,
                    Value = colors[i].ColorValue,
                    Selected = (selectedColors[i])
                };
                itemList.Add(itemToAdd);
            }

            return itemList;
        }
    }
}