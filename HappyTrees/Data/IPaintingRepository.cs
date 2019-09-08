using HappyTrees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTrees.Data
{
    public interface IPaintingRepository
    {
        List<Painting> GetAllPaintings();

        Painting GetPainting(string title);
    }
}
