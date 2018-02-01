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
        private GameCreationHandler handler;

        public NewGameForm(GameCreationHandler handler)
        {
            InitializeComponent();

            this.handler = handler;
        }

        private void NewGameForm_Load(object sender, EventArgs e)
        {
            ApplyBlueStyle(buttonMarkPlayer1);
            ApplyRedStyle(buttonMarkPlayer2);
        }

        private void buttonMarkPlayer1_Click(object sender, EventArgs e)
        {
            SwitchLabels(buttonMarkPlayer1);
            SwitchLabels(buttonMarkPlayer2);
        }

        private void buttonMarkPlayer2_Click(object sender, EventArgs e)
        {
            SwitchLabels(buttonMarkPlayer2);
            SwitchLabels(buttonMarkPlayer1);
        }

        private void SwitchLabels(Button button)
        {
            if (button.ForeColor == Color.Blue)
            {
                ApplyRedStyle(button);
            }
            else
            {
                ApplyBlueStyle(button);
            }
        }

        private void ApplyBlueStyle(Button button)
        {
            button.ForeColor = Color.Blue;
            button.Text = "X";
        }

        private void ApplyRedStyle(Button button)
        {
            button.ForeColor = Color.Red;
            button.Text = "O";
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            string name1 = namePlayer1.Text == "" ? "Player 1" : namePlayer1.Text;
            string mark1 = buttonMarkPlayer1.Text;
            Color color1 = buttonMarkPlayer1.ForeColor;
            string name2 = namePlayer2.Text == "" ? "Player 2" : namePlayer2.Text;
            string mark2 = buttonMarkPlayer2.Text;
            Color color2 = buttonMarkPlayer2.ForeColor;
            bool isComputer = computerCheckbox.Checked;

            Player player1 = new Player(name1, mark1, color1);
            Player player2 = new Player(name2, mark2, color2, isComputer);

            handler(player1, player2);

            this.Close();
        }
    }
}
