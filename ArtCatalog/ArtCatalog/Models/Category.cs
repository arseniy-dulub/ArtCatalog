using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ArtCatalog.Resources;

namespace ArtCatalog.Models
{
    /// <summary>
    /// Категория работ
    /// </summary>
    public class Category
    {
        public int CategoryID { get; set; }

        [Display(Name = "CategoryName", ResourceType = typeof(CategoryRes))]
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}