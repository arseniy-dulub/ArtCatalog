using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace GEOArchive.Tools.GEOEntities
{
    public class Ige
    {
        public Ige()
        {
            this.IntermProbeItems = new List<IgeItem>();
        }

        /// <summary>
        /// Разделители по Pд: 0 - грав. 1 - мелк. 2 - пыл.
        /// </summary>
        public double?[] ShareParamsPD012 
        {
            get
            {
                return Items.Find(item => item.Pd != null).ShareParamsPD012;
            }
        }

        /// <summary>
        /// Разделители по Qc: 0 - грав. 1 - мелк. 2 - пыл. 3 - пыл. водонасыщ.
        /// </summary>
        public double?[] ShareParamsQC0123 
        {
            get
            {
                return Items.Find(item => item.QC != null).ShareParamsQC0123;
            }
        }

        /// <summary>
        /// Коллекция записей 
        /// </summary>
        public List<IgeItem> Items { get; set; }

        /// <summary>
        /// Подэлементы промежуточного зондирования
        /// </summary>
        public List<IgeItem> IntermProbeItems { get; set; }

        /// <summary>
        /// Номер элемента
        /// </summary>
        public int Id { get; set; }

        private string groundName;
        /// <summary>
        /// Наименование ИГЭ
        /// </summary>
        public string GroundName
        {
            get { return groundName; }
            set { groundName = value; }
        }

        /// <summary>
        /// Количество записей
        /// </summary>
        public int ItemsCount { get { return Items.Distinct().Count(); } }

        private double? probeParameter;
        /// <summary>
        /// Среднее значение прочности (Pд или Qc)
        /// </summary>
        public double? ProbeParameter
        {
            get { return probeParameter; }
            set { probeParameter = value; }
        }

        private double? il;
        /// <summary>
        /// Параметр консистенции
        /// </summary>
        public double? Il
        {
            get { return il; }
            set { il = value; }
        }

        private double? e;
        /// <summary>
        /// Параметр е для песчаных грунтов
        /// </summary>
        public double? E
        {
            get { return e; }
            set { e = value; }
        }

        public bool Com(string ground)
        {
            string gcouple1 = ground.Substring(0, 2);
            string gcouple2 = "";
            string gcouple3 = "";
            string gcouple4 = "";

            try { gcouple2 = ground.Substring(2, 2); } catch { }

            try { gcouple3 = ground.Substring(4, 2); } catch { gcouple3 = "__"; }

            try { gcouple4 = ground.Substring(6, 2); } catch { gcouple4 = "__"; }

            string couple1 = this.GroundName.Substring(0, 2);
            string couple2 = "";
            string couple3 = "";
            string couple4 = "";

            try { couple2 = this.GroundName.Substring(2, 2); } catch { }

            try { couple3 = this.GroundName.Substring(4, 2); } catch { couple3 = "__"; }

            try { couple4 = this.GroundName.Substring(6, 2); } catch { couple4 = "__"; }

            // Глинистые грубые
            if (
                (couple1 == "СП" || couple1 == "СГ") && (couple1 == gcouple1) &&
                (couple2 == "ГР" && gcouple2 == "ГР") &&
                (couple4 == gcouple4)
                )
            {
                return true;
            }

            // Глинистые пылеватые
            if (
                (couple1 == "СП" || couple1 == "СГ" || couple1 == "ГЛ") && (couple1 == gcouple1) &&
                (couple2 == "ПЛ" && gcouple2 == "ПЛ") && 
                (couple3 == gcouple3) && 
                (couple4 == gcouple4)
                )
            {
                return true;
            }

            string[] sands = {"ПП","ПМ","ПС","ПГ","ГГ","ПК"};

            if (sands.Contains(couple1) && (couple1 == gcouple1) && (couple2 == gcouple2) && (couple3 == gcouple3))
            {
                return true;
            }

            if ((couple1 == "НГ" || couple1 == "ПР") && (couple1 == gcouple1))
            {
                return true;
            }

            return false;
        }

        public bool IsSand
        {
            get 
            {
                string[] sands = { "ПП", "ПМ", "ПС", "ПК", "ПГ", "ГГ", "ГА" };

                if (sands.Contains(this.GroundName.Substring(0, 2))) return true;

                return false;
            }
        }

        public bool IsClay
        {
            get
            {
                string[] clays = { "СП", "СГ", "ГЛ" };

                if (clays.Contains(this.GroundName.Substring(0, 2))) return true;

                return false;
            }
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }

    public class IgeItem : IEquatable<IgeItem>
    {
        /// <summary>
        /// Заторфованность
        /// </summary>
        [XmlIgnore]
        public AdmixtureType Admixture
        {
            get 
            {
                if (this.ByLab && this.labItem != null)
                {
                    return labItem.Admixture;
                }

                return AdmixtureType.Undefined;
            }
        }

        public bool IsBoring { get; set; }

        private string igeName;
        public string IgeName
        {
            get
            {
                return igeName;
            }
            set
            {
                igeName = value;
            }
        }

        /// <summary>
        /// Глубина пробы
        /// </summary>
        public double? LabDepth 
        {
            get
            {
                if (labItem != null)
                {
                    return labItem.Depth;
                }
                else return null;
            }
        }

        /// <summary>
        /// Показатель консистенции
        /// </summary>
        public double? IL
        {
            get
            {
                if (labItem != null)
                {
                    return labItem.Il;
                }
                else return null;
            }
        }

        public double? Wp
        {
            get
            {
                if (labItem != null)
                {
                    return labItem.Wp;
                }
                else return null;
            }
        }

        public double? Io
        {
            get 
            {
                if (labItem != null)
                {
                    return labItem.Iom;
                }
                else return null; 
            }
        }

        private int igeNum;
        /// <summary>
        /// Номер ИГЭ
        /// </summary>
        public int IgeNum { get { return igeNum; } set { igeNum = value; } }

        /// <summary>
        /// Номер выработки
        /// </summary>
        public string OutObjId { get; set; }

        /// <summary>
        /// Статическое зондирование
        /// </summary>
        public bool Static { get; set; }

        /// <summary>
        /// Динамическое зонидрование
        /// </summary>
        public bool Dynamic { get; set; }

        /// <summary>
        /// По лаборатории
        /// </summary>
        public bool ByLab { get; set; }

        /// <summary>
        /// Глина
        /// </summary>
        public bool IsClay
        {
            get
            {
                try
                {
                    string str = GroundName.Substring(0, 2);

                    if ((str == "СП") || (str == "СГ") || (str == "ГЛ")) return true;
                    else return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Песок
        /// </summary>
        public bool IsSand
        {
            get
            {
                try
                {
                    string str = GroundName.Substring(0, 2);

                    if ((str == "ПП") || (str == "ПМ") || (str == "ПС")
                        || (str == "ПК") || (str == "ПГ") || (str == "ГГ")) return true;
                    else return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        public double? ShareByWP { get; set; }

        /// <summary>
        /// Разеделять песчаные грунты 0 - грав. 1 - мелк. 2 - пыл.
        /// </summary>
        public bool?[] ShareOnDurability012 { get; set; }

        /// <summary>
        /// Разделители по Pд: 0 - грав. 1 - мелк. 2 - пыл.
        /// </summary>
        public double?[] ShareParamsPD012 { get; set; }

        /// <summary>
        /// Разделители по Qc: 0 - грав. 1 - мелк. 2 - пыл. 3 - пыл. водонасыщ.
        /// </summary>
        public double?[] ShareParamsQC0123 { get; set; }

        /// <summary>
        /// Показатель динамического зонирования Pд
        /// </summary>
        public double? Pd { get; set; }

        /// <summary>
        /// Показатель статического зондирования Qc
        /// </summary>
        public double? QC { get; set; }

        /// <summary>
        /// Начальная глубина
        /// </summary>
        public double D1 { get; set; }

        /// <summary>
        /// Конечная глубина
        /// </summary>
        public double D2 { get; set; }

        /// <summary>
        /// Глубина грунтовых вод
        /// </summary>
        public double? WaterDepth { get; set; }

        /// <summary>
        /// Параметры прочности по пылеватым глинистым грунтам
        /// </summary>
        public double[] StrengthParams { get; set; }

        private DurabilityType durability;
        /// <summary>
        /// Прочность
        /// </summary>
        public DurabilityType Durability
        {
            get { return durability; }
            set { durability = value; }
        }

        /// <summary>
        /// Лабораторный образец
        /// </summary>
        public ResultTable labItem { get; set; }

        public string LabItemNum 
        {
            get 
            {
                if (labItem != null)
                    return labItem.Test;
                else return "";
            }
        }

        private string groundName;
        /// <summary>
        /// Наименование грунта (изначальное)
        /// </summary>
        public string GroundName
        {
            get { return groundName; }
            set { groundName = value; }
        }

        private string finalName;
        /// <summary>
        /// Наименование грунта (последнее)
        /// </summary>
        public string FinalName 
        {
            get
            {
                igeName = Couple1 + Couple2 + Couple3 + Couple4 + Couple5;
                return finalName;
            }
            set { finalName = value; }
        }

        /// <summary>
        /// Тип грунта 
        /// </summary>
        public string Couple1
        {
            get
            {
                string result = "";

                result = GroundName.Substring(0, 2);

                return result;
            }
        }

        /// <summary>
        /// Грубый, пылеватый, водонасыщенный, маловлажный
        /// </summary>
        public string Couple2
        {
            get
            {
                string result = "";

                if (ByLab && labItem != null && ShareByWP != null)
                {
                    if (IsClay)
                    {
                        if (labItem.Wp <= ShareByWP)
                            result = "ГР";
                        else if (labItem.Wp > ShareByWP)
                            result = "ПЛ";
                    }
                }
                else
                {
                    try
                    {
                        result = GroundName.Substring(2, 2);
                    }
                    catch (ArgumentOutOfRangeException) { result = "__"; }
                }

                if (Couple1 == "ГЛ") result = "ПЛ";

                if (IsSand)
                {
                    if ((WaterDepth != null) && (D2 > WaterDepth))
                    {
                        result = "ВН";
                    }
                    else result = "МВ";
                }

                if (Couple1 == "ПР") result = "C";
                if (Couple1 == "НГ") result = "";

                if (Couple1 == "ТО") result = "РФ";

                return result;
            }
        }

        /// <summary>
        /// Консистенция для глинистых грунтов
        /// </summary>
        public string Couple3
        {
            get
            {
                string result = "";

                // ?????????????????????????????????

                if (ByLab)
                {
                    if (IsClay)
                    {
                        try { result = GroundName.Substring(2, 2); }
                        catch (ArgumentOutOfRangeException) { result = "__"; }
                    }
                }
                else
                {
                    if (IsClay)
                    {
                        try { result = GroundName.Substring(4, 2); }
                        catch (ArgumentOutOfRangeException) { result = "__"; }
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Прочность
        /// </summary>
        public string Couple4
        {
            get
            {
                string result = "";

                switch (Durability)
                {
                    case DurabilityType.WeakStrength:
                        {
                            if (this.IsSand) result = "МП";
                            else result = "СЛ";
                            break;
                        }
                    case DurabilityType.MediumStrength:
                        {
                            result = "СП";
                            break;
                        }
                    case DurabilityType.MoreStrength:
                        {
                            result = "БП";
                            break;
                        }
                    case DurabilityType.Strength:
                        {
                            result = "ПР";
                            break;
                        }
                    case DurabilityType.VeryStrength:
                        {
                            result = "ОП";
                            break;
                        }
                    case DurabilityType.Undefined:
                        {
                            result = "";
                            break;
                        }
                }

                return result;
            }
        }

        /// <summary>
        /// Примесь растительных остатков
        /// </summary>
        public string Couple5
        {
            get
            {
                switch (Admixture)
                {
                    case AdmixtureType.Undefined:
                        {
                            return "";
                        }
                    case AdmixtureType.OV:
                        {
                            return "";
                        }
                    case AdmixtureType.Low:
                        {
                            return "02";
                        }
                    case AdmixtureType.Medium:
                        {
                            return "03";
                        }
                    case AdmixtureType.High:
                        {
                            return "04";
                        }
                }

                return "";
            }
        }

        public string StrDurability
        {
            get
            {
                switch (Durability)
                {
                    case DurabilityType.WeakStrength:
                        {
                            string str = "";
                            if (IsSand)
                            {
                                str = "Малопрочный";
                            }
                            else
                                if (IsClay)
                                {
                                    str = "Слабый";
                                }
                            return str;
                        }
                    case DurabilityType.MediumStrength:
                        {
                            return "Средней прочности";
                        }
                    case DurabilityType.Strength:
                        {
                            return "Прочный";
                        }
                    case DurabilityType.VeryStrength:
                        {
                            return "Очень прочный";
                        }
                    case DurabilityType.MoreStrength:
                        {
                            return "Более прочный";
                        }
                    default:
                        {
                            return "Не определено";
                        }
                }
            }
        }

        public bool Equals(IgeItem other)
        {
            if (Object.ReferenceEquals(other, null)) return false;

            if (Object.ReferenceEquals(this, other)) return true;

            return D1.Equals(other.D1) && D2.Equals(other.D2) && OutObjId.Equals(other.OutObjId);
        }

        public override int GetHashCode()
        {
            int hashIgeItemD1 = this.D1.GetHashCode();
            int hashIgeItemD2 = this.D2.GetHashCode();
            int hashIgeItemOutObjId = this.OutObjId == null ? 0 : this.OutObjId.GetHashCode();

            return hashIgeItemD1 ^ hashIgeItemD2 ^ hashIgeItemOutObjId;
        }
    }
}
