using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tictactoe
{
    class CDBC
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private Form3 f3;

        public void setform(Form3 f3)
        {
            this.f3 = f3;
        }
        void dbConn()
        {
            server = "localhost";
            database = "Tictactoe";
            uid = "root";
            password = "Veerjay@1";
            string connectionString = "SERVER=" + server + ";" +
                "DATABASE=" + database + ";" +
                "UID=" + uid + ";" +
                "PASSWORD=" + password + ";" +
                "PORT= 3306";
            connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                dbConn();
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password.");
                        break;
                }
                return false;
            }
        }

        public void Insert(String name1)
        {
            if (this.OpenConnection() == true)
            {
                String name=name1;
                int a=0;int b=0;int c=0;int d=0;
                String query = "INSERT INTO statics (name,times,win,loss,draw) VALUES (@name,@a,@b,@c,@d)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.Add("@name",name);
                cmd.Parameters.Add("@a",a);
                cmd.Parameters.Add("@b",b);
                cmd.Parameters.Add("@c",c);
                cmd.Parameters.Add("@d",d);
                try  
                {
                    cmd.ExecuteNonQuery();
                }
                catch(Exception e){

                }
            }
        }

        public void Update(string query,int state)

        {
               if (this.OpenConnection() == true)
            {
                
            if (state == 0)
            {
                MySqlDataReader datar = Select(query);
               // MySqlCommand cmd = new MySqlCommand();
                String name = query;
                MySqlCommand cmd =new MySqlCommand("UPDATE statics SET draw = @add,times=@time Where name = @fn",connection);
              
                int a = datar.GetInt16("draw") + 1;
                int b = datar.GetInt16("times") + 1;
                datar.Close();
                cmd.Parameters.AddWithValue("@fn", name);
                cmd.Parameters.AddWithValue("@time", b.ToString());
                cmd.Parameters.AddWithValue("@add", a.ToString());
                cmd.ExecuteNonQuery();
                
            }
            if (state == 1)
            {
                MySqlDataReader datar = Select(query);
               
                String name = query;
                MySqlCommand cmd = new MySqlCommand("UPDATE statics SET win = @add,times=@time Where name = @fn", connection);
                int a = datar.GetInt16("win") + 1;
                int b = datar.GetInt16("times") + 1;
                datar.Close();
                cmd.Parameters.AddWithValue("@fn", name);
                cmd.Parameters.AddWithValue("@time", b.ToString());
                cmd.Parameters.AddWithValue("@add", a.ToString());
                cmd.ExecuteNonQuery();
            }
            if (state == -1)
            {
                MySqlDataReader datar = Select(query);
      
                MySqlCommand cmd = new MySqlCommand("UPDATE statics SET loss =@add,times=@time Where name = @fn", connection);
                String name = query;
                int a = datar.GetInt16("loss") + 1;
                int b = datar.GetInt16("times") + 1;
                datar.Close();
                cmd.CommandText = "UPDATE statics SET loss =@add Where name = @fn";
                cmd.Parameters.AddWithValue("@fn", name);
                cmd.Parameters.AddWithValue("@time", b.ToString());
                cmd.Parameters.AddWithValue("@add", a.ToString());
                cmd.ExecuteNonQuery();
            }

          
               }
         
        }

        public void Delete(string query)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }

        public MySqlDataReader Select(string query)
        {
            if (this.OpenConnection() == true)
            {
                String test = "SELECT * FROM statics WHERE name=\"" + query + "\"";
                MySqlCommand cmd = new MySqlCommand(test , connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    return dataReader;
                }
                else
                {
                    MessageBox.Show("Sorry.....");
                }
                dataReader.Close();
            }
            return null;
        }
       
        public List<String> SelectDataSet(string query)
        {
            List<String> ds = new List<String>();
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while(dataReader.Read()){
                    ds.Add(dataReader.GetString("name"));
                }
                dataReader.Close();
                return ds;
            }
            else
            {
                
                return ds;
            }
        }
        public List<Player> SelectData(string query)
        {
            List<Player> ds = new List<Player>();
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Player p1 = new Player();
                    p1.setName(dataReader.GetString("name"));
                    p1.setWin(dataReader.GetInt16("win"));
                    p1.setLoss(dataReader.GetInt16("loss"));
                    p1.setDraw(dataReader.GetInt16("draw"));
                    p1.setTimes(dataReader.GetInt16("times"));
                    ds.Add(p1);
                }
                dataReader.Close();
                return ds;
            }
            else
            {
                return ds;
            }
        }
    }
}
