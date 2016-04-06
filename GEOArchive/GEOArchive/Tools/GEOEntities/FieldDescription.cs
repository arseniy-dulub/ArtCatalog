using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel;

namespace GEOArchive.Tools.GEOEntities
{
    [XmlRootAttribute("GeoObject", Namespace="http://www.cpandl.com",IsNullable = false)]
    public class GeoObject
    {
        private String id;
        private String name;
        private DateTime dateCreate;
        private List<Section> sections;
        private List<OutObject> outObjects;
        private List<Coord> coords;        

        public List<Section> Sections
        {
            get { return sections; }
            set { sections = value; }
        }

        public List<Coord> Coords
        {
            get { return coords; }
            set { coords = value; }
        }

        public List<OutObject> OutObjects
        {
            get
            {
                return outObjects;
            }
            set 
            {
                outObjects = value;
            }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string DoerName { get; set; }
        public string DoerPosit { get; set; }
        public string CheckerName { get; set; }
        public string CheckerPosit { get; set; }

        public DateTime DateCreate
        {
            get { return dateCreate; }
            set { dateCreate = value; }
        }

        public GeoObject() { }

        override public String ToString()
        {
            return id;
        }
    }
    
    /// <summary>
    /// Глубина отбора, тип грунта, описание
    /// </summary>
    public class DepthGround
    {
        public double D1 { get; set; }
        public double Depth { get; set; }
        public string DGround { get; set; }       

        public override string ToString()
        {
            return D1 + " - " + Depth + "(м)     " + DGround;
        }
    }
    
    /// <summary>
    /// Глубина, дата отбора проб воды
    /// </summary>
    public class DepthWater
    {
        private double depth; 
        private string date;

        public double Depth { get { return depth; } set { depth = value; } }
        public string Date { get { return date; } set { date = value; } }

        public override string ToString()
        {
            return depth.ToString();
        }
    }

    public class OutObject
    {
        public OutObject()
        {
            if (StartD == 0)
            {
                this.StartD = 0.6D;
            }
            if (StepD == 0)
            {
                this.StepD = 0.2D;
            }
        }

        public bool IsIntermediateProbe()
        {
            if (this.DepthGround.Count <= 0)
            {
                return true;
            }
            else if (this.DepthGround.Count == 1)
            {
                if (this.DepthGround[0].Depth == 0.0 || this.DepthGround[0].DGround == "")
                {
                    return true;
                }
                return false;
            }
            else if (this.DepthGround.Count > 1) return false;

            return false;
        }

        public string BoreType { get; set; }

        private List<DepthGround> depthGround;

        private List<DynamicProbe> dynamicProbes;

        private List<StaticProbe> staticProbes;

        private List<ProbePlace> probePlaces;

        /// <summary>
        /// Номер выработки
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Полевое описание
        /// </summary>
        public List<DepthGround> DepthGround 
        {
            get 
            {
                if (depthGround != null)
                {
                    depthGround = depthGround.OrderBy(key => key.Depth).ToList();

                    for (int i = 0; i < depthGround.Count; i++)
                    {
                        if (i != 0)
                        {
                            depthGround[i].D1 = depthGround[i - 1].Depth;
                        }
                        else if (i == 0)
                        {
                            depthGround[i].D1 = 0;
                        }
                    }
                }
                return depthGround;
            } 
            set 
            { 
                depthGround = value;
            }
        }

        /// <summary>
        /// Замеры грунтовых вод
        /// </summary>
        public List<DepthWater> Water { get; set; }

        /// <summary>
        /// Динамическое зондирование
        /// </summary>
        public List<DynamicProbe> DynamicProbes
        {
            get
            {
                if (dynamicProbes != null)
                {
                    dynamicProbes = dynamicProbes.OrderBy(key => key.Depth).ToList();

                    for (int i = 0; i < dynamicProbes.Count; i++)
                    {
                        if (i != 0)
                        {
                            dynamicProbes[i].D1 = dynamicProbes[i - 1].Depth;
                        }
                        else if (i == 0)
                        {
                            // Начальная глубина по дин. зонлированию - 0.5м = 5дм
                            dynamicProbes[i].D1 = 5;
                        }
                    }
                }
                return dynamicProbes;
            } 
            set
            {
                dynamicProbes = value; 
            } 
        }
        
        /// <summary>
        /// Статическое зондирование
        /// </summary>
        public List<StaticProbe> StaticProbes 
        {
            get
            {
                if (staticProbes != null)
                {
                    staticProbes = staticProbes.OrderBy(key => key.Depth).ToList();

                    for (int i = 0; i < staticProbes.Count; i++)
                    {
                        if (i != 0)
                        {
                            staticProbes[i].D1 = staticProbes[i - 1].Depth;
                        }
                        else if (i == 0)
                        {
                            staticProbes[i].D1 = (double)this.StartD;
                        }
                    }
                }
                return staticProbes;
            }
            set
            {
                staticProbes = value;
            }  
        }

        /// <summary>
        /// Места предполагаемого отбора проб
        /// </summary>
        public List<ProbePlace> ProbePlaces { get { return probePlaces; } set { probePlaces = value; } }

        /// <summary>
        /// Начальная глубина статического зондирования
        /// </summary>
        [DefaultValue(0.6D)]
        public double StartD { get; set; }

        /// <summary>
        /// Шаг статического зондирования
        /// </summary>
        [DefaultValue(0.2D)]
        public double StepD { get; set; }

        private string maxCone, maxMuff;

        /// <summary>
        /// Максимальное услие для конуса зонда
        /// </summary>
        public string MaxCone
        {
            get
            {
                if (maxCone == null)
                {
                    maxCone = "";
                }
                return maxCone;
            }
            set { maxCone = value; }
        }

        /// <summary>
        /// Максимальное усилие для муфты зонда
        /// </summary>
        public string MaxMuff
        {
            get
            {
                if (maxMuff == null)
                {
                    maxMuff = "";
                }
                return maxMuff;
            }
            set { maxMuff = value; }
        }

        public override string ToString()
        {
            return Id;
        }

        private ProbeSetting _probeSetting;

        public ProbeSetting ProbeSetting 
        {
            get
            {
                try
                {
                    return _probeSetting;
                }
                catch { return ProbeSetting.Medium; }
            }
            set
            {
                _probeSetting = value;
            }
        }
    }

    public class DynamicProbe 
    {
        private int? igeNum;

        public int? IgeNum { get { return igeNum; } set { igeNum = value; } }

        [DefaultValue(false)]
        public bool IsBoring { get; set; }

        private double d1, depth, strikeCount;

        public double D1
        {
            get { return d1; }
            set { d1 = value; }
        }

        /// <summary>
        /// Глубина
        /// </summary>
        public double Depth
        {
            get { return depth; }
            set { depth = value; }
        }

        /// <summary>
        /// Число ударов
        /// </summary>
        public double StrikeCount
        {
            get { return strikeCount; }
            set { strikeCount = value; }
        }

        private ProbeSetting _probeSetting;

        public ProbeSetting ProbeSetting
        {
            get
            {
                try
                {
                    return _probeSetting;
                }
                catch { return ProbeSetting.Medium; }
            }
            set
            {
                _probeSetting = value;
            }
        }

        public double K1
        {
            get
            {
                double result = 0;

                switch (ProbeSetting)
                {
                    case ProbeSetting.Light:
                        {
                            result = GetK1Value(0, depth);
                            break;
                        }
                    case ProbeSetting.Medium:
                        {
                            result = GetK1Value(1, depth);
                            break;
                        }
                    case ProbeSetting.Heavy:
                        {
                            result = GetK1Value(2, depth);
                            break;
                        }
                }

                return result;
            }
        }

        private double[,] K1Table = new double[3, 6] { 
        { 0.49, 0.43, 0.37, 0.32, 0.28, 0.25 }, 
        { 0.62, 0.56, 0.48, 0.42, 0.37, 0.34 }, 
        { 0.72, 0.64, 0.57, 0.51, 0.46, 0.42 } };

        private double GetK1Value(int setting, double depth)
        {
            double result = 0;

            double depth_ = depth / 10;

            if ((depth_ > 0D) && (depth_ <= 1.5D))
            {
                result = K1Table[setting, 0];
            }
            if ((depth_ > 1.5D) && (depth_ <= 4.0D))
            {
                result = K1Table[setting, 1];
            }
            if ((depth_ > 4.0D) && (depth_ <= 8.0D))
            {
                result = K1Table[setting, 2];
            }
            if ((depth_ > 8.0D) && (depth_ <= 12.0D))
            {
                result = K1Table[setting, 3];
            }
            if ((depth_ > 12.0D) && (depth_ <= 16.0D))
            {
                result = K1Table[setting, 4];
            }
            if (depth_ > 16.0D)
            {
                result = K1Table[setting, 5];
            }

            return result;
        }

        /// <summary>
        /// Коэффициент учета потерь энергии при трении
        /// </summary>
        public double K2
        {
            get
            {
                double result = 0F;

                double depth_ = this.depth / 10;

                if ((depth_ >= 0.5F) && (depth_ <= 1.5F))
                {
                    result = 1.0F;
                }
                if ((depth_ > 1.5F) && (depth_ <= 4.0F))
                {
                    result = 0.875F;
                }
                if ((depth_ > 4.0F) && (depth_ <= 8.0F))
                {
                    result = 0.795F;
                }
                if ((depth_ > 8.0F) && (depth_ <= 12.0F))
                {
                    result = 0.715F;
                }
                if ((depth_ > 12.0F) && (depth_ <= 16.0F))
                {
                    result = 0.635F;
                }
                if (depth_ > 16.0F)
                {
                    result = 0.55F;
                }

                return result;
            }
        }

        public int A
        {
            get
            {
                switch (ProbeSetting)
                {
                    case ProbeSetting.Undefined:
                        {
                            return 1120;
                        }
                    case ProbeSetting.Light:
                        {
                            return 280;
                        }
                    case ProbeSetting.Medium:
                        {
                            return 1120;
                        }
                    case ProbeSetting.Heavy:
                        {
                            return 2800;
                        }
                    default:
                        {
                            return 1120;
                        }
                }
            }
        }

        private const int H = 10;

        private double pd;

        /// <summary>
        /// Условное динамическое сопротивление грунта
        /// </summary>
        public double Pd
        {
            get
            {
                this.pd = ((A * K1 * K2 * StrikeCount) / (100 * H));

                return pd;
            }
        }

        public double StatPd { get; set; }

        public DurabilityType Durability
        {
            get
            {
                DurabilityType d = DurabilityType.WeakStrength;

                if (Pd > 8.3D)
                {
                    d = DurabilityType.VeryStrength;
                }
                else if ((Pd > 2.8D) && (Pd <= 8.3D))
                {
                    d = DurabilityType.Strength;
                }
                else if ((Pd >= 1.2D) && (Pd <= 2.8D))
                {
                    d = DurabilityType.MediumStrength;
                }
                else if (Pd < 1.2D)
                {
                    d = DurabilityType.WeakStrength;
                }

                return d;
            }
        }

        public override string ToString()
        {
            return depth + "(дм)     " + Pd;
        }

        /// <summary>
        /// Попадает в диапазон d1-d2
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public bool IsOnDiap(double d1, double d2)
        {
            #region scared
            #region VERY SCARED D:
            // V
            if (Math.Round(this.depth / 10, 1) <= d1)
                return false;
            // V
            else if (Math.Round(this.d1 / 10, 1) >= d2)
                return false;
            // V
            else if (Math.Round(this.depth / 10, 1) > d1 && Math.Round(this.depth / 10, 1) <= d2)
                return true;
            // V
            else if (Math.Round(this.d1 / 10, 1) >= d1 && Math.Round(this.d1 / 10, 1) <= d2)
                return true;
            // V
            else if (Math.Round(this.d1 / 10, 1) == d1 && Math.Round(this.depth / 10, 1) == d2)
                return true;
            // V
            else if (Math.Round(this.d1 / 10, 1) <= d1 && Math.Round(this.depth / 10, 1) >= d2)
                return true;
            // V
            else if (Math.Round(this.d1 / 10, 1) < d1 && Math.Round(this.depth / 10, 1) > d2)
                return true;
            // V
            else if ((Math.Round(this.d1 / 10, 1) >= d1 && Math.Round(this.d1 / 10, 1) < d2) && ((Math.Round(this.depth / 10, 1) >= d2)))
                return true;
            // V
            else if (Math.Round(this.d1 / 10, 1) == d1 && Math.Round(this.depth / 10, 1) <= d2)
                return true;
            else return false;
            #endregion
            #endregion
        }
    }

    public class StaticProbe 
    {
        [DefaultValue(false)]
        public bool IsBoring { get; set; }

        private int counter;

        public int Counter { get { return counter; } set { counter = value; } }

        private int? igeNum;

        public int? IgeNum { get { return igeNum; } set { igeNum = value; } }

        private double d1, depth, cone, muff;

        public double D1 { get { return d1; } set { d1 = value; } }

        /// <summary>
        /// Глубина
        /// </summary>
        public double Depth { get { return depth; } set { depth = value; } }

        /// <summary>
        /// Отсчет по конусу
        /// </summary>
        public double Cone { get { return cone; } set { cone = value; } }

        /// <summary>
        /// Отсчет по муфте
        /// </summary>
        public double Muff { get { return muff; } set { muff = value; } }

        private double qc;

        public double QC
        {
            get
            {
                qc = 0D;
                try
                {
                    qc = (15D / 250D) * this.cone;
                }
                catch { }
                return Math.Round(qc, 2);
            }
        }

        public double StatQc { get; set; }

        public double FZ
        {
            get
            {
                double result = 0D;
                try
                {
                    result = ((10D * 10000D) / (350D * 250D)) * this.muff;
                }
                catch { }
                return Math.Round(result, 2);
            }
        }

        public DurabilityType Durability
        {
            get
            {
                DurabilityType d = DurabilityType.WeakStrength;

                if (QC > 6.5D)
                {
                    d = DurabilityType.VeryStrength;
                }
                else if ((QC > 2.5D) && (QC <= 6.5D))
                {
                    d = DurabilityType.Strength;
                }
                else if ((QC >= 1D) && (QC <= 2.5D))
                {
                    d = DurabilityType.MediumStrength;
                }
                else if (QC < 1D)
                {
                    d = DurabilityType.WeakStrength;
                }

                return d;
            }
        }

        /// <summary>
        /// Попадает в диапазон d1-d2
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public bool IsOnDiap(double d1, double d2)
        {
            #region scared
            #region VERY SCARED D:
            // V
            if (this.depth <= d1)
                return false;
            // V
            else if (this.d1 >= d2)
                return false;
            // V
            else if (this.depth > d1 && this.depth <= d2)
                return true;
            // V
            else if (this.d1 >= d1 && this.d1 <= d2)
                return true;
            // V
            else if (this.d1 == d1 && this.depth == d2)
                return true;
            // V
            else if (this.d1 <= d1 && this.depth >= d2)
                return true;
            // V
            else if (this.d1 < d1 && this.depth > d2)
                return true;
            // V
            else if ((this.d1 >= d1 && this.d1 < d2) && (this.depth >= d2))
                return true;
            // V
            else if (this.d1 == d1 && this.depth <= d2)
                return true;
            else return false;
            #endregion
            #endregion
        }

        public override string ToString()
        {
            return depth + "(м)     " + QC;
        }
    }

    /// <summary>
    /// Прочность
    /// </summary>
    public enum DurabilityType 
    {
        /// <summary>
        /// Не определено
        /// </summary>
        [XmlEnum(Name = "Undefined")]
        Undefined = 0,
        /// <summary>
        /// Слабопрочный
        /// </summary>
        [XmlEnum(Name = "WeakStrength")]
        WeakStrength = 1,
        /// <summary>
        /// Средней прочности
        /// </summary>
        [XmlEnum(Name = "MediumStrength")]
        MediumStrength = 2,
        /// <summary>
        /// Прочный
        /// </summary>
        [XmlEnum(Name = "Strength")]
        Strength = 3,
        /// <summary>
        /// Очень прочный
        /// </summary>
        [XmlEnum(Name = "VeryStrength")]
        VeryStrength = 4,
        /// <summary>
        /// "Более прочный", чем средней прочности (для разделения песчаных грунтов)
        /// </summary>
        [XmlEnum(Name = "MoreStrength")]
        MoreStrength = 5,
        /// <summary>
        /// Слабопрочная
        /// </summary>
        [XmlEnum(Name = "WeakStrength2")]
        WeakStrength2 = 1,
        /// <summary>
        /// Слабопрочная
        /// </summary>
        [XmlEnum(Name = "WeakStrength3")]
        WeakStrength3 = 1,
        /// <summary>
        /// Средней прочности
        /// </summary>
        [XmlEnum(Name = "MediumStrength2")]
        MediumStrength2 = 2,
        /// <summary>
        /// Прочный
        /// </summary>
        [XmlEnum(Name = "Strength2")]
        Strength2 = 3,
        /// <summary>
        /// Очень прочный
        /// </summary>
        [XmlEnum(Name = "VeryStrength2")]
        VeryStrength2 = 4,
        /// <summary>
        /// "Более прочный", чем средней прочности (для разделения песчаных грунтов)
        /// </summary>
        [XmlEnum(Name = "MoreStrength2")]
        MoreStrength2 = 5
    }

    public class Section 
    {
        private string id;
        private List<OutDist> outDists;

        public string Id { get { return id; } set { id = value; } }

        public List<OutDist> OutDists { get { return outDists; } set { outDists = value; } }

        public override string ToString()
        {
            return id;
        }
    }

    public class OutDist 
    {
        private string id;
        private double dist;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public double Dist
        {
            get { return dist; }
            set { dist = value; }
        }
    }

    public class Coord
    {
        public string BoreType
        {
            get;
            set;
        }

        private string id;
        private double seaLevel;
        private double x, y;
        public string Id { get { return id; } set { id = value; } }
        public double SeaLevel { get { return seaLevel; } set { seaLevel = value; } }
        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }

        public override string ToString()
        {
            return id;
        }
    }

    /// <summary>
    /// Место отбора пробы
    /// </summary>
    public class ProbePlace
    {
        /// <summary>
        /// Глубина отбора
        /// </summary>
        public double Depth { get; set; }

        /// <summary>
        /// Тип пробы
        /// </summary>
        public string ProbeType { get; set; }

        /// <summary>
        /// 0 - бюкса, 1 - монолит
        /// </summary>
        public int Type { get { if (this.ProbeType == "Бюкса") return 0; else return 1; } }
    }

    /// <summary>
    /// Тип установки (легкая, средняя, тяжелая)
    /// </summary>
    public enum ProbeSetting
    {
        /// <summary>
        /// Не определено
        /// </summary>
        Undefined = 0,
        /// <summary>
        /// Легкая установка А = 280
        /// </summary>
        Light = 1,
        /// <summary>
        /// Средняя установка А = 1120
        /// </summary>
        Medium = 2,
        /// <summary>
        /// Тяжелая установка A = 2800
        /// </summary>
        Heavy = 3
    }
}
