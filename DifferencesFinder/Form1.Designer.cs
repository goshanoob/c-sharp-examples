namespace goshanoob.DifferencesFinder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.makeScreenButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.makeClicksButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // makeScreenButton
            // 
            this.makeScreenButton.Location = new System.Drawing.Point(24, 8);
            this.makeScreenButton.Name = "makeScreenButton";
            this.makeScreenButton.Size = new System.Drawing.Size(93, 91);
            this.makeScreenButton.TabIndex = 2;
            this.makeScreenButton.Text = "Запустить анимацию";
            this.makeScreenButton.UseVisualStyleBackColor = true;
            this.makeScreenButton.Click += new System.EventHandler(this.makeScreenButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(24, 129);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(413, 388);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 8);
            this.label1.MaximumSize = new System.Drawing.Size(230, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 78);
            this.label1.TabIndex = 4;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(220, 95);
            this.label2.MaximumSize = new System.Drawing.Size(220, 0);
            this.label2.MinimumSize = new System.Drawing.Size(100, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Пока поддержка разрешения только 1600х900";
            // 
            // makeClicksButton
            // 
            this.makeClicksButton.Location = new System.Drawing.Point(123, 8);
            this.makeClicksButton.Name = "makeClicksButton";
            this.makeClicksButton.Size = new System.Drawing.Size(91, 91);
            this.makeClicksButton.TabIndex = 6;
            this.makeClicksButton.Text = "Сделать ход";
            this.makeClicksButton.UseVisualStyleBackColor = true;
            this.makeClicksButton.Click += new System.EventHandler(this.makeClicksButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 661);
            this.Controls.Add(this.makeClicksButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.makeScreenButton);
            this.Name = "Form1";
            this.Text = "Поиск отличий";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button makeScreenButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button makeClicksButton;
    }
}

