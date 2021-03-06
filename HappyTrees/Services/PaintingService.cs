﻿using HappyTrees.Data;
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

        // Service layer validation
        private bool ValidatePainting(Painting painting)
        {
            if (painting.Season <= 0) return false;
            if (painting.Episode <= 0) return false;

            return true;
        }

        public void AddPainting(Painting painting)
        {
            if(ValidatePainting(painting))
                paintingRepository.AddPainting(painting);
        }

        public List<Painting> GetAllPaintings(IColorService colorService)
        {
            return paintingRepository.GetAllPaintings(colorService);
        }

        public List<Painting> GetPaintingsOfSeason(int season, IColorService colorService)
        {
            return paintingRepository.GetPaintingsOfSeason(season, colorService);
        }

        public Painting GetPainting(int id, IColorService colorService)
        {
            return paintingRepository.GetPainting(id, colorService);
        }

        public void UpdatePainting(Painting painting)
        {
            if(ValidatePainting(painting))
                paintingRepository.UpdatePainting(painting);
        }

        public bool DeletePainting(int id)
        {
            return paintingRepository.DeletePainting(id);
        }
    }
}
