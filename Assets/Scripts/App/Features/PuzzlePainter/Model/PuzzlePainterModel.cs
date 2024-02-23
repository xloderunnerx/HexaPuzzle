using App.Core.Puzzle;
using System.Collections.Generic;
using UnityEngine;

namespace App.Features.PuzzlePainter
{
    public class PuzzlePainterModel
    {
        private List<IPuzzlePainterBehaviour> puzzlePainterBehaviours;
        private List<IPuzzleColorBehaviour> puzzleColorBehaviours;

        public PuzzlePainterModel(PuzzlePainterConfiguration configuration)
        {
            puzzlePainterBehaviours = new List<IPuzzlePainterBehaviour>();
            puzzleColorBehaviours = new List<IPuzzleColorBehaviour>();

            //puzzlePainterBehaviours.Add(new LinearGradientPuzzleShapeBehaviour());
            puzzlePainterBehaviours.Add(new PerlinPuzzlePainterBehaviour());
            puzzlePainterBehaviours.Add(new VoronoiPuzzlePainterBehaviour());

            //puzzleColorBehaviours.Add(new ComplementaryPuzzleColorBehaviour());
            //puzzleColorBehaviours.Add(new ComplementaryDarkenPuzzleColorBehaviour());
            //puzzleColorBehaviours.Add(new AnalogousPuzzleColorBehaviour());
            //puzzleColorBehaviours.Add(new TriadicPuzzleColorBehaviour());
            puzzleColorBehaviours.Add(new PreDefinedPuzzleColorBehaviour());
        }

        public void PaintPuzzle(PuzzleModel puzzleModel, PuzzlePainterConfiguration puzzlePainterConfiguration)
        {
            var puzzleColorBehaviour = puzzleColorBehaviours[Random.Range(0, puzzleColorBehaviours.Count)];
            puzzlePainterBehaviours[Random.Range(0, puzzlePainterBehaviours.Count)].Paint(puzzleModel, puzzlePainterConfiguration, puzzleColorBehaviour);
        }
    }
}