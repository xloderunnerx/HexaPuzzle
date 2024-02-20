using System.Collections.Generic;

using UnityEngine;

namespace App.Features.PuzzlePainter
{
    public class ComplementaryPuzzleColorBehaviour : IPuzzleColorBehaviour
    {
        public List<Color> GetColors()
        {
            var result = new List<Color>();
            var firstColor = Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(0.95f, 1f), Random.Range(0.95f, 1f));
            var secondColor = new Color(1 - firstColor.r, 1 - firstColor.g, 1 - firstColor.b, 1);
            result.Add(firstColor);
            result.Add(secondColor);
            return result;
        }
    }
}
