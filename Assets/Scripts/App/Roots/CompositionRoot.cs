using App.Features.CardsHand;
using App.Features.GridModelGenerator;
using App.Features.GridViewGenerator;
using App.Features.PuzzleModelGenerator;
using App.Features.PuzzleViewGenerator;
using App.Features.PuzzlePainter;
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
        BindFeature<PuzzleViewGeneratorFeature>();
        BindFeature<GridViewGeneratorFeature>();
        BindFeature<GridModelGeneratorFeature>();
        BindFeature<PuzzleModelGeneratorFeature>();
    }
}