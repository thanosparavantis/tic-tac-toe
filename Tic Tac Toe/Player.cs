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
            return CheckHorizontal(x) || CheckVertical(y) || CheckDiagLeft() || CheckDiagRight();
        }

        private bool CheckHorizontal(int x)
        {
            for (int i = 0; i < MainForm.Y; i++)
            {
                if (!moves[x, i])
                    return false;
            }

            return true;
        }

        private bool CheckVertical(int y)
        {
            for (int i = 0; i < MainForm.X; i++)
            {
                if (!moves[i, y])
                    return false;
            }

            return true;
        }

        private bool CheckDiagLeft()
        {
            for (int i = 0; i < MainForm.X; i++)
            {
                if (!moves[i, i])
                    return false;
            }

            return true;
        }

        private bool CheckDiagRight()
        {
            for (int i = 0; i < MainForm.X; i++)
            {
                if (!moves[i, (MainForm.X - 1) - i])
                    return false;
            }

            return true;
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
