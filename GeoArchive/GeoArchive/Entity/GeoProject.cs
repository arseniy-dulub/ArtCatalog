using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace GeoArchive.Entity
{
    public class GeoProject
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// № Проекта (наименование)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание проекта
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Ссылки на вложенные файлы
        /// </summary>
        public string Files { get; set; }
    }
}
