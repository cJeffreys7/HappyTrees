using HappyTrees.Models;
using System.Collections.Generic;

namespace HappyTrees.Services
{
    public interface IColorService
    {
        void AddColor(Color color);

        List<Color> GetAllColors();

        Color GetColor(string colorValue);

        void UpdateColor(Color color);

        bool DeleteColor(Color color);
    }
}
