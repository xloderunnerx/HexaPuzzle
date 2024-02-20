using UnityEngine;

namespace App.Features.PuzzleModelGenerator
{
	[CreateAssetMenu(menuName = "Configuration/Features/PuzzleModelGenerator/PuzzleModelGeneratorConfiguration", fileName = "PuzzleModelGeneratorConfiguration")]
	public class PuzzleModelGeneratorConfiguration : AbstractConfiguration
	{
		public int segmentsCount;
	}
}