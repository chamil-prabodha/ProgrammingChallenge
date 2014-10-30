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
        private Token[,] tiles = new Token[3, 3];

        public Token[,] Tiles
        {
            get { return tiles; }
            set { tiles = value; }
        }

        public void addPlayer1(Player player)
        {
            this.player1 = player;
            player1.PlayerName = window.TxtPlayer1.Text;
            player1.Sign = (Token)1;

            ListViewItem playerItem = new ListViewItem(player1.PlayerName);
            playerItem.SubItems.Add("X");
            playerItem.SubItems.Add(player1.Score.ToString());
            window.CurrentPlayerList.Items.Add(playerItem);

            if (PlayerDA.getInstance().getPlayerFromDB(player1.PlayerName) == null)
                PlayerDA.getInstance().addPlayerToDB(player1);

            else
            {
                player1 = PlayerDA.getInstance().getPlayerFromDB(player1.PlayerName);
                player1.Sign = (Token)1;
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
            player2.Sign = (Token)2;

            ListViewItem playerItem = new ListViewItem(player2.PlayerName);
            playerItem.SubItems.Add("O");
            playerItem.SubItems.Add(player2.Score.ToString());
            window.CurrentPlayerList.Items.Add(playerItem);

            if (PlayerDA.getInstance().getPlayerFromDB(player2.PlayerName) == null)
                PlayerDA.getInstance().addPlayerToDB(player2);

            else
            {
                player2 = PlayerDA.getInstance().getPlayerFromDB(player2.PlayerName);
                player2.Sign = (Token)2;
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


        public int Check_win( Player player, int x,int y){

            string Caption = "Congratulations";
            string Message = player.PlayerName + " Won!!!";
            player.MoveCount++;

            for (int i = 0; i < 3; i++)
            {
                if (tiles[x, i] != player.Sign)
                    break;
                if (i == 2)
                {
                    MessageBox.Show(Message, Caption);
                    player.Score += 10;
                    window.DisableTiles();
                    return 1;
                }

            }

            for (int i = 0; i < 3; i++)
            {
                if (tiles[i, y] != player.Sign)
                    break;
                if (i == 2)
                {
                    MessageBox.Show(Message, Caption);
                    player.Score += 10;
                    window.DisableTiles();
                    return 1;
                }
            }

            if (x == y)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (tiles[i, i] != player.Sign)
                        break;
                    if (i == 2)
                    { 
                        MessageBox.Show(Message, Caption);
                        player.Score += 10;
                        window.DisableTiles();
                        return 1;
                    }
                }

            }

            for (int i = 0; i < 3; i++)
            {
                if (tiles[i, 2 - i] != player.Sign)
                    break;
                if (i == 2)
                {
                    MessageBox.Show(Message, Caption);
                    player.Score += 10;
                    window.DisableTiles();
                    return 1;
                }
            }

            if (player.MoveCount == 9)
            {
                MessageBox.Show("Game Drawn");
                return 2;
            }

            return 0;
        }

        public void clearGame()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tiles[i, j] = 0;
                }
            }
            player1.MoveCount = 0;
            player2.MoveCount = 0;
        }

        public void updatePlayer()
        {
            window.ListViewPlayers.FindItemWithText(currentPlayer.PlayerName).SubItems[2].Text = currentPlayer.Score.ToString();
            PlayerDA.getInstance().updateScore(currentPlayer);
        }

        
    }
}
