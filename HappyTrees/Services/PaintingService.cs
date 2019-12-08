using HappyTrees.Data;
using HappyTrees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTrees.Services
{
    public class PaintingService : IPaintingService
    {
        private readonly IPaintingRepository paintingRepository;

        public PaintingService(IPaintingRepository paintingRepository)
        {
            this.paintingRepository = paintingRepository;
        }

        public void AddPainting(Painting painting)
        {
            paintingRepository.AddPainting(painting);
        }

        public List<Painting> GetAllPaintings()
        {
            List<Painting> paintings = paintingRepository.GetAllPaintings();

            return paintings;
        }

        public List<Painting> GetPaintingsOfSeason(int season)
        {
            List<Painting> paintings = paintingRepository.GetPaintingsOfSeason(season);
            return paintings;
        }

        public Painting GetPainting(int id)
        {
            Painting painting = paintingRepository.GetPainting(id);

            return painting;
        }

        public void UpdatePainting(Painting painting)
        {
            paintingRepository.UpdatePainting(painting);
        }

        public bool DeletePainting(int id)
        {
            bool deleteSuccess = paintingRepository.DeletePainting(id);

            return deleteSuccess;
        }
    }
}
