using App.Core.CardsHand;
using UnityEngine;

namespace App.Features.CardsHand
{
	[CreateAssetMenu(menuName = "Configuration/Features/CardsHand/CardsHandConfiguration", fileName = "CardsHandConfiguration")]
	public class CardsHandConfiguration : AbstractConfiguration
	{
		public CardView cardViewPrefab;
		public CardPuzzleCellView cardPuzzleCellViewPrefab;
		public int defaultSortingOrder;
	}
}