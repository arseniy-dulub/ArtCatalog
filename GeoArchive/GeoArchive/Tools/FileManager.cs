using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoArchive.Tools
{
    public static class FileManager
    {
        public static string GetFileName(string filename)
        {
            int lastPointStringLength = filename.LastIndexOf(@".");
            return filename.Substring(filename.LastIndexOf(@"\") + 1, filename.Length - lastPointStringLength - 1);
        }

        public static string GetFileExtension(string filename) 
        {
            return filename.Substring(filename.LastIndexOf('.'));
        }
    }
}
