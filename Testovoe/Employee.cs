namespace Testovoe
{
    internal abstract class Employee
    {
        private double rate;
        public string Name { get;}
        public int Id { get; }
        public EmployeeType EmployeeType { get; set; } = EmployeeType.FixedPayEmployee;

        public abstract double Salary();
        public double Rate
        {
            set
            {
                if (value > 0)
                    rate = value;
            }
            get
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

    internal enum EmployeeType : byte
    {
        HourlyPayEmployee,
        FixedPayEmployee
    }
}
