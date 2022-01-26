namespace Testovoe
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            var list = new List<Employee>()
            {
                new FixedPayEmployee("Tom", 1, 20000),
                new FixedPayEmployee("Bob", 2, 30000),
                new HourlyPayEmployee("John", 3, 10),
                new HourlyPayEmployee("Anna", 4, 20),
                new FixedPayEmployee("Sara", 5, 25000),
                new HourlyPayEmployee("Jack", 6, 30)
            };

        }
    }
}