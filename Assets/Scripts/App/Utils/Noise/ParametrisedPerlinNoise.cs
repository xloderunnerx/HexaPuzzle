using UnityEngine;

namespace App.Utils
{
    public class ParametrisedPerlinNoise
    {
        public float GeneratePerlinNoise(float x, float y, float scale, float amplitude, float frequency, int octaves, Vector2 offset, float persistence, float lacunarity)
        {
            if (scale <= 0)
            {
                scale = 0.0001f; // Prevent division by zero to avoid scaling issues
            }

            float maxPossibleHeight = 0;
            float noiseHeight = 0;

            for (int i = 0; i < octaves; i++)
            {
                float sampleX = (x + offset.x) * scale * frequency;
                float sampleY = (y + offset.y) * scale * frequency;

                float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1; // Shift to range [-1,1] for more dynamic range
                noiseHeight += perlinValue * amplitude;

                maxPossibleHeight += amplitude;

                amplitude *= persistence; // Decrease amplitude each octave
                frequency *= lacunarity; // Increase frequency each octave
            }

            // Normalize the noise value to ensure it is between 0 and 1
            float normalizedHeight = (noiseHeight + maxPossibleHeight) / (2 * maxPossibleHeight);
            return normalizedHeight;
        }
    }
}