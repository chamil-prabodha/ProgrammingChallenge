using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TicTacToe.DataAccess
{
    class PlayerDA
    {
        private static PlayerDA instance = null;

        public static PlayerDA getInstance()
        {
            if (instance == null)
                instance = new PlayerDA();

            return instance;

        }

        public bool addPlayerToDB(Player newPlayer)
        {
            string query = "INSERT INTO `tictactoe`.`players` (`PlayerName`,`Score`,`PlayedTimes`,`WinTimes`,`WinPlayRatio`) VALUES('" + newPlayer.PlayerName + "','" + newPlayer.Score + "','" + newPlayer.PlayCount + "','" + newPlayer.WinCount + "','" + newPlayer.WinPlayRatio + "');";
            Connector.Connect();
            bool success = Connector.writeToDB(query);
            Connector.CloseConnection();
            return success;
        }

        public bool updateScore(Player currentPlayer)
        {
            string query = "UPDATE `tictactoe`.`players` SET `Score`='" + currentPlayer.Score + "', `PlayTimes` ='" + currentPlayer.PlayCount + "', `WinTimes` ='" + currentPlayer.WinCount + "', `WinPlayRatio` ='" + currentPlayer.WinPlayRatio + "' WHERE `players`.`PlayerName` = '" + currentPlayer.PlayerName + "';";
            Connector.Connect();
            bool success = Connector.writeToDB(query);
            Connector.CloseConnection();
            return success;
        }

        public Player getPlayerFromDB(string playerName)
        {
            string query = "SELECT * FROM `tictactoe`.`players` WHERE `PlayerName` = '" + playerName + "';";

            Connector.Connect();
            MySqlDataReader reader = Connector.readFromDB(query);

            if (reader.Read())
            {
                Player currentPlayer = new Player();
                currentPlayer.PlayerName = reader.GetString(0);
                currentPlayer.Score = reader.GetInt32(1);
                currentPlayer.PlayCount = reader.GetInt32(2);
                currentPlayer.WinCount = reader.GetInt32(3);
                currentPlayer.WinPlayRatio = reader.GetFloat(4);

                return currentPlayer;
            }

            return null;
        }

    }
}
