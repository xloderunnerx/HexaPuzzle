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
		}

        public override void SubscribeToSignals()
        {
            //SubscribeToSignal<OnHexagonalGridModelGenerated>(Present);
            SubscribeToSignal<OnHexagonalGridModelCut>(Present);
        }

        private void Present(OnHexagonalGridModelCut signal)
        {
            Discard();
            var gridCutModel = signal.GridCutModel;
            gridView = new GameObject("Grid").AddComponent<HexagonalGridView>();
            gridView.gameObject.transform.parent = view.transform;

            var cellViewSize = configuration.hexagonalCellViewPrefab.GetSizeWithoutBorder();

            var cellViewWidth = cellViewSize * 2;
            var cellViewHeight = Mathf.Sqrt(3) * cellViewSize;

            gridCutModel.gridSegments.ForEach(gridModel => {
                gridModel.grid.ForEach(cellModel => {
                    var cellView = GameObject.Instantiate(configuration.hexagonalCellViewPrefab, gridView.gameObject.transform);
                    cellView.SetPositionHex(cellModel.transform.position);
                    cellView.SetFillColor(cellModel.debugColor);
                    cellView.transform.position = new Vector3(cellModel.transform.position.x * cellViewWidth - cellModel.transform.position.x * cellViewWidth * 0.25f,
                        cellModel.transform.position.y * cellViewHeight + cellModel.transform.position.x * cellViewHeight * 0.5f, 0);
                    cellView.gameObject.name = $"X: {cellModel.transform.position.x}; Y: {cellModel.transform.position.y}; Z: {cellModel.transform.position.z}";
                    gridView.grid.Add(cellView);
                });
            });
        }

        private void Present(OnHexagonalGridModelGenerated signal)
        {
            Discard();
            var gridModel = signal.HexagonalGridModel;
            gridView = new GameObject("Grid").AddComponent<HexagonalGridView>();
            gridView.gameObject.transform.parent = view.transform;

            var cellViewSize = configuration.hexagonalCellViewPrefab.GetSizeWithoutBorder();

            var cellViewWidth = cellViewSize * 2;
            var cellViewHeight = Mathf.Sqrt(3) * cellViewSize;

            gridModel.grid.ForEach(cellModel =>
            {
                var cellView = GameObject.Instantiate(configuration.hexagonalCellViewPrefab, gridView.gameObject.transform);
                cellView.SetPositionHex(cellModel.transform.position);
                cellView.SetFillColor(cellModel.debugColor);
                cellView.transform.position = new Vector3(cellModel.transform.position.x * cellViewWidth - cellModel.transform.position.x * cellViewWidth * 0.25f,
                    cellModel.transform.position.y * cellViewHeight + cellModel.transform.position.x * cellViewHeight * 0.5f, 0);
                cellView.gameObject.name = $"X: {cellModel.transform.position.x}; Y: {cellModel.transform.position.y}; Z: {cellModel.transform.position.z}";
                gridView.grid.Add(cellView);
            });
        }

        private void Discard()
        {
            if (gridView == null)
                return;
            if (gridView.grid == null)
                return;
            gridView.grid.ForEach(cell => GameObject.Destroy(cell.gameObject));
            gridView.grid = null;
            GameObject.Destroy(gridView.gameObject);
            gridView = null;
        }
    }
}