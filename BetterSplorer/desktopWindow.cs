using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace BetterSplorer
{
    public partial class desktopWindow : Form
    {
        public static IntPtr desktopHandle;
        public desktopWindow()
        {
            InitializeComponent();
            desktopHandle = Handle;

            Timer timer = new Timer();
            timer.Interval = 1;
            timer.Tick += Timer_Tick;
            timer.Start();

            ProcessStartInfo kill = new ProcessStartInfo();
            kill.WindowStyle = ProcessWindowStyle.Minimized;
            kill.FileName = "taskkill.exe";
            kill.Arguments = "/im explorer.exe /f";
            Process.Start(kill);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            win32.EnumDesktopWindows(IntPtr.Zero, delegate (IntPtr hwnd, IntPtr lParam) {
                if ((win32.GetWindowLong(hwnd, -16) & 0x00C00000) == 0x00C00000)
                {
                    win32.SetParent(hwnd, Handle);
                }
            }, IntPtr.Zero);
        }

        private void desktopWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            new UI.Dialogs.exitDialog().Show();
            e.Cancel = true;
        }

        private void desktopWindow_Shown(object sender, EventArgs e)
        {
            desktopWorkArea.Rect desktopArea = new desktopWorkArea.Rect();
            desktopArea.Top = 0;
            desktopArea.Right = Width;
            desktopArea.Bottom = Height;
            desktopArea.Left = 0;
            desktopWorkArea.Set(desktopArea);
        }

        private void label_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "/n");
        }
    }
}
