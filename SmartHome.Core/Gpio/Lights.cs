using System.Runtime.InteropServices;
using CliWrap;

namespace SmartHome.Core.Gpio;

public static class Lights
{
    private static bool _state;
    
    public static bool State => _state;

    public static void Toggle( )
    {
        if( _state )
            Off( );
        else 
            On( );
    }
    
    public static void On( )
    {
        if( !Os.IsLinux( ) )
            return;
        
        _state = true;
        _ = Cli.Wrap( "/usr/bin/python" ).WithWorkingDirectory( "/opt/smart-home/external" ).WithArguments( "lightsOn.py" ).ExecuteAsync();
    }
    
    public static void Off( )
    {
        if( !Os.IsLinux( ) )
            return;
        
        _state = false;
        _ = Cli.Wrap( "/usr/bin/python" ).WithWorkingDirectory( "/opt/smart-home/external" ).WithArguments( "lightsOff.py" ).ExecuteAsync();
    }
}