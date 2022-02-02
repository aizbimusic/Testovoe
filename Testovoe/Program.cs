using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Testovoe
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
    
}