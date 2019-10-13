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

        List<Painting> GetAllPaintings();

        List<Painting> GetPaintingsOfSeason(int season);

        Painting GetPainting(int id);

        void AddPainting(Painting painting);
    }
}
