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
        private string name;
        private string mark;
        private Color color;
        private Label nameLabel, scoreLabel;
        private bool[,] moves;
        private int score;

        public Player(string name, string mark, Color color, Label nameLabel, Label scoreLabel)
        {
            this.name = name;
            this.mark = mark;
            this.color = color;
            this.nameLabel = nameLabel;
            this.scoreLabel = scoreLabel;

            moves = new bool[5, 5];
            nameLabel.Text = name;
            scoreLabel.Text = score.ToString();
        }

        public bool MakeMove(Button button, int x, int y)
        {
            button.ForeColor = color;
            button.Text = mark;
            moves[x, y] = true;
            return IsWinMove(x, y);
        }

        private bool IsWinMove(int x, int y)
        {
            bool wonX = true;

            for (int j = 0; j < 5; j++)
            {
                if (! moves[x, j])
                {
                    wonX = false;
                    break;
                }
            }

            bool wonY = true;

            for (int i = 0; i < 5; i++)
            {
                if (! moves[i, y])
                {
                    wonY = false;
                    break;
                }
            }

            return wonX || wonY;
        }

        public void AddWin()
        {
            score++;
            scoreLabel.Text = score.ToString();
        }

        public void ResetMoves()
        {
            moves = new bool[5, 5];
        }

        public override string ToString()
        {
            return name;
        }
    }
}
