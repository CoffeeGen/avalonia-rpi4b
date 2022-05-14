using Avalonia.Controls;
using ReactiveUI;
using SmartHome.Core.Gpio;
using SmartHome.Gui.Layouts;

namespace SmartHome.Gui.Features.Dashboard;

public class Dashboard : ModelBase
{
    public override IControl? Control { get; set; } = new DashboardView( );

    private string _lightsState;

    public string LightsState
    {
        get => _lightsState;
        set => this.RaiseAndSetIfChanged(ref _lightsState, value);
    }

    public Dashboard( )
    {
        Update( );
    }
    
    public void ToggleLights_OnClick( )
    {
        Lights.Toggle( );
        Update( );
    }

    private void Update( )
    {
        LightsState = Lights.State ? "Turn Off" : "Turn On";
    }
}