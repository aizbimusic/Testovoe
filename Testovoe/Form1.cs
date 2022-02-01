using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Testovoe
{
    public partial class Form1 : Form
    {
        
        List<Employee> list = new List<Employee>()
            {
                //new FixedPayEmployee("Tom", 1, 15000),
                //new FixedPayEmployee("Bob", 2, 10000) { EmployeeType = EmployeeType.HourlyPayEmployee },
                //new HourlyPayEmployee("John", 3, 10),
                //new HourlyPayEmployee("Anna", 4, 10),
                //new FixedPayEmployee("Sara", 5, 5000) { EmployeeType = EmployeeType.HourlyPayEmployee },
                //new HourlyPayEmployee("Jack", 6, 30),
                //new HourlyPayEmployee("Travis", 7, 20) { EmployeeType = EmployeeType.HourlyPayEmployee }
            };
        List<Employee> filteredList = new List<Employee>();
        public Form1()
        {
            InitializeComponent();

            string connectionString = "Data Source=EDS42\\DEMOSERVER;Database = adonetdb;Integrated Security=SSPI;Encrypt=True;TrustServerCertificate=True";
            string sqlExpression = "SELECT * FROM Employee";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    int id = reader.GetInt32(1);
                    double rate = reader.GetDouble(2);
                    int employeeTypeId = reader.GetInt32(3);
                    if (employeeTypeId == (int)EmployeeType.HourlyPayEmployee)
                    {
                        list.Add(new HourlyPayEmployee(name, id, rate, employeeTypeId));
                    }
                    else if (employeeTypeId == (int) EmployeeType.FixedPayEmployee)
                    {
                        list.Add(new FixedPayEmployee(name, id, rate, employeeTypeId));
                    }
                }
            }

            var bindingList = new BindingList<Employee>(list);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            filteredList = list.Select(x => x).OrderByDescending(x => x.Salary()).ThenBy(x => x.Name).ToList();
            var bindingList = new BindingList<Employee>(filteredList);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            filteredList = list.Select(x => x).Take(5).ToList();
            var bindingList = new BindingList<Employee>(filteredList);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            filteredList = list.TakeLast(3).ToList();
            foreach (var item in filteredList.Select(x => x.Id))
            {
                dt.Rows.Add(item);
            }
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string writePath = @"C:\Users\sokolovskyi\Desktop\test.txt";
            string json = System.Text.Json.JsonSerializer.Serialize(filteredList);
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var readPath = (sender as OpenFileDialog)?.FileName;
            var json = File.ReadAllText(readPath);
            JsonConverter[] converters = { new FooConverter() };
            var restoredList = JsonConvert.DeserializeObject<List<Employee>>(json, new JsonSerializerSettings() { Converters = converters });
            dataGridView1.DataSource = restoredList;
        }

        public class FooConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return (objectType == typeof(Employee));
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                JObject jo = JObject.Load(reader);
                if (jo["EmployeeType"].Value<int>() == (int)EmployeeType.HourlyPayEmployee)
                    return jo.ToObject<HourlyPayEmployee>(serializer);
                else if (jo["EmployeeType"].Value<int>() == (int)EmployeeType.FixedPayEmployee)
                    return jo.ToObject<FixedPayEmployee>(serializer);

                return null;
            }

            public override bool CanWrite
            {
                get { return false; }
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }

        

        }
    }
}
