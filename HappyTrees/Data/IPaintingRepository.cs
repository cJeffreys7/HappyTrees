using HappyTrees.Models;
using HappyTrees.Services;
using System.Collections.Generic;

namespace HappyTrees.Data
{
    public interface IPaintingRepository
    {
        void AddPainting(Painting painting);

        List<Painting> GetAllPaintings(IColorService colorService);

        List<Painting> GetPaintingsOfSeason(int season);

        Painting GetPainting(int id, IColorService colorService);

        void UpdatePainting(Painting painting);

        bool DeletePainting(int id);
    }

}
