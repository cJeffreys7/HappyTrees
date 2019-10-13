using HappyTrees.Models;
using System.Collections.Generic;

namespace HappyTrees.Data
{
    public interface IPaintingRepository
    {
        List<Painting> GetAllPaintings();

        List<Painting> GetPaintingsOfSeason(int season);

        Painting GetPainting(int id);

        void AddPainting(Painting painting);
    }

}
