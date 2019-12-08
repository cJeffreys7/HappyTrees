using HappyTrees.Models;
using System.Collections.Generic;

namespace HappyTrees.Data
{
    public interface IPaintingRepository
    {
        void AddPainting(Painting painting);

        List<Painting> GetAllPaintings();

        List<Painting> GetPaintingsOfSeason(int season);

        Painting GetPainting(int id);

        void UpdatePainting(Painting painting);

        bool DeletePainting(int id);
    }

}
