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

        private Random random;

        public const int X = 5;
        public const int Y = 5;

        public static int MatchMoves { get; set; }

        public MainForm()
        {
            InitializeComponent();
            
            buttons = new Button[X, Y] {
                { button1, button2, button3, button4, button5 },
                { button6, button7, button8, button9, button10 },
                { button11, button12, button13, button14, button15 },
                { button16, button17, button18, button19, button20 },
                { button21, button22, button23, button24, button25 },
            };

            random = new Random();
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

        private void newGameButton_Click(object sender, EventArgs e)
        {
            if (player1 == null || player2 == null)
            {
                NewGameForm newGameForm = new NewGameForm(CreateGame);
                newGameForm.Show();
            }
            else
            {
                StartGame();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGameForm newGameForm = new NewGameForm(CreateGame);
            newGameForm.Show();
        }

        private void CreateGame(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;

            labelNamePlayer1.Text = player1.Νame;
            labelScorePlayer1.Text = "0";
            labelNamePlayer2.Text = player2.Νame;
            labelScorePlayer2.Text = "0";
            newGameButton.Text = "Restart";

            StartGame();
        }

        private void StartGame()
        {
            turn = random.Next(0, 1) == 0 ? player1 : player2;

            foreach (Button button in buttons)
            {
                button.Enabled = true;
            }

            newGameButton.Visible = false;
        }
        
        private void ResetGame()
        {
            MatchMoves = 0;

            player1.ResetMoves();
            player2.ResetMoves();

            turn = player1;

            foreach (Button button in buttons)
            {
                button.Text = "";
                button.Enabled = false;
            }

            newGameButton.Visible = true;
            newGameButton.Focus();
        }

        private void EndGameWin()
        {
            MessageBox.Show(turn.ToString() + " won the game!");

            turn.AddWin();

            if (turn == player1)
                labelScorePlayer1.Text = turn.Score.ToString();
            else
                labelScorePlayer2.Text = turn.Score.ToString();

            ResetGame();
        }

        private void EndGameDraw()
        {
            MessageBox.Show("The game ended with a draw!");
            ResetGame();
        }

        private void SwitchTurns()
        {
            if (turn.Equals(player1))
                turn = player2;
            else
                turn = player1;
        }

        private void HandleMoves(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            KeyValuePair<int, int> coords = GetCoordinates(button);
            int x = coords.Key;
            int y = coords.Value;

            if (button.Text.Length == 0)
            {
                MoveState state = turn.MakeMove(button, x, y);

                if (state == MoveState.Win)
                {
                    EndGameWin();
                }
                else if (state == MoveState.Draw)
                {
                    EndGameDraw();
                }
                else
                {
                    SwitchTurns();
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
