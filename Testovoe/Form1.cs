using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Testovoe
{
    public partial class Form1 : Form
    {

        List<Employee> list = new List<Employee>();
        List<Employee> filteredList = new List<Employee>();
        internal DataSet dataSet = new DataSet();
        DataTable dt = new DataTable();
        SqlConnection SqlConnection = new SqlConnection(Helper.sqlConnection);
        public Form1()
        {
            InitializeComponent();

            string sqlExpression = "SELECT * FROM Employee";
            using (SqlConnection sql = new SqlConnection(Helper.sqlConnection))
            {
                sql.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, sql);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    double rate = reader.GetDouble(2);
                    int employeeTypeId = reader.GetInt32(3);
                    if (employeeTypeId == (int)EmployeeType.HourlyPayEmployee)
                    {
                        list.Add(new HourlyPayEmployee(name, id, rate));
                    }
                    else if (employeeTypeId == (int) EmployeeType.FixedPayEmployee)
                    {
                        list.Add(new FixedPayEmployee(name, id, rate));
                    }
                }
            }

            //Если сразу начать обновлять сотрудника без фильтрации елементов - происходит ошибка, так как filteredList не имеет значений
            filteredList = list;
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

        private void button6_Click(object sender, EventArgs e)
        {
            CreateForm editForm = new CreateForm();
            editForm.Owner = this;
            editForm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var columnIndex = dataGridView1.Columns["Id"].Index;
                var ids = new List<string>();

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    var id = row.Cells[columnIndex]?.Value?.ToString();
                    if(!string.IsNullOrEmpty(id))
                        ids.Add(id);
                }
                var cmdText = string.Format("DELETE Employee WHERE Id in ({0})", string.Join(",", ids));
                var cmd = new SqlCommand(cmdText, SqlConnection);
                SqlConnection.Open();
                cmd.ExecuteNonQuery();
                SqlConnection.Close();
                MessageBox.Show("Запись была успешно удалена");
            }
            else
            {
                MessageBox.Show("Выберите запись которую хотите удалить!");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            var emp = filteredList[i];
            string textName = (string)dataGridView1.Rows[i].Cells[0].Value;
            int employeeId = (int)dataGridView1.Rows[i].Cells[1].Value;
            double textRate = (double)dataGridView1.Rows[i].Cells[3].Value;
            UpdateForm updateForm = new UpdateForm(emp) { Owner = this };
            updateForm.ShowDialog();
        }
    }
}
