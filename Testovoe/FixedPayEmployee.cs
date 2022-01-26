namespace Testovoe
{
    internal class FixedPayEmployee : Employee
    {
        public FixedPayEmployee(string name, int id, double rate) : base(name, id, rate)
        {
        }

        public override double Salary => Rate;
    }
}
