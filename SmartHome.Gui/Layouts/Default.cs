using System.Collections.Generic;
using System.Diagnostics;
using Avalonia.Controls;
using ReactiveUI;
using SmartHome.Gui.Components.Common;
using SmartHome.Gui.Events;
using SmartHome.Gui.Features.Dashboard;
using SmartHome.Gui.Features.Monitor;
using SmartHome.Gui.Interfaces;

namespace SmartHome.Gui.Layouts;

public class Default : ModelBase
{
    private static Default? _instance;

    public static Default Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Default();
            }

            return _instance;
        }
        set => _instance = value;
    }

    public override IControl? Control { get; set; } = new DefaultView( );
    
    private List<ModelBase> _views;

    public List<ModelBase> Views
    {
        get => _views;
        set => this.RaiseAndSetIfChanged(ref _views, value);
    }

    private int _activeViewId = 0;

    public ModelBase ActiveView => Views[ _activeViewId ];
    
    private MHeader _header;

    public MHeader Header
    {
        get => _header;
        set => this.RaiseAndSetIfChanged(ref _header, value);
    }

    public Default()
    {
        _instance = this;
        
        Views = new List<ModelBase>
        {
            new Dashboard( ),
            new Monitor( )
        };
        
        Header = new MHeader( );
        
        View.Change += ViewOnChange;
    }

    private void ViewOnChange( int oldViewId, ModelBase oldView, int newViewId, ModelBase newView )
    {
        Debug.WriteLine( $"old: { oldViewId }, new: { newViewId }" );
    }
}