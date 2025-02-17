using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.BL.Helper
{
    public static class ProcessBlocker
    {
        private static readonly string[] BlockedProcesses = { "SnippingTool", "SnipAndSketch", "mspaint" };

        public static void StartMonitoring()
        {
            new Thread(() =>
            {
                while (true)
                {
                    foreach (var processName in BlockedProcesses)
                    {
                        var processes = Process.GetProcessesByName(processName);
                        foreach (var process in processes)
                        {
                            process.Kill(); // Prosesi bağlayır
                        }
                    }
                    Thread.Sleep(1000); // Hər 1 saniyədə bir yoxlayır
                }
            })
            { IsBackground = true }.Start();
        }
    }
}
