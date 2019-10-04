using HappyTrees.Models;
using System.Collections.Generic;

namespace HappyTrees.Data
{
    public interface IPaintingRepository
    {
        List<Painting> GetAllPaintings();

        Painting GetPainting(string title);

        void AddPainting(Painting painting);
    }

}
