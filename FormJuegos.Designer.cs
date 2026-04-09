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
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(778, 544);
            KeyPreview = true;
            Margin = new Padding(2);
            Name = "FormJuego";
            Text = "Laverinto: Nivel 1";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer tmrCronometro;
    }
}
