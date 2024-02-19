using App.Core.Hexagonal;
using Hexagonal;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace App.Features.HexagonalGridModelGenerator
{
    public class HexagonalGridModelGeneratorModel
    {
        public HexagonalGridModel grid;

        public HexagonalGridModelGeneratorModel(HexagonalGridModelGeneratorConfiguration configuration)
        {
            grid = new HexagonalGridModel();
            GenerateGrid(configuration);
        }

        public void Regenerate(HexagonalGridModelGeneratorConfiguration configuration)
        {
            grid.grid.Clear();
            GenerateGrid(configuration);
        }

        private void GenerateGrid(HexagonalGridModelGeneratorConfiguration configuration)
        {
            var radius = configuration.radius;
            var gridCenter = new Vector3Hex(radius / 2, radius / 2, -radius / 2 - radius / 2);
            Debug.Log("GridCenter = " + gridCenter);
            for (int x = 0; x < radius; x++)
            {
                for (int y = 0; y < radius; y++)
                {
                    var position = new Vector3Hex(x, y, -x - y);
                    var distanceFromCenter = Vector3Hex.Distance(gridCenter, position);
                    if (distanceFromCenter > radius / 2)
                        continue;
                    var perlinNoise = GeneratePerlinNoise(x, y, configuration);
                    if (perlinNoise > configuration.discardThreshold * (radius / (1 + distanceFromCenter)) /* && distanceFromCenter > radius / 4*/)
                        continue;
                    HexagonalCellModel cellModel = new HexagonalCellModel(position);
                    grid.AddCell(cellModel);
                }
            }

            CutFloatingHexes(configuration);
        }

        private float GeneratePerlinNoise(float x, float y, HexagonalGridModelGeneratorConfiguration configuration)
        {
            if (configuration.scale <= 0)
            {
                configuration.scale = 0.0001f; // Prevent division by zero to avoid scaling issues
            }

            float maxPossibleHeight = 0;
            float amplitude = configuration.amplitude;
            float frequency = configuration.frequency;
            float noiseHeight = 0;

            for (int i = 0; i < configuration.octaves; i++)
            {
                float sampleX = (x + configuration.offset.x) * configuration.scale * frequency;
                float sampleY = (y + configuration.offset.y) * configuration.scale * frequency;

                float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1; // Shift to range [-1,1] for more dynamic range
                noiseHeight += perlinValue * amplitude;

                maxPossibleHeight += amplitude;

                amplitude *= configuration.persistence; // Decrease amplitude each octave
                frequency *= configuration.lacunarity; // Increase frequency each octave
            }

            // Normalize the noise value to ensure it is between 0 and 1
            float normalizedHeight = (noiseHeight + maxPossibleHeight) / (2 * maxPossibleHeight);
            return normalizedHeight;
        }

        private void CutFloatingHexes(HexagonalGridModelGeneratorConfiguration configuration)
        {
            var radius = configuration.radius;
            var gridCenter = new Vector3Hex(radius / 2, radius / 2, -radius / 2 - radius / 2);
            var centralHexModel = grid.grid.Where(cell => cell.transform.position == gridCenter).FirstOrDefault();

            var connectedHexModels = FindConnectedCells(grid.grid, centralHexModel);
            connectedHexModels.ForEach(cell => cell.debugColor = Color.red);
            grid.grid.Clear();
            grid.grid = connectedHexModels;
        }

        public static List<HexagonalCellModel> FindConnectedCells(List<HexagonalCellModel> allCells, HexagonalCellModel startCell)
        {
            // A list to keep track of all found connected cells
            List<HexagonalCellModel> connectedCells = new List<HexagonalCellModel>();

            // A queue for BFS
            Queue<HexagonalCellModel> queue = new Queue<HexagonalCellModel>();

            // A set to keep track of visited cells to avoid revisiting
            HashSet<Vector3Hex> visited = new HashSet<Vector3Hex>();

            // Start with the initial cell
            visited.Add(startCell.transform.position); // Assuming Coordinates is the Vector3Hexagonal property
            queue.Enqueue(startCell);

            while (queue.Count > 0)
            {
                HexagonalCellModel currentCell = queue.Dequeue();
                connectedCells.Add(currentCell);

                // Get neighbors (implement GetNeighbors based on your grid's structure)
                foreach (var neighborCoord in GetNeighborCoords(currentCell.transform.position))
                {
                    HexagonalCellModel neighborCell = allCells.FirstOrDefault(cell => cell.transform.position.Equals(neighborCoord));

                    if (neighborCell != null && !visited.Contains(neighborCoord))
                    {
                        visited.Add(neighborCoord);
                        queue.Enqueue(neighborCell);
                    }
                }
            }

            return connectedCells;
        }

        private static IEnumerable<Vector3Hex> GetNeighborCoords(Vector3Hex coordinates)
        {
            // Assuming Vector3Hexagonal has X, Y, Z properties
            // Define the six neighboring directions for hexagonal cube coordinates
            Vector3Hex[] directions = new Vector3Hex[]
            {
            new Vector3Hex(1, -1, 0), new Vector3Hex(1, 0, -1), new Vector3Hex(0, 1, -1),
            new Vector3Hex(-1, 1, 0), new Vector3Hex(-1, 0, 1), new Vector3Hex(0, -1, 1)
            };

            foreach (var direction in directions)
            {
                yield return new Vector3Hex(coordinates.x + direction.x, coordinates.y + direction.y, coordinates.z + direction.z);
            }
        }
    }
}