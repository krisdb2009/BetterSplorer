using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetterSplorer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new desktopWindow());
        }
        public static void QuitBetterSplorer(bool releaseWindows = true)
        {
            List<IntPtr> childrenhHwnd = new List<IntPtr>();
            win32.EnumChildWindows(desktopWindow.desktopHandle, delegate (IntPtr hwnd, IntPtr lParam) {
                childrenhHwnd.Add(hwnd);
            }, IntPtr.Zero);

            foreach(IntPtr hwnd in childrenhHwnd)
            {
                if(desktopWindow.desktopHandle == win32.GetAncestor(hwnd, 1))
                {
                    win32.SetParent(hwnd, IntPtr.Zero);
                }
            }
            Process.Start("explorer.exe");
            Application.ExitThread();
        }
    }
}
