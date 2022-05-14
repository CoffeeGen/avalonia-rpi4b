using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using SmartHome.Gui.Layouts;
using SmartHome.Gui.Windows;

namespace SmartHome.Gui
{
    public partial class App : Application
    {
        public override void Initialize( )
        {
            AvaloniaXamlLoader.Load( this );
        }

        public override void OnFrameworkInitializationCompleted( )
        {
            if( ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop )
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel( ),
                };
            }
            else if( ApplicationLifetime is ISingleViewApplicationLifetime singleView )
            {
                singleView.MainView = new DefaultView
                {
                    DataContext = new Default( )
                };
            }
            
            base.OnFrameworkInitializationCompleted( );
        }
    }
}