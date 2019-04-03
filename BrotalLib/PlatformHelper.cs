using System.Runtime.InteropServices;

using static System.Runtime.InteropServices.OSPlatform;

namespace Brotal.Extensions
{
    public static class Platform
    {
        public static bool IsWindows =>
            RuntimeInformation.IsOSPlatform(Windows);

        public static bool IsLinux =>
            RuntimeInformation.IsOSPlatform(Linux);

        public static bool IsMac =>
            RuntimeInformation.IsOSPlatform(OSX);

        public static OSPlatform OS => 
            IsWindows 
                ? Windows 
                : IsLinux 
                    ? Linux 
                    : OSX;
    }
}
