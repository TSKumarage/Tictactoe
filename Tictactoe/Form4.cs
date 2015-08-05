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
    public partial class Form4 : Form
    {
       // private String name;
        CDBC con = new CDBC();

        public Form4(String name)
        {
            InitializeComponent();
            CenterToScreen();
            label1.BackColor = System.Drawing.Color.Transparent;
            label2.BackColor = System.Drawing.Color.Transparent;
            panel1.BackColor = System.Drawing.Color.Transparent;
            //dataGridView1.BackColor = System.Drawing.Color.Transparent;
           // dataGridView2.BackColor = System.Drawing.Color.Transparent;
            
            List<Player> players = con.SelectData("SELECT * FROM statics");
            for (int i = 0; i < players.Count; i++)
            {
                players.ElementAt(i).setRatio(players.ElementAt(i).getWin() * 5 + players.ElementAt(i).getDraw() * 2 - players.ElementAt(i).getLoss());
            }


            List<Player> SortedList = players.OrderBy(o => o.getRatio()).ToList();

            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "Rank";
            dataGridView1.Columns[1].Name = "Name";
            dataGridView1.Columns[2].Name = "Times Played";
            dataGridView1.Columns[3].Name = "Win";
            dataGridView1.Columns[4].Name = "Loss";
            dataGridView1.Columns[5].Name = "Draw";
            dataGridView1.Columns[6].Name = "Points";
            for (int i = players.Count-1; i >=0; i--)
                
            {
                string[] row = new string[] { (players.Count-i).ToString(),SortedList.ElementAt(i).getName(), SortedList.ElementAt(i).getTimes().ToString(), 
                    SortedList.ElementAt(i).getWin().ToString(), SortedList.ElementAt(i).getLoss().ToString(), 
                    SortedList.ElementAt(i).getDraw().ToString(),SortedList.ElementAt(i).getRatio().ToString()};
                dataGridView1.Rows.Add(row);
            }

            dataGridView2.ColumnCount = 7;
            dataGridView2.Columns[0].Name = "Rank";
            dataGridView2.Columns[1].Name = "Name";
            dataGridView2.Columns[2].Name = "Times Played";
            dataGridView2.Columns[3].Name = "Win";
            dataGridView2.Columns[4].Name = "Loss";
            dataGridView2.Columns[5].Name = "Draw";
            dataGridView2.Columns[6].Name = "Points";
            for (int i = players.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(name);
                if (SortedList.ElementAt(i).getName().Equals(name))
                {
                    string[] row = new string[] { (players.Count-i).ToString(),SortedList.ElementAt(i).getName(), SortedList.ElementAt(i).getTimes().ToString(), 
                    SortedList.ElementAt(i).getWin().ToString(), SortedList.ElementAt(i).getLoss().ToString(), 
                    SortedList.ElementAt(i).getDraw().ToString(),SortedList.ElementAt(i).getRatio().ToString()};
                    dataGridView2.Rows.Add(row);
                }
            }
                

        }
        public void setName(String nameu)
        {
           // this.name = nameu;
        }
        private void Form4_Load(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
