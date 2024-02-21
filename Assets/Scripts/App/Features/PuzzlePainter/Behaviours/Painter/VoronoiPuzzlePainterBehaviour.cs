using App.Core.HexagonalGrid;
using App.Core.Puzzle;
using Hexagonal;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace App.Features.PuzzlePainter
{
    public class VoronoiPuzzlePainterBehaviour : IPuzzlePainterBehaviour
    {
        public void Paint(PuzzleModel puzzleModel, PuzzlePainterConfiguration configuration, IPuzzleColorBehaviour puzzleColorBehaviour)
        {
            // Generate Voronoi segments
            var segments = DivideGridIntoVoronoiSegments(puzzleModel, configuration.segmentsCount);

            // Retrieve a list of colors to use
            var colors = puzzleColorBehaviour.GetColors(configuration);

            // Iterate through each segment and assign a color from the color list
            
            foreach (var segment in segments.puzzle)
            {
                var rndColor = colors[Random.Range(0, colors.Count)];
                // Loop through each cell in the segment and set its color
                foreach (var cell in segment.segment)
                {
                    PuzzleCellModel existingCell = puzzleModel.GetCells().Where(existingCell => existingCell.transform.position == cell.transform.position).FirstOrDefault();
                    if (existingCell != null)
                    {
                        // Apply color to existing cell
                        existingCell.fillColor = rndColor;
                    }
                }
            }
        }

        private PuzzleModel DivideGridIntoVoronoiSegments(PuzzleModel puzzleModel, int numberOfSegments)
        {
            // Generate seed points
            List<Vector3Hex> seedPoints = GenerateSeedPoints(puzzleModel, numberOfSegments);

            // Initialize a dictionary to hold segment assignments
            Dictionary<Vector3Hex, PuzzleSegmentModel> segments = new Dictionary<Vector3Hex, PuzzleSegmentModel>();

            foreach (var seedPoint in seedPoints)
            {
                segments[seedPoint] = new PuzzleSegmentModel();
            }

            // Assign cells to the nearest seed point
            foreach (var cell in puzzleModel.GetCells())
            {
                Vector3Hex closestSeed = FindClosestSeedPoint(cell.transform.position, seedPoints);
                segments[closestSeed].AddCell(new PuzzleCellModel(cell.transform.position));
            }

            // Convert dictionary values to a List<List<HexagonalCellModel>>
            return new PuzzleModel(segments.Values.ToList());
        }

        private List<Vector3Hex> GenerateSeedPoints(PuzzleModel puzzleModel, int numberOfSegments)
        {
            // Placeholder: Implement logic to generate seed points within the grid bounds
            // This could be random, evenly spaced, or based on specific criteria
            List<Vector3Hex> seedPoints = new List<Vector3Hex>();

            // Example: simple random placement (consider your grid's actual bounds and structure)
            for (int i = 0; i < numberOfSegments; i++)
            {
                // Randomly generate within bounds; replace with your grid's bounds
                int x = Random.Range(5, puzzleModel.radius - 5);
                int y = Random.Range(5, puzzleModel.radius - 5);
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
