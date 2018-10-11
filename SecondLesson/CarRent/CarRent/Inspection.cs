using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent
{
    public class Inspection
    {
        public Inspection(DateTimeOffset star, Car car)
        {
            this.star = start;
            this.car = car ?? throw new ArgumentNullException(nameof(car));
        }

        public DateTimeOffset star { get; }
        public Car car { get; }
    }
}
