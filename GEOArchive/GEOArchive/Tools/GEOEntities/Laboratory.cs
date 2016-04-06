using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEOArchive.Tools.GEOTools;
using System.Xml.Serialization;
using System.ComponentModel;

namespace GEOArchive.Tools.GEOEntities
{
    public class LabObject
    {
        public LabObject() { }

        public string Id { get; set; }
        public string Name { get; set; }
        public string DoerName { get; set; }
        public string DoerPosit { get; set; }
        public string CheckerName { get; set; }
        public string CheckerPosit { get; set; }

        public List<ParamzTable> Items { get; set; }

        public List<ResultTable> ResultItems
        {
            get
            {
                List<ResultTable> result = new List<ResultTable>();

                foreach (ParamzTable pt in this.Items)
                {
                    result.Add(CalcManager.getInstance().CalcResItem(pt));
                }

                return result;
            }
        }
    }

    public class ParamzTable
    {
        protected int cId, type;
        protected string obj, id, test;
        protected double depth,
            wet, wetdry, wetbux,
            roll, rolldry, rolljar,
            weight01, weight025, weight05, weight2, weight,
            liqujar, liqudry, liqu,
            calcto, calcafter, calck,
            ringweight, ringsize;

        protected double? p1, w01, w025, w05, w1, w2, w5, w10, w10_;
        protected string t;

        public double? P1 { get { return p1; } set { p1 = value; } }
        public string T { get { return t; } set { t = value; } }

        public double? W01 { get { return w01; } set { w01 = value; } }
        public double? W025 { get { return w025; } set { w025 = value; } }
        public double? W05 { get { return w05; } set { w05 = value; } }
        public double? W1 { get { return w1; } set { w1 = value; } }
        public double? W2 { get { return w2; } set { w2 = value; } }
        public double? W5 { get { return w5; } set { w5 = value; } }
        public double? W10 { get { return w10; } set { w10 = value; } }     

        /// <summary>
        /// Порядковый номер
        /// </summary>
        public int CId { get { return cId; } set { cId = value; } }
        
        /// <summary>
        /// Номер лабраторной таблицы
        /// </summary>
        public string Obj { get { return obj; } set { obj = value; } }
        
        
        /// <summary>
        /// Тип грунта
        /// </summary>
        public int Type { get { return type; } set { type = value; } }

        
        /// <summary>
        /// Номер выработки
        /// </summary>
        public string Id { get { return id; } set { id = value; } }

        
        /// <summary>
        /// Глубина пробы
        /// </summary>
        public double Depth { get { return depth; } set { depth = value; } }

        
        /// <summary>
        /// Номер образца
        /// </summary>
        public string Test { get { return test; } set { test = value; } }


        //*****************************************************
        //*****ВЛАЖНОСТЬ*****

        
        /// <summary>
        /// Естесственная влажность
        /// </summary>
        public double Wet { get { return wet; } set { wet = value; } }

        
        /// <summary>
        /// Параметр "сухой" влажности
        /// </summary>
        public double WetDry { get { return wetdry; } set { wetdry = value; } }

        
        /// <summary>
        /// Параметр "бюкс" влажности
        /// </summary>
        public double WetBux { get { return wetbux; } set { wetbux = value; } }


        //*****************************************************
        //*****РАСКАТЫВАНИЕ*****
        

        
        /// <summary>
        /// Предел раскатывания
        /// </summary>
        public double Roll { get { return roll; } set { roll = value; } }

        
        /// <summary>
        /// Параметр "сухой" раскатывания
        /// </summary>
        public double RollDry { get { return rolldry; } set { rolldry = value; } }

        
        /// <summary>
        /// Параметр "банка" раскатывания
        /// </summary>
        public double RollJar { get { return rolljar; } set { rolljar = value; } }


        //*****************************************************
        //*****ГРАН. СОСТАВ*****


        
        /// <summary>
        /// Общий вес
        /// </summary>
        public double Weight { get { return weight; } set { weight = value; } }

        
        /// <summary>
        /// Вес >2mm
        /// </summary>
        public double Weight2 { get { return weight2; } set { weight2 = value; } }

        
        /// <summary>
        /// Вес >0.5mm
        /// </summary>
        public double Weight05 { get { return weight05; } set { weight05 = value; } }

        
        /// <summary>
        /// Вес >0,25mm
        /// </summary>
        public double Weight025 { get { return weight025; } set { weight025 = value; } }

        
        /// <summary>
        /// Вес >0,1mm
        /// </summary>
        public double Weight01 { get { return weight01; } set { weight01 = value; } }


        //*****************************************************
        //*****ТЕКУЧЕСТЬ*****


        /// <summary>
        /// Предел текучести
        /// </summary>
        public double Liqu { get { return liqu; } set { liqu = value; } }

        
        /// <summary>
        /// Параметр "сухой" текучести
        /// </summary>
        public double LiquDry { get { return liqudry; } set { liqudry = value; } }

        
        /// <summary>
        /// Параметр "банка" текучести
        /// </summary>
        public double LiquJar { get { return liqujar; } set { liqujar = value; } }


        //*****************************************************
        //*****ПРОКАЛИВАНИЕ*****
        // до прокаливания

        
        /// <summary>
        /// До прокаливания
        /// </summary>
        public double CalcTo { get { return calcto; } set { calcto = value; } }


        
        /// <summary>
        /// После прокаливания
        /// </summary>
        public double CalcAfter { get { return calcafter; } set { calcafter = value; } }


        /// <summary>
        /// Коэффицент прокаливания
        /// </summary>
        public double CalcK { get { return calck; } set { calck = value; } }


        //*****************************************************
        //*****КОЛЬЦО*****
        
        /// <summary>
        /// Вес кольца
        /// </summary>
        public double RingWeight { get { return ringweight; } set { ringweight = value; } }
        

        /// <summary>
        /// Объем кольца
        /// </summary>
        public double RingSize { get { return ringsize; } set { ringsize = value; } }
        //*****************************************************


        public override string ToString()
        {
            return test + "(" + cId.ToString() + ")";
        }
    }

    public class ResultTable : IEquatable<ResultTable>
    {
        [DefaultValue(false)]
        public bool CantUse { get; set; }

        protected int igeNum, cId, type;
        protected string obj, id, test, name, t;
        protected double depth;
        protected double? il, natureWet, sr, ys, y, n, e, wl, wp, ip, iom, pd, p1, mmNaN_10, mm10_5, mm5_2, mm2_1, mm1_05, mm05_025, mm025_01, mm01_NaN;

        [XmlIgnore]
        public List<double> Tarr
        {
            get
            {
                string[] tarr = T.Split(' ');
                List<double> result = new List<double>();

                for (int i = 0; i < tarr.Length; i++)
                {
                    double res;

                    res = double.Parse(tarr[i].Replace('.',','));
                    //bool parsed = double.TryParse(tarr[i].Replace(',','.'), out res);

                    //if (parsed)
                    result.Add(res);
                }

                return result;
            }
        }

        CalcManager calcManager = CalcManager.getInstance();

        /// <summary>
        /// >10mm
        /// </summary>
        public double? MmNaN_10 { get { return mmNaN_10; } set { mmNaN_10 = value; } }
        /// <summary>
        /// 10-5mm
        /// </summary>
        public double? Mm10_5 { get { return mm10_5; } set { mm10_5 = value; } }
        /// <summary>
        /// 5-2mm
        /// </summary>
        public double? Mm5_2 { get { return mm5_2; } set { mm5_2 = value; } }
        /// <summary>
        /// 2-1mm
        /// </summary>
        public double? Mm2_1 { get { return mm2_1; } set { mm2_1 = value; } }
        /// <summary>
        /// 1-0.5mm
        /// </summary>
        public double? Mm1_05 { get { return mm1_05; } set { mm1_05 = value; } }
        /// <summary>
        /// 0.5-0.25mm
        /// </summary>
        public double? Mm05_025 { get { return mm05_025; } set { mm05_025 = value; } }
        /// <summary>
        /// 0.25-0.1mm
        /// </summary>
        public double? Mm025_01 { get { return mm025_01; } set { mm025_01 = value; } }
        /// <summary>
        /// <0.1mm
        /// </summary>
        public double? Mm01_NaN { get { return mm01_NaN; } set { mm01_NaN = value; } }
        /// <summary>
        /// Номер ИГЭ
        /// </summary>
        public int IgeNum { get { return igeNum; } set { igeNum = value; } }
        /// <summary>
        /// Порядковый номер
        /// </summary>
        public int CId { get { return cId; } set { cId = value; } }
        /// <summary>
        /// № таблицы
        /// </summary>
        public string Obj { get { return obj; } set { obj = value; } }
        /// <summary>
        /// Тип грунта {1 - глин,2 - песч}
        /// </summary>
        public int Type { get { return type; } set { type = value; } }
        /// <summary>
        /// № Выработки
        /// </summary>
        public string Id { get { return id; } set { id = value; } }
        /// <summary>
        /// Глубина
        /// </summary>
        public double Depth { get { return Math.Round(depth, 2); } set { depth = Math.Round(value, 2); } }
        /// <summary>
        /// № образца
        /// </summary>
        public string Test { get { return test; } set { test = value; } }
        /// <summary>
        /// Наименование грунта (аббревиатура)
        /// </summary>
        public string Name { get { if (Iom >= 0.5D) name = "ТОРФ"; return name; } set { name = value; } }
        /// <summary>
        /// Полное наименование грунта
        /// </summary>
        public string FullName
        {
            get
            {
                string result = calcManager.ReturnFullGroundNameForReport(this.name, this.type);

                switch (Note)
                {
                    case "СЛТФ": 
                        {
                            result += " слабозат.";
                            break;
                        }
                    case "СРТФ":
                        {
                            result += " среднезат.";
                            break;
                        }
                    case "СНТФ":
                        {
                            result += " сильнозат.";
                            break;
                        }
                    case "ОВ":
                        {
                            result += " с прим. орг. в-ва";
                            break;
                        }
                }

                if (Iom >= 0.5D)
                    result = "ТОРФ";

                return result;
            }
        }
        /// <summary>
        /// Природная влажность W %
        /// </summary>
        public double? NatureWet { get { return natureWet; } set { natureWet = value; } }
        /// <summary>
        /// Степень влажности Sr
        /// </summary>
        public double? Sr { get { return sr; }  set { sr = value; } }
        /// <summary>
        /// Ys
        /// </summary>
        public double? Ys { get { return ys; } set { ys = value; } }
        /// <summary>
        /// Плотность грунта Y
        /// </summary>
        public double? Y { get { return y; } set { y = value; } }
        /// <summary>
        /// Пористость N %
        /// </summary>
        public double? N {  get { return n; } set { n = value; } }
        /// <summary>
        /// Коэффициент пористости E
        /// </summary>
        public double? E { get { return e; } set { e = value; } }
        /// <summary>
        /// Влажность на уровне текучести WL %
        /// </summary>
        public double? Wl { get { return wl; } set { wl = value; } }      
        /// <summary>
        /// Влажность на уровне раскатывания WP %
        /// </summary>
        public double? Wp { get { return wp; } set { wp = value; } }
        /// <summary>
        /// Число пластичности IP
        /// </summary>
        public double? Ip { get { return ip; } set { ip = value; } }
        /// <summary>
        /// IOM %
        /// </summary>
        public double? Iom { get { return iom; } set { iom = value; } }
        /// <summary>
        /// Pd г/см3
        /// </summary>
        public double? Pd { get { return pd; } set { pd = value; } }
        /// <summary>
        /// Консестенция IL
        /// </summary>
        public double? Il { get { return il; } set { il = value; } }
        /// <summary>
        /// P кгс/см2
        /// </summary>
        public double? P1 { get { return p1; } set { p1 = value; } }
        /// <summary>
        /// t кгс/см2
        /// </summary>
        public string T { get { return t; } set { t = value; } }
        /// <summary>
        /// Примечание
        /// </summary>
        public string Note 
        {
            get 
            {
                string result = "";

                switch (type)
                {
                    case 1:
                        {
                            if ((iom > 0.05) && (iom <= 0.1))
                            {
                                result = "ОВ";
                            }
                            break;
                        }
                    case 2:
                        {
                            if ((iom > 0.03) && (iom <= 0.1))
                            {
                                result = "ОВ";
                            }
                            break;
                        }
                }

                if (iom > 0.1)
                {
                    if ((iom > 0.1) && (iom <= 0.25))
                    {
                        result = "СЛТФ";
                    }
                    if ((iom > 0.25) && (iom <= 0.4))
                    {
                        result = "СРТФ";
                    }
                    if ((iom > 0.4) && (iom < 0.5))
                    {
                        result = "СНТФ";
                    }
                }

                return result;
            }
        }
        /// <summary>
        /// Заторфованность
        /// </summary>
        [XmlIgnore]
        public AdmixtureType Admixture
        {
            get
            {
                switch (Note)
                {
                    case "ОВ":
                        {
                            return AdmixtureType.OV;
                        }
                    case "СЛТФ":
                        {
                            return AdmixtureType.Low;
                        }
                    case "СРТФ":
                        {
                            return AdmixtureType.Medium;
                        }
                    case "СНТФ":
                        {
                            return AdmixtureType.High;
                        }
                    default:
                        {
                            return AdmixtureType.Undefined;
                        }
                }
            }
        }

        public override string ToString()
        {
            return Test + "   " + Depth + "(м)   " + Name + " " + Note;
        }

        public bool Equals(ResultTable other)
        {
            if (Object.ReferenceEquals(other, null)) return false;

            if (Object.ReferenceEquals(this, other)) return true;

            return Depth.Equals(other.Depth) && Test.Equals(other.Test);
        }

        public override int GetHashCode()
        {
            int hashRTItemDepth = this.Depth.GetHashCode();
            int hashRTItemTest = this.Test.GetHashCode();

            return hashRTItemDepth ^ hashRTItemTest;
        }         
    }

    /// <summary>
    /// Примесь органического вещества
    /// </summary>
    public enum AdmixtureType
    {
        /// <summary>
        /// Не определено
        /// </summary>
        [XmlEnum(Name = "Undefined")]
        Undefined = 0,
        /// <summary>
        /// Органическое в-во
        /// </summary>
        [XmlEnum(Name = "OV")]
        OV = 1,
        /// <summary>
        /// Слабозаторфованное
        /// </summary>
        [XmlEnum(Name = "Low")]
        Low = 2,
        /// <summary>
        /// Среднезаторфованное
        /// </summary>
        [XmlEnum(Name = "Medium")]
        Medium = 3,
        /// <summary>
        /// Сильнозаторфованное
        /// </summary>
        [XmlEnum(Name = "High")]
        High = 4
    }
}
