﻿using HappyTrees.Data;
using HappyTrees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTrees.Services
{
    public interface IPaintingService
    {

        List<Painting> GetAllPaintings();

        Painting GetPainting(int id);

        void AddPainting(Painting painting);
    }
}
