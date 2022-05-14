using System.Runtime.InteropServices;

namespace SmartHome.Core;

public static class Os
{
    public static bool IsLinux( ) => RuntimeInformation.IsOSPlatform( OSPlatform.Linux );
    public static bool IsWindows( ) => RuntimeInformation.IsOSPlatform( OSPlatform.Windows );
}