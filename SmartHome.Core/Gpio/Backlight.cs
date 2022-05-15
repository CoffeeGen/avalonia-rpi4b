using System.ComponentModel.DataAnnotations;
using CliWrap;
using CliWrap.Buffered;

namespace SmartHome.Core.Gpio;

public static class Backlight
{
    public static async void SetBrightness( int brightness )
    {
        if( !Os.IsLinux( ) )
            return;
        
        // Make sure to chmod +x the file to make it executable
        _ = Cli.Wrap( "backlight.sh" ).WithWorkingDirectory( "/opt/smart-home/external" ).WithArguments( $"{ brightness }" ).ExecuteAsync();
        Console.WriteLine( $"brightness set to : { brightness }" );
    }
    public static async Task<byte> GetBrightness( )
    {
        if( !Os.IsLinux( ) )
            return 255;
        
        BufferedCommandResult result = await Cli.Wrap( "cat" ).WithArguments( "/sys/class/backlight/10-0045/brightness" )
            .ExecuteBufferedAsync( );

        Console.WriteLine( $"brightness: { result.StandardOutput }" );
        
        return byte.Parse( result.StandardOutput );
    }
}