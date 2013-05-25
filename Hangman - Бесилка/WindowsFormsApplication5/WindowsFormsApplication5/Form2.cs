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
    public partial class Form2 : Form
    {
        Form oppener;
        public Form2(Form parentForm)
        {
            InitializeComponent();
            oppener = parentForm;
           
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            oppener.Close();
            this.Close();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            oppener.Show();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Game f3 = new Game(oppener,this, 1);
            f3.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Game f3 = new Game(oppener, this, 2);
            f3.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Game f3 = new Game(oppener, this, 3);
            f3.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Game f3 = new Game(oppener, this, 4);
            f3.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Game f3 = new Game(oppener, this, 5);
            f3.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Game f3 = new Game(oppener, this, 6);
            f3.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Game f3 = new Game(oppener, this, 7);
            f3.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Game f3 = new Game(oppener, this, 8);
            f3.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button1.Show();
            button2.Show();
            button3.Show();
            button4.Show();
            button5.Show();
            button6.Show();
            button7.Show();
            button8.Show();
            button9.Show();
            button10.Show();
            button11.Hide();
        }

        
    }
}
