using App.Core.Grid;
using App.Core.Puzzle;
using Hexagonal;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace App.Features.PuzzleModelGenerator
{
    public class PuzzleModelGeneratorModel
    {
        public PuzzleModel puzzleModel;

        public PuzzleModelGeneratorModel()
        {
            puzzleModel = new PuzzleModel();
        }

        public void GeneratePuzzleModel(GridModel gridModel, PuzzleModelGeneratorConfiguration configuration)
        {
            puzzleModel = DivideGridIntoVoronoiSegments(gridModel, configuration.segmentsCount);
            puzzleModel.radius = gridModel.radius;
            puzzleModel.RemoveEmptySegments();
        }

        private PuzzleModel DivideGridIntoVoronoiSegments(GridModel gridModel, int numberOfSegments)
        {
            // Generate seed points
            List<Vector3Hex> seedPoints = GenerateSeedPoints(gridModel, numberOfSegments);

            // Initialize a dictionary to hold segment assignments
            Dictionary<Vector3Hex, PuzzleSegmentModel> segments = new Dictionary<Vector3Hex, PuzzleSegmentModel>();

            foreach (var seedPoint in seedPoints)
            {
                segments[seedPoint] = new PuzzleSegmentModel();
            }

            // Assign cells to the nearest seed point
            foreach (var cell in gridModel.grid)
            {
                Vector3Hex closestSeed = FindClosestSeedPoint(cell.transform.position, seedPoints);
                segments[closestSeed].AddCell(new PuzzleCellModel(cell.transform.position));
            }

            // Convert dictionary values to a List<List<HexagonalCellModel>>
            return new PuzzleModel(segments.Values.ToList());
        }

        private List<Vector3Hex> GenerateSeedPoints(GridModel gridModel, int numberOfSegments)
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