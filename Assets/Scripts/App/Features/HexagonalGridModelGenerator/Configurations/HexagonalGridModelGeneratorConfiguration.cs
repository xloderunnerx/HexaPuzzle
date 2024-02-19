using UnityEngine;

namespace App.Features.HexagonalGridModelGenerator
{
	[CreateAssetMenu(menuName = "Configuration/Features/HexagonalGridModelGenerator/HexagonalGridModelGeneratorConfiguration", fileName = "HexagonalGridModelGeneratorConfiguration")]
	public class HexagonalGridModelGeneratorConfiguration : AbstractConfiguration
	{
		public int radius;
	}
}