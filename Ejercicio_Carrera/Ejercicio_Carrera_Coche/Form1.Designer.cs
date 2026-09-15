namespace Ejercicio_Carrera_Coche
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
            btn_1 = new Button();
            button2 = new Button();
            LB_1_1 = new Label();
            LB_1 = new Label();
            SuspendLayout();
            // 
            // btn_1
            // 
            btn_1.Location = new Point(60, 143);
            btn_1.Name = "btn_1";
            btn_1.Size = new Size(75, 23);
            btn_1.TabIndex = 0;
            btn_1.Text = "button1";
            btn_1.UseVisualStyleBackColor = true;
            btn_1.Click += btn_1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(379, 245);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // LB_1_1
            // 
            LB_1_1.AutoSize = true;
            LB_1_1.Location = new Point(122, 100);
            LB_1_1.Name = "LB_1_1";
            LB_1_1.Size = new Size(13, 15);
            LB_1_1.TabIndex = 2;
            LB_1_1.Text = "0";
            // 
            // LB_1
            // 
            LB_1.AutoSize = true;
            LB_1.Location = new Point(44, 100);
            LB_1.Name = "LB_1";
            LB_1.Size = new Size(57, 15);
            LB_1.TabIndex = 3;
            LB_1.Text = "Recorrida";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(641, 298);
            Controls.Add(LB_1);
            Controls.Add(LB_1_1);
            Controls.Add(button2);
            Controls.Add(btn_1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_1;
        private Button button2;
        private Label LB_1_1;
        private Label LB_1;
    }
}
