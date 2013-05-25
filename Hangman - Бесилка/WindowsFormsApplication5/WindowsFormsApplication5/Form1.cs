using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        OleDbConnection connection;

        public Form1()
        {
            InitializeComponent();

            
            connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=besilka.accdb;Persist Security Info=False;";


            listBox1.Hide();
            button4.Hide();
            pictureBox1.Hide();
            button6.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this);
            f2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();

            OleDbCommand getHighScore = new OleDbCommand();
            getHighScore.Connection = connection;
            getHighScore.CommandText = "SELECT * FROM Highscore ORDER BY Score ASC";

            OleDbDataReader highScoresReader = getHighScore.ExecuteReader();

            listBox1.Items.Clear();
            while (highScoresReader.Read())
            {
                string score = highScoresReader[1].ToString();
                string name = highScoresReader[2].ToString();

                listBox1.Items.Add(name + " " + score);
            }

            connection.Close();

            button6.Show();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button5.Hide();
            listBox1.Show();
            button4.Show();

            if (listBox1.Items.Count == 0)
            {
                button6.Enabled = false;
            }
            else
                button6.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Hide();
            button4.Hide();
            button1.Show();
            button2.Show();
            button3.Show();
            button5.Show();
            pictureBox1.Hide();
            button6.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button5.Hide();
            button4.Show();
            pictureBox1.Show();



        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("form1");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            connection.Open();

            OleDbCommand clearHighScore = new OleDbCommand();
            clearHighScore.Connection = connection;
            clearHighScore.CommandText = "DELETE FROM Highscore";
            clearHighScore.ExecuteNonQuery();

            connection.Close();

            listBox1.Items.Clear();
            button6.Enabled = false;

            
        }
    }
}
