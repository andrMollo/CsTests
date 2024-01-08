using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace AddPDFTextConsole
{
    internal class Program
    {
        private static readonly string baseFile = @"C:\Users\AndreaMollo\Desktop\testPDF\origin.pdf";

        private static readonly string watermarkFile = @"C:\Users\AndreaMollo\Desktop\testPDF\watermark.jpg";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.ReadLine();
        }
    }
}
