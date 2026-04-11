namespace JuegoLaberinto
{
    partial class FormIns
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
            lblIns = new Label();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lblIns
            // 
            lblIns.AutoSize = true;
            lblIns.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIns.ForeColor = Color.Gold;
            lblIns.Location = new Point(26, 55);
            lblIns.Name = "lblIns";
            lblIns.Size = new Size(528, 90);
            lblIns.TabIndex = 0;
            lblIns.Text = "Usa las flechas para moverte.\r\nNo toques las paredes negras.\r\nTienes 3 vidas, pierdes se reinica el juego.\r\n";
            lblIns.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Indigo;
            btnClose.FlatAppearance.BorderColor = Color.Magenta;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Showcard Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.Transparent;
            btnClose.Location = new Point(212, 181);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(156, 57);
            btnClose.TabIndex = 1;
            btnClose.Text = "Cerrar";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // FormIns
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Black;
            ClientSize = new Size(580, 292);
            ControlBox = false;
            Controls.Add(btnClose);
            Controls.Add(lblIns);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            Name = "FormIns";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIns;
        private Button btnClose;
    }
}