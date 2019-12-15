using System.Collections.Generic;
using HappyTrees.Data;
using HappyTrees.Models;

namespace HappyTrees.Services
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository colorRepository;

        public ColorService(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }

        // Service layer validation
        protected bool ValidateColor(Color color)
        {
            if ((color.ColorName).Trim().Length == 0) return false;
            if ((color.ColorValue).Trim().Length == 0) return false;
            if ((color.BuyLink).Trim().Length == 0) return false;
            if ((color.HexColor).Trim().Length == 0) return false;
            return true;
        }

        public void AddColor(Color color)
        {
            if(ValidateColor(color))
                colorRepository.AddColor(color);
        }

        public List<Color> GetAllColors()
        {
            return colorRepository.GetAllColors();
        }

        public Color GetColor(string colorValue)
        {
            return colorRepository.GetColor(colorValue);
        }

        public void UpdateColor(Color color)
        {
            if(ValidateColor(color))
                colorRepository.UpdateColor(color);
        }

        public bool DeleteColor(Color color)
        {
            return colorRepository.DeleteColor(color);
        }
    }
}
