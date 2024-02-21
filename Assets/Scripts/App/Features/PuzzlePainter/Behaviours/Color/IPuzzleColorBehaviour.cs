using System.Collections.Generic;
using UnityEngine;

namespace App.Features.PuzzlePainter
{
    public interface IPuzzleColorBehaviour
    {
        public List<Color> GetColors(PuzzlePainterConfiguration configuration);
    }
}
