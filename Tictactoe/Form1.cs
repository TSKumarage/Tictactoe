using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tictactoe
{
    public partial class Form1 : Form
    {
        private ComputeMove Computer;
        private String player;
        private int steps;
        private int check ;
        private String level = "esay";
        CDBC css =new CDBC();
        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
            Init();
            
            lbl_player.BackColor = System.Drawing.Color.Transparent;
            lbl_computer.BackColor = System.Drawing.Color.Transparent;
            pb_computer.BackColor = System.Drawing.Color.Transparent;
            pb_player.BackColor = System.Drawing.Color.Transparent;
            pb.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox2.BackColor = System.Drawing.Color.Transparent;
            label1.BackColor = System.Drawing.Color.Transparent;
            label2.BackColor = System.Drawing.Color.Transparent;
            label3.BackColor = System.Drawing.Color.Transparent;
            label4.BackColor = System.Drawing.Color.Transparent;
            label5.BackColor = System.Drawing.Color.Transparent;
            pb.Visible = false;
            label1.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            label4.Visible = false;
            label5.Visible = false;

        }
     
        public void setCheck(int i)
        {
            check = i;
        }
        public void setName(String name)
        {
            player = name;
            lbl_player.Text = name;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Init()
        {
            Computer = new ComputeMove();
            steps = 0;
            Console.WriteLine(check);
            if (check == 0)
            {
                Computer.Compute(level);
                Computer.play(Computer.get_computersMove(), 1);
                set_play(Computer.get_computersMove());
                steps = 1;
                label2.Text="X";
                label3.Text="O";
            }
            
        }

        public void userWon()
        {
            pb.Visible = true;
            label1.Visible = true;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
        }

        private void Button_Click(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            b.Enabled = false;
            steps += 2;
            b.Text = "X";
            Char x = b.Name[0];
            Char y = b.Name[1];
            Computer.play(new Square(x - 65, y - 49), 2);
            //Boolean check=(Computer.hasOWon()||Computer.hasXWon());
            Boolean check = Winner_Check();
            if (!check)
            {
                if (steps >= 9)
                {
                    MessageBox.Show("Game draw!!");
                    css.Update(player,0);
                    Clear_Board();
                    Init();

                }
                else
                {
                    Computer.Compute(level);
                    Computer.play(Computer.get_computersMove(), 1);
                    set_play(Computer.get_computersMove());
                    Winner_Check();
                    

                }


            }
            else
            {

            }

        }
        public void set_play(Square spot)
        {
            if (spot.get_x() == 0)
            {
                if (spot.get_y() == 0)
                {
                    A1.Text = "O";
                    A1.Enabled = false;
                }
                if (spot.get_y() == 1)
                {
                    A2.Text = "O";
                    A2.Enabled = false;
                }
                if (spot.get_y() == 2)
                {
                    A3.Text = "O";
                    A3.Enabled = false;
                }
            }
            if (spot.get_x() == 1)
            {
                if (spot.get_y() == 0)
                {
                    B1.Text = "O";
                    B1.Enabled = false;
                }
                if (spot.get_y() == 1)
                {
                    B2.Text = "O";
                    B2.Enabled = false;
                }
                if (spot.get_y() == 2)
                {
                    B3.Text = "O";
                    B3.Enabled = false;
                }
            }
            if (spot.get_x() == 2)
            {
                if (spot.get_y() == 0)
                {
                    C1.Text = "O";
                    C1.Enabled = false;
                }
                if (spot.get_y() == 1)
                {
                    C2.Text = "O";
                    C2.Enabled = false;
                }
                if (spot.get_y() == 2)
                {
                    C3.Text = "O";
                    C3.Enabled = false;
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form3 frm = new Form3();
            frm.Show();
           
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Team Active X", "About");
        }

        public void setLevel(String level)
        {
            this.level = level;
        }
        // Game Logic

        private Boolean Winner_Check()
        {
            if (A1.Text == A2.Text && A2.Text == A3.Text && A1.Text != "")
            {
                Show_Winner(A1, A2, A3);
                return true;
            }
            else if (B1.Text == B2.Text && B2.Text == B3.Text && B1.Text != "")
            {
                Show_Winner(B1, B2, B3);
                return true;
            }
            else if (C1.Text == C2.Text && C2.Text == C3.Text && C1.Text != "")
            {
                Show_Winner(C1, C2, C3);
                return true;
            }
            else if (A1.Text == B1.Text && B1.Text == C1.Text && A1.Text != "")
            {
                Show_Winner(A1, B1, C1);
                return true;
            }
            else if (A2.Text == B2.Text && B2.Text == C2.Text && A2.Text != "")
            {
                Show_Winner(A2, B2, C2);
                return true;
            }
            else if (A3.Text == B3.Text && B3.Text == C3.Text && A3.Text != "")
            {
                Show_Winner(A3, B3, C3);
                return true;
            }
            else if (A1.Text == B2.Text && B2.Text == C3.Text && A1.Text != "")
            {
                Show_Winner(A1, B2, C3);
                return true;
            }
            else if (A3.Text == B2.Text && B2.Text == C1.Text && A3.Text != "")
            {
                Show_Winner(A3, B2, C1);
                return true;
            }
            return false;
        }
        public async Task waiter()
        {
            await Task.Delay(1000);

        }
        private async void Show_Winner(Button b1, Button b2, Button b3)
        {
            if (b1.Text == "X" || b1.Text == "O")
            {
                steps = 0;
                b1.BackColor = Color.DarkOrange;
                b2.BackColor = Color.DarkOrange;
                b3.BackColor = Color.DarkOrange;

                if (b1.Text == "X")
                {
                    await waiter();
                    userWon();
                }
                else
                {
                    await waiter();
                    userWon();

                }
                b1.BackColor = Color.Azure;

                b2.BackColor = Color.Azure;

                b3.BackColor = Color.Azure;

                Clear_Board();
                Init();

            }
        }
        private void Clear_Board()
        {
            try
            {
                foreach (Control c in this.Controls.OfType<Button>())
                {

                    Button b = (Button)c;
                    b.Text = "";
                    b.Enabled = true;
                }
            }
            catch (Exception) { }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pb.Visible = false;
            label1.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
        }

        private void highScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4(player);
            frm.setName(player);
            frm.Show();
        }



        /*private int player=1;
        private int steps = 0;

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void Button_Click(object sender, EventArgs e)
        {
            
            Button b = (Button)sender;
            if (steps%2 == 0)
            {
                b.Text = "X";
                //player = 2;
            }
            else {
                b.Text = "O";
                //player = 1;
            }
            steps++;
            b.Enabled = false;
            if (!Winner_Check()&&steps==9) {
                MessageBox.Show("Game draw!!");
                Clear_Board();
            }
            
        }
        private Boolean Winner_Check() {
            if (A1.Text == A2.Text && A2.Text == A3.Text) {
                Show_Winner(A1, A2, A3);
                return true;
            }
            else if (B1.Text == B2.Text && B2.Text == B3.Text)
            {
                Show_Winner(B1, B2, B3);
                return true;
            }
            else if (C1.Text == C2.Text && C2.Text == C3.Text)
            {
                Show_Winner(C1,C2,C3);
                return true;
            }
            else if (A1.Text == B1.Text && B1.Text == C1.Text)
            {
                Show_Winner(A1, B1, C1);
                return true;
            }
            else if (A2.Text == B2.Text && B2.Text == C2.Text)
            {
                Show_Winner(A2,B2,C2);
                return true;
            }
            else if (A3.Text == B3.Text && B3.Text == C3.Text)
            {
                Show_Winner(A3, B3, C3);
                return true;
            }
            else if (A1.Text == B2.Text && B2.Text == C3.Text)
            {
                Show_Winner(A1, B2, C3);
                return true;
            }
            else if (A3.Text == B2.Text && B2.Text == C1.Text)
            {
                Show_Winner(A3, B2, C1);
                return true;
            }
            return false;
        }
        private void Show_Winner(Button b1,Button b2,Button b3) {
            if(b1.Text=="X"||b1.Text=="O"){
                steps = 0;
            b1.BackColor = Color.DarkOrange;
            b2.BackColor = Color.DarkOrange;
            b3.BackColor = Color.DarkOrange;
           
            if (b1.Text == "X")
            {
                MessageBox.Show("X wins !!","Tic Tac Toe");
            }
            else
            {
                MessageBox.Show("O wins !!","TickStyle Tac Toe");
            }
            b1.BackColor = Color.Azure;
           
            b2.BackColor = Color.Azure;
            
            b3.BackColor = Color.Azure;
           
            Clear_Board();
            
            }
        }
        private void Clear_Board() {
            try {
                foreach (Control c in this.Controls.OfType<Button>()) {
                    
                    Button b = (Button)c;
                    b.Text = "";
                    b.Enabled = true;
                }
            }
            catch(Exception){}
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear_Board();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Team Active X", "About");
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
        */
    }

}
