namespace JuegoLaberinto
{
    partial class FormJuego
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tmrCronometro = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // tmrCronometro
            // 
            tmrCronometro.Enabled = true;
            tmrCronometro.Interval = 1000;
            tmrCronometro.Tick += tmrCronometro_Tick;
            // 
            // FormJuego
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(798, 564);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "FormJuego";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LABERINTO: EL JUEGO";
            FormClosing += FormJuego_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer tmrCronometro;
    }
}
