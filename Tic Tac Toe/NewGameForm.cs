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
    public partial class NewGameForm : Form
    {
        // A reference to a delegate that will be called when a new game is created.
        private GameCreationHandler handler;

        public NewGameForm(GameCreationHandler handler)
        {
            InitializeComponent();

            this.handler = handler;
        }

        private void ApplyBlueStyle(Button button)
        {
            // Apply the styles of a blue marker to a specific button.

            button.ForeColor = Color.Blue;
            button.Text = "X";
        }

        private void ApplyRedStyle(Button button)
        {
            // Apply the styles of a red marker to a specific button.

            button.ForeColor = Color.Red;
            button.Text = "O";
        }

        private void buttonMarkPlayer1_Click(object sender, EventArgs e)
        {
            // When the player 1 marker is clicked, switch markers.

            SwitchMarkers(buttonMarkPlayer1);
            SwitchMarkers(buttonMarkPlayer2);
        }

        private void buttonMarkPlayer2_Click(object sender, EventArgs e)
        {
            // When the player 2 marker is clicked, switch markers.

            SwitchMarkers(buttonMarkPlayer2);
            SwitchMarkers(buttonMarkPlayer1);
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            // Collect the characteristics of the first player.
            string name1 = namePlayer1.Text == "" ? "Player 1" : namePlayer1.Text;
            string mark1 = buttonMarkPlayer1.Text;
            Color color1 = buttonMarkPlayer1.ForeColor;

            // Collect the characteristics of the second player.
            string name2 = namePlayer2.Text == "" ? "Player 2" : namePlayer2.Text;
            string mark2 = buttonMarkPlayer2.Text;
            Color color2 = buttonMarkPlayer2.ForeColor;
            bool isComputer = computerCheckbox.Checked;

            // Create new player objects and assign references.
            Player player1 = new Player(name1, mark1, color1);
            Player player2 = new Player(name2, mark2, color2, isComputer);

            // Call the delegate and pass the two player references.
            handler(player1, player2);

            // Close the form.
            this.Close();
        }

        private void NewGameForm_Load(object sender, EventArgs e)
        {
            // When the form loads apply the blue and red style to the markers.

            ApplyBlueStyle(buttonMarkPlayer1);
            ApplyRedStyle(buttonMarkPlayer2);
        }

        private void SwitchMarkers(Button button)
        {
            if (button.ForeColor == Color.Blue)
            {
                // If the button is blue, then switch to a red marker.

                ApplyRedStyle(button);
            }
            else
            {
                // If the button is red, then switch to a blue marker.

                ApplyBlueStyle(button);
            }
        }
    }
}
