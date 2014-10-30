using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.DataAccess;

namespace TicTacToe
{
    public partial class Scores : Form
    {
        public Scores()
        {
            InitializeComponent();
            //Changes Made by Chamil
            dataGridViewScores.DataSource = PlayerDA.getInstance().getAllScores();
            //Changes Made by Chamil
        }
    }
}
