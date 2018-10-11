using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent
{
    public class Park
    {
        public List<Car> Cars { get; private set; }
        public List<Inspection> Insp { get; private set; }
        public void AddCar(Car car)
        {
            if (!Cars.Contains(car))
                Cars.Add(car);
        }

      

        public void GoOnInspection(Car car)
        {
            Insp.Add(new Inspection(DateTimeOffset.Now, car));
            car.IsGood = false;
        }
       
    }
}
