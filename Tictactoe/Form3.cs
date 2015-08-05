using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tictactoe
{
    public partial class Form3 : Form

    {
        private MySqlDataReader dataReader;
        private Boolean check;
        CDBC con = new CDBC();
        public Form3()
        {
            InitializeComponent();
            CenterToScreen();
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel2.BackColor = System.Drawing.Color.Transparent;
            panel3.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox2.BackColor = System.Drawing.Color.Transparent;
            pictureBox3.BackColor = System.Drawing.Color.Transparent;
           
            panel2.Enabled = false;
            con.setform(this);
            init();
        }
        private void init()
        {
            List<String> ds = con.SelectDataSet("SELECT name FROM statics");
            try
            { 
                int i=0;
                for ( i = 0;i<ds.Count;i++ ){
                    comboBox1.Items.Add(ds.ElementAt(i));
   
                }
                    
            }
            catch (Exception ex)
            {

            }
        }
        public void setReader(MySqlDataReader dataR)
        {
            dataReader = dataR;
        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            String text=textBox1.Text;
            if (e.KeyChar == (char)13 && textBox1.Text!="")
            {
                con.Insert(text);
                comboBox1.Items.Clear();
                init();
                MessageBox.Show("A new player has been created.Select the new player from the list", "New Player");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Enabled = true;
            radioButton6.Enabled = true;
            radioButton7.Enabled = true;
            label7.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                Form2 frm = new Form2();
                frm.Show();
                this.Visible = false;
                
            }
            else
            {
                Form1 frm = new Form1();
                
                if (check == true)
                {
                    frm.setCheck(1);
                }
                else
                {
                    frm.setCheck(0);
                }
                if (radioButton1.Checked)
                {
                    frm.setLevel("Easy");
                }
                else if (radioButton3.Checked)
                {
                    frm.setLevel("Hard");
                }
                else
                {
                    frm.setLevel("Medium");
                }
                frm.setName(comboBox1.Text);
                frm.Show();
                this.Visible = false;
               // frm.setCDBC(con);
            }
            
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            radioButton6.Enabled = false;
            radioButton7.Enabled = false;
            label7.Enabled = false;
            panel2.Enabled = false;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            check = true; //human -true
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            check = false; //computer -false
        }
    }
}
