using App.Core;
using App.Core.Hexagonal;
using App.Core.Signals;
using Composite.Core;
using System;
using UnityEngine;

namespace App.Features.HexagonalGridViewPresenter
{
	public class HexagonalGridViewPresenterController : AbstractController
	{
		private HexagonalGridViewPresenterView view;
		private HexagonalGridViewPresenterConfiguration configuration;
		private HexagonalGridViewPresenterModel model;

        private HexagonalGridView gridView;

        public HexagonalGridViewPresenterController(HexagonalGridViewPresenterView view, HexagonalGridViewPresenterConfiguration configuration, HexagonalGridViewPresenterModel model)
        {
            this.view = view;
            this.configuration = configuration;
            this.model = model;
        }

        public override void Initialize()
		{
            gridView = new GameObject("HexagonalGridView").AddComponent<HexagonalGridView>();
            gridView.transform.parent = view.transform;
		}

        public override void DeclareSignals()
        {
            DeclareSignal<OnHexagonalGridViewPresented>();
        }

        public override void SubscribeToSignals()
        {
            SubscribeToSignal<OnHexagonalGridModelGenerated>(Present);
        }

        private void Present(OnHexagonalGridModelGenerated signal)
        {
            Discard();
            var gridModel = signal.HexagonalGridModel;

            var cellViewSize = configuration.hexagonalCellViewPrefab.GetSizeBorder();

            var cellViewWidth = cellViewSize * 2;
            var cellViewHeight = Mathf.Sqrt(3) * cellViewSize;

            gridModel.grid.ForEach(cellModel =>
            {
                var cellView = GameObject.Instantiate(configuration.hexagonalCellViewPrefab, gridView.transform);
                cellView.SetPositionHex(cellModel.transform.position);
                cellView.transform.position = new Vector3(cellModel.transform.position.x * cellViewWidth - cellModel.transform.position.x * cellViewWidth * 0.25f,
                    cellModel.transform.position.y * cellViewHeight + cellModel.transform.position.x * cellViewHeight * 0.5f, 0);
                cellView.gameObject.name = $"X: {cellModel.transform.position.x}; Y: {cellModel.transform.position.y}; Z: {cellModel.transform.position.z}";
                gridView.grid.Add(cellView);
            });
            TryFireSignal(new OnHexagonalGridViewPresented(gridView));
        }

        private void Discard()
        {
            gridView.RemoveAndDestroyAll();
        }
    }
}