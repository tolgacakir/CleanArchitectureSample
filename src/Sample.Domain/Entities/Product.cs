using Sample.Domain.Common;
using Sample.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Entities
{
    public class Product : AuditableEntity<Guid>
    {
        public string Name { get; set; }
        public uint Quantity { get; set; }

        private double _price;
        public double Price
        {
            get => _price;

            set => _price = (value < 0)
                ? throw new PriceCannotBeNegativeException()
                : value;
        }
        private int _stock;
        public int Stock
        {
            get => _stock;

            set => _stock = (value < 0)
                ? throw new StockCannotBeNegativeException()
                : value;
        }
    }
}
