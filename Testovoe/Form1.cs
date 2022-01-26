using System.ComponentModel;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Testovoe
{
    public partial class Form1 : Form
    {
        private Panel buttonPanel = new Panel();
        private DataGridView employeesDataGridView = new DataGridView();
        private Button addNewRowButton = new Button();
        private Button deleteRowButton = new Button();
        List<Employee> list = new List<Employee>()
            {
                new FixedPayEmployee("Tom", 1, 15000),
                new FixedPayEmployee("Bob", 2, 10000),
                new HourlyPayEmployee("John", 3, 10),
                new HourlyPayEmployee("Anna", 4, 10),
                new FixedPayEmployee("Sara", 5, 5000),
                new HourlyPayEmployee("Jack", 6, 30),
                new HourlyPayEmployee("Travis", 7, 20)
            };
        public Form1()
        {
            InitializeComponent();

           
            var bindingList = new BindingList<Employee>(list);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var bindingList = new BindingList<Employee>(list.Select(x => x).OrderByDescending(x => x.Salary).ThenBy(x=>x.Name).ToList());
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var bindingList = new BindingList<Employee>(list.Select(x=>x).Take(5).ToList());
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            foreach (var item in list.Select(x => x.Id).TakeLast(3))
            {
                dt.Rows.Add(item);
            }
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string writePath = @"C:\Users\sokolovskyi\Desktop\test.txt";

            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    foreach (var item in list)
                    {
                        sw.WriteLine(item);
                    }
                }
            }
            catch (Exception test)
            {
                Console.WriteLine(test.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
          
        }
    }
}
