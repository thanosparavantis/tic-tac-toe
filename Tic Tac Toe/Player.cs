using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    class Player
    {
        private string mark;
        private Color color;
        private bool[,] moves;

        public Player(string mark, Color color)
        {
            this.mark = mark;
            this.color = color;
            moves = new bool[5, 5];
        }

        public bool MakeMove(Button button, int x, int y)
        {
            button.ForeColor = color;
            button.Text = mark;
            moves[x, y] = true;
            return false;
        }
    }
}
