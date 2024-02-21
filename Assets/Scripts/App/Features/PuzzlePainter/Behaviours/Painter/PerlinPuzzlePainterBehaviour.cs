using App.Core.Puzzle;
using App.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace App.Features.PuzzlePainter
{
    public class PerlinPuzzlePainterBehaviour : IPuzzlePainterBehaviour
    {
        public void Paint(PuzzleModel puzzleModel, PuzzlePainterConfiguration configuration, IPuzzleColorBehaviour puzzleColorBehaviour)
        {
            var perlinNoise = new ParametrisedPerlinNoise();
            var cells = puzzleModel.GetCells();
            var colors = puzzleColorBehaviour.GetColors(configuration);
            var offset = new Vector2(Random.Range(-1000, 1000), Random.Range(-1000, 1000));
            cells.ForEach(cell =>
            {
                var perlinValue = perlinNoise.GeneratePerlinNoise(cell.transform.position.x, cell.transform.position.y, configuration.scale, configuration.amplitude, configuration.frequency, configuration.octaves, offset, configuration.persistence, configuration.lacunarity);
                cell.fillColor = GetInterpolatedColor(colors, perlinValue);
            });
        }

        private Color GetInterpolatedColor(List<Color> colors, float t)
        {
            // Clamp t to the range [0, 1] to ensure it doesn't go out of bounds
            t = Mathf.Clamp01(t);

            if (colors.Count == 1) return colors[0]; // If there's only one color, return it
            if (colors.Count == 0) return Color.white; // Return white if no colors are provided

            float totalRange = 1f; // Total t range
            float segmentSize = totalRange / (colors.Count - 1); // Size of each segment in t terms

            // Find the current segment
            int startIndex = Mathf.Min(Mathf.FloorToInt(t / segmentSize), colors.Count - 2);
            int endIndex = startIndex + 1;

            // Calculate local t for the current segment
            float segmentT = (t % segmentSize) / segmentSize;

            // Interpolate between the two colors of the current segment
            return Color.Lerp(colors[startIndex], colors[endIndex], segmentT);
        }
    }
}
