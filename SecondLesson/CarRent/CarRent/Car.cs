using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent
{
    public class Car
    {
        public Car(string name, int id, bool isGood)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Id = id;
            IsGood = isGood;
        }

        public string Name { get; }
        public int Id { get; }
        public int CountUsed { get; private set; }
        public bool IsGood { get; set; }
    }
}
