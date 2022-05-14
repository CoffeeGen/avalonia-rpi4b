using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using SmartHome.Core.Services;

namespace SmartHome.Gui.Features.Dashboard;

public partial class DashboardView : UserControl
{
    public DashboardView( )
    {
        InitializeComponent( );
    }

    private void InitializeComponent( )
    {
        AvaloniaXamlLoader.Load( this );
    }

    private void Reboot_OnClick( object? sender, RoutedEventArgs e )
    {
        Device.Reboot( );
    }

    private void Shutdown_OnClock( object? sender, RoutedEventArgs e )
    {
        Device.Shutdown();
    }
}