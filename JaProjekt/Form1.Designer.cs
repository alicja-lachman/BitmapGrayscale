namespace JaProjekt
{
    partial class Form1
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
            this.text_threads = new System.Windows.Forms.TextBox();
            this.button_reset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radio_asm = new System.Windows.Forms.RadioButton();
            this.radio_cpp = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_generate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_path = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label_threads = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button_output = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // text_threads
            // 
            this.text_threads.Location = new System.Drawing.Point(154, 180);
            this.text_threads.Name = "text_threads";
            this.text_threads.Size = new System.Drawing.Size(25, 20);
            this.text_threads.TabIndex = 2;
            this.text_threads.Text = "0";
            this.text_threads.TextChanged += new System.EventHandler(this.text_watki_TextChanged);
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(445, 452);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(75, 23);
            this.button_reset.TabIndex = 3;
            this.button_reset.Text = "Wyzeruj";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_wyzeruj_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Podaj ścieżkę do pliku wejściowego";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Podaj ścieżkę do pliku wyjściowego";
            // 
            // radio_asm
            // 
            this.radio_asm.AutoSize = true;
            this.radio_asm.Checked = true;
            this.radio_asm.Location = new System.Drawing.Point(34, 147);
            this.radio_asm.Name = "radio_asm";
            this.radio_asm.Size = new System.Drawing.Size(48, 17);
            this.radio_asm.TabIndex = 6;
            this.radio_asm.TabStop = true;
            this.radio_asm.Text = "ASM";
            this.radio_asm.UseVisualStyleBackColor = true;
            // 
            // radio_cpp
            // 
            this.radio_cpp.AutoSize = true;
            this.radio_cpp.Location = new System.Drawing.Point(97, 147);
            this.radio_cpp.Name = "radio_cpp";
            this.radio_cpp.Size = new System.Drawing.Size(44, 17);
            this.radio_cpp.TabIndex = 7;
            this.radio_cpp.Text = "C++";
            this.radio_cpp.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Wybierz wykorzystywaną bibliotekę";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Podaj liczbę wątków";
            // 
            // button_generate
            // 
            this.button_generate.Location = new System.Drawing.Point(526, 452);
            this.button_generate.Name = "button_generate";
            this.button_generate.Size = new System.Drawing.Size(75, 23);
            this.button_generate.TabIndex = 10;
            this.button_generate.Text = "Generuj";
            this.button_generate.UseVisualStyleBackColor = true;
            this.button_generate.Click += new System.EventHandler(this.button_generuj_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(246, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(237, 127);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(364, 309);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // button_path
            // 
            this.button_path.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_path.Location = new System.Drawing.Point(237, 40);
            this.button_path.Name = "button_path";
            this.button_path.Size = new System.Drawing.Size(239, 23);
            this.button_path.TabIndex = 13;
            this.button_path.Text = "ścieżka";
            this.button_path.UseVisualStyleBackColor = false;
            this.button_path.Click += new System.EventHandler(this.button_sciezka_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Liczba dostępnych wątków: ";
            // 
            // label_threads
            // 
            this.label_threads.AutoSize = true;
            this.label_threads.Location = new System.Drawing.Point(172, 205);
            this.label_threads.Name = "label_threads";
            this.label_threads.Size = new System.Drawing.Size(0, 13);
            this.label_threads.TabIndex = 15;
            this.label_threads.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(187, 266);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 17;
            this.label9.Visible = false;
            // 
            // button_output
            // 
            this.button_output.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_output.Location = new System.Drawing.Point(237, 69);
            this.button_output.Name = "button_output";
            this.button_output.Size = new System.Drawing.Size(239, 23);
            this.button_output.TabIndex = 18;
            this.button_output.Text = "ścieżka";
            this.button_output.UseVisualStyleBackColor = false;
            this.button_output.Click += new System.EventHandler(this.button_output_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 487);
            this.Controls.Add(this.button_output);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label_threads);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_path);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_generate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radio_cpp);
            this.Controls.Add(this.radio_asm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.text_threads);
            this.Name = "Form1";
            this.Text = "Skala szarości";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox text_threads;
        private System.Windows.Forms.Button button_reset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radio_asm;
        private System.Windows.Forms.RadioButton radio_cpp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_generate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_path;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_threads;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_output;
    }
}

