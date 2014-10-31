using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe.DataAccess
{
    class Connector
    {
        private static MySqlConnection connection;

        public static void Init()
        {
            string constring = "server=db4free.net;port=3306;database=tictactoecl;user=admincl;password=myadmin";
            connection = new MySqlConnection(constring);
            try
            {
                Connect();
                LoadForm load = new LoadForm();
                load.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void Connect()
        {
            try
            {
                connection.Close();
                connection.Open();
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static  void CloseConnection()
        {
            connection.Close();
        }

        public static MySqlDataReader readFromDB(string query)
        {
            Connect();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public static DataView readTableFromDB(string query)
        {
            Connect();
            MySqlDataAdapter dataAdapt = new MySqlDataAdapter(query, connection);

            DataSet data = new DataSet();
            dataAdapt.Fill(data);

            DataView dataview = new DataView(data.Tables[0]);
            CloseConnection();

            return dataview;

        }

        public static bool writeToDB(string query)
        {
            MySqlCommand command = new MySqlCommand(query,connection);

            if (command.ExecuteNonQuery() > 0)
                return true;

            else
                return false;
        }
    }
}
