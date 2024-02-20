using App.Core.Puzzle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Features.PuzzlePainter
{
    public interface IPuzzlePainterBehaviour
    {
        public void Paint(PuzzleModel puzzleModel, PuzzlePainterConfiguration configuration, IPuzzleColorBehaviour puzzleColorBehaviour);
    }
}
