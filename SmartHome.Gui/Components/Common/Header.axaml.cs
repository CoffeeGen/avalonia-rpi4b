using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SmartHome.Gui.Components.Common;

public partial class Header : UserControl
{
    public Header( )
    {
        InitializeComponent( );
    }

    private void InitializeComponent( )
    {
        AvaloniaXamlLoader.Load( this );
    }

}