
using System;
using System.Drawing;
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

        public bool[,] Moves { get; private set; }

        public int LastMoveX { get; private set; }

        public int LastMoveY { get; private set; }

        private WinGoal winGoal;
        private DrawGoal drawGoal;
        private Random random;

        public Player(string name, string mark, Color color, bool isComputer = false)
        {
            Νame = name;
            Μark = mark;
            Color = color;
            IsComputer = isComputer;
            Moves = new bool[5, 5];
            LastMoveX = -1;
            LastMoveY = -1;
            winGoal = new WinGoal();
            drawGoal = new DrawGoal();
            random = new Random();
        }

        public Button SelectButton(Player otherPlayer, Button[,] buttons)
        {
            int buttonX, buttonY;
            int lastX = otherPlayer.LastMoveX;
            int lastY = otherPlayer.LastMoveY;

            if (lastX >= 0 && lastY >= 0)
            {
                buttonX = lastX;
                buttonY = lastY;

                int[,] options = 
                    {
                        { lastX, lastY + 1 },
                        { lastX + 1, lastY },
                        { lastX, lastY - 1 },
                        { lastX - 1, lastY },
                        { lastX + 1, lastY + 1 },
                        { lastX - 1, lastY - 1 },
                        { lastX + 1, lastY - 1 },
                        { lastX - 1, lastY + 1 },
                    };

                bool isTrapped = true;

                for (int i = 0; i < options.GetLength(0); i++)
                {
                    int x = options[i, 0];
                    int y = options[i, 1];

                    if (x > 0 && y > 0 && x != MainForm.X && y != MainForm.Y && 
                        !otherPlayer.Moves[x, y] && !Moves[x, y])
                    {
                        isTrapped = false;
                        break;
                    }
                }

                if (!isTrapped)
                {
                    do
                    {
                        int index = random.Next(0, options.GetLength(0));
                        buttonX = options[index, 0];
                        buttonY = options[index, 1];
                    } while (buttonX < 0 || buttonY < 0 ||
                        buttonX == MainForm.X || buttonY == MainForm.Y ||
                        otherPlayer.Moves[buttonX, buttonY] || Moves[buttonX, buttonY]);
                }
                else
                {
                    do
                    {
                        buttonX = random.Next(0, MainForm.X);
                        buttonY = random.Next(0, MainForm.Y);
                    } while (otherPlayer.Moves[buttonX, buttonY] || Moves[buttonX, buttonY]);
                }
            }
            else
            {
                do
                {
                    buttonX = random.Next(0, MainForm.X);
                    buttonY = random.Next(0, MainForm.Y);
                } while (otherPlayer.Moves[buttonX, buttonY] || Moves[buttonX, buttonY]);
            }

            return buttons[buttonX, buttonY];
        }

        public MoveState MakeMove(Button button, int x, int y)
        {
            button.ForeColor = Color;
            button.Text = Μark;

            Moves[x, y] = true;
            LastMoveX = x;
            LastMoveY = y;

            MainForm.MatchMoves++;

            winGoal.UpdateCurrentMove(Moves, x, y);

            if (winGoal.GoalReached())
                return MoveState.Win;
            else if (drawGoal.GoalReached())
                return MoveState.Draw;
            else
                return MoveState.Continue;
        }
        
        public void AddWin()
        {
            Score++;
        }

        public void Reset()
        {
            Moves = new bool[MainForm.X, MainForm.Y];
            LastMoveX = -1;
            LastMoveY = -1;
        }

        public override string ToString()
        {
            return Νame;
        }
    }
}
