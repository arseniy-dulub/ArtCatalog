using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtCatalog.Models
{
    public class Tag
    {
        public int TagId { get; set; }

        public string TagName { get; set; }

        public virtual ICollection<Product> Products { get; set; } 
    }
}