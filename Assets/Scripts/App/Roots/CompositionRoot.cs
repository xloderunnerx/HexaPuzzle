using App.Features.GridModelGenerator;
using App.Features.GridViewGenerator;
using App.Features.PuzzleModelGenerator;
using App.Features.PuzzleViewGenerator;
using App.Features.PuzzlePainter;
using Composite.Core;
using App.Features.HandModelGenerator;
using App.Features.HandViewGenerator;

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
        BindFeature<HandViewGeneratorFeature>();
        BindFeature<HandModelGeneratorFeature>();
        BindFeature<PuzzleViewGeneratorFeature>();
        BindFeature<GridViewGeneratorFeature>();
        BindFeature<GridModelGeneratorFeature>();
        BindFeature<PuzzleModelGeneratorFeature>();
    }
}