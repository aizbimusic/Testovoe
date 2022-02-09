namespace Testovoe
{
    internal class HourlyPayEmployee : Employee
    {
        public HourlyPayEmployee(string name, int id, double rate) : base(name, id, rate)
        {
            EmployeeType = EmployeeType.HourlyPayEmployee;
        }
        public override double Salary() => 20.8 * 8 * Rate;
    }
}
