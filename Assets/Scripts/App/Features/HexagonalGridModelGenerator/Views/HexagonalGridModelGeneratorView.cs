using Composite.Core;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace App.Features.HexagonalGridModelGenerator
{
    public class HexagonalGridModelGeneratorView : AbstractView
    {
        [SerializeField] private Button regenerateButton;

        public Action onRegenerateClick;

        private void Awake()
        {
            regenerateButton.onClick.AddListener(() => onRegenerateClick?.Invoke());
        }
    }
}
