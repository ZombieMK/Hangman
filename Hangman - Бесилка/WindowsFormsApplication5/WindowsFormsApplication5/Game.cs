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
    public partial class Game : Form
    {
        string choosenWord;
        PictureBox head = new PictureBox();
        List<PictureBox> pictures;
        List<PictureBox> picturesStart;
        int score;
        int buttonnum;
        string pomosen;
        string pomosenZaGreska;

        Form2 oppener2;
        Form oppener;
        public Game(Form parentForm1, Form2 parentForm, int pom)
        {
            InitializeComponent();
            score = 0;
            oppener2 = parentForm;
            oppener = parentForm1;
            pomosen += '1';
            pomosenZaGreska += '1';

            pictures = new List<PictureBox>();
            picturesStart = new List<PictureBox>();
            buttonnum = pom;

            pictureBox1.Hide();
            pictureBox2.Hide();
            pictureBox3.Hide();
            pictureBox4.Hide();
            pictureBox5.Hide();

            // Head


            head.Size = new Size(50, 50);
            head.Location = new Point(347, 130);
            head.BackColor = System.Drawing.Color.Transparent;
            string loc = @"Heads\head" + pom + ".png";
            head.Image = Image.FromFile(loc);
            this.Controls.Add(head);
            head.Hide();


        }

        private int charCount(string zbor, char karakter)
        {
            int counter = 0;

            for (int i = 0; i < zbor.Length; i++)
            {
                if (zbor[i] == karakter)
                    counter++;
            }

            return counter;
        }

        private void startGame(int type)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=besilka.accdb;Persist Security Info=False;";
            connection.Open();

            OleDbCommand getWords = new OleDbCommand();
            getWords.Connection = connection;
            getWords.CommandText = "SELECT * FROM Words WHERE ID_Category = " + type.ToString();

            OleDbDataReader wordsReader = getWords.ExecuteReader();

            List<string> words = new List<string>();

            while (wordsReader.Read())
            {
                string tmoWord = wordsReader[2].ToString();
                words.Add(tmoWord);
            }

            connection.Close();

            Random nrnd = new Random();
            choosenWord = words[nrnd.Next(words.Count())];

            

            pictures.Clear();
            picturesStart.Clear();

            for (int i = 0; i < choosenWord.Length; i++)
            {
                if (choosenWord[i] == ' ')
                {
                    PictureBox emptyPC = new PictureBox();
                    picturesStart.Add(emptyPC);
                    pictures.Add(emptyPC);
                    continue;
                }

                // Picture Start
                PictureBox tmpPicure = new PictureBox();
                tmpPicure.Size = new Size(40, 40);
                tmpPicure.Location = new Point(380 + i * 35, 400);
                tmpPicure.Image = Image.FromFile(@"Letters\_.png");
                tmpPicure.BackColor = System.Drawing.Color.Transparent;
                tmpPicure.Show();
                picturesStart.Add(tmpPicure);
                this.Controls.Add(tmpPicure);

                // Picture

                PictureBox realPicture = new PictureBox();
                realPicture.Size = new Size(40, 40);
                realPicture.Location = new Point(380 + i * 35, 400);
                realPicture.BackColor = System.Drawing.Color.Transparent;
                realPicture.Hide();
                string location = @"Letters\" + choosenWord[i] + ".png";
                realPicture.Image = Image.FromFile(location);

                pictures.Add(realPicture);
                this.Controls.Add(realPicture);
            }

        }

        private void Game_Load(object sender, EventArgs e)
        {
            startGame(buttonnum);
        }

        private void Game_KeyPress(object sender, KeyPressEventArgs e)
        {
            char tmpKey = Char.ToLower(e.KeyChar);

            bool found = false;

            for (int i = 0; i < choosenWord.Length; i++)
            {
                if (choosenWord[i] == tmpKey)
                {
                    found = true;
                    pictures[i].Show();
                    picturesStart[i].Hide();
                }
            }

            if (found)
            {
                bool flag = false;
                int br = charCount(choosenWord, tmpKey);
                int br2 = charCount(pomosen, tmpKey);

                for (int x = 0; x < pomosen.Length; x++)
                {
                    if (pomosen[x] == tmpKey)
                    {
                        flag = true;
                    }
                }

                if (!flag)
                {
                    for (int i = 0; i < br; i++)
                    {
                        pomosen = pomosen + tmpKey;
                    }
                    score += (int)tmpKey * 100 + 20;
                    flag = false;
                }
                else if (flag)
                    MessageBox.Show("You already tried that letter!");

                int pom3 = 0;
                for (int i = 0; i < choosenWord.Length; i++)
                {
                    if (choosenWord[i] == ' ')
                        pom3++;
                }

                if (pomosen.Length - 1 == choosenWord.Length - pom3)
                {
                    Highscores high = new Highscores(oppener, this, score);
                    high.Show();
                }
            }
            else
            {
                bool flag = false;

                for (int x = 0; x < pomosenZaGreska.Length; x++)
                {
                    if (pomosenZaGreska[x] == tmpKey)
                    {
                        flag = true;
                        MessageBox.Show("You already tried that letter!");
                    }
                }

                if (!flag)
                {
                    pomosenZaGreska = pomosenZaGreska + tmpKey;
                    score -= (int)tmpKey * 20 + 20;
                    flag = false;
                }

                if (pomosenZaGreska.Length - 1 == 1)
                    head.Show();
                else if (pomosenZaGreska.Length - 1 == 2)
                    pictureBox1.Show();
                else if (pomosenZaGreska.Length - 1 == 3)
                    pictureBox2.Show();
                else if (pomosenZaGreska.Length - 1 == 4)
                    pictureBox3.Show();
                else if (pomosenZaGreska.Length - 1 == 5)
                    pictureBox4.Show();
                else if (pomosenZaGreska.Length - 1 == 6)
                {
                    pictureBox5.Show();

                    MessageBox.Show("Game Over!");
                    oppener.Show();
                    oppener2.Close();
                    this.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oppener2.Show();
            this.Close();
        }


    }
}
