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
    public partial class UpdateForm : Form
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection sql = new SqlConnection(Helper.sqlConnection);
        public int EmployeeId { get; set; }

        public UpdateForm(int employeeId)
        {
            EmployeeId = employeeId;
            InitializeComponent();
        }

        private void UptadeBtn_Click(object sender, EventArgs e)
        {
            if (tbName.Text != "" && tbRate.Text != "" && tbEmployeeType.Text != "")
            {
                try
                {
                    cmd = new SqlCommand("UPDATE Employee SET Name = @name, Rate = @rate, EmployeeType = @employeetype WHERE Id =" + EmployeeId+1, sql);
                    sql.Open();
                    cmd.Parameters.AddWithValue("@name", tbName.Text);
                    cmd.Parameters.AddWithValue("@rate", tbRate.Text);
                    cmd.Parameters.AddWithValue("@employeetype", tbEmployeeType.SelectedIndex);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно обновлена");
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

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
