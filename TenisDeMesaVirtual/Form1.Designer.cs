namespace TenisDeMesaVirtual
{
    partial class Form1
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
            jugador = new PictureBox();
            rival = new PictureBox();
            bola = new PictureBox();
            temporizador = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)jugador).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rival).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bola).BeginInit();
            SuspendLayout();
            // 
            // jugador
            // 
            jugador.Image = Properties.Resources.player;
            jugador.Location = new Point(10, 250);
            jugador.Name = "jugador";
            jugador.Size = new Size(30, 120);
            jugador.SizeMode = PictureBoxSizeMode.StretchImage;
            jugador.TabIndex = 0;
            jugador.TabStop = false;
            // 
            // rival
            // 
            rival.Image = Properties.Resources.computer;
            rival.Location = new Point(936, 250);
            rival.Name = "rival";
            rival.Size = new Size(30, 120);
            rival.SizeMode = PictureBoxSizeMode.StretchImage;
            rival.TabIndex = 1;
            rival.TabStop = false;
            // 
            // bola
            // 
            bola.Image = Properties.Resources.ball;
            bola.Location = new Point(468, 300);
            bola.Name = "bola";
            bola.Size = new Size(30, 30);
            bola.SizeMode = PictureBoxSizeMode.StretchImage;
            bola.TabIndex = 2;
            bola.TabStop = false;
            // 
            // temporizador
            // 
            temporizador.Enabled = true;
            temporizador.Interval = 20;
            temporizador.Tick += EventoTemporizadorJuego;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(978, 644);
            Controls.Add(bola);
            Controls.Add(rival);
            Controls.Add(jugador);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Jugador: 0 - CPU: 0";
            KeyDown += EventoPresionarTeclas;
            KeyUp += EventoSoltarTeclas;
            ((System.ComponentModel.ISupportInitialize)jugador).EndInit();
            ((System.ComponentModel.ISupportInitialize)rival).EndInit();
            ((System.ComponentModel.ISupportInitialize)bola).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox jugador;
        private PictureBox rival;
        private PictureBox bola;
        private System.Windows.Forms.Timer temporizador;
    }
}