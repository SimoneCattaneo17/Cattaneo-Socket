namespace SimpleSocketClient {
    partial class Form1 {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_min = new System.Windows.Forms.Label();
            this.label_max = new System.Windows.Forms.Label();
            this.textBox_invio = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button_genera = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Min";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Max";
            // 
            // label_min
            // 
            this.label_min.AutoSize = true;
            this.label_min.Location = new System.Drawing.Point(12, 63);
            this.label_min.Name = "label_min";
            this.label_min.Size = new System.Drawing.Size(83, 16);
            this.label_min.TabIndex = 2;
            this.label_min.Text = "Place holder";
            // 
            // label_max
            // 
            this.label_max.AutoSize = true;
            this.label_max.Location = new System.Drawing.Point(276, 63);
            this.label_max.Name = "label_max";
            this.label_max.Size = new System.Drawing.Size(83, 16);
            this.label_max.TabIndex = 3;
            this.label_max.Text = "Place holder";
            this.label_max.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_invio
            // 
            this.textBox_invio.Location = new System.Drawing.Point(130, 145);
            this.textBox_invio.Name = "textBox_invio";
            this.textBox_invio.Size = new System.Drawing.Size(116, 22);
            this.textBox_invio.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(130, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Invia";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(284, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Inserisci un numero compreso tra il max e il min";
            // 
            // button_genera
            // 
            this.button_genera.Location = new System.Drawing.Point(130, 173);
            this.button_genera.Name = "button_genera";
            this.button_genera.Size = new System.Drawing.Size(116, 23);
            this.button_genera.TabIndex = 7;
            this.button_genera.Text = "Genera";
            this.button_genera.UseVisualStyleBackColor = true;
            this.button_genera.Click += new System.EventHandler(this.button_genera_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 237);
            this.Controls.Add(this.button_genera);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_invio);
            this.Controls.Add(this.label_max);
            this.Controls.Add(this.label_min);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_min;
        private System.Windows.Forms.Label label_max;
        private System.Windows.Forms.TextBox textBox_invio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_genera;
    }
}

