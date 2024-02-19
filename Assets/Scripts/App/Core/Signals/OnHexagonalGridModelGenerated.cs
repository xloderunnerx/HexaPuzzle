using App.Core.Hexagonal;

public class OnHexagonalGridModelGenerated
{
    private HexagonalGridModel hexagonalGridModel;

    public OnHexagonalGridModelGenerated(HexagonalGridModel hexagonalGridModel)
    {
        this.hexagonalGridModel = hexagonalGridModel;
    }

    public HexagonalGridModel HexagonalGridModel { get => hexagonalGridModel; private set => hexagonalGridModel = value; }
}
