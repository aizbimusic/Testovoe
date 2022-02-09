using Microsoft.Data.SqlClient;

namespace Testovoe
{
    public partial class UpdateForm : Form
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection sql = new SqlConnection(Helper.sqlConnection);

        public int EmployeeId { get; set; }

        public int TextRate { get; set; }

        public string TextName { get; set; }
        internal Employee Employee { get; set; }

        internal UpdateForm(Employee emp)
        {
            InitializeComponent();
            Employee = emp;
            EmployeeId = emp.Id;
            tbName.Text = emp.Name;
            tbRate.Text = emp.Rate.ToString();
            tbEmployeeType.SelectedIndex = (int)emp.EmployeeType;
        }

        private void UptadeBtn_Click(object sender, EventArgs e)
        {
            if (tbName.Text != "" && tbRate.Text != "" && tbEmployeeType.Text != "")
            {
                try
                {
                    cmd = new SqlCommand("UPDATE Employee SET Name = @name, Rate = @rate, EmployeeType = @employeetype WHERE Id =" + EmployeeId, sql);
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

        private void tbName_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tbRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbEmployeeType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
