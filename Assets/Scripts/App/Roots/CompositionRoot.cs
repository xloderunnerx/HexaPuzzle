using App.Features.HexagonalGridGenerator;
using App.Features.HexagonalGridModelGenerator;
using App.Features.HexagonalGridViewPresenter;
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
        BindFeature<HexagonalGridGeneratorFeature>();
        BindFeature<HexagonalGridModelGeneratorFeature>();
        BindFeature<HexagonalGridViewPresenterFeature>();
    }
}