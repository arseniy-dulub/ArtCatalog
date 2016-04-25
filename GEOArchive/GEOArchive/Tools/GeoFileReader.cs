using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using GEOArchive.Tools.GEOEntities;
using System.IO;
using GEOArchive.Entity;

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
            catch { }

            file.Close();

            return result;
        }

        public static LabObject DeSerializeLabObject(string filename)
        {
            LabObject result = new LabObject();

            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(LabObject));

            System.IO.StreamReader file = new StreamReader(filename);

            try
            {
                result = (LabObject)reader.Deserialize(file);
            }
            catch {}

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

        public static List<Ige> DeserializeIgeList(string filename)
        {
            List<Ige> result = new List<Ige>();

            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(List<Ige>));

            System.IO.StreamReader file = new StreamReader(filename);

            result = (List<Ige>)reader.Deserialize(file);

            file.Close();

            return result;
        }

        public static string GetGeoSetNum(GeoObject source)
        {
            return source.Id;
        }

        public static string GetGeoSetNum(LabObject source)
        {
            return source.Id;
        }
        
        public static string GetGeoSetCreator(LabObject source)
        {
            return source.DoerPosit + " " + source.DoerName;
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

        public static string GetGeoSetName(LabObject source)
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
                result += @"   Динамическое: есть" + "\n";
            else result += @"   Динамическое: нет" + "\n";
            if (staticProbeContains)
                result += @"   Статическое: есть" + "\n";
            else result += @"   Статическое: нет" + "\n";

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

        public static string GetTableNumsFromLabDataStraight(List<ResultTable> source)
        {
            string result = string.Empty;

            List<string> diffTables = new List<string>();

            foreach (var test in source)
            {
                if (!diffTables.Contains(test.Obj)) diffTables.Add(test.Obj);
            }

            foreach (var table in diffTables)
            {
                result += table + "; ";
            }

            return result;
        }

        public static string GetGroundsFromTestsStraight(List<ResultTable> source)
        {
            string result = string.Empty;

            List<string> diffGrounds = new List<string>();

            foreach (var test in source)
            {
                if (!diffGrounds.Contains(test.Name)) diffGrounds.Add(test.Name);
            }

            foreach (var g in diffGrounds)
            {
                result += g + "; ";
            }

            return result;
        }

        public static string GetIgeCount(List<Ige> source)
        {
            return source.Count.ToString("N0");
        }

        public static string GetIgeStraight(List<Ige> source)
        {
            string result = string.Empty;

            int columner = 0;

            foreach (var ige in source)
            {
                if (columner % 4 == 0 && columner != 0)
                {
                    result += ige.Id + " - " + ige.GroundName + "; " + '\n';
                }
                else
                {
                    result += ige.Id + " - " + ige.GroundName + "; ";
                }
                columner++;
            }

            return result;
        }

        public static List<CutEntity> DeserializeCutList(string filename)
        {
            List<CutEntity> result = new List<CutEntity>();
            XmlSerializer reader = new XmlSerializer(typeof(List<CutEntity>));
            StreamReader file = new StreamReader(filename);
            result = (List<CutEntity>)reader.Deserialize(file);
            file.Close();
            return result;
        }

        public static string GetCutsCount(List<CutEntity> source)
        {
            return source.Count.ToString("N0");
        }

        public static string GetCutsStraight(List<CutEntity> source)
        {
            string result = string.Empty;

            foreach (var cut in source)
            {
                result += cut.Id + "; ";
            }

            return result;
        }

        public static string IndentifyGeoFile(GeoFile file)
        {
            string result = string.Empty;
            string extencion = FileManager.GetFileExtension(file.GeoFilePath);

            switch (extencion)
            {
                case ".xgeoobj":
                    #region Гео объект
                    {
                        try
                        {
                            GeoObject geoObject = DeSerializeGeoObject(file.GeoFilePath);
                            result +=
                                "Тип файла: " + FileManager.GetFileFullType(file) +'\n' + '\n' +
                                "Первоначальная информация:" + '\n' +
                                "   -Номер объекта: " + GetGeoSetNum(geoObject) + '\n' +
                                "   -Исполнитель: " + GetGeoSetCreator(geoObject) + '\n' +
                                "   -Дата создания: " + GetGeoSetDateCreate(geoObject) + '\n' +
                                "   -Наименование объекта: " + GetGeoSetName(geoObject) + '\n' + '\n' +
                                "   -Выработки(кол-во: " + GetGeoSetOutsCount(geoObject) + "): " + GetGeoSetOutsStraight(geoObject) + '\n' + '\n' +
                                "   -" + GetProbingContains(geoObject) + '\n' +
                                "   -Разрезы: " + GetGeoSetCuts(geoObject) + '\n' + '\n';
                        }
                        catch
                        { result += "Не удалось прочитать файл."; }
                        break;
                        
                    }
                #endregion
                case ".xgeolab":
                    #region Гео таблица
                    {
                        try
                        {
                            LabObject labObject = DeSerializeLabObject(file.GeoFilePath);
                            result +=
                                "Тип файла: " + FileManager.GetFileFullType(file) + '\n' + '\n' +
                                "Первоначальная информация:" + '\n' +
                                "   -Номер таблицы: " + GetGeoSetNum(labObject) + '\n' +
                                "   -Исполнитель: " + GetGeoSetCreator(labObject) + '\n' +
                                "   -Наименование объекта: " + GetGeoSetName(labObject) + '\n' + '\n' +
                                "   -Пробы(кол-во: " + GetLabResultCount(labObject.ResultItems) + "): " + GetGroundsFromTestsStraight(labObject.ResultItems) + '\n' + '\n' +
                                GetShearTestingContains(labObject.ResultItems);
                        }
                        catch
                        { result += "Не удалось прочитать файл."; }
                        break;
                    }
                #endregion
                case ".labdata":
                    #region LabData
                    {
                        try
                        {
                            List<ResultTable> labData = DeserializeResultTables(file.GeoFilePath);
                            result +=
                                "Тип файла: " + FileManager.GetFileFullType(file) + '\n' + '\n' +
                                "Первоначальная информация:" + '\n' +
                                "   -Номера таблиц: " + GetTableNumsFromLabDataStraight(labData) + '\n' +
                                "   -Пробы(кол-во: " + GetLabResultCount(labData) + "): " + GetGroundsFromTestsStraight(labData) + '\n' + '\n' +
                                GetShearTestingContains(labData);
                        }
                        catch { result += "Не удалось прочитать файл."; }
                        break;
                    }
                #endregion
                case ".igelist":
                    #region IgeList
                    {
                        try
                        {
                            List<Ige> igeList = DeserializeIgeList(file.GeoFilePath);
                            result +=
                                "Тип файла: " + FileManager.GetFileFullType(file) + '\n' + '\n' +
                                "   -Инженерно геологические элементы(ИГЭ кол-во: " + GetIgeCount(igeList) + ")" + '\n' +
                                GetIgeStraight(igeList);// + '\n' +

                        }
                        catch { result += "Не удалось прочитать файл."; }
                        break;
                    }
                #endregion
                case ".cutlist":
                    #region CutList
                    {
                        try
                        {
                            List<CutEntity> cuts = DeserializeCutList(file.GeoFilePath);
                            result +=
                                "Тип файла: " + FileManager.GetFileFullType(file) + '\n' + '\n' +
                                "   -Геологические разреы(кол-во: " + GetCutsCount(cuts) + ")" + '\n' +
                                GetCutsStraight(cuts);

                        }
                        catch { result += "Не удалось прочитать файл."; }
                        break;
                    }
                #endregion
                default:
                    {
                        result += "Тип файла: " + FileManager.GetFileFullType(file);
                        break;
                    }
            }
                        
            return result;
        }
    }
}
