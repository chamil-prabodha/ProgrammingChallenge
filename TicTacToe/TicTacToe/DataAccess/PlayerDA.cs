using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

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
            string query = "INSERT INTO `tictactoecl`.`Players` (`PlayerName`,`Score`,`PlayedTimes`,`WinTimes`,`WinPlayRatio`) VALUES('" + newPlayer.PlayerName + "','" + newPlayer.Score + "','" + newPlayer.PlayCount + "','" + newPlayer.WinCount + "','" + newPlayer.WinPlayRatio + "');";
            Connector.Connect();
            bool success = Connector.writeToDB(query);
            Connector.CloseConnection();
            return success;
        }

        //Changes Made by Chamil
        public bool updateScore(Player currentPlayer)
        {
            string query = "UPDATE `tictactoecl`.`Players` SET `Score`='" + currentPlayer.AllTimeScore + "', `PlayedTimes` ='" + currentPlayer.PlayCount + "', `WinTimes` ='" + currentPlayer.WinCount + "', `WinPlayRatio` ='" + currentPlayer.WinPlayRatio + "' WHERE `Players`.`PlayerName` = '" + currentPlayer.PlayerName + "';";
            Connector.Connect();
            bool success = Connector.writeToDB(query);
            Connector.CloseConnection();
            return success;
        }
        //Changes Made by Chamil

        //Changes Made by Chamil
        public Player getPlayerFromDB(string playerName)
        {
            string query = "SELECT * FROM `tictactoecl`.`Players` WHERE `PlayerName` = '" + playerName + "';";

            Connector.Connect();
            MySqlDataReader reader = Connector.readFromDB(query);

            if (reader.Read())
            {
                Player currentPlayer = new Player();
                currentPlayer.PlayerName = reader.GetString(0);
                currentPlayer.AllTimeScore = reader.GetInt32(1);
                currentPlayer.PlayCount = reader.GetInt32(2);
                currentPlayer.WinCount = reader.GetInt32(3);
                currentPlayer.WinPlayRatio = reader.GetFloat(4);

                return currentPlayer;
            }

            return null;
        }
        //Changes Made by Chamil

        //New changes to PlayerDA class
        public DataView getAllScores()
        {
            string query = "SELECT * FROM `tictactoecl`.`Players`";
            return Connector.readTableFromDB(query);
        }

    }
}
