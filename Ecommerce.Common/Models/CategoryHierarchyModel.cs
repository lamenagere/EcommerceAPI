using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class CategoryHierarchyModel
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public List<CategoryHierarchyModel> subCategories { get; set; }
    }
}