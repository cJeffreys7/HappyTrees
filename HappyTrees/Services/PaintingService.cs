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


        public List<Painting> GetAllPaintings()
        {
            List<Painting> paintings = paintingRepository.GetAllPaintings();

            return paintings;
        }

        public Painting GetPainting(string title)
        {
            Painting painting = paintingRepository.GetPainting(title);

            return painting;
        }
    }
}