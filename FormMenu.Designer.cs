namespace JuegoLaberinto
{
    partial class FormMenu
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
            btnIniciar = new Button();
            btnSalir = new Button();
            btnIns = new Button();
            SuspendLayout();
            // 
            // btnIniciar
            // 
            btnIniciar.Anchor = AnchorStyles.None;
            btnIniciar.BackColor = Color.Indigo;
            btnIniciar.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 255);
            btnIniciar.FlatAppearance.BorderSize = 2;
            btnIniciar.FlatAppearance.MouseOverBackColor = Color.DeepPink;
            btnIniciar.FlatStyle = FlatStyle.Flat;
            btnIniciar.Font = new Font("Showcard Gothic", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIniciar.ForeColor = Color.Gold;
            btnIniciar.Location = new Point(242, 112);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(300, 100);
            btnIniciar.TabIndex = 1;
            btnIniciar.Text = "Iniciar Juego";
            btnIniciar.UseVisualStyleBackColor = false;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.None;
            btnSalir.BackColor = Color.Indigo;
            btnSalir.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 255);
            btnSalir.FlatAppearance.BorderSize = 2;
            btnSalir.FlatAppearance.MouseOverBackColor = Color.DeepPink;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Showcard Gothic", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.Transparent;
            btnSalir.Location = new Point(242, 348);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(300, 100);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnIns
            // 
            btnIns.Anchor = AnchorStyles.None;
            btnIns.BackColor = Color.Indigo;
            btnIns.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 255);
            btnIns.FlatAppearance.BorderSize = 2;
            btnIns.FlatAppearance.MouseOverBackColor = Color.DeepPink;
            btnIns.FlatStyle = FlatStyle.Flat;
            btnIns.Font = new Font("Showcard Gothic", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIns.ForeColor = Color.Transparent;
            btnIns.Location = new Point(242, 230);
            btnIns.Name = "btnIns";
            btnIns.Size = new Size(300, 100);
            btnIns.TabIndex = 2;
            btnIns.Text = "Instrucciones";
            btnIns.UseVisualStyleBackColor = false;
            btnIns.Click += btnIns_Click;
            // 
            // FormMenu
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.fondoMenuV3;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(784, 561);
            Controls.Add(btnIns);
            Controls.Add(btnSalir);
            Controls.Add(btnIniciar);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LABERINTO: EL JUEGO";
            FormClosing += FormMenu_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private Button btnIniciar;
        private Button btnSalir;
        private Button btnIns;
    }
}