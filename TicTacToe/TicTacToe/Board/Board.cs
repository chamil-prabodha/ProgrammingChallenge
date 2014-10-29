using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.DataAccess;

namespace TicTacToe
{
    class Board
    {
        private Player player1 = null;
        private Player player2 = null;
        private Player currentPlayer;
        private bool boardEnabled;
        private MainWin window = null;

        public void addPlayer1(Player player)
        {
            this.player1 = player;
            player1.PlayerName = window.TxtPlayer1.Text;
            player1.Sign = "X";

            ListViewItem playerItem = new ListViewItem(player1.PlayerName);
            playerItem.SubItems.Add("X");
            playerItem.SubItems.Add(player1.Score.ToString());
            window.CurrentPlayerList.Items.Add(playerItem);

            if (PlayerDA.getInstance().getPlayerFromDB(player1.PlayerName) == null)
                PlayerDA.getInstance().addPlayerToDB(player1);

            else
            {
                player1 = PlayerDA.getInstance().getPlayerFromDB(player1.PlayerName);
                player1.Sign = "X";
            }


            if (player1 != null && player2 != null)
                window.EnableTiles();

            else
                window.DisableTiles();

            currentPlayer = player1;
        }

        public void addPlayer2(Player player)
        {
            this.player2 = player;
            player2.PlayerName = window.TxtPlayer2.Text;
            player2.Sign = "O";

            ListViewItem playerItem = new ListViewItem(player2.PlayerName);
            playerItem.SubItems.Add("O");
            playerItem.SubItems.Add(player2.Score.ToString());
            window.CurrentPlayerList.Items.Add(playerItem);

            if (PlayerDA.getInstance().getPlayerFromDB(player2.PlayerName) == null)
                PlayerDA.getInstance().addPlayerToDB(player2);

            else
            {
                player2 = PlayerDA.getInstance().getPlayerFromDB(player2.PlayerName);
                player2.Sign = "O";
            }
            if (player1 != null && player2 != null)
                window.EnableTiles();

            else
                window.DisableTiles();
        }

        public Player CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }

        public bool BoardEnabled
        {
            get { return boardEnabled; }
            set { boardEnabled = value; }
        }

        public Board(MainWin window)
        {
            this.window = window;
            boardEnabled = false;
        }

    }
}
