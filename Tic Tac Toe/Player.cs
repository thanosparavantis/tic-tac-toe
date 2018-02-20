
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    public class Player
    {
        // The display name of the player.
        public string Νame { get; private set; }

        // The mark of the player in the board, can be X or O.
        public string Μark { get; private set; }

        // The color of the player's mark in the board.
        public Color Color { get; private set; }

        // The number of wins achieved from this player.
        public int Score { get; private set; }

        // Whether this player is controlled by the computer.
        public bool IsComputer { get; private set; }

        // A 2-dimensional array that holds all moves made by this player for a specific match.
        public bool[,] Moves { get; private set; }

        // The X coordinate of the last move for a match.
        public int LastMoveX { get; private set; }

        // The Y coordinate of the last move for a specific match.
        public int LastMoveY { get; private set; }

        // The criteria that need to be fulfilled for the player to win the match.
        private WinGoal winGoal;

        // The criteria that need to be fulfilled for the match to end as a draw.
        private DrawGoal drawGoal;

        // A random reference used when the player plays as the computer.
        private Random random;

        public Player(string name, string mark, Color color, bool isComputer = false)
        {
            // Initialize and create new objects.

            this.Νame = name;
            this.Μark = mark;
            this.Color = color;
            this.IsComputer = isComputer;
            this.Moves = new bool[5, 5];
            this.LastMoveX = -1;
            this.LastMoveY = -1;
            this.winGoal = new WinGoal();
            this.drawGoal = new DrawGoal();
            this.random = new Random();
        }

        public void AddWin()
        {
            // Increment the score counter.
            this.Score++;
        }

        public MoveState MakeMove(Button button, int x, int y)
        {
            // Makes a move on the board.

            // Change the color and the text of the button.
            button.ForeColor = Color;
            button.Text = Μark;

            // Track the move on the board.
            this.Moves[x, y] = true;
            this.LastMoveX = x;
            this.LastMoveY = y;

            // Increase the global number of moves for this match.
            MainForm.MatchMoves++;

            // Update the win goal criteria to take into account this specific move.
            this.winGoal.UpdateCurrentMove(Moves, x, y);

            // Check if the move can result to a win, draw or just continue the match.
            if (this.winGoal.GoalReached())
                return MoveState.Win;
            else if (this.drawGoal.GoalReached())
                return MoveState.Draw;
            else
                return MoveState.Continue;
        }

        public void Reset()
        {
            // Reset the moves array and the X, Y coordinates of the last move.
            this.Moves = new bool[MainForm.X, MainForm.Y];
            this.LastMoveX = -1;
            this.LastMoveY = -1;
        }

        public Button SelectButton(Player otherPlayer, Button[,] buttons)
        {
            // The X and Y coordinates of the button that will be selected.
            int buttonX, buttonY;

            // The X and Y coordinates of the last move made by the other player.
            int lastX = otherPlayer.LastMoveX;
            int lastY = otherPlayer.LastMoveY;

            // A 2-dimensional array that holds all nearby X, Y coordinates
            // relative to the last move made by the opponent.
            //
            // Basically, we're retrieving all positions marked with asterisks below:
            //
            // *   *   *
            // *   ~   *
            // *   *   *

            // We are searching for a nearby slot to block our opponent.

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

            // We need to loop through all of our options and find a suitable spot
            // to make our next move. If all of the positions are blocked then we are
            // surrounded and we should make random move.

            // The list of valid options, we will select a random one afterwards.
            List<int[]> validOptions = new List<int[]>();

            // Loop through all elements.
            for (int i = 0; i < options.GetLength(0); i++)
            {
                // Get the X and Y coordinate of the position candidate.
                int x = options[i, 0];
                int y = options[i, 1];

                // Check if the X and Y coordinates are valid and not blocked/used.
                if (x >= 0 && y >= 0 && x != MainForm.X && y != MainForm.Y &&
                    !otherPlayer.Moves[x, y] && !this.Moves[x, y])
                {
                    // Add our option to the list.
                    validOptions.Add(new int[] {x, y});
                }
            }

            if (lastX >= 0 && lastY >= 0 && validOptions.Count > 0)
            {
                // If the player already made his first move and we're not surrounded
                // then we can make a move relative to his last one.

                // Get a random position relative to his last move.
                int[] choice = validOptions[this.random.Next(validOptions.Count)];
                buttonX = choice[0];
                buttonY = choice[1];
            }
            else
            {
                // Otherwise if we have no valid options or the computer player is playing first
                // we will just make a random move on the board.

                do
                {
                    buttonX = this.random.Next(MainForm.X);
                    buttonY = this.random.Next(MainForm.Y);

                    // We want to make sure our random move can be actually made.
                    // The button may have already been clicked, keep searching if that's the case.
                } while (otherPlayer.Moves[buttonX, buttonY] || this.Moves[buttonX, buttonY]);
            }

            // Return the button that was selected.
            return buttons[buttonX, buttonY];
        }

        public override string ToString()
        {
            // Overrides the default ToString() method, returns the name of the player instead.
            return this.Νame;
        }
    }
}
