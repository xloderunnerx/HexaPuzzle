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

            puzzlePainterBehaviours.Add(new LinearGradientPuzzleShapeBehaviour());

            //puzzleColorBehaviours.Add(new ComplementaryPuzzleColorBehaviour());
            puzzleColorBehaviours.Add(new AnalogousPuzzleColorBehaviour(configuration.analogousColorHarmonySeparation));
        }

        public void PaintPuzzle(PuzzleModel puzzleModel, PuzzlePainterConfiguration puzzlePainterConfiguration)
        {
            var puzzleColorBehaviour = puzzleColorBehaviours[Random.Range(0, puzzleColorBehaviours.Count)];
            puzzlePainterBehaviours[Random.Range(0, puzzlePainterBehaviours.Count)].Paint(puzzleModel, puzzlePainterConfiguration, puzzleColorBehaviour);
        }
    }
}