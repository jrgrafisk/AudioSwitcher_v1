using System;
using System.Threading;
using System.Windows.Forms;

namespace FocusGuard
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            // Single-instance guard
            using var mutex = new Mutex(true, "FocusGuard_SingleInstance", out bool first);
            if (!first)
            {
                MessageBox.Show(
                    "FocusGuard is already running.\nCheck your system tray.",
                    "FocusGuard", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Environment.OSVersion.Version.Major < 6)
            {
                MessageBox.Show(
                    "FocusGuard requires Windows Vista or later.",
                    "Unsupported OS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ApplicationExit += (_, _) =>
                FocusGuardForm.Instance.TrayIconVisible = false;

            Application.Run(FocusGuardForm.Instance);
        }
    }
}
