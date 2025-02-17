using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.BL.Helper
{
    public static class ScreenshotBlocker
    {
        [DllImport("user32.dll")]
        private static extern int SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);

        private const uint WDA_NONE = 0;
        private const uint WDA_EXCLUDEFROMCAPTURE = 2; // Windows 10 və sonrası üçün

        public static void BlockScreenshots()
        {
            IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
            SetWindowDisplayAffinity(handle, WDA_EXCLUDEFROMCAPTURE);
        }
    }
}
