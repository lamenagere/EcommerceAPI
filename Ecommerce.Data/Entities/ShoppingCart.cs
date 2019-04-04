using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public virtual Account User { get; set; }
        public virtual ICollection<ShoppingProduct> ShoppingProducts { get; set; }
    }
}