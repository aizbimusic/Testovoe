namespace Testovoe
{
    internal class FixedPayEmployee : Employee
    {

        public FixedPayEmployee(string name, int id, double rate, int employeeTypeId) : base(name, id, rate)
        {
        }

        public override double Salary() => Rate;
    }
}
