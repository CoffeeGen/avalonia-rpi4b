using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SmartHome.Gui.Features.Monitor;

public partial class MonitorView : UserControl
{
    public MonitorView( )
    {
        InitializeComponent( );
    }

    private void InitializeComponent( )
    {
        AvaloniaXamlLoader.Load( this );
    }
}