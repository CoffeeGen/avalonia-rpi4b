using System.Threading.Tasks;
using Avalonia.Controls;
using ReactiveUI;
using SmartHome.Core.Gpio;
using SmartHome.Gui.Features.Dashboard;
using SmartHome.Gui.Layouts;

namespace SmartHome.Gui.Features.Shutdown;

public class Shutdown : ModelBase
{
    public override IControl? Control { get; set; } = new DashboardView( );

    private string _lightsState;

    public string LightsState
    {
        get => _lightsState;
        set => this.RaiseAndSetIfChanged(ref _lightsState, value);
    }
    
    private int _backlightBrightness;
    public int BacklightBrightness
    {
        get => _backlightBrightness;
        set
        {
            Backlight.SetBrightness( value );
            this.RaiseAndSetIfChanged( ref _backlightBrightness, value );
        }
    }

    public Shutdown( )
    {
        Update( );
    }
    
    public void ToggleLights_OnClick( )
    {
        Lights.Toggle( );
        _ = Update( );
    }

    private async Task Update( )
    {
        LightsState = Lights.State ? "Turn Off" : "Turn On";
        BacklightBrightness = await Backlight.GetBrightness( );
    }
}