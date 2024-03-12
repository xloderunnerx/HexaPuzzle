using Composite.Core;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace App.Features.GridModelGenerator
{
    public class GridModelGeneratorView : AbstractView
    {
        [SerializeField] private Button regenerateButton;

        public Action onRegenerateClick;

        private void Awake()
        {
            regenerateButton.onClick.AddListener(() => onRegenerateClick?.Invoke());
        }
    }
}
