using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SmartHome.Gui.Features.Shutdown;

public partial class ShutdownView : UserControl
{
    public ShutdownView( )
    {
        InitializeComponent( );
    }

    private void InitializeComponent( )
    {
        AvaloniaXamlLoader.Load( this );
    }
}