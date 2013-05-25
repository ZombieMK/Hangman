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
    public partial class Highscores : Form
    {
        int score2;
        Form oppener;
        Game oppener2;
        public Highscores(Form parentForm, Game parrent2Form, int score)
        {
            InitializeComponent();
            score2 = score;
            oppener = parentForm;
            oppener2 = parrent2Form;
            textBox2.Text = score.ToString();
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            oppener2.Close();
            oppener.Show();
            this.Close();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=besilka.accdb;Persist Security Info=False;";
            connection.Open();             

            OleDbCommand putScore = new OleDbCommand();
            putScore.Connection = connection;
            putScore.CommandText = "INSERT INTO Highscore (Score, Name) VALUES ('" + score2 + "', '" + textBox1.Text + "')";

            putScore.ExecuteNonQuery();
            
            connection.Close();

            oppener2.Close();
            oppener.Show();
            this.Close();
        }
    }
}
