using CliWrap;
using CliWrap.Buffered;

namespace SmartHome.Core.Services;

public static class Device
{
    public static void Reboot( )
    {
        if( !Os.IsLinux( ) )
            return;
        
        _ = Cli.Wrap( "/sbin/reboot" ).ExecuteAsync();
    }

    public static void Shutdown( )
    {
        if( !Os.IsLinux( ) )
            return;
        
        _ = Cli.Wrap( "/sbin/shutdown" ).WithArguments( "-h now" ).ExecuteAsync( );
    }

    public static async Task<double> GetCpuTemp( )
    {
        if( !Os.IsLinux( ) )
            return 0;
        
        BufferedCommandResult result = await Cli.Wrap( "cat" ).WithArguments( "/sys/class/thermal/thermal_zone0/temp" )
            .ExecuteBufferedAsync( );

        return double.Parse( result.StandardOutput[ ..2 ] );
    }
}