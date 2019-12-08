using HappyTrees.Data;
using HappyTrees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTrees.Services
{
    public interface IPaintingService
    {
        void AddPainting(Painting painting);

        List<Painting> GetAllPaintings();

        List<Painting> GetPaintingsOfSeason(int season);

        Painting GetPainting(int id);

        void UpdatePainting(Painting painting);

        bool DeletePainting(int id);
    }
}
