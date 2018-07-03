using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BetterSplorer
{
    class win32
    {
        public delegate void enumDesktopWindows(IntPtr hwnd, IntPtr lParam);
        public delegate void enumChildWindows(IntPtr hwnd, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern void SetParent(IntPtr HwndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll")]
        public static extern IntPtr GetParentTestest(IntPtr HwndChild);
        [DllImport("user32.dll")]
        public static extern IntPtr GetAncestor(IntPtr HwndChild, uint gaFlags);
        [DllImport("user32.dll")]
        public static extern long GetWindowLong(IntPtr HwndChild, int nIndex);
        [DllImport("user32.dll")]
        public static extern void EnumDesktopWindows(IntPtr hDesktop, enumDesktopWindows lpfn, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern void EnumChildWindows(IntPtr hWndParent, enumDesktopWindows lpfn, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern void GetWindowRect(IntPtr hWnd, ref desktopWorkArea.Rect lpRect);
        [DllImport("user32.dll")]
        public static extern void SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
    }
}
