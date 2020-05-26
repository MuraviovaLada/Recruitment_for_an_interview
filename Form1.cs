/*
 * Sql for database table for clients. Sql for database table for employees is the same.
 * 
 * CREATE TABLE [dbo].[Clients] (
    [Id]          INT        IDENTITY (1, 1) NOT NULL,
    [FIO]         NCHAR (30) NULL,
    [Sex]         BIT        DEFAULT ((0)) NOT NULL,
    [Age]         INT        DEFAULT ((20)) NOT NULL,
    [Temperament] NCHAR (15) NULL,
    [Nationality] NCHAR (15) NULL,
    [Religion]    NCHAR (15) NULL,
    [Sociability] NCHAR (15) NULL,
    [Perception]  NCHAR (15) NULL,
    [Actions]     NCHAR (15) NULL,
    [Work]        NCHAR (20) NULL,
    [Military]    BIT        DEFAULT ((0)) NOT NULL,
    [Sport]       NCHAR (20) NULL,
    [Hobby]       NCHAR (20) NULL,
    [Smoking]     BIT        DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
 */

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

        List<string> temperament = new List<string>();
        private int FullSum = 30;

        /*
        List<List<string>> empList = new List<List<string>>();
        List<string> empListPart = new List<string>();*/

        public Form1()
        {
            InitializeComponent();

            /*Button for filling test database. Made it invisible for no need anymore, but to save the code.*/
            button1.Visible = false;

            /*Fill temperament for algorithm*/
            temperament.Add(Convert.ToString("sanguine"));
            temperament.Add(Convert.ToString("phlegmatic"));
            temperament.Add(Convert.ToString("melancholic"));
            temperament.Add(Convert.ToString("choleric"));
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [Clients]", sqlConnection);

            /*Filling combobox with names of clients to choose*/
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
            /*List for chosen cliend information*/
            clientList.Clear();

            lbFinal.Items.Clear();
            tbFinal.Text = " ";

            /*The name of the best candidate */
            string theName = "";

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
                   /*Getting all info of a chosen client*/
                    if (Convert.ToString(sqlReader["FIO"]) == comboBox1.Text)
                    {
                        clientList.Add(Convert.ToString(sqlReader["FIO"]));
                        clientList.Add(Convert.ToString(sqlReader["Sex"]));
                        clientList.Add(Convert.ToString(sqlReader["Age"]));
                        clientList.Add(Convert.ToString(sqlReader["Temperament"]));
                        clientList.Add(Convert.ToString(sqlReader["Nationality"]));
                        clientList.Add(Convert.ToString(sqlReader["Religion"]));
                        clientList.Add(Convert.ToString(sqlReader["Sociability"]));
                        clientList.Add(Convert.ToString(sqlReader["Perception"]));
                        clientList.Add(Convert.ToString(sqlReader["Actions"]));
                        clientList.Add(Convert.ToString(sqlReader["Work"]));
                        clientList.Add(Convert.ToString(sqlReader["Military"]));
                        clientList.Add(Convert.ToString(sqlReader["Sport"]));
                        clientList.Add(Convert.ToString(sqlReader["Hobby"]));
                        clientList.Add(Convert.ToString(sqlReader["Smoking"]));
                    }
                }
                sqlReader.Close();
                /*Starting to read employees table for a match*/
                sqlReader = await empCommand.ExecuteReaderAsync();

                /*To calculate the level of compliance*/
                int permScore = 0;
                int prevScore = 0;

                /*For age range*/
                int clientAge = 0;
                int workerAge = 0;

                //tbFinal.Text = clientList[2];

                while (await sqlReader.ReadAsync())
                {
                    if (clientList[1] == Convert.ToString(sqlReader["Sex"])) 
                    {
                        permScore = 0;

                        if (Convert.ToString(sqlReader["Temperament"]).Replace(" ", "") == temperament[0] ||
                            Convert.ToString(sqlReader["Temperament"]).Replace(" ", "") == temperament[1] ||
                            Convert.ToString(sqlReader["Temperament"]).Replace(" ", "") == temperament[2] &&
                            clientList[3].Replace(" ", "") == temperament[2] ||
                            Convert.ToString(sqlReader["Temperament"]).Replace(" ", "") == temperament[3] &&
                            clientList[3].Replace(" ", "") == temperament[0] ||
                                Convert.ToString(sqlReader["Temperament"]).Replace(" ", "") == temperament[3] &&
                            clientList[3].Replace(" ", "") == temperament[1]
                            )
                        {
                            clientAge = Convert.ToInt32(clientList[2].Replace(" ", ""));
                            workerAge = Convert.ToInt32(Convert.ToString(sqlReader["Age"]));
                            if (workerAge >= clientAge-5 && workerAge <= clientAge + 5)
                            {
                                permScore += 3;
                            }
                            if (Convert.ToString(sqlReader["Nationality"]) == clientList[4])
                            {
                                permScore += 3;
                            }
                            if (Convert.ToString(sqlReader["Religion"]) == clientList[5])
                            {
                                permScore += 4;
                            }
                            if (Convert.ToString(sqlReader["Sociability"]) == clientList[6])
                            {
                                permScore += 4;
                            }
                            if (Convert.ToString(sqlReader["Perception"]) == clientList[7])
                            {
                                permScore += 4;
                            }
                            if (Convert.ToString(sqlReader["Actions"]) == clientList[8])
                            {
                                permScore += 4;
                            }
                            if (Convert.ToString(sqlReader["Work"]) == clientList[9])
                            {
                                permScore += 1;
                            }
                            if (Convert.ToString(sqlReader["Military"]) == clientList[10])
                            {
                                permScore += 1;
                            }
                            if (Convert.ToString(sqlReader["Sport"]) == clientList[11])
                            {
                                permScore += 2;
                            }

                            if (Convert.ToString(sqlReader["Hobby"]) == clientList[12])
                            {
                                permScore += 2;
                            }

                            if (Convert.ToString(sqlReader["Smoking"]) == clientList[13])
                            {
                                permScore += 2;
                            }

                            lbFinal.Items.Add(Convert.ToString(sqlReader["FIO"]).Replace(" ", "") + " Score: " + Convert.ToString((FullSum / 10 * permScore) + "%"));

                            if (permScore >= prevScore)
                            {
                                theName = Convert.ToString(sqlReader["FIO"]).Replace(" ", "");
                                prevScore = permScore;
                                tbFinal.Text = theName;
                                tbFinalScore.Text = Convert.ToString((FullSum / 10 * permScore) + "%");
                            }
                        }
                    }
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

        private async void button1_Click(object sender, EventArgs e)
        {
            /*

            string[] nationality = { "russian", "russian", "armenian" };
            string[] sex = { "male", "male", "female" };
            string[] religion = { "hristianity", "atheism" };
            string[] socialization = { "extravert", "introvert" };
            string[] perseption = { "thinker", "sentient" };
            string[] action = { "process", "result" };
            string[] work = { "programmer", "designer", "manager" };
            string[] sport = { "nothing", "football", "hockey" };
            string[] hobby = { "travel", "club", "skill" };
            string[] temperament = { "sanguine", "sanguine", "sanguine", "choleric", "phlegmatic", "phlegmatic", "melancholic" };

            int age = 0;
            byte military = 0;
            byte smoking = 0;
            byte gender = 0;
            byte[] rndByte = { 0, 1 };


            string[] rus_male_names = { "Maksim", "Ivan", "Anton", "Stanislav" };
            string[] rus_male_fath_names = { "Maksimovich", "Ivanov", "Antonovich", "Stanislavovich" };

            string[] rus_female_names = { "Elena", "Olga", "Ekaterina", "Nataliya" };
            string[] rus_female_fath_names = { "Maksimovna", "Ivanova", "Antonovna", "Stanislavovna" };

            string[] rus_surnames = { "Korolenko", "Duma", "Chernih", "Kruchenih" };

            string[] arm_male_names = { "Ayk", "Tigran", "Samvel", "Armen", "Aram", "Ashot", "Gebork", "Vage" };

            string[] arm_female_names = { "Ani", "Gayane", "Mariam", "Lilit", "Asmik", "Goar", "Karine", "Anush", "Arevik", };

            string[] arm_surnames = { "Ayki", "Tigrani", "Samveli", "Armeni", "Arami", "Ashoti", "Geborki", "Vagei" };
            string[] arm_fath_names = { "Aykyan", "Tigranyan", "Samvelyan", "Armenyan", "Aramyan", "Ashotyan", "Geborkyan", "Vageyan" };


            var rnd = new Random();
            for (int i = 0; i <= 60; i++)
            {
                int nationalityIndex = rnd.Next(nationality.Length);
                int sexIndex = rnd.Next(sex.Length);

                string FIO = "none";

                if (nationality[nationalityIndex] == "russian")
                {
                    if (sex[sexIndex] == "male")
                    {
                        gender = 0;
                        int maleNameIndex = rnd.Next(rus_male_names.Length);
                        int maleFathNameIndex = rnd.Next(rus_male_fath_names.Length);
                        int surnamesIndex = rnd.Next(rus_surnames.Length);

                        FIO = rus_surnames[surnamesIndex] + " " + rus_male_names[maleNameIndex]
                            + " " + rus_male_fath_names[maleFathNameIndex];
                    }
                    else
                    {
                        gender = 1;
                        int femaleNameIndex = rnd.Next(rus_female_names.Length);
                        int femaleFathNameIndex = rnd.Next(rus_female_fath_names.Length);
                        int surnamesIndex = rnd.Next(rus_surnames.Length);

                        FIO = rus_surnames[surnamesIndex] + " " + rus_female_names[femaleNameIndex]
                            + " " + rus_female_fath_names[femaleFathNameIndex];
                    }
                }
                else
                {
                    if (sex[sexIndex] == "male")
                    {
                        gender = 0;
                        int maleNameIndex = rnd.Next(arm_male_names.Length);
                        int maleFathNameIndex = rnd.Next(arm_fath_names.Length);
                        int surnamesIndex = rnd.Next(arm_surnames.Length);

                        FIO = arm_surnames[surnamesIndex] + " " + arm_male_names[maleNameIndex]
                            + " " + arm_fath_names[maleFathNameIndex];
                    }
                    else
                    {
                        gender = 1;
                        int femaleNameIndex = rnd.Next(arm_female_names.Length);
                        int femaleFathNameIndex = rnd.Next(arm_fath_names.Length);
                        int surnamesIndex = rnd.Next(arm_surnames.Length);

                        FIO = arm_surnames[surnamesIndex] + " " + arm_female_names[femaleNameIndex]
                            + " " + arm_fath_names[femaleFathNameIndex];
                    }
                }

                age = rnd.Next(20, 46);

                int temperamentIndex = rnd.Next(temperament.Length);
                int religionIndex = rnd.Next(religion.Length);
                int socializationIndex = rnd.Next(socialization.Length);
                int perseptionIndex = rnd.Next(perseption.Length);
                int actionIndex = rnd.Next(action.Length);
                int workIndex = rnd.Next(work.Length);
                int sportIndex = rnd.Next(sport.Length);
                int hobbyIndex = rnd.Next(hobby.Length);

                if (sex[sexIndex] == "male")
                {
                    int militaryIndex = rnd.Next(rndByte.Length);
                    military = rndByte[militaryIndex];
                }
                else
                {
                    military = 0;
                }

                int smokingIndex = rnd.Next(rndByte.Length);
                smoking = rndByte[smokingIndex];

                SqlCommand command = new SqlCommand("INSERT INTO [Employees] " +
                    "(FIO, Sex, Age, Temperament, Nationality, Religion, Sociability, Perception, Actions, Work, Military, Sport, Hobby, Smoking) VALUES " +
                    "(@FIO, @sex, @Age, @Temperament, @nationality, @religion, @socialization, @perseption, @action, @work, @military, @sport, @hobby, @smoking)", sqlConnection);

                command.Parameters.AddWithValue("FIO", FIO);
                command.Parameters.AddWithValue("sex", gender);
                command.Parameters.AddWithValue("Age", age);
                command.Parameters.AddWithValue("Temperament", temperament[temperamentIndex]);
                command.Parameters.AddWithValue("nationality", nationality[nationalityIndex]);
                command.Parameters.AddWithValue("religion", religion[religionIndex]);
                command.Parameters.AddWithValue("socialization", socialization[socializationIndex]);
                command.Parameters.AddWithValue("perseption", perseption[perseptionIndex]);
                command.Parameters.AddWithValue("action", action[actionIndex]);
                command.Parameters.AddWithValue("work", work[workIndex]);
                command.Parameters.AddWithValue("military", military);
                command.Parameters.AddWithValue("sport", sport[sportIndex]);
                command.Parameters.AddWithValue("hobby", hobby[hobbyIndex]);
                command.Parameters.AddWithValue("smoking", smoking);

                await command.ExecuteNonQueryAsync();
            }*/
        }
    }
}
