using System;
using System.Collections.Generic;
using System.Linq;

namespace GEOArchive.Tools.GEOEntities
{
    public class CutEntity
    {
        /// <summary>
        /// Номер разреза
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Расстояние между скважинами
        /// </summary>
        public List<OutDist> OutDists { get; set; }

        /// <summary>
        /// Скважины
        /// </summary>
        public List<Bore> Bores { get; set; }

        private double startSeaDepth;
        public double StartSeaDepth
        {
            get 
            { 
                return startSeaDepth;
            }
            set 
            { 
                startSeaDepth = value; 
            }
        }

        private double endSeaDepth;
        public double EndSeaDepth
        {
            get { return endSeaDepth; }
            set { endSeaDepth = value; }
        }
    }

    public class Bore
    {
        public BoreType Type
        { get; set; }

        /// <summary>
        /// Номер скважины
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Слои земли
        /// </summary>
        public List<IgeItem> Items { get; set; }

        public List<BoreItem> BoreItems { get; set; }

        /// <summary>
        /// Динамическое зондирование
        /// </summary>
        public List<DynamicProbe> DynamicProbes { get; set; }

        /// <summary>
        /// Статическое зондирование
        /// </summary>
        public List<StaticProbe> StaticProbes { get; set; }

        /// <summary>
        /// Грунтовые воды
        /// </summary>
        public List<DepthWater> DepthWater { get; set; }

        /// <summary>
        /// Лабораторные пробы
        /// </summary>
        public List<ResultTable> Lab { get; set; }

        /// <summary>
        /// Предполагаемые места отбора проб
        /// </summary>
        public List<ProbePlace> ProbePlaces { get; set; }

        /// <summary>
        /// Глубина всей скважины
        /// </summary>
        public double Depth
        {
            get;
            set;
        }

        /// <summary>
        /// Уровень относительно моря
        /// </summary>
        public double SeaLevel { get; set; }

        /// <summary>
        /// Крайняя глубина земли относительно моря
        /// </summary>
        public double SeaDepth 
        {
            get 
            {
                List<double> depths = new List<double>();

                if (BoreItems.Count > 0)
                {
                    depths.Add(SeaLevel - Items.Max(item => item.D2));
                }
                if (DynamicProbes.Count > 0)
                {
                    depths.Add(SeaLevel - DynamicProbes.Max(item => item.Depth / 10));
                }
                if (StaticProbes.Count > 0)
                {
                    depths.Add(SeaLevel - StaticProbes.Max(item => item.Depth));
                }
                    
                return depths.Min();
            } 
        }

        /// <summary>
        /// Координата x
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Координата Y
        /// </summary>
        public double Y { get; set; }
    }

    public class BoreItem
    {
        public string Couple1 { get; set; }
        public string Couple2 { get; set; }
        public string Couple3 { get; set; }
        public string Couple4 { get; set; }
        public string Couple5 { get; set; }

        public int IgeNum { get; set; }
        public string OutObjId { get; set; }
        public double D2 { get; set; }
        public bool IsClay { get; set; }
        public bool IsSand { get; set; }
    }

    public enum BoreType
    {
        /// <summary>
        /// Скважина
        /// </summary>
        Bore = 0,
        /// <summary>
        /// Промежуточная точка
        /// </summary>
        Point = 1,
        /// <summary>
        /// Промежуточное зондирование
        /// </summary>
        Probe = 2
    }
}
