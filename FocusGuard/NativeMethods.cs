using System;
using System.Runtime.InteropServices;
using System.Text;

namespace FocusGuard
{
    internal static class NativeMethods
    {
        // SystemParametersInfo actions
        public const int SPI_GETFOREGROUNDLOCKTIMEOUT = 0x2000;
        public const int SPI_SETFOREGROUNDLOCKTIMEOUT = 0x2001;
        public const int SPIF_SENDCHANGE = 0x0002;

        // Shell hook codes delivered via WM_SHELLHOOKMESSAGE
        public const int HSHELL_WINDOWCREATED    = 1;
        public const int HSHELL_WINDOWDESTROYED  = 2;
        public const int HSHELL_WINDOWACTIVATED  = 4;  // normal activation
        public const int HSHELL_RUDEAPPACTIVATED = 0x8004; // forced activation

        // FlashWindowEx flags
        public const uint FLASHW_STOP      = 0;
        public const uint FLASHW_CAPTION   = 1;
        public const uint FLASHW_TRAY      = 2;
        public const uint FLASHW_ALL       = 3;
        public const uint FLASHW_TIMER     = 4;
        public const uint FLASHW_TIMERNOFG = 12; // flash until window is in foreground

        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public uint  cbSize;
            public IntPtr hwnd;
            public uint  dwFlags;
            public uint  uCount;
            public uint  dwTimeout;
        }

        [DllImport("user32.dll")]
        public static extern bool RegisterShellHookWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool DeregisterShellHookWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern uint RegisterWindowMessage(string lpString);

        // Get/Set timeout (uint overload for reading, then writing)
        [DllImport("user32.dll")]
        public static extern bool SystemParametersInfo(int uiAction, uint uiParam, ref uint pvParam, uint fWinIni);

        [DllImport("user32.dll")]
        public static extern bool SystemParametersInfo(int uiAction, uint uiParam, uint pvParam, uint fWinIni);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool FlashWindowEx(ref FLASHWINFO pfwi);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("kernel32.dll")]
        public static extern uint GetCurrentProcessId();

        [DllImport("user32.dll")]
        public static extern bool DestroyIcon(IntPtr hIcon);

        // Flash the taskbar button until the user brings the window to the front
        public static void FlashTaskbar(IntPtr hwnd)
        {
            var fi = new FLASHWINFO
            {
                cbSize   = (uint)Marshal.SizeOf(typeof(FLASHWINFO)),
                hwnd     = hwnd,
                dwFlags  = FLASHW_TRAY | FLASHW_TIMERNOFG,
                uCount   = 5,
                dwTimeout = 0
            };
            FlashWindowEx(ref fi);
        }

        public static string GetWindowTitle(IntPtr hwnd)
        {
            var sb = new StringBuilder(256);
            GetWindowText(hwnd, sb, sb.Capacity);
            return sb.ToString();
        }
    }
}
