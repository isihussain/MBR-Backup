namespace MBRCopy
{
    using System;

    internal static partial class Program
    {  
        public static void Main()
        {
            Console.Title = "MBR Backup by r3xq1";
            MBRoot.Inizialize("mbr.img");
            Console.ReadKey();
        }
    }
}
