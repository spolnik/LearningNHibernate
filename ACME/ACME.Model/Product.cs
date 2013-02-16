using System.Collections.Generic;

namespace ACME.Model
{
    public class Product
    {
        public virtual int? ProductId { get; set; }
        public virtual string ProductName { get; set; }
        public virtual UnitOfMeasure UOM { get; set; }
        public virtual IList<Category> Categories { get; set; }

        public Product()
        {
            this.Categories = new List<Category>();
        }
    }
}
