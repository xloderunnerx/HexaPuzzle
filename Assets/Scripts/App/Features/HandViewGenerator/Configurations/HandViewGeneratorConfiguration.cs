using App.Core.Hand;
using App.Core.Puzzle;
using UnityEngine;

namespace App.Features.HandViewGenerator
{
	[CreateAssetMenu(menuName = "Configuration/Features/HandViewGenerator/HandViewGeneratorConfiguration", fileName = "HandViewGeneratorConfiguration")]
	public class HandViewGeneratorConfiguration : AbstractConfiguration
	{
        public CardView cardViewPrefab;
        public PuzzleCellView puzzleCellViewPrefab;
        public int defaultSortingOrder;
    }
}