using App.Core.Grid;
using UnityEngine;

namespace App.Features.GridViewGenerator
{
	[CreateAssetMenu(menuName = "Configuration/Features/HexagonalGridViewPresenter/HexagonalGridViewPresenterConfiguration", fileName = "HexagonalGridViewPresenterConfiguration")]
	public class GridViewGeneratorConfiguration : AbstractConfiguration
	{
		public CellView cellViewPrefab;
	}
}