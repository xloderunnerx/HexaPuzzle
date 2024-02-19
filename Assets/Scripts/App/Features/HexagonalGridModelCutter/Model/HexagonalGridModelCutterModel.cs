using App.Core.Hexagonal;
using Hexagonal;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace App.Features.HexagonalGridModelCutter
{
    public class HexagonalGridModelCutterModel
    {
        public HexagonalGridCutModel hexagonalGridSegments;

        public HexagonalGridModelCutterModel()
        {
            hexagonalGridSegments = new HexagonalGridCutModel();
        }

        public void Cut(HexagonalGridModel gridModel, HexagonalGridModelCutterConfiguration configuration)
        {
            hexagonalGridSegments.gridSegments.Clear();
            var segmentsCount = (int)((float)gridModel.grid.Count * configuration.voronoiSeedsPercentage);
            var segments = DivideGridIntoVoronoiSegments(gridModel, segmentsCount);
            segments.ForEach(segment =>
            {
                var color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0, 1));
                segment.ForEach(hexagonalCellModel =>
                {
                    hexagonalCellModel.debugColor = color;
                });
            });
            segments.ForEach(segment => hexagonalGridSegments.gridSegments.Add(new HexagonalGridModel(segment)));
        }

        private List<List<HexagonalCellModel>> DivideGridIntoVoronoiSegments(HexagonalGridModel gridModel, int numberOfSegments)
        {
            // Generate seed points
            List<Vector3Hex> seedPoints = GenerateSeedPoints(gridModel, numberOfSegments);

            // Initialize a dictionary to hold segment assignments
            Dictionary<Vector3Hex, List<HexagonalCellModel>> segments = new Dictionary<Vector3Hex, List<HexagonalCellModel>>();

            foreach (var seedPoint in seedPoints)
            {
                segments[seedPoint] = new List<HexagonalCellModel>();
            }

            // Assign cells to the nearest seed point
            foreach (var cell in gridModel.grid)
            {
                Vector3Hex closestSeed = FindClosestSeedPoint(cell.transform.position, seedPoints);
                segments[closestSeed].Add(cell);
            }

            // Convert dictionary values to a List<List<HexagonalCellModel>>
            return segments.Values.ToList();
        }

        private List<Vector3Hex> GenerateSeedPoints(HexagonalGridModel gridModel, int numberOfSegments)
        {
            // Placeholder: Implement logic to generate seed points within the grid bounds
            // This could be random, evenly spaced, or based on specific criteria
            List<Vector3Hex> seedPoints = new List<Vector3Hex>();

            // Example: simple random placement (consider your grid's actual bounds and structure)
            for (int i = 0; i < numberOfSegments; i++)
            {
                // Randomly generate within bounds; replace with your grid's bounds
                int x = Random.Range(5, gridModel.radius - 5);
                int y = Random.Range(5, gridModel.radius - 5);
                int z = -x - y; // Ensure valid cube coordinates
                seedPoints.Add(new Vector3Hex(x, y, z));
            }

            return seedPoints;
        }

        private Vector3Hex FindClosestSeedPoint(Vector3Hex cellPosition, List<Vector3Hex> seedPoints)
        {
            Vector3Hex closestSeed = seedPoints[0];
            float minDistance = float.MaxValue;

            foreach (var seed in seedPoints)
            {
                float distance = Vector3Hex.Distance(cellPosition, seed);
                if (distance < minDistance)
                {
                    closestSeed = seed;
                    minDistance = distance;
                }
            }

            return closestSeed;
        }
    }
}