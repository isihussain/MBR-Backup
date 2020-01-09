namespace MBRCopy
{
    using System;
    using System.IO;
    using Microsoft.Win32.SafeHandles;

    public static class MBRoot
    {
        public static void Inizialize(string filename)
        {
            if (!string.IsNullOrEmpty(filename))
            {
                if (!File.Exists(Path.Combine(Environment.CurrentDirectory, "mbr.img")))
                {
                    using (SafeFileHandle handle =
                    SafeNativeMethods.CreateFile(@"\\.\C:", FileAccess.Read,
                    FileShare.ReadWrite, IntPtr.Zero, FileMode.OpenOrCreate, FileAttributes.Normal, IntPtr.Zero))
                    {
                        using (var disk = new FileStream(handle, FileAccess.Read))
                        {
                            byte[] mbrData = new byte[512];

                            ConsoleHelper.WriteLineWithColor(ConsoleColor.Red, "Starting MBR Backup...");
                            try
                            {
                                int unused = disk.Read(mbrData, 0, mbrData.Length);
                                if (unused != 0)
                                {
                                    using (var mbrSave = new FileStream(filename, FileMode.Create))
                                    {
                                        mbrSave?.Write(mbrData, 0, mbrData.Length);
                                        ConsoleHelper.WriteLineWithColor(ConsoleColor.Green, "MBR Backuped to my mbr.img success!");
                                    }
                                }
                            }
                            catch (Exception e) { Console.WriteLine(e.Message); }
                        }
                    }
                }
                else
                {
                    ConsoleHelper.WriteLineWithColor(ConsoleColor.Yellow, "mbr.img file already exists!");
                }
            }
            else
            {
                ConsoleHelper.WriteLineWithColor(ConsoleColor.Yellow, "The file name cannot be empty");
            }
        }
    }
}