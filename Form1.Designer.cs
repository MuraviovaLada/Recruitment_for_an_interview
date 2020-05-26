namespace Combo
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbFinal1 = new System.Windows.Forms.TextBox();
            this.lbFinal = new System.Windows.Forms.ListBox();
            this.tbFinal2 = new System.Windows.Forms.TextBox();
            this.tbFinal3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(42, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(403, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(675, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Fill database";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbFinal1
            // 
            this.tbFinal1.Location = new System.Drawing.Point(42, 91);
            this.tbFinal1.Name = "tbFinal1";
            this.tbFinal1.Size = new System.Drawing.Size(403, 22);
            this.tbFinal1.TabIndex = 2;
            // 
            // lbFinal
            // 
            this.lbFinal.FormattingEnabled = true;
            this.lbFinal.ItemHeight = 16;
            this.lbFinal.Location = new System.Drawing.Point(42, 194);
            this.lbFinal.Name = "lbFinal";
            this.lbFinal.Size = new System.Drawing.Size(403, 212);
            this.lbFinal.TabIndex = 3;
            // 
            // tbFinal2
            // 
            this.tbFinal2.Location = new System.Drawing.Point(42, 119);
            this.tbFinal2.Name = "tbFinal2";
            this.tbFinal2.Size = new System.Drawing.Size(403, 22);
            this.tbFinal2.TabIndex = 4;
            // 
            // tbFinal3
            // 
            this.tbFinal3.Location = new System.Drawing.Point(42, 147);
            this.tbFinal3.Name = "tbFinal3";
            this.tbFinal3.Size = new System.Drawing.Size(403, 22);
            this.tbFinal3.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbFinal3);
            this.Controls.Add(this.tbFinal2);
            this.Controls.Add(this.lbFinal);
            this.Controls.Add(this.tbFinal1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbFinal1;
        private System.Windows.Forms.ListBox lbFinal;
        private System.Windows.Forms.TextBox tbFinal2;
        private System.Windows.Forms.TextBox tbFinal3;
    }
}

