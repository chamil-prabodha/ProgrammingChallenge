using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.DataAccess;

namespace TicTacToe
{
    class Player
    {
        private string playerName = null;
        private string sign = null;
        private int score = 0;
        private int playCount = 0;
        private int winCount = 0;
        private float winPlayRatio = 0f;
        private string[,] tiles = new string[3, 3];
        private int moveCount = 0;

        public int MoveCount
        {
            get { return moveCount; }
            set { moveCount = value; }
        }

        public string[,] Tiles
        {
            get { return tiles; }
            set { tiles = value; }
        }

        public Player()
        {
            playCount = 0;
            winCount = 0;
        }



        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        public string Sign
        {
            get { return sign; }
            set { sign = value; }
        }

        public int WinCount
        {
            get { return winCount; }
            set { winCount = value; }
        }

        public int PlayCount
        {
            get { return playCount; }
            set { playCount = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public float WinPlayRatio
        {
            get { return winPlayRatio; }
            set { winPlayRatio = value; }
        }

        public bool addToDatabase()
        {
            return PlayerDA.getInstance().addPlayerToDB(this);
        }

        public void clearGame()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tiles[i, j] = null;
                }
            }
            moveCount = 0;
        }

    }
}
