using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ArtCatalog.Resources;

namespace ArtCatalog.Models
{
    /// <summary>
    /// Работа
    /// </summary>
    public class Product
    {
        public int ProductID { get; set; }

        [Display(Name = "Name", ResourceType = typeof(ProductRes))]
        public string ProductName { get; set; }

        [Display(Name = "Description", ResourceType = typeof(ProductRes))]
        public string ProductDescription { get; set; }

        [Display(Name = "ProducedAt", ResourceType = typeof(ProductRes))]
        public string ProducedAt { get; set; }

        [Display(Name = "Size", ResourceType = typeof(ProductRes))]
        public string Size { get; set; }

        public int CategoryID { get; set; }

        [Display(Name = "Thumbinal", ResourceType = typeof(ProductRes))]
        public string ThumbinalPath { get; set; }
        
        public string OriginalPath { get; set; }
        
        [Display(Name = "Name", ResourceType = typeof(CategoryRes))]
        public virtual Category Categ { get; set; } 
    }
}