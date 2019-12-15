using HappyTrees.Models;
using System.Collections.Generic;

namespace HappyTrees.Data
{
    public interface IColorRepository
    {
        void AddColor(Color color);

        List<Color> GetAllColors();

        Color GetColor(string colorValue);

        void UpdateColor(Color color);

        bool DeleteColor(Color color);
    }

}
