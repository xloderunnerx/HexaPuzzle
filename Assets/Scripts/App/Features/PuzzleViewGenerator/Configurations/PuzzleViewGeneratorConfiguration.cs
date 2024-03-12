using App.Core.Puzzle;
using UnityEngine;

namespace App.Features.PuzzleViewGenerator
{
	[CreateAssetMenu(menuName = "Configuration/Features/PuzzleViewPresenter/PuzzleViewPresenterConfiguration", fileName = "PuzzleViewPresenterConfiguration")]
	public class PuzzleViewGeneratorConfiguration : AbstractConfiguration
	{
		public PuzzleCellView puzzleCellViewPrefab;
	}
}