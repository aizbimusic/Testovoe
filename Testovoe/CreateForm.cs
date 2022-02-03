using Microsoft.Data.SqlClient;

namespace Testovoe
{
    public partial class CreateForm : Form
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection sql = new SqlConnection(Helper.sqlConnection);

        public CreateForm()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (tbName.Text != ""  && tbRate.Text != "" && tbEmployeeType.Text!= "")
            {
                try 
                {
                    cmd = new SqlCommand("INSERT INTO Employee(Name, Rate, EmployeeType)VALUES(@name, @rate, @employeetype)", sql);
                    sql.Open();
                    cmd.Parameters.AddWithValue("@name", tbName.Text);
                    cmd.Parameters.AddWithValue("@rate", tbRate.Text);
                    cmd.Parameters.AddWithValue("@employeetype", tbEmployeeType.SelectedIndex);
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

        private void tbEmployeeType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
