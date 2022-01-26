using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testovoe
{
    internal abstract class Employee
    {
        private double rate;
        public string Name { get;}
        public int Id { get; }

        public abstract double Salary { get; }
        public double Rate
        {
            set
            {
                if (value > 0)
                    rate = value;
            }
            protected get
            {
                return rate;
            }
        }

        public Employee(string name, int id, double rate)
        {
            Name = name;
            Id = id;
            Rate = rate;
        }
        public override string ToString()
        {
            return $"Id: {Id}; Name: {Name}; Rate {Rate}";
        }

    }
}
