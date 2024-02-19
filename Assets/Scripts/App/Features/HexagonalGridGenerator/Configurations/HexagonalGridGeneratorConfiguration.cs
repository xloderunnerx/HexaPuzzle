using UnityEngine;

namespace App.Features.HexagonalGridGenerator
{
	[CreateAssetMenu(menuName = "Configuration/Features/HexagonalGridGenerator/HexagonalGridGeneratorConfiguration", fileName = "HexagonalGridGeneratorConfiguration")]
	public class HexagonalGridGeneratorConfiguration : AbstractConfiguration
	{
		public HexagonalCellView hexagonalCellViewPrefab;
	}
}