using App.Core.Puzzle;
using UnityEngine;

namespace App.Features.PuzzleViewPresenter
{
	[CreateAssetMenu(menuName = "Configuration/Features/PuzzleViewPresenter/PuzzleViewPresenterConfiguration", fileName = "PuzzleViewPresenterConfiguration")]
	public class PuzzleViewPresenterConfiguration : AbstractConfiguration
	{
		public PuzzleCellView puzzleCellViewPrefab;
	}
}