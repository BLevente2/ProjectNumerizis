using System.Runtime.InteropServices;

namespace MainProgram;

internal static class Program
{
    private static bool debugMode = false;

    [DllImport("kernel32.dll")]
    private static extern bool AllocConsole();

    [StructLayout(LayoutKind.Sequential)]
    private struct DEVMODE
    {
        private const int CCHDEVICENAME = 32;
        private const int CCHFORMNAME = 32;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
        public string dmDeviceName;
        public ushort dmSpecVersion;
        public ushort dmDriverVersion;
        public ushort dmSize;
        public ushort dmDriverExtra;
        public uint dmFields;
        public int dmPositionX;
        public int dmPositionY;
        public uint dmDisplayOrientation;
        public uint dmColor;
        public int dmDuplex;
        public int dmYResolution;
        public int dmTTOption;
        public int dmCollate;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
        public string dmFormName;
        public ushort dmLogPixels;
        public uint dmBitsPerPel;
        public uint dmPelsWidth;
        public uint dmPelsHeight;
        public uint dmDisplayFlags;
        public uint dmDisplayFrequency;
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern bool EnumDisplaySettings(string? lpszDeviceName, int iModeNum, ref DEVMODE lpDevMode);

    private static double GetRefreshRate()
    {
        DEVMODE devMode = new DEVMODE();
        devMode.dmSize = (ushort)Marshal.SizeOf(typeof(DEVMODE));

        if (EnumDisplaySettings(null, -1, ref devMode) && devMode.dmDisplayFrequency > 0)
        {
            return devMode.dmDisplayFrequency;
        }

        return 60.0;
    }

    [STAThread]
    static void Main()
    {
        if (debugMode)
        {
            AllocConsole();
        }

        double refreshRate = GetRefreshRate();

        if (debugMode)
        {
            Console.WriteLine($"Detected refresh rate: {refreshRate} Hz");
        }

        ApplicationConfiguration.Initialize();
        Application.Run(new MainWindow(refreshRate));

        if (debugMode)
        {
            Console.WriteLine("Press any key to exit from the console.");
            Console.ReadLine();
        }
    }
}