namespace lab12
{
    partial class Form2
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
            this.boxA = new System.Windows.Forms.TextBox();
            this.boxB = new System.Windows.Forms.TextBox();
            this.boxC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkPlosh = new System.Windows.Forms.CheckBox();
            this.checkPerim = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxA
            // 
            this.boxA.Location = new System.Drawing.Point(114, 55);
            this.boxA.Name = "boxA";
            this.boxA.Size = new System.Drawing.Size(100, 20);
            this.boxA.TabIndex = 0;
            // 
            // boxB
            // 
            this.boxB.Location = new System.Drawing.Point(114, 93);
            this.boxB.Name = "boxB";
            this.boxB.Size = new System.Drawing.Size(100, 20);
            this.boxB.TabIndex = 1;
            // 
            // boxC
            // 
            this.boxC.Location = new System.Drawing.Point(114, 130);
            this.boxC.Name = "boxC";
            this.boxC.Size = new System.Drawing.Size(100, 20);
            this.boxC.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.CausesValidation = false;
            this.label1.Location = new System.Drawing.Point(50, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Сторона a";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Сторона b";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Сторона c";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkPlosh);
            this.groupBox1.Controls.Add(this.checkPerim);
            this.groupBox1.Location = new System.Drawing.Point(231, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 95);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Требуемые вычисления";
            // 
            // checkPlosh
            // 
            this.checkPlosh.AutoSize = true;
            this.checkPlosh.Checked = true;
            this.checkPlosh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkPlosh.Location = new System.Drawing.Point(32, 55);
            this.checkPlosh.Name = "checkPlosh";
            this.checkPlosh.Size = new System.Drawing.Size(73, 17);
            this.checkPlosh.TabIndex = 1;
            this.checkPlosh.Text = "Площадь";
            this.checkPlosh.UseVisualStyleBackColor = true;
            // 
            // checkPerim
            // 
            this.checkPerim.AutoSize = true;
            this.checkPerim.Checked = true;
            this.checkPerim.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkPerim.Location = new System.Drawing.Point(32, 32);
            this.checkPerim.Name = "checkPerim";
            this.checkPerim.Size = new System.Drawing.Size(77, 17);
            this.checkPerim.TabIndex = 0;
            this.checkPerim.Text = "Периметр";
            this.checkPerim.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(114, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(229, 66);
            this.button1.TabIndex = 7;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 275);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.boxC);
            this.Controls.Add(this.boxB);
            this.Controls.Add(this.boxA);
            this.Name = "Form2";
            this.Text = "Ввод сторон треугольника";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox boxA;
        private System.Windows.Forms.TextBox boxB;
        private System.Windows.Forms.TextBox boxC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkPlosh;
        private System.Windows.Forms.CheckBox checkPerim;
        private System.Windows.Forms.Button button1;
    }
}