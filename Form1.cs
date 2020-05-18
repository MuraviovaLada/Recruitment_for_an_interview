using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Combo
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\barba\source\repos\Combo\Database1.mdf;Integrated Security=True";
        List<string> clientList = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [Clients]", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    comboBox1.Items.Add(Convert.ToString(sqlReader["FIO"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                {
                    sqlReader.Close();
                }
            }


        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            sqlConnection.Close();
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clientList.Clear();
            /*string theName;*/

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            SqlCommand cusCommand = new SqlCommand("SELECT * FROM [Clients]", sqlConnection);
            SqlCommand empCommand = new SqlCommand("SELECT * FROM [Employees]", sqlConnection);

            try
            {
                sqlReader = await cusCommand.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    if (Convert.ToString(sqlReader["FIO"]) == comboBox1.Text)
                    {
                        clientList.Add(Convert.ToString(sqlReader["FIO"]));
                    }
                }
                /*
                sqlReader = await empCommand.ExecuteReaderAsync();
                int permScore = 0;
                int prevScore = 0;

                while (await sqlReader.ReadAsync())
                {
                    if (clientList[1] == Convert.ToString(sqlReader["Hobby"]))
                    {
                        prevScore += 1;
                    }
                    if (clientList[2] == Convert.ToString(sqlReader["Work"]))
                    {
                        prevScore += 2;
                    }
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                {
                    sqlReader.Close();
                }
            }

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            /*
            List<string> rus_male_names = new List<string>() {"Maksim", "Ivan", "Anton", "Stanislav"};
            List<string> rus_female_names = new List<string>();
            List<string> rus_surnames = new List<string>();



            string name = "Test Testovich";
            SqlCommand command = new SqlCommand("INSERT INTO [Clients] (FIO) VALUES (@Name)", sqlConnection);

            command.Parameters.AddWithValue("Name", name);

            await command.ExecuteNonQueryAsync();
            */
        }
    }
}
