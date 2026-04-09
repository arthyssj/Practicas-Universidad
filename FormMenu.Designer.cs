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
            SuspendLayout();
            // 
            // btnIniciar
            // 
            btnIniciar.BackColor = Color.Indigo;
            btnIniciar.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 255);
            btnIniciar.FlatAppearance.MouseOverBackColor = Color.DeepPink;
            btnIniciar.FlatStyle = FlatStyle.Flat;
            btnIniciar.Font = new Font("Showcard Gothic", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIniciar.ForeColor = Color.Transparent;
            btnIniciar.Location = new Point(207, 137);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(327, 98);
            btnIniciar.TabIndex = 0;
            btnIniciar.Text = "Iniciar Juego";
            btnIniciar.UseVisualStyleBackColor = false;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Indigo;
            btnSalir.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 255);
            btnSalir.FlatAppearance.MouseOverBackColor = Color.DeepPink;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Showcard Gothic", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.Transparent;
            btnSalir.Location = new Point(207, 268);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(327, 98);
            btnSalir.TabIndex = 0;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.laberinto_fondo;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(778, 544);
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
    }
}