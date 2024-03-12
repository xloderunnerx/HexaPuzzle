using App.Core.Hand;
using App.Core.Puzzle;
using System.Collections.Generic;
using UnityEngine;

namespace App.Features.HandModelGenerator
{
	public class HandModelGeneratorModel
	{
        public HandModel handModel;

        public HandModelGeneratorModel()
        {
            handModel = new HandModel();
        }

        public void Generate(PuzzleModel puzzleModel)
        {
            puzzleModel.puzzle.ForEach(segment =>
            {
                var cardModel = new CardModel(segment);
                handModel.cards.Add(cardModel);
            });
        }
    }
}