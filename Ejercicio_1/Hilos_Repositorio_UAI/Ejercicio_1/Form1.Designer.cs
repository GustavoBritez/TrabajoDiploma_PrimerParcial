namespace Ejercicio_1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblCaballo1 = new System.Windows.Forms.Label();
            this.pbCaballo1 = new System.Windows.Forms.ProgressBar();
            this.lblEstado1 = new System.Windows.Forms.Label();

            this.lblCaballo2 = new System.Windows.Forms.Label();
            this.pbCaballo2 = new System.Windows.Forms.ProgressBar();
            this.lblEstado2 = new System.Windows.Forms.Label();

            this.lblCaballo3 = new System.Windows.Forms.Label();
            this.pbCaballo3 = new System.Windows.Forms.ProgressBar();
            this.lblEstado3 = new System.Windows.Forms.Label();

            this.lblCaballo4 = new System.Windows.Forms.Label();
            this.pbCaballo4 = new System.Windows.Forms.ProgressBar();
            this.lblEstado4 = new System.Windows.Forms.Label();

            this.btnCarreraThreads = new System.Windows.Forms.Button();
            this.btnCarreraTasks = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.grpPista = new System.Windows.Forms.GroupBox();

            this.grpPista.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(16, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(430, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Simulación Carrera de Caballos (Hilos y Tasks)";

            // 
            // grpPista
            // 
            this.grpPista.Controls.Add(this.lblCaballo1);
            this.grpPista.Controls.Add(this.pbCaballo1);
            this.grpPista.Controls.Add(this.lblEstado1);

            this.grpPista.Controls.Add(this.lblCaballo2);
            this.grpPista.Controls.Add(this.pbCaballo2);
            this.grpPista.Controls.Add(this.lblEstado2);

            this.grpPista.Controls.Add(this.lblCaballo3);
            this.grpPista.Controls.Add(this.pbCaballo3);
            this.grpPista.Controls.Add(this.lblEstado3);

            this.grpPista.Controls.Add(this.lblCaballo4);
            this.grpPista.Controls.Add(this.pbCaballo4);
            this.grpPista.Controls.Add(this.lblEstado4);

            this.grpPista.Location = new System.Drawing.Point(16, 50);
            this.grpPista.Name = "grpPista";
            this.grpPista.Size = new System.Drawing.Size(760, 260);
            this.grpPista.TabIndex = 1;
            this.grpPista.TabStop = false;
            this.grpPista.Text = "Pista de Carreras";

            // Caballo A
            this.lblCaballo1.Location = new System.Drawing.Point(15, 30);
            this.lblCaballo1.Size = new System.Drawing.Size(180, 20);
            this.lblCaballo1.Text = "Caballo A (Highest)";
            this.pbCaballo1.Location = new System.Drawing.Point(200, 30);
            this.pbCaballo1.Size = new System.Drawing.Size(350, 23);
            this.lblEstado1.Location = new System.Drawing.Point(560, 30);
            this.lblEstado1.Size = new System.Drawing.Size(190, 20);
            this.lblEstado1.Text = "Listo";

            // Caballo B
            this.lblCaballo2.Location = new System.Drawing.Point(15, 80);
            this.lblCaballo2.Size = new System.Drawing.Size(180, 20);
            this.lblCaballo2.Text = "Caballo B (AboveNormal)";
            this.pbCaballo2.Location = new System.Drawing.Point(200, 80);
            this.pbCaballo2.Size = new System.Drawing.Size(350, 23);
            this.lblEstado2.Location = new System.Drawing.Point(560, 80);
            this.lblEstado2.Size = new System.Drawing.Size(190, 20);
            this.lblEstado2.Text = "Listo";

            // Caballo C
            this.lblCaballo3.Location = new System.Drawing.Point(15, 130);
            this.lblCaballo3.Size = new System.Drawing.Size(180, 20);
            this.lblCaballo3.Text = "Caballo C (BelowNormal)";
            this.pbCaballo3.Location = new System.Drawing.Point(200, 130);
            this.pbCaballo3.Size = new System.Drawing.Size(350, 23);
            this.lblEstado3.Location = new System.Drawing.Point(560, 130);
            this.lblEstado3.Size = new System.Drawing.Size(190, 20);
            this.lblEstado3.Text = "Listo";

            // Caballo D
            this.lblCaballo4.Location = new System.Drawing.Point(15, 180);
            this.lblCaballo4.Size = new System.Drawing.Size(180, 20);
            this.lblCaballo4.Text = "Caballo D (Lowest)";
            this.pbCaballo4.Location = new System.Drawing.Point(200, 180);
            this.pbCaballo4.Size = new System.Drawing.Size(350, 23);
            this.lblEstado4.Location = new System.Drawing.Point(560, 180);
            this.lblEstado4.Size = new System.Drawing.Size(190, 20);
            this.lblEstado4.Text = "Listo";

            // Buttons
            this.btnCarreraThreads.Location = new System.Drawing.Point(16, 320);
            this.btnCarreraThreads.Size = new System.Drawing.Size(260, 40);
            this.btnCarreraThreads.Text = "1. Carrera con Threads (ta, tb, tc, td)";
            this.btnCarreraThreads.UseVisualStyleBackColor = true;
            this.btnCarreraThreads.Click += new System.EventHandler(this.btnCarreraThreads_Click);

            this.btnCarreraTasks.Location = new System.Drawing.Point(290, 320);
            this.btnCarreraTasks.Size = new System.Drawing.Size(260, 40);
            this.btnCarreraTasks.Text = "2. Carrera con Task.WaitAll(...)";
            this.btnCarreraTasks.UseVisualStyleBackColor = true;
            this.btnCarreraTasks.Click += new System.EventHandler(this.btnCarreraTasks_Click);

            // RichTextBox Log
            this.rtbLog.Location = new System.Drawing.Point(16, 375);
            this.rtbLog.Size = new System.Drawing.Size(760, 150);
            this.rtbLog.ReadOnly = true;

            // Form1
            this.ClientSize = new System.Drawing.Size(790, 540);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.grpPista);
            this.Controls.Add(this.btnCarreraThreads);
            this.Controls.Add(this.btnCarreraTasks);
            this.Controls.Add(this.rtbLog);
            this.Name = "Form1";
            this.Text = "Carrera de Caballos - Hilos y Programación Concurrente";
            this.Load += new System.EventHandler(this.Form1_Load);

            this.grpPista.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpPista;

        private System.Windows.Forms.Label lblCaballo1;
        private System.Windows.Forms.ProgressBar pbCaballo1;
        private System.Windows.Forms.Label lblEstado1;

        private System.Windows.Forms.Label lblCaballo2;
        private System.Windows.Forms.ProgressBar pbCaballo2;
        private System.Windows.Forms.Label lblEstado2;

        private System.Windows.Forms.Label lblCaballo3;
        private System.Windows.Forms.ProgressBar pbCaballo3;
        private System.Windows.Forms.Label lblEstado3;

        private System.Windows.Forms.Label lblCaballo4;
        private System.Windows.Forms.ProgressBar pbCaballo4;
        private System.Windows.Forms.Label lblEstado4;

        private System.Windows.Forms.Button btnCarreraThreads;
        private System.Windows.Forms.Button btnCarreraTasks;
        private System.Windows.Forms.RichTextBox rtbLog;
    }
}
