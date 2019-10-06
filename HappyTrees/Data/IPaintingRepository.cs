using HappyTrees.Models;
using System.Collections.Generic;

namespace HappyTrees.Data
{
    public interface IPaintingRepository
    {
        List<Painting> GetAllPaintings();

        Painting GetPainting(int id);

        void AddPainting(Painting painting);
    }

}
