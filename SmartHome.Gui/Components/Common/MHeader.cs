using System;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Threading;
using ReactiveUI;
using SmartHome.Gui.Interfaces;
using SmartHome.Gui.Layouts;

namespace SmartHome.Gui.Components.Common;

public class MHeader : ModelBase, IUpdatable
{
    public override IControl? Control { get; set; } = new Header( );
    
    private DateTime _currentDateTime;

    public DateTime CurrentDateTime
    {
        get => _currentDateTime;
        set => this.RaiseAndSetIfChanged(ref _currentDateTime, value);
    }

    protected override void OnUpdateMainThread( )
    {
        CurrentDateTime = DateTime.Now;
    }
}