using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Threading;
using ReactiveUI;
using SmartHome.Core.Services;
using SmartHome.Gui.Interfaces;
using SmartHome.Gui.Layouts;

namespace SmartHome.Gui.Features.Monitor;

public class Monitor : ModelBase, IUpdatable
{
    public override IControl? Control { get; set; } = new MonitorView( );
    
    private string _cpuTemp;

    public string CpuTemp
    {
        get => _cpuTemp;
        set => this.RaiseAndSetIfChanged(ref _cpuTemp, value);
    }

    protected override async Task OnUpdate( )
    {
        var cpuTemp = await Device.GetCpuTemp( );
        
        await Dispatcher.UIThread.InvokeAsync( ( ) =>
        {
            CpuTemp = $"{ cpuTemp } °C";
        } );
    }
}