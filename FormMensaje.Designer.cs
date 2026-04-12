namespace JuegoLaberinto
{
    partial class FormMensaje
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
            btnOk = new Button();
            lblMensaje = new Label();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.None;
            btnOk.BackColor = Color.Indigo;
            btnOk.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 255);
            btnOk.FlatAppearance.MouseOverBackColor = Color.DeepPink;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Font = new Font("Showcard Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOk.ForeColor = Color.White;
            btnOk.Location = new Point(116, 96);
            btnOk.Margin = new Padding(2, 2, 2, 2);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(67, 33);
            btnOk.TabIndex = 0;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click;
            // 
            // lblMensaje
            // 
            lblMensaje.Font = new Font("Showcard Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMensaje.ForeColor = Color.Gold;
            lblMensaje.Location = new Point(50, 19);
            lblMensaje.Margin = new Padding(2, 0, 2, 0);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(199, 67);
            lblMensaje.TabIndex = 1;
            lblMensaje.Text = "Mensaje";
            lblMensaje.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormMensaje
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.Black;
            ClientSize = new Size(298, 148);
            ControlBox = false;
            Controls.Add(lblMensaje);
            Controls.Add(btnOk);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            Name = "FormMensaje";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
        }

        #endregion

        private Button btnOk;
        private Label lblMensaje;
    }
}