using UnityEngine;

namespace App.Features.PuzzlePainter
{
	[CreateAssetMenu(menuName = "Configuration/Features/PuzzlePainter/PuzzlePainterConfiguration", fileName = "PuzzlePainterConfiguration")]
	public class PuzzlePainterConfiguration : AbstractConfiguration
	{
		public float analogousColorHarmonySeparation = 30;
	}
}