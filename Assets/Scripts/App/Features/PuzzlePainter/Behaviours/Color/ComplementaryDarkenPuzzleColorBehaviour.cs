using App.Features.PuzzlePainter;
using UnityEngine;
using System.Collections.Generic;


namespace App.Features.PuzzlePainter
{
    public class ComplementaryDarkenPuzzleColorBehaviour : IPuzzleColorBehaviour
    {
        public List<Color> GetColors(PuzzlePainterConfiguration configuration)
        {
            var result = new List<Color>();
            var firstColor = Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(0.95f, 1f), Random.Range(0.95f, 1f));
            float h, s, v;
            Color.RGBToHSV(firstColor, out h, out s, out v);

            var secondColor = Color.HSVToRGB(h, 1, Random.Range(0.05f, 0.1f));
            result.Add(firstColor);
            result.Add(secondColor);
            return result;
        }
    }
}
