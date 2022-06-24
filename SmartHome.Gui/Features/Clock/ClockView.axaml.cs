using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace SmartHome.Gui.Features.Clock;

public partial class ClockView : UserControl
{
    public ClockView( )
    {
        InitializeComponent( );
    }

    private void InitializeComponent( )
    {
        AvaloniaXamlLoader.Load( this );
    }
}