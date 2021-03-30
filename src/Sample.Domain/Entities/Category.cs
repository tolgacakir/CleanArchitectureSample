using Sample.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Entities
{
    public class Category : Entity, ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
        public bool IsDeleted { get; set; }

        public Category()
        {
            Products = new HashSet<Product>();
        }
    }
}
