using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent
{
    public class Car
    {
        public Car(string name, int id)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Id = id;
   
        }

        public string Name { get; }
        public int Id { get; }
        public int CountUsed { get; private set; }

        public void AddCountUsed()
        {
            CountUsed++;
        }
    }
}
