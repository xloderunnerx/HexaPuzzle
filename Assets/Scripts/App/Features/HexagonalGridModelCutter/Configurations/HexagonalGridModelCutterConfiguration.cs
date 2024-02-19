using UnityEngine;

namespace App.Features.HexagonalGridModelCutter
{
	[CreateAssetMenu(menuName = "Configuration/Features/HexagonalGridModelCutter/HexagonalGridModelCutterConfiguration", fileName = "HexagonalGridModelCutterConfiguration")]
	public class HexagonalGridModelCutterConfiguration : AbstractConfiguration
	{
		public float voronoiSeedsPercentage = 0.5f;
	}
}