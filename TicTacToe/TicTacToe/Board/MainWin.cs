using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class MainWin : Form
    {

        Board board;

        public ListView ListViewPlayers
        {
            get { return listViewPlayers; }
            set { listViewPlayers = value; }
        }

        public MainWin()
        {
            InitializeComponent();
            DisableTiles();

            board = new Board(this);
            cboxMode.Text = cboxMode.Items[0].ToString(); 
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPlayer1_Click(object sender, EventArgs e)
        {
            if (!txtPlayer1.Text.Equals(""))
            {
                board.addPlayer1(new Player());
                btnPlayer1.Enabled = false;
            }

            else
                MessageBox.Show("Enter Name First!");

        }

        private void btnPlayer2_Click(object sender, EventArgs e)
        {
            if (!txtPlayer2.Text.Equals(""))
            {
                board.addPlayer2(new Player());

                btnPlayer2.Enabled = false;
            }
            else
                MessageBox.Show("Enter Name First!");
        }

        private void scoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scores scorewin = new Scores();
            scorewin.ShowDialog();
            //this.Enabled = false;
        }

        public void EnableTiles()
        {
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;
        }

        public void DisableTiles()
        {
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            btn7.Enabled = false;
            btn8.Enabled = false;
            btn9.Enabled = false;
        }

        public TextBox TxtPlayer1
        {
            get { return txtPlayer1; }
            set { txtPlayer1 = value; }
        }

        public TextBox TxtPlayer2
        {
            get { return txtPlayer2; }
            set { txtPlayer2 = value; }
        }

        public ListView CurrentPlayerList
        {
            get { return listViewPlayers; }
            set { listViewPlayers = value; }
        }
        

        
        

       
    }
}
