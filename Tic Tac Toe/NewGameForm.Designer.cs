namespace Tic_Tac_Toe
{
    partial class NewGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewGameForm));
            this.labelNamePlayer1 = new System.Windows.Forms.Label();
            this.namePlayer1 = new System.Windows.Forms.TextBox();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.newGameButton = new System.Windows.Forms.Button();
            this.labelNamePlayer2 = new System.Windows.Forms.Label();
            this.namePlayer2 = new System.Windows.Forms.TextBox();
            this.computerCheckbox = new System.Windows.Forms.CheckBox();
            this.buttonMarkPlayer2 = new System.Windows.Forms.Button();
            this.labelPlayer2 = new System.Windows.Forms.Label();
            this.buttonMarkPlayer1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNamePlayer1
            // 
            this.labelNamePlayer1.AutoSize = true;
            this.labelNamePlayer1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelNamePlayer1.Location = new System.Drawing.Point(57, 20);
            this.labelNamePlayer1.Name = "labelNamePlayer1";
            this.labelNamePlayer1.Size = new System.Drawing.Size(66, 21);
            this.labelNamePlayer1.TabIndex = 0;
            this.labelNamePlayer1.Text = "Player 1";
            // 
            // namePlayer1
            // 
            this.namePlayer1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.namePlayer1.Location = new System.Drawing.Point(12, 53);
            this.namePlayer1.Name = "namePlayer1";
            this.namePlayer1.Size = new System.Drawing.Size(160, 29);
            this.namePlayer1.TabIndex = 1;
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelPlayer1.Location = new System.Drawing.Point(67, 125);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(47, 21);
            this.labelPlayer1.TabIndex = 2;
            this.labelPlayer1.Text = "Label";
            // 
            // newGameButton
            // 
            this.newGameButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.newGameButton.Location = new System.Drawing.Point(12, 303);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(360, 46);
            this.newGameButton.TabIndex = 9;
            this.newGameButton.Text = "Start new game";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // labelNamePlayer2
            // 
            this.labelNamePlayer2.AutoSize = true;
            this.labelNamePlayer2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNamePlayer2.Location = new System.Drawing.Point(261, 20);
            this.labelNamePlayer2.Name = "labelNamePlayer2";
            this.labelNamePlayer2.Size = new System.Drawing.Size(66, 21);
            this.labelNamePlayer2.TabIndex = 4;
            this.labelNamePlayer2.Text = "Player 2";
            // 
            // namePlayer2
            // 
            this.namePlayer2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.namePlayer2.Location = new System.Drawing.Point(212, 53);
            this.namePlayer2.Name = "namePlayer2";
            this.namePlayer2.Size = new System.Drawing.Size(160, 29);
            this.namePlayer2.TabIndex = 5;
            // 
            // computerCheckbox
            // 
            this.computerCheckbox.AutoSize = true;
            this.computerCheckbox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.computerCheckbox.Location = new System.Drawing.Point(232, 247);
            this.computerCheckbox.Name = "computerCheckbox";
            this.computerCheckbox.Size = new System.Drawing.Size(131, 23);
            this.computerCheckbox.TabIndex = 8;
            this.computerCheckbox.Text = "Computer Player";
            this.computerCheckbox.UseVisualStyleBackColor = true;
            // 
            // buttonMarkPlayer2
            // 
            this.buttonMarkPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F);
            this.buttonMarkPlayer2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonMarkPlayer2.Location = new System.Drawing.Point(250, 151);
            this.buttonMarkPlayer2.Name = "buttonMarkPlayer2";
            this.buttonMarkPlayer2.Size = new System.Drawing.Size(90, 90);
            this.buttonMarkPlayer2.TabIndex = 7;
            this.buttonMarkPlayer2.UseVisualStyleBackColor = true;
            this.buttonMarkPlayer2.Click += new System.EventHandler(this.buttonMarkPlayer2_Click);
            // 
            // labelPlayer2
            // 
            this.labelPlayer2.AutoSize = true;
            this.labelPlayer2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelPlayer2.Location = new System.Drawing.Point(270, 125);
            this.labelPlayer2.Name = "labelPlayer2";
            this.labelPlayer2.Size = new System.Drawing.Size(47, 21);
            this.labelPlayer2.TabIndex = 6;
            this.labelPlayer2.Text = "Label";
            // 
            // buttonMarkPlayer1
            // 
            this.buttonMarkPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F);
            this.buttonMarkPlayer1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonMarkPlayer1.Location = new System.Drawing.Point(48, 151);
            this.buttonMarkPlayer1.Name = "buttonMarkPlayer1";
            this.buttonMarkPlayer1.Size = new System.Drawing.Size(90, 90);
            this.buttonMarkPlayer1.TabIndex = 3;
            this.buttonMarkPlayer1.UseVisualStyleBackColor = true;
            this.buttonMarkPlayer1.Click += new System.EventHandler(this.buttonMarkPlayer1_Click);
            // 
            // NewGameForm
            // 
            this.AcceptButton = this.newGameButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.labelNamePlayer1);
            this.Controls.Add(this.labelNamePlayer2);
            this.Controls.Add(this.namePlayer1);
            this.Controls.Add(this.namePlayer2);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.labelPlayer2);
            this.Controls.Add(this.buttonMarkPlayer1);
            this.Controls.Add(this.buttonMarkPlayer2);
            this.Controls.Add(this.computerCheckbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "NewGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Game";
            this.Load += new System.EventHandler(this.NewGameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNamePlayer1;
        private System.Windows.Forms.TextBox namePlayer1;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Label labelNamePlayer2;
        private System.Windows.Forms.TextBox namePlayer2;
        private System.Windows.Forms.CheckBox computerCheckbox;
        private System.Windows.Forms.Button buttonMarkPlayer2;
        private System.Windows.Forms.Label labelPlayer2;
        private System.Windows.Forms.Button buttonMarkPlayer1;
    }
}