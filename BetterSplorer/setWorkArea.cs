using System;
using System.Runtime.InteropServices;

namespace BetterSplorer
{
    class desktopWorkArea
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SystemParametersInfo(
            int uiAction,
            IntPtr uiParam,
            ref Rect pvParam,
            int fWinIni
        );

        private const Int32 SPIF_SENDWININICHANGE = 2;
        private const Int32 SPIF_UPDATEINIFILE = 1;
        private const Int32 SPI_SETWORKAREA = 47;
        private const Int32 SPI_GETWORKAREA = 48;

        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public Int32 Left;
            public Int32 Top;
            public Int32 Right;
            public Int32 Bottom;
        }

        public static bool Set(Rect rect)
        {
            SystemParametersInfo(
                SPI_SETWORKAREA,
                IntPtr.Zero,
                ref rect,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE
            );
            bool result = SystemParametersInfo(
                SPI_SETWORKAREA,
                IntPtr.Zero,
                ref rect,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE
            );
            return result;
        }
    }
}