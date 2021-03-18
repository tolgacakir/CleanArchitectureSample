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
        public uint QuantityPerUnit { get; set; }

        private double _unitPrice;
        public double UnitPrice
        {
            get => _unitPrice;

            set => _unitPrice = (value < 0)
                ? throw new PriceCannotBeNegativeException()
                : value;
        }
        private int _unitsInStock;
        public int UnitsInStock
        {
            get => _unitsInStock;

            set => _unitsInStock = (value < 0)
                ? throw new StockCannotBeNegativeException()
                : value;
        }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
