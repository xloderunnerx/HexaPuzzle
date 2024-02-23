using App.Features.PuzzlePainter;
using System.Collections.Generic;
using UnityEngine;

namespace App.Features.PuzzlePainter
{
    public class PreDefinedPuzzleColorBehaviour : IPuzzleColorBehaviour
    {
        public List<Color> GetColors(PuzzlePainterConfiguration configuration)
        {
            if(configuration.predefinedPalette == null)
                return new List<Color>() { new Color(1, 1, 1, 1) };
            if(configuration.predefinedPalette.Count == 0)
                return new List<Color>() { new Color(1, 1, 1, 1) };
            return configuration.predefinedPalette[Random.Range(0, configuration.predefinedPalette.Count)].colors;
        }
    }
}
