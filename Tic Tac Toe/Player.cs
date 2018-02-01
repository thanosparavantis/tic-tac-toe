using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public class Player
    {
        public string Νame { get; private set; }

        public string Μark { get; private set; }

        public Color Color { get; private set; }

        public int Score { get; private set; }

        public bool IsComputer { get; private set; }

        private bool[,] moves;

        public Player(string name, string mark, Color color, bool isComputer = false)
        {
            Νame = name;
            Μark = mark;
            Color = color;
            IsComputer = isComputer;

            moves = new bool[5, 5];
        }
        
        public MoveState MakeMove(Button button, int x, int y)
        {
            button.ForeColor = Color;
            button.Text = Μark;

            moves[x, y] = true;
            MainForm.MatchMoves++;

            if (CheckHorizontal(x) || CheckVertical(y) || CheckDiagLeft() || CheckDiagRight())
            {
                return MoveState.Win;
            }
            else if (CheckDraw())
            {
                return MoveState.Draw;
            }
            else
            {
                return MoveState.Continue;
            }
        }

        // Win detection

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

        // Draw detection

        private bool CheckDraw()
        {
            return MainForm.MatchMoves == MainForm.X * MainForm.Y;
        }
        
        public void AddWin()
        {
            Score++;
        }

        public void ResetMoves()
        {
            moves = new bool[5, 5];
        }

        public override string ToString()
        {
            return Νame;
        }
    }
}
