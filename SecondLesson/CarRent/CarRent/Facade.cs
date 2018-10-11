using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent
{
    public class Facade
    {
        Repository repa;

        public Facade(Repository repa)
        {
            this.repa = repa ?? throw new ArgumentNullException(nameof(repa));
        }

        public List<Car> SeeFreeCars(DateTimeOffset start, DateTimeOffset end)
        {
            List<Car> freeCars = new List<Car>();
            foreach (RentContract cont in repa.Contracts)
            {
                if ((start > cont.EndRent) && (end < cont.StartRent)) freeCars.Add(cont.car);   
            }
            return freeCars;
        }

        public bool RentCar(Car car, User user, DateTimeOffset startRent, DateTimeOffset endRent)
        {
            
            repa.Contracts.Add(new RentContract(startRent, endRent, user, car));
            return true;
        }

        public List<RentContract> GetRentHistory(User user)
        {
            List<RentContract> history = new List<RentContract>();
            foreach(RentContract cont in repa.Contracts)
            {
                if (cont.User == user) history.Add(cont);
            }
            return history;
        }
        public void AddCar(Car car)
        {
            repa.Park.AddCar(car);
        }
    }
}
