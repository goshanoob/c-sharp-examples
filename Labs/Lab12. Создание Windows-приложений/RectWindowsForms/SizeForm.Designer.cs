namespace RectWindowsForms
{
    partial class SizeForm
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
            this.sizeA = new System.Windows.Forms.TextBox();
            this.sizeB = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.blueFlag = new System.Windows.Forms.CheckBox();
            this.greenFlag = new System.Windows.Forms.CheckBox();
            this.redFlag = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sizeA
            // 
            this.sizeA.Location = new System.Drawing.Point(27, 35);
            this.sizeA.Name = "sizeA";
            this.sizeA.Size = new System.Drawing.Size(100, 20);
            this.sizeA.TabIndex = 0;
            this.sizeA.Text = "100";
            // 
            // sizeB
            // 
            this.sizeB.Location = new System.Drawing.Point(169, 35);
            this.sizeB.Name = "sizeB";
            this.sizeB.Size = new System.Drawing.Size(100, 20);
            this.sizeB.TabIndex = 1;
            this.sizeB.Text = "50";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.blueFlag);
            this.groupBox1.Controls.Add(this.greenFlag);
            this.groupBox1.Controls.Add(this.redFlag);
            this.groupBox1.Location = new System.Drawing.Point(56, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 90);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Цвет";
            // 
            // blueFlag
            // 
            this.blueFlag.AutoSize = true;
            this.blueFlag.Location = new System.Drawing.Point(94, 68);
            this.blueFlag.Name = "blueFlag";
            this.blueFlag.Size = new System.Drawing.Size(57, 17);
            this.blueFlag.TabIndex = 2;
            this.blueFlag.Text = "Синий";
            this.blueFlag.UseVisualStyleBackColor = true;
            // 
            // greenFlag
            // 
            this.greenFlag.AutoSize = true;
            this.greenFlag.Location = new System.Drawing.Point(94, 45);
            this.greenFlag.Name = "greenFlag";
            this.greenFlag.Size = new System.Drawing.Size(71, 17);
            this.greenFlag.TabIndex = 1;
            this.greenFlag.Text = "Зеленый";
            this.greenFlag.UseVisualStyleBackColor = true;
            // 
            // redFlag
            // 
            this.redFlag.AutoSize = true;
            this.redFlag.Location = new System.Drawing.Point(94, 19);
            this.redFlag.Name = "redFlag";
            this.redFlag.Size = new System.Drawing.Size(71, 17);
            this.redFlag.TabIndex = 0;
            this.redFlag.Text = "Красный";
            this.redFlag.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(111, 159);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Сторона A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Сторона B";
            // 
            // SizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 205);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sizeB);
            this.Controls.Add(this.sizeA);
            this.Name = "SizeForm";
            this.Text = "Ввод сторон прямоугольника";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sizeA;
        private System.Windows.Forms.TextBox sizeB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox blueFlag;
        private System.Windows.Forms.CheckBox greenFlag;
        private System.Windows.Forms.CheckBox redFlag;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}