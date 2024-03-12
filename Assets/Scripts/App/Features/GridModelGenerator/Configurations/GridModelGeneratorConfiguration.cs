using UnityEngine;

namespace App.Features.GridModelGenerator
{
	[CreateAssetMenu(menuName = "Configuration/Features/HexagonalGridModelGenerator/HexagonalGridModelGeneratorConfiguration", fileName = "HexagonalGridModelGeneratorConfiguration")]
	public class GridModelGeneratorConfiguration : AbstractConfiguration
	{
		public int radius;

        [Header("Perlin Noise")]
        public float scale = 0.5f;
        public int octaves = 4;
        public float persistence = 0.5f;
        public float lacunarity = 2.0f;
        public Vector2 offset = new Vector2(100, 100);
        public float amplitude = 1.0f;
        public float frequency = 1.0f;
        public float discardThreshold = 0.5f;
    }
}