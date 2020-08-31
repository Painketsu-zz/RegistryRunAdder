using Microsoft.Win32;
using System;

namespace RegistryRunAdd
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 2)
                    Add(args);
                else
                    Console.WriteLine("its 2 params you drooling moron");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void Add(string[] args)
        {
            string path = args[0];
            string name = args[1] + ".exe";
            string KeyName = string.Format(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\{0}", name);

            RegistryKey reg = null;
            reg = Registry.LocalMachine.CreateSubKey(KeyName);
            reg.SetValue("", path);

            if (reg != null)
                reg.Close();
        }
    }
}
