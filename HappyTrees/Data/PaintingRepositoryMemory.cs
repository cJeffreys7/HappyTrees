using HappyTrees.Models;
using HappyTrees.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HappyTrees.Data
{
    public class PaintingRepositoryMemory : IPaintingRepository
    {
        readonly string FilePath = @"C:\Users\Chris\source\repos\HappyTrees\HappyTrees\Data\PaintingRepositoryMemory.csv";

        public void AddPainting(Painting painting)
        {
            throw new NotImplementedException();
        }

        public List<Painting> GetAllPaintings(IColorService colorService)
        {
            return ConvertLinesToPaintings(File.ReadAllLines(FilePath), 1, File.ReadAllLines(FilePath).Length - 1, colorService);
        }


        public List<Painting> GetPaintingsOfSeason(int season, IColorService colorService)
        {
            List<Painting> paintings = ConvertLinesToPaintings(File.ReadAllLines(FilePath), 1, File.ReadAllLines(FilePath).Length - 1, colorService);
            return paintings.Where(p => p.Season == season).ToList();
        }

        public Painting GetPainting(int id, IColorService colorService)
        {
            Painting painting = ConvertLinesToPaintings(File.ReadAllLines(FilePath), id, 1, colorService).FirstOrDefault();
            return painting;
        }

        public void UpdatePainting(Painting painting)
        {
            throw new NotImplementedException();
        }

        public bool DeletePainting(int id)
        {
            throw new NotImplementedException();
            //foreach (var painting in paintings)
            //{
            //    if(id == painting.Id)
            //    {
            //        paintings.Remove(painting);
            //        return true;
            //    }
            //};
        }
        private List<Painting> ConvertLinesToPaintings(string[] csvLines, int startLine, int totalLines, IColorService colorService)
        {
            csvLines = csvLines.AsSpan(startLine, totalLines).ToArray();

            List<Painting> paintings = new List<Painting>();
            foreach (var csvLine in csvLines)
            {
                string[] csvPainting = csvLine.Split(',');
                string[] csvColors = csvPainting
                    .AsSpan(7, csvPainting.Length - 7).ToArray();
                csvColors[0] = csvColors[0].TrimStart('/', '"');
                csvColors[csvColors.Length - 1] = csvColors.Last().TrimEnd('"','/');

                List<Color> colors = new List<Color>();
                foreach (var csvColor in csvColors)
                {
                    colors.Add(colorService.GetColor(csvColor));
                }

                Painting painting = new Painting
                {
                    Id = Int32.TryParse(csvPainting[0], out int i) ? i : -1,
                    Title = csvPainting[1],
                    Season = Int32.TryParse(csvPainting[2], out int s) ? s : 0,
                    Episode = Int32.TryParse(csvPainting[3], out int e) ? e : 0,
                    ThumbnailFile = csvPainting[4],
                    Description = csvPainting[5],
                    VideoUrl = csvPainting[6],
                    Colors = colors
                };
                paintings.Add(painting);
            }

            return paintings;
        }
    }
}
