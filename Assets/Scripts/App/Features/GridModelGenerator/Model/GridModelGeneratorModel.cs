using App.Core.Grid;
using App.Utils;
using Hexagonal;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace App.Features.GridModelGenerator
{
    public class GridModelGeneratorModel
    {
        public GridModel grid;

        public GridModelGeneratorModel(GridModelGeneratorConfiguration configuration)
        {
            grid = new GridModel();
            GenerateGrid(configuration);
            CutFloatingHexes(configuration);
        }

        public void Regenerate(GridModelGeneratorConfiguration configuration)
        {
            grid.grid.Clear();
            GenerateGrid(configuration);
            CutFloatingHexes(configuration);
        }

        private void GenerateGrid(GridModelGeneratorConfiguration configuration)
        {
            var radius = configuration.radius;
            var gridCenter = new Vector3Hex(radius / 2, radius / 2, -radius / 2 - radius / 2);
            grid.radius = radius;
            for (int x = 0; x < radius; x++)
            {
                for (int y = 0; y < radius; y++)
                {
                    var position = new Vector3Hex(x, y, -x - y);
                    var distanceFromCenter = Vector3Hex.Distance(gridCenter, position);
                    if (distanceFromCenter > radius / 2)
                        continue;
                    var parametrisedPerlinNoise = new ParametrisedPerlinNoise();
                    var perlinNoise = parametrisedPerlinNoise.GeneratePerlinNoise(x, y, configuration.scale, configuration.amplitude, configuration.frequency, configuration.octaves, configuration.offset, configuration.persistence, configuration.lacunarity);
                    if (perlinNoise > configuration.discardThreshold * (radius / (1 + distanceFromCenter)))
                        continue;
                    CellModel cellModel = new CellModel(position);
                    grid.AddCell(cellModel);
                }
            }            
        }

        private void CutFloatingHexes(GridModelGeneratorConfiguration configuration)
        {
            var radius = configuration.radius;
            var gridCenter = new Vector3Hex(radius / 2, radius / 2, -radius / 2 - radius / 2);
            var centralHexModel = grid.grid.Where(cell => cell.transform.position == gridCenter).FirstOrDefault();

            var connectedHexModels = FindConnectedCells(grid.grid, centralHexModel);
            grid.grid.Clear();
            grid.grid = connectedHexModels;
        }

        public static List<CellModel> FindConnectedCells(List<CellModel> allCells, CellModel startCell)
        {
            // A list to keep track of all found connected cells
            List<CellModel> connectedCells = new List<CellModel>();

            // A queue for BFS
            Queue<CellModel> queue = new Queue<CellModel>();

            // A set to keep track of visited cells to avoid revisiting
            HashSet<Vector3Hex> visited = new HashSet<Vector3Hex>();

            // Start with the initial cell
            visited.Add(startCell.transform.position); // Assuming Coordinates is the Vector3Hexagonal property
            queue.Enqueue(startCell);

            while (queue.Count > 0)
            {
                CellModel currentCell = queue.Dequeue();
                connectedCells.Add(currentCell);

                // Get neighbors (implement GetNeighbors based on your grid's structure)
                foreach (var neighborCoord in GetNeighborCoords(currentCell.transform.position))
                {
                    CellModel neighborCell = allCells.FirstOrDefault(cell => cell.transform.position.Equals(neighborCoord));

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