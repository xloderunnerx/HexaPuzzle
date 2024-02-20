using UnityEngine;
using System.Collections.Generic;

namespace App.Features.PuzzlePainter
{
    public class AnalogousPuzzleColorBehaviour : IPuzzleColorBehaviour
    {
        private float separation;

        public AnalogousPuzzleColorBehaviour(float separation)
        {
            this.separation = separation;
        }

        public List<Color> GetColors()
        {
            var result = new List<Color>();
            var firstColor = Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(0.9f, 1f), Random.Range(0.9f, 1f));
            separation /= 360f;

            float H, S, V;
            Color.RGBToHSV(firstColor, out H, out S, out V);

            float leftHue = (H - separation + 1f) % 1f;
            float rightHue = (H + separation) % 1f;

            Color leftColor = Color.HSVToRGB(leftHue, S, V);
            Color rightColor = Color.HSVToRGB(rightHue, S, V);

            result.Add(leftColor);
            result.Add(firstColor);
            result.Add(rightColor);
            return result;
        }
    }
}
