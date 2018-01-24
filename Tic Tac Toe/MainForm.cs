using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class MainForm : Form
    {
        private Button[,] buttons;

        // The two player references of the game.
        private Player player1, player2;

        // The current player's turn.
        private Player turn;

        public MainForm()
        {
            InitializeComponent();
            
            buttons = new Button[5, 5] {
                { button1, button2, button3, button4, button5 },
                { button6, button7, button8, button9, button10 },
                { button11, button12, button13, button14, button15 },
                { button16, button17, button18, button19, button20 },
                { button21, button22, button23, button24, button25 },
            };

            // Create two new player objects.
            player1 = new Player("Player 1", "X", Color.Blue, player1Label, player1ScoreLabel);
            player2 = new Player("Player 2", "O", Color.Red, player2Label, player2ScoreLabel);

            // Who plays first when the game starts.
            turn = player1;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Add a new event handler for the Click event of all tic tac toe buttons.
            foreach (Button button in buttons)
            {
                button.Enabled = false;
                button.Click += new EventHandler(this.HandleMoves);
            }
        }

        private void StartGame()
        {
            foreach (Button button in buttons)
            {
                button.Enabled = true;
            }

            startButton.Visible = false;
        }

        private void ResetGame()
        {
            player1.ResetMoves();
            player2.ResetMoves();

            turn = player1;

            foreach (Button button in buttons)
            {
                button.Text = "";
                button.Enabled = false;
            }

            startButton.Visible = true;
            startButton.Focus();
        }

        private void EndGame()
        {
            MessageBox.Show(turn.ToString() + " won the game!");

            turn.AddWin();
            ResetGame();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void HandleMoves(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            KeyValuePair<int, int> coords = GetCoordinates(button);
            int x = coords.Key;
            int y = coords.Value;

            if (button.Text.Length == 0)
            {
                bool won = turn.MakeMove(button, x, y);

                if (won)
                {
                    EndGame();
                }
                else
                {
                    if (turn.Equals(player1))
                        turn = player2;
                    else
                        turn = player1;
                }
            }
        }

        private KeyValuePair<int, int> GetCoordinates(Button button)
        {
            int x = 0, y = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (buttons[i, j].Equals(button))
                    {
                        x = i;
                        y = j;
                        break;
                    }
                }
            }

            return new KeyValuePair<int, int>(x, y);
        }
    }
}
