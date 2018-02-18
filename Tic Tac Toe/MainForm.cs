using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class MainForm : Form
    {
        // The number of buttons in the horizontal axis.
        public const int X = 5;

        // The number of buttons in the vertical axis.
        public const int Y = 5;

        // The 2-dimensional array that contains all buttons in the board.
        private Button[,] buttons;

        // The two players of the game, player 2 may be a computer player.
        private Player player1, player2;

        // The current player's turn.
        private Player turn;

        // A random reference used to decide which player will play first.
        private Random random;

        // A reference to a new game form.
        private NewGameForm newGameForm;

        // Counts the number of moves for each match.
        public static int MatchMoves { get; set; }

        public MainForm()
        {
            InitializeComponent();
            
            // Initialize the 2-dimensional array of usable buttons.
            this.buttons = new Button[X, Y] {
                { button1, button2, button3, button4, button5 },
                { button6, button7, button8, button9, button10 },
                { button11, button12, button13, button14, button15 },
                { button16, button17, button18, button19, button20 },
                { button21, button22, button23, button24, button25 },
            };

            // Create a new random object.
            this.random = new Random();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Exercise 2" + Environment.NewLine +
                Environment.NewLine +
                "Π16036. Παναγιώτης Ιωαννίδης" + Environment.NewLine +
                "Π16097. Διονύσης Νίκας" + Environment.NewLine +
                "Π16112. Αθανάσιος Παραβάντης",
                "About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void CheckComputerPlay()
        {
            // Check if the player is controlled by the computer.
            if (this.turn.IsComputer)
            {
                // If that's the case then select a button and perform a click.
                Button selected = this.turn.SelectButton(
                    this.turn.Equals(player1) ? this.player2 : this.player1, this.buttons);

                // Click the button that was selected.
                selected.PerformClick();
            }
        }

        private void CreateGame(Player player1, Player player2)
        {
            // Assuming the users have interacted with the new game form window,
            // this method will be called when they finish setting up the players.

            // We have our two player objects passed in with all the settings from the new game form.
            this.player1 = player1;
            this.player2 = player2;

            // Updated the score labels.
            this.labelNamePlayer1.Text = player1.Νame;
            this.labelScorePlayer1.Text = "0";
            this.labelNamePlayer2.Text = player2.Νame;
            this.labelScorePlayer2.Text = "0";

            // The new game button now works as a Restart button when every match ends.
            this.newGameButton.Text = "Restart";

            // Everything is ready, start the game.
            this.StartGame();
        }

        private void EndGameDraw()
        {
            // Display a message box for the draw.
            MessageBox.Show("The game ended with a draw!", "Match");

            // Reset the current game, prepare for the next one.
            this.ResetGame();
        }

        private void EndGameWin()
        {
            // Display a message box for the winner.
            MessageBox.Show(this.turn.ToString() + " won the game!", "Match");

            // Add one to the total wins of the player.
            this.turn.AddWin();

            // Update the score label of the winner.
            if (this.turn == player1)
                this.labelScorePlayer1.Text = this.turn.Score.ToString();
            else
                this.labelScorePlayer2.Text = this.turn.Score.ToString();

            // Reset the current game, prepare for the next one.
            this.ResetGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private KeyValuePair<int, int> GetCoordinates(Button button)
        {
            // Initialize x, y variables.
            int x = 0, y = 0;

            // Loop through all buttons along the X and Y axis.
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    // If the buttons are equal then get the x and y coordinates.
                    if (this.buttons[i, j].Equals(button))
                    {
                        x = i;
                        y = j;
                        break;
                    }
                }
            }

            // Return a new key-pair object that will hold the x and y variables.
            // Basically we're returning two variables.
            return new KeyValuePair<int, int>(x, y);
        }

        private void HandleMoves(object sender, EventArgs e)
        {
            // Handles all moves for each match when a button is clicked.

            // Find which button was clicked, perform casting.
            Button button = (Button)sender;

            // Get the X and Y coordinates of the button.
            KeyValuePair<int, int> coords = GetCoordinates(button);
            int x = coords.Key;
            int y = coords.Value;

            // If the clicked button hasn't been used before then proceed.
            if (button.Text.Length == 0)
            {
                // Register the move of the current player.
                MoveState state = this.turn.MakeMove(button, x, y);

                // Determine the result of the move.
                if (state == MoveState.Win)
                {
                    // The move formed a set of Xs or Os that resulted to a win.
                    this.EndGameWin();
                }
                else if (state == MoveState.Draw)
                {
                    // The move didn't result to a win and all buttons are clicked.
                    this.EndGameDraw();
                }
                else
                {
                    // The match still has potential and may result to a win or a draw.
                    // Switch turns and let the other player make his move.
                    this.SwitchTurns();
                }
            }
        }

        private bool IsNewGameFormClosed()
        {
            // Check if the new game form is null or already closed, then we can open it.
            return this.newGameForm == null || this.newGameForm.IsDisposed;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Loop through all registered buttons and add a new click event handler.
            foreach (Button button in buttons)
            {
                // At first, all buttons are disabled until the match starts.
                button.Enabled = false;

                // Add a new event handler, HandleMoves() is the method handling this event.
                button.Click += new EventHandler(this.HandleMoves);
            }
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            // The new button should open the new game form if there are no players.
            if (this.player1 == null || this.player2 == null)
            {
                // Prevent the game form from opening more than once.
                if (this.IsNewGameFormClosed())
                    this.OpenNewGameForm();
            }
            // Otherwise we already have two players so we just start the game.
            // At this point the first match already finished and we are ready to start a new one.
            else
            {
                this.StartGame();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Make sure the game form isn't already opened.
            if (this.IsNewGameFormClosed())
            {
                // If we already have two players created, just reset the game.
                // For example, if a match is already started we will end it gracefully.
                if (this.player1 != null && this.player2 != null)
                    this.ResetGame();

                // Open the new game form to create new players.
                this.OpenNewGameForm();
            }
        }

        private void OpenNewGameForm()
        {
            // Create a new game form object and show the form.
            // The new game form requires a game creation handler as a callback, we use delegates.
            this.newGameForm = new NewGameForm(this.CreateGame);
            this.newGameForm.Show();
        }

        private void RandomTurn()
        {
            // Generate a random number from 0 to 1, basically true/false.
            int rand = this.random.Next(0, 2);

            // Choose who is going to play next.
            if (rand == 0)
                this.SetTurnPlayer1();
            else
                this.SetTurnPlayer2();

            // Check if the player is being controlled by the computer,
            // if that's the case then make a move.
            this.CheckComputerPlay();
        }

        private void ResetGame()
        {
            // This method cleans everything up after a match finishes.
            // All player settings are preserved, this will only prepare the game for a new match.

            // Reset the number of moves for this match.
            MatchMoves = 0;

            // Reset each player.
            this.player1.Reset();
            this.player2.Reset();

            // Reset the player labels.
            this.ResetNameLabels();

            // Remove the text from all buttons and disable them.
            foreach (Button button in this.buttons)
            {
                button.Text = "";
                button.Enabled = false;
            }

            // Make the Restart button visible again.
            this.newGameButton.Visible = true;
            this.newGameButton.Focus();
        }

        private void ResetNameLabel1()
        {
            // Reset the name label of player 1 back to it's original state.
            this.labelNamePlayer1.Font = new Font(this.labelNamePlayer1.Font, FontStyle.Regular);
            this.labelNamePlayer1.ForeColor = Color.Black;
        }

        private void ResetNameLabel2()
        {
            // Reset the name label of player 2 back to it's original state.
            this.labelNamePlayer2.Font = new Font(this.labelNamePlayer2.Font, FontStyle.Regular);
            this.labelNamePlayer2.ForeColor = Color.Black;
        }

        private void ResetNameLabels()
        {
            // Reset all name labels back to their original state.
            this.ResetNameLabel1();
            this.ResetNameLabel2();
        }

        private void SetTurnPlayer1()
        {
            // Player 1 is now playing.
            this.turn = this.player1;

            // Change the name label of player 1 to indicate his turn.
            this.labelNamePlayer1.Font = new Font(this.labelNamePlayer1.Font, FontStyle.Bold);
            this.labelNamePlayer1.ForeColor = this.turn.Color;

            // Reset the name label of player 2.
            this.ResetNameLabel2();
        }

        private void SetTurnPlayer2()
        {
            // Player 2 is now playing.
            this.turn = this.player2;

            // Change the name label of player 2 to indicate his turn.
            this.labelNamePlayer2.Font = new Font(this.labelNamePlayer2.Font, FontStyle.Bold);
            this.labelNamePlayer2.ForeColor = this.turn.Color;

            // Reset the name label of player 1.
            this.ResetNameLabel1();
        }

        private void StartGame()
        {
            // Enable all buttons so they can be clicked.
            foreach (Button button in this.buttons)
            {
                button.Enabled = true;
            }

            // The new game button is no longer visible since the match has started.
            this.newGameButton.Visible = false;

            // Choose randomly one of the two players for the first turn.
            this.RandomTurn();
        }

        private void SwitchTurns()
        {
            // Choose who is going to play next.
            // If this was player 1's turn, then player 2 is going to play next.
            // If this was player 2's turn, then player 1 is going to play next.
            if (this.turn.Equals(player1))
                this.SetTurnPlayer2();
            else
                this.SetTurnPlayer1();

            // Check if the player is being controlled by the computer,
            // if that's the case then make a move.
            this.CheckComputerPlay();
        }
    }
}
