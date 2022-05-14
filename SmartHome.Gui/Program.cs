using System;
using System.Linq;
using Avalonia;
using Avalonia.ReactiveUI;
using SmartHome.Core.Gpio;

namespace SmartHome.Gui
{
    class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [ STAThread ]
        public static int Main(string[] args)
        {
            // Reset to defaults
            Lights.Off( );
            
            var builder = BuildAvaloniaApp();

            if( args.Contains( "--drm" ) )
            {
                return builder.StartLinuxDrm(args, "/dev/dri/card1", scaling: 1 );
            }
            
            return builder.StartWithClassicDesktopLifetime( args );
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp( )
            => AppBuilder.Configure<App>( )
                .UsePlatformDetect( )
                .LogToTrace( )
                .UseReactiveUI( );
    }
}