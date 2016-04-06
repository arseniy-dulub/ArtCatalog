using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using GEOArchive.Tools.GEOEntities;
using System.IO;
using System.Windows.Forms;

namespace GEOArchive.Tools
{
    public static class GeoFileReader
    {
        public static GeoObject DeSerializeGeoObject(string filename)
        {
            GeoObject result = new GeoObject();

            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(GeoObject));

            System.IO.StreamReader file = new StreamReader(filename);

            try
            {
                result = (GeoObject)reader.Deserialize(file);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.ToString());
            }

            file.Close();

            return result;
        }

        public static List<ResultTable> DeserializeResultTables(string filename)
        {
            List<ResultTable> result = new List<ResultTable>();

            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(List<ResultTable>));

            System.IO.StreamReader file = new StreamReader(filename);

            result = (List<ResultTable>)reader.Deserialize(file);

            file.Close();

            return result;
        }

        public static string GetGeoSetNum(GeoObject source)
        {
            return source.Id;
        }

        public static string GetGeoSetOutsCount(GeoObject source)
        {
            return source.OutObjects.Count.ToString("N0");
        }

        public static string GetGeoSetOutsStraight(GeoObject source)
        {
            string result = string.Empty;

            if (source.OutObjects.Count > 0)
            {
                foreach (var obj in source.OutObjects)
                {
                    result += obj.Id + ";";
                }
            }
            else result = "-";

            return result;
        }

        public static string GetGeoSetCreator(GeoObject source)
        {
            return source.DoerPosit + " " + source.DoerName;
        }

        public static string GetGeoSetDateCreate(GeoObject source)
        {
            return source.DateCreate.ToShortDateString();
        }

        public static string GetGeoSetName(GeoObject source)
        {
            return source.Name;
        }

        public static string GetGeoSetCuts(GeoObject source)
        {
            string result = string.Empty;

            if (source.Sections.Count > 0)
            {
                foreach (var cut in source.Sections)
                {
                    result += cut.Id + ";";
                }
            }
            else result = "-";

            return result;
        }

        public static string GetLabResultCount(List<ResultTable> source)
        {
            int result = 0;

            if (source.Count > 0)
            {
                result = source.Count(item => item.Test != null && item != null && item != new ResultTable());
                return result.ToString("N0");
            }
            else return "-";           
        }

        public static string GetProbingContains(GeoObject source)
        {
            string result = "Зондирование:\n";

            bool dynamProbeContains = false;
            bool staticProbeContains = false;

            if (source.OutObjects.Count > 0)
            {
                foreach (var obj in source.OutObjects)
                {
                    if (obj.DynamicProbes.Count > 0)
                        dynamProbeContains = true;
                    if (obj.StaticProbes.Count > 0)
                        staticProbeContains = true;
                }
            }

            if (dynamProbeContains)
                result += @"   Динамическое: +\n";
            else result += @"   Динамическое: -\n";
            if (staticProbeContains)
                result += @"   Статическое: +\n";
            else result += @"   Статическое: -\n";

            return result;
        }

        public static string GetShearTestingContains(List<ResultTable> source)
        {
            string result = string.Empty;

            if (source.Exists(item => item.P1 != null && item.T != null))
            {
                result += @"Есть данные по сдвиговым испытаниям.";
            }
            else result += @"Нет данных по сдвиговым испытаниям.";
        
            return result;
        }
    }
}
