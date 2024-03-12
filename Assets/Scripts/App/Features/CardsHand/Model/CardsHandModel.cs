using App.Core.CardsHand;
using App.Core.Puzzle;
using System.Collections.Generic;

namespace App.Features.CardsHand
{
	public class CardsHandModel
	{
		public List<CardModel> cards;

        public CardsHandModel()
        {
            this.cards = new List<CardModel>();
        }

        public void GenerateCardModels(PuzzleModel puzzleModel)
        {
            puzzleModel.puzzle.ForEach(segment =>
            {
                var cardModel = new CardModel(segment);
                cards.Add(cardModel);
            });
        }
    }
}