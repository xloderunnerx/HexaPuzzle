using App.Features.CardsHand;
using App.Features.HexagonalGridModelGenerator;
using App.Features.HexagonalGridViewPresenter;
using App.Features.PuzzleModelGenerator;
using App.Features.PuzzlePainter;
using App.Features.PuzzleViewPresenter;
using Composite.Core;

public class CompositionRoot : AbstractCompositionRoot
{
    private void Awake()
    {
        BindConfigurations();
        BindSignalBus();
        BindFeatures();
    }

    private void Start()
    {
        DeclareSignals();
        SubscribeToSignals(); 
        InitializeControllers();
    }

    private void Update()
    {
        UpdateControllers(); 
    }

    public void BindFeatures()
    {
        BindFeature<PuzzlePainterFeature>();
        BindFeature<CardsHandFeature>();
        BindFeature<PuzzleViewPresenterFeature>();
        BindFeature<HexagonalGridViewPresenterFeature>();
        BindFeature<HexagonalGridModelGeneratorFeature>();
        BindFeature<PuzzleModelGeneratorFeature>();
    }
}