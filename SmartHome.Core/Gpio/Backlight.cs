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
        _ = Cli.Wrap( "/opt/smart-home/external/backlight-brightness.sh" ).WithArguments( $"{ brightness }" ).ExecuteAsync();
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

    public static async Task<bool> State( )
    {
        if( !Os.IsLinux( ) )
            return false;
        
        BufferedCommandResult result = await Cli.Wrap( "cat" ).WithArguments( "/sys/class/backlight/10-0045/bl_power" )
            .ExecuteBufferedAsync( );

        return result.StandardOutput == "0";
    }
    
    public static async Task Toggle( )
    {
        if( !Os.IsLinux( ) )
            return;

        if( await State() )
            Off( );
        else
            On( );
    }
    public static void On( )
    {
        if( !Os.IsLinux( ) )
            return;
        
        _ = Cli.Wrap( "/opt/smart-home/external/backlight.sh" ).WithArguments( "0" ).ExecuteAsync();
    }
    public static void Off( )
    {
        if( !Os.IsLinux( ) )
            return;
        
        _ = Cli.Wrap( "/opt/smart-home/external/backlight.sh" ).WithArguments( "1" ).ExecuteAsync();
    }
}