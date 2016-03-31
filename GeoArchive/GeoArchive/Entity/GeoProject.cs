using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoArchive.Entity
{
    public class GeoProject
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование (№ Проекта)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание проекта
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Содержание проекта
        /// </summary>
        public string Files { get; set; }
    }
}
