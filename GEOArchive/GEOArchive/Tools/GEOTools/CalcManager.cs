using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEOArchive.Tools.GEOEntities;

namespace GEOArchive.Tools.GEOTools
{
    /// <summary>
    /// КЛАСС ВЫЧИСЛЕНИЯ ЛАБОРАТОРНЫХ РЕЗУЛЬТАТОВ
    /// </summary>
    class CalcManager
    {
        private const int GAMMA_W = 1;

        private volatile static CalcManager instance; 

        public static CalcManager getInstance()
        {
            if (instance == null)
            {
                if (instance == null)
                {
                    instance = new CalcManager();
                }
            }
            return instance;
        }

        #region ПОЛУЧЕНИЕ НАИМЕНОВАНИЯ ГРУНТА

        /// <summary>
        /// Определяет наименование грунта в виде СП, СГ и т.д.
        /// </summary>
        /// <param name="paramz">Экземпляр таблицы результатов просчета</param>
        /// <param name="type">Тип грунта 1\2</param>
        /// <returns></returns>
        public string IndentifyGroundName(ResultTable paramz, int type)
        {
            string result = "";
            double? ip = paramz.Ip;
            double? wp = paramz.Wp;
            double? il = paramz.Il;

            switch (type)
            {
                case 1:
                    {
                        #region ГЛИНА

                        #region ip<7

                        if (ip <= 7.0)
                        {
                            result = "СП";
                            #region Консистенция
                            if (il != null)
                            {
                                if (il < 0)
                                {
                                    result += "ТВ";
                                }
                                else if ((il >= 0) && (il < 1))
                                {
                                    result += "ПЛ";
                                }
                                else if (il > 1)
                                {
                                    result += "ТК";
                                }
                            }
                            #endregion
                        }
                        #endregion
                        #region ip>17
                        else if (ip > 17)
                        {
                            result = "ГЛ";
                            #region Консистенция
                            if (il != null)
                            {
                                if (il < 0)
                                {
                                    result = result + "ТВ";
                                }
                                else if ((il <= 0.25) && (il > 0))
                                {
                                    result = result + "ПТ";
                                }
                                else if ((il <= 0.50) && (il > 0.25))
                                {
                                    result = result + "ТГ";
                                }
                                else if ((il <= 0.75) && (il > 0.5))
                                {
                                    result = result + "МП";
                                }
                                else if ((il <= 1) && (il >= 0.75))
                                {
                                    result = result + "ТП";
                                }
                                else if (il > 1)
                                {
                                    result = result + "ТК";
                                }
                            }
                            #endregion
                        }
                        #endregion
                        #region 7<ip>=17
                        else if ((ip > 7) && (ip <= 17))
                        {
                            result = "СГ";
                            #region Консистенция
                            if (il != null)
                            {
                                if (il < 0)
                                {
                                    result = result + "ТВ";
                                }
                                else if ((il <= 0.25) && (il > 0))
                                {
                                    result = result + "ПТ";
                                }
                                else if ((il <= 0.50) && (il > 0.25))
                                {
                                    result = result + "ТГ";
                                }
                                else if ((il <= 0.75) && (il > 0.5))
                                {
                                    result = result + "МП";
                                }
                                else if ((il <= 1) && (il >= 0.75))
                                {
                                    result = result + "ТП";
                                }
                                else if (il > 1)
                                {
                                    result = result + "ТК";
                                }
                            }
                            #endregion
                        }
                        #endregion
                        break;
                        #endregion
                    }
                case 2:
                    {
                        #region ПЕСОК
                        // Масса частиц крупнее 0.1мм
                        double? _mm01 = paramz.Mm025_01 + paramz.Mm05_025 + paramz.Mm1_05 + paramz.Mm2_1 + paramz.Mm5_2 + paramz.Mm10_5 + paramz.MmNaN_10;

                        // Масса частиц крупнее 0.25мм
                        double? _mm025 = _mm01 - paramz.Mm025_01;
                        
                        // Масса частиц крупнее 0.5мм
                        double? _mm05 = _mm025 - paramz.Mm05_025;

                        // Масса частиц крупнее 2мм
                        double? _mm2 = _mm05 - paramz.Mm1_05 - paramz.Mm2_1;

                        // Масса частиц крупнее 10мм
                        double? _mm10 = paramz.MmNaN_10;

                        if (_mm01 < 75) result = "ПП";
                        if (_mm01 >= 75) result = "ПМ";
                        if (_mm025 > 50) result = "ПС";
                        if (_mm05 > 50) result = "ПК";
                        if (_mm2 > 25) result = "ПГ";
                        if (_mm2 > 50) result = "ГГ";
                        if (_mm10 > 50) result = "ГАЛГ";

                        break;
                        #endregion
                    }
            }

            return result;
        }

        /// <summary>
        /// Возвращает полное наименование грунта
        /// </summary>
        /// <param name="paramz">Экземпляр таблицы результатов просчета</param>
        /// <returns></returns>
        public string ReturnFullGroundName(ResultTable paramz)
        {
            string result = "";
            string str1 = "";
            try
            {
                str1 = paramz.Name.Substring(0, 2);
            }
            catch { }
            string str2 = "";
            try
            {
                str2 = paramz.Name.Substring(2, 2);
            }
            catch { }
            switch (paramz.Type)
            {
                case 1:
                    {
                        #region case 1
                        if (str1 == "СП")
                        {
                            result = "супесь ";
                        }
                        if (str1 == "СГ")
                        {
                            result = "сугл ";
                        }
                        if (str1 == "ГЛ")
                        {
                            result = "глина ";
                        }

                        if (str2 == "ПЛ")
                        {
                            result += "пластич.";
                        }
                        if (str2 == "ТВ")
                        {
                            result += "тверд.";
                        }
                        if (str2 == "ПТ")
                        {
                            result += "полутв.";
                        }
                        if (str2 == "ТГ")
                        {
                            result += "тугопл.";
                        }
                        if (str2 == "МП")
                        {
                            result += "мягкопл.";
                        }
                        if (str2 == "ТП")
                        {
                            result += "текучепл.";
                        }
                        if (str2 == "ТК")
                        {
                            result += "текуч.";
                        }

                        break;
                        #endregion
                    }
                case 2:
                    { 
                        #region case 2

                        if (str1 == "ПП")
                        {
                            result = "песок пыл.";
                        }

                        if (str1 == "ПМ")
                        {
                            result = "песок мел.";
                        }

                        if (str1 == "ПС")
                        {
                            result = "песок сред.";
                        }

                        if (str1 == "ПК")
                        {
                            result = "песок круп.";
                        }

                        if (str1 == "ПГ")
                        {
                            result = "песок грав.";
                        }

                        if (str1 == "ГГ")
                        {
                            result = "гравийный грунт";
                        }

                        break; 
                        #endregion
                    }
            }

            if (str1 + str2 == "ГАЛГ")
                result = "галечниковый грунт";

            return result;
        }

        public string ReturnFullGroundNameForReport(string str, int type)
        {
            string result = "";

            string str1 = "";
            try
            {
                str1 = str.Substring(0, 2);
            }
            catch { }
            string str2 = "";
            try
            {
                str2 = str.Substring(2, 2);
            }
            catch { }

            switch (type)
            {
                case 1:
                    {
                        #region case 1
                        if (str1 == "СП")
                        {
                            result = "супесь ";
                        }
                        if (str1 == "СГ")
                        {
                            result = "сугл ";
                        }
                        if (str1 == "ГЛ")
                        {
                            result = "глина ";
                        }

                        if (str2 == "ПЛ")
                        {
                            result += "пластич.";
                        }
                        if (str2 == "ТВ")
                        {
                            result += "тверд.";
                        }
                        if (str2 == "ПТ")
                        {
                            result += "полутв.";
                        }
                        if (str2 == "ТГ")
                        {
                            result += "тугопл.";
                        }
                        if (str2 == "МП")
                        {
                            result += "мягкопл.";
                        }
                        if (str2 == "ТП")
                        {
                            result += "текучепл.";
                        }
                        if (str2 == "ТК")
                        {
                            result += "текуч.";
                        }

                        break;
                        #endregion
                    }
                case 2:
                    {
                        #region case 2

                        if (str1 == "ПП")
                        {
                            result = "песок пыл.";
                        }

                        if (str1 == "ПМ")
                        {
                            result = "песок мел.";
                        }

                        if (str1 == "ПС")
                        {
                            result = "песок сред.";
                        }

                        if (str1 == "ПК")
                        {
                            result = "песок круп.";
                        }

                        if (str1 == "ПГ")
                        {
                            result = "песок грав.";
                        }

                        if (str1 == "ГГ")
                        {
                            result = "гравийный грунт";
                        }

                        break;
                        #endregion
                    }
            }

            if (str1 + str2 == "ГАЛГ")
            {
                result = "галечниковый грунт";
            }

            return result;
        }

        #endregion

        #region ВЫЧИСЛЕНИЕ IL, IP

        /// <summary>
        /// Вычисление Ip параметра 
        /// </summary>
        /// <param name="paramz">Экземпляр таблицы результатов просчета</param>
        /// <returns></returns>        
        private double? CalcIP(ResultTable paramz)
        {
            double? wl = paramz.Wl;
            double? wp = paramz.Wp;
            double? result = wl - wp;

            if (wl == null || wp == null) return null;

            return result;
        }

        /// <summary>
        /// Вычисление Il параметра 
        /// </summary>
        /// <param name="paramz">Экземпляр таблицы результатов просчета</param>
        /// <returns></returns>
        private double? CalcIL(ResultTable paramz)
        {
            double? w = paramz.NatureWet;
            double? wp = paramz.Wp;
            double? ip = paramz.Ip;
            double? result = (w - wp) / ip;

            if (w == null || wp == null || ip == null) return null; 

            return result;
        }

        #endregion

        #region ВЫЧИСЛЕНИЕ Y, W, Sr, e, n, wl, wp, Ys

        /// <summary>
        /// Вычисление гаммы образца
        /// </summary>
        /// <param name="paramz"></param>
        /// <returns></returns>
        private double? CalcY(ParamzTable paramz)
        {
            double? result = (paramz.RingWeight / paramz.RingSize);

            if (paramz.RingWeight == 0 || paramz.RingSize == 0) return null;

            return result;
        }

        /// <summary>
        /// Вычисление влажности образца
        /// </summary>
        /// <param name="paramz"></param>
        /// <returns></returns>
        private double? CalcW(ParamzTable paramz)
        {
            double? result = ((paramz.Wet - paramz.WetDry) / (paramz.WetDry - paramz.WetBux)) * 100;

            if (paramz.Wet == 0) return null;

            return result;
        }

        private double? CalcN(ResultTable resParamz)
        {
            double? result = (1 - (resParamz.Y / (resParamz.Ys * (1 + (resParamz.NatureWet / 100)))));

            if (result < 0)
            {
                result = result * -1; 
            }
            return result * 100;
        }

        private double? CalcE(ResultTable resParamz)
        {
            double? n = resParamz.N;
            double? result = n / (100 - n);
            return result;
        }

        private double? CalcSr(ParamzTable paramz, ResultTable resParamz)
        {
            double? result = 0;

            double? e = resParamz.E;
            double? w = resParamz.NatureWet;

            result = (w * resParamz.Ys) / (e * GAMMA_W);

            return result / 100;
        }

        private double? CalcWl(ParamzTable paramz)
        {
            double? result = (paramz.Liqu - paramz.LiquDry) / (paramz.LiquDry - paramz.LiquJar);
            return result * 100;
        }

        private double? CalcWP(ParamzTable paramz)
        { 
            double result = (paramz.Roll - paramz.RollDry) / (paramz.RollDry - paramz.RollJar);
            return result * 100;
        }

        private double ReturnYs(string type)
        {
            double result = 0;
            switch (type)
            {
                case "СП":
                    {
                        result = 2.68;
                        break;
                    }
                case "СГ":
                    {
                        result = 2.70;
                        break;
                    }
                case "ГЛ":
                    {
                        result = 2.74;
                        break;
                    }
                default:
                    {
                        result = 2.66;
                        break;
                    }
            }
            return result;
        }

        #endregion

        /// <summary>
        /// Генерирует полный список резульатов рассчета 
        /// </summary>
        /// <param name="paramz">Список входных данных по образцам</param>
        /// <returns></returns>
        public List<ResultTable> GenerateResultList(List<ParamzTable> paramz)
        {
            List<ResultTable> result = new List<ResultTable>();
            ResultTable res;

            for (int i = 0; i < paramz.Count; i++)
            {
                if (i + 1 != paramz.Count)
                {
                    if (paramz[i].Test != paramz[i + 1].Test)
                    {
                        res = CalcResItem(paramz[i]);
                        result.Add(res);
                        result.Add(new ResultTable());
                    }
                    else
                    {
                        res = CalcResItem(paramz[i]);
                        result.Add(res);
                    }
                }
                else
                {
                    res = CalcResItem(paramz[i]);
                    result.Add(res);
                }
                
            }

            return result;
        }

        public ResultTable CalcResItem(ParamzTable pr)
        {
            ResultTable res = new ResultTable();
            switch (pr.Type)
            {
                case 1: // ГЛИНА СТАНДАРТ
                    {
                        #region ГЛИНА
                        //******
                        res.CId = pr.CId;
                        res.Obj = pr.Obj;
                        res.Type = 1;
                        res.Id = pr.Id;
                        res.Depth = pr.Depth;
                        res.Test = pr.Test;
                        //******

                        // 1) Тип грунта (глин, песч)
                        res.Type = 1;

                        res.Wl = CalcWl(pr);
                        res.Wp = CalcWP(pr);

                        // 2) ip, il
                        res.Ip = CalcIP(res);

                        res.NatureWet = CalcW(pr);

                        res.Il = CalcIL(res);

                        // 3) наименование грунта
                        res.Name = IndentifyGroundName(res, res.Type);

                        // 4) высчит Ys
                        try
                        {
                            string tempName = res.Name.Substring(0, 2);
                            res.Ys = ReturnYs(tempName);
                        }
                        catch
                        {                          
                            res.Ys = 0;
                        }

                        // 5) высчит Y
                        res.Y = CalcY(pr);

                        // 6) высчитать n портистость
                        res.N = CalcN(res);

                        // 7) высчитать e коэф пористости
                        res.E = CalcE(res);

                        // 9) высчитать Sr степень влажности
                        res.Sr = CalcSr(pr, res);

                        // 10) высчитать pd вес скелета
                        res.Pd = res.Y / (1 + (res.NatureWet / 100));

                        res.P1 = pr.P1;
                        res.T = pr.T;

                        //result.Add(res);
                        break;
                        #endregion
                    }
                case 2: // ПЕСОК СТАНДАРТ
                    {
                        #region ПЕСОК
                        //******
                        res.CId = pr.CId;
                        res.Obj = pr.Obj;
                        res.Type = 2;
                        res.Id = pr.Id;
                        res.Depth = pr.Depth;
                        res.Test = pr.Test;
                        //******

                        res.Type = 2;

                        res.MmNaN_10 = pr.W10 / (pr.Weight / 100);
                        res.Mm10_5 = pr.W5 / (pr.Weight / 100);
                        res.Mm5_2 = pr.W2 / (pr.Weight / 100);
                        res.Mm2_1 = pr.W1 / (pr.Weight / 100);
                        res.Mm1_05 = pr.W05 / (pr.Weight / 100);
                        res.Mm05_025 = pr.W025 / (pr.Weight / 100);
                        res.Mm025_01 = pr.W01 / (pr.Weight / 100);
                        res.Mm01_NaN = 100 - (res.MmNaN_10 + res.Mm10_5 + res.Mm5_2 + res.Mm2_1 + res.Mm1_05 + res.Mm05_025 + res.Mm025_01);

                        res.Name = IndentifyGroundName(res, res.Type);

                        res.Ys = ReturnYs(res.Name);

                        res.Y = CalcY(pr);

                        res.NatureWet = CalcW(pr);

                        res.N = CalcN(res);

                        res.E = CalcE(res);                     

                        res.Sr = CalcSr(pr, res);

                        res.Pd = res.Y / (1 + (res.NatureWet / 100));

                        res.P1 = pr.P1;
                        res.T = pr.T;

                        break;
                        #endregion
                    }
                case 3: // ГЛИНА ОРГАНИЧ.
                    {
                        #region ГЛИНА
                        //******
                        res.CId = pr.CId;
                        res.Obj = pr.Obj;
                        res.Type = 1;
                        res.Id = pr.Id;
                        res.Depth = pr.Depth;
                        res.Test = pr.Test;
                        //******

                        // 1) Тип грунта (глин, песч)
                        res.Type = 1;

                        try
                        {
                            res.Wl = CalcWl(pr);
                            res.Wp = CalcWP(pr);
                        }
                        catch { res.Wl = 0; res.Wp = 0; }

                        // 2) ip, il
                        try
                        {
                            res.Ip = CalcIP(res);

                            res.NatureWet = CalcW(pr);

                            res.Il = CalcIL(res);
                        }
                        catch { res.Ip = 0; res.NatureWet = 0; res.Il = 0; }

                        // 3) наименование грунта
                        try
                        {
                            res.Name = IndentifyGroundName(res, res.Type);
                        }
                        catch { res.Name = ""; }

                        // 4) высчит Ys
                        try
                        {
                            string tempName = res.Name.Substring(0, 2);
                            res.Ys = ReturnYs(tempName);
                        }
                        catch { res.Ys = 0; }

                        // 5) высчит Y
                        try
                        {
                            res.Y = CalcY(pr);
                        }
                        catch { res.Y = 0; }

                        // 6) высчитать n портистость
                        res.N = CalcN(res);

                        // 7) высчитать e коэф пористости
                        try
                        {
                            res.E = CalcE(res);
                        }
                        catch { res.E = 0; }

                        // 9) высчитать Sr степень влажности
                        try
                        {
                            res.Sr = CalcSr(pr, res);
                        }
                        catch { res.Sr = 0; }

                        // 10) высчитать pd вес скелета
                        try
                        {
                            res.Pd = res.Y / (1 + (res.NatureWet / 100));
                        }
                        catch { res.Pd = 0; }

                        res.Iom = pr.CalcK * ((pr.CalcTo - pr.CalcAfter) / pr.CalcTo);// *100;

                        res.P1 = pr.P1;
                        res.T = pr.T;

                        //result.Add(res);
                        break;
                        #endregion
                    }
                case 4: // ПЕСОК ОРГАНИЧ.
                    {
                        #region ПЕСОК
                        //******
                        res.CId = pr.CId;
                        res.Obj = pr.Obj;
                        res.Type = 2;
                        res.Id = pr.Id;
                        res.Depth = pr.Depth;
                        res.Test = pr.Test;
                        //******

                        res.Type = 2;

                        res.MmNaN_10 = pr.W10 / (pr.Weight / 100);
                        res.Mm10_5 = pr.W5 / (pr.Weight / 100);
                        res.Mm5_2 = pr.W2 / (pr.Weight / 100);
                        res.Mm2_1 = pr.W1 / (pr.Weight / 100);
                        res.Mm1_05 = pr.W05 / (pr.Weight / 100);
                        res.Mm05_025 = pr.W025 / (pr.Weight / 100);
                        res.Mm025_01 = pr.W01 / (pr.Weight / 100);
                        res.Mm01_NaN = 100 - (res.MmNaN_10 + res.Mm10_5 + res.Mm5_2 + res.Mm2_1 + res.Mm1_05 + res.Mm05_025 + res.Mm025_01);

                        res.Name = IndentifyGroundName(res, res.Type);

                        res.Ys = ReturnYs(res.Name);

                        res.Y = CalcY(pr);

                        res.NatureWet = CalcW(pr);

                        res.N = CalcN(res);

                        res.E = CalcE(res);               

                        res.Sr = CalcSr(pr, res);

                        res.Pd = res.Y / (1 + (res.NatureWet / 100));

                        res.Iom = pr.CalcK * ((pr.CalcTo - pr.CalcAfter) / pr.CalcTo);// *100;

                        res.P1 = pr.P1;
                        res.T = pr.T;

                        break;
                        #endregion
                    }
            }

            return res;
        }
    }
}
