using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEOArchive.Entity;
using System.IO;

namespace GEOArchive.Tools
{
    public static class FileManager
    {
        public static string GetFileNameWithExtensionFromPath(string path)
        {
            string result = string.Empty;

            result = path.Substring(path.LastIndexOf(@"\") + 1);

            return result;
        }
        public static string GetFileNameWithoutExtensionFromPath(string path)
        {
            string result = string.Empty;

            result = path.Substring(path.LastIndexOf(@"\") + 1);
            result = result.Substring(0, result.LastIndexOf('.'));

            return result;
        }
        public static string GetFileExtension(string path)
        {
            string result = string.Empty;

            result = path.Substring(path.LastIndexOf('.'));

            return result;
        }
        public static string GetFileFullType(GeoFile file)
        {
            string result = string.Empty;

            switch(file.GeoFileType)
            {
                case ".xgeoobj":
                    {
                        result = "Исходные данные полевых исследований.";
                        break;
                    }
                case ".igelist":
                    {
                        result = "Список ИГЭ.";
                        break;
                    }
                case ".cutlist":
                    {
                        result = "Файл геологического разреза (для AutoCAD).";
                        break;
                    }
                case ".labdata":
                    {
                        result = "Лабораторные данные по проекту.";
                        break;
                    }
                case ".xgeolab":
                    {
                        result = "Исходные лабораторные данные.";
                        break;
                    }
                default:
                    {
                        result = "Прочие";
                        break;
                    }
            }

            return result;
        }
        public static List<GeoFile> GenarateGeoFileList(string[] files)
        {
            List<GeoFile> result = new List<GeoFile>();

            foreach (var file in files)
            {
                FileInfo pFile = new FileInfo(file);

                GeoFile newGeoFile = new GeoFile();
                newGeoFile.GeoFileDateCreate = pFile.CreationTime.ToShortDateString();
                newGeoFile.GeoFilePath = pFile.FullName;
                newGeoFile.GeoFileType = pFile.Extension;
                result.Add(newGeoFile);
            }

            return result;
        }
    }
}
