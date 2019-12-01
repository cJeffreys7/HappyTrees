using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HappyTrees.Data;
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

        private int paintingId;
        private int totalSeasons;

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
            Painting painting = paintingService.GetPainting(paintingId);

            return View(painting);
        }

        // GET: Painting/Create
        public ActionResult CreatePainting()
        {
            List<Color> colors = new List<Color>()
            {
                Color.SapGreen,
                Color.AlizarinCrimson,
                Color.VanDykeBrown,
                Color.DarkSienna,
                Color.MidnightBlack,
                Color.PrussianBlue,
                Color.PhthaloBlue,
                Color.PhthaloGreen,
                Color.CadmiumYellow,
                Color.YellowOchre,
                Color.IndianYellow,
                Color.BrightRed,
                Color.TitaniumWhite,
                Color.BurntUmber,
                Color.BlackGesso,
                Color.LiquidBlack,
                Color.LiquidClear
            };

            var itemList = new List<SelectListItem>();

            for (int i = 0; i < colors.Count; i++)
            {
                var itemToAdd = new SelectListItem
                {
                    Text = colors[i].ColorName,
                    Value = (i + 1).ToString()
                };
                itemList.Add(itemToAdd);
            }

            ViewBag.itemList = itemList;
            return View();
        }

        // POST: Painting/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePainting(Painting painting, string[] colors)
        {
            try
            {
                List<Color> colorsToAdd = new List<Color>();

                if (colors.Length > 1)
                {
                    foreach (var colorName in colors)
                    {
                        var colorToAdd = new Color();

                        if(Int32.TryParse(colorName, out int colorIndex))
                        {
                            colorToAdd = colorToAdd.AssignColor(colorIndex);
                            if (colorToAdd.Validate())
                            {
                                colorsToAdd.Add(colorToAdd);
                            }
                        }
                    }
                }
                else if (colors.Any())
                {
                    var colorToAdd = new Color();
                    if (Int32.TryParse(colors[0], out int colorIndex))
                    {
                        colorToAdd = colorToAdd.AssignColor(colorIndex);
                        if (colorToAdd.Validate())
                        {
                            colorsToAdd.Add(colorToAdd);
                        }
                    }
                }

                if (colorsToAdd.Any())
                {
                    painting.Colors = colorsToAdd;
                }

                if (painting.Validate())
                {
                    paintingService.AddPainting(painting);
                }

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
        public ActionResult DeletePainting(int id)
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