using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testovoe
{
    public partial class EditForm : Form
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection sql = new SqlConnection(Helper.sqlConnection);

        public EditForm()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (tbName.Text != "" && tbId.Text != "" && tbRate.Text != "" && tbEmployeeType.Text!= "")
            {
                try 
                {
                    cmd = new SqlCommand("INSERT INTO Employee(Name, Id, Rate, EmployeeType)VALUES(@name, @id, @rate, @employeetype)", sql);
                    sql.Open();
                    cmd.Parameters.AddWithValue("@name", tbName.Text);
                    cmd.Parameters.AddWithValue("@id", tbId.Text);
                    cmd.Parameters.AddWithValue("@rate", tbRate.Text);
                    cmd.Parameters.AddWithValue("@employeetype", tbEmployeeType.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно добавлена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sql.Close();

                }

            }
            else
            {
                MessageBox.Show("Внесите корректные данные");
            }

        }
      
    }
}
