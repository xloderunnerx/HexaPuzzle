using App.Core.Hexagonal;
using UnityEngine;

namespace App.Features.HexagonalGridViewPresenter
{
	[CreateAssetMenu(menuName = "Configuration/Features/HexagonalGridViewPresenter/HexagonalGridViewPresenterConfiguration", fileName = "HexagonalGridViewPresenterConfiguration")]
	public class HexagonalGridViewPresenterConfiguration : AbstractConfiguration
	{
		public HexagonalCellView hexagonalCellViewPrefab;
	}
}