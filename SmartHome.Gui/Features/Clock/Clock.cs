using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using ReactiveUI;
using SmartHome.Core.Gpio;
using SmartHome.Gui.Features.Dashboard;
using SmartHome.Gui.Interfaces;
using SmartHome.Gui.Layouts;

namespace SmartHome.Gui.Features.Clock;

public class Clock : ModelBase, IUpdatable
{
    public override IControl? Control { get; set; } = new DashboardView( );

    public List<Point> Points { get; set; }

    public Clock( )
    {
    }
}