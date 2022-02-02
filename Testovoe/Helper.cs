using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testovoe
{
    internal static class Helper
    {
       internal static string sqlConnection = "Data Source=EDS42\\DEMOSERVER;Database = adonetdb;Integrated Security=SSPI;Encrypt=True;TrustServerCertificate=True";
       internal static SqlDataAdapter EmployeeTableAdapter = new SqlDataAdapter();

    }
}
