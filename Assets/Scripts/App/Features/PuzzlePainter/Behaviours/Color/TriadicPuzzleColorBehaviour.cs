using App.Features.PuzzlePainter;
using System.Collections.Generic;
using UnityEngine;

namespace App.Features.PuzzlePainter
{
    public class TriadicPuzzleColorBehaviour : IPuzzleColorBehaviour
    {
        public List<Color> GetColors(PuzzlePainterConfiguration configuration)
        {
            var baseColor = Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(0.9f, 1f), Random.Range(0.9f, 1f));
            Color.RGBToHSV(baseColor, out float h, out float s, out float v);

            // Create a list to hold the triadic colors
            List<Color> triadicColors = new List<Color>();

            // Add the base color to the list
            triadicColors.Add(baseColor);

            // Calculate the two additional colors 120 degrees apart
            for (int i = 1; i < 3; i++)
            {
                // Rotate the hue by 120 degrees (0.333 in normalized scale because 120/360 = 0.333)
                float newHue = (h + (0.333f * i)) % 1f; // Use modulo to wrap the hue value if it goes over 1
                triadicColors.Add(Color.HSVToRGB(newHue, s, v));
            }

            // Return the list of triadic colors
            return triadicColors;
        }
    }
}
