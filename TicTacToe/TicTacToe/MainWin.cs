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
        Player player1;
        Player player2;

        public MainWin()
        {
            InitializeComponent();
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPlayer1_Click(object sender, EventArgs e)
        {
            player1 = new Player(txtPlayer1.Text, "X");
            ListViewItem player = new ListViewItem(txtPlayer1.Text);
            player.SubItems.Add("X");
            player.SubItems.Add("0");

            listViewPlayers.Items.Add(player);
            btnPlayer1.Enabled = false;

        }

        private void btnPlayer2_Click(object sender, EventArgs e)
        {
            player2 = new Player(txtPlayer2.Text, "O");
            ListViewItem player = new ListViewItem(txtPlayer2.Text);
            player.SubItems.Add("O");
            player.SubItems.Add("0");

            listViewPlayers.Items.Add(player);
            btnPlayer2.Enabled = false;
        }

       

        

        
        

       
    }
}
