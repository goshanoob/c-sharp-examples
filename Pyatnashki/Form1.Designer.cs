namespace Pyatnashki
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
            this.tag9 = new System.Windows.Forms.Button();
            this.tag8 = new System.Windows.Forms.Button();
            this.tag7 = new System.Windows.Forms.Button();
            this.tag6 = new System.Windows.Forms.Button();
            this.tag5 = new System.Windows.Forms.Button();
            this.tag4 = new System.Windows.Forms.Button();
            this.tag3 = new System.Windows.Forms.Button();
            this.tag2 = new System.Windows.Forms.Button();
            this.tag1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.shuffleTags = new System.Windows.Forms.ToolStripMenuItem();
            this.quitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tag9
            // 
            this.tag9.Location = new System.Drawing.Point(400, 300);
            this.tag9.Name = "tag9";
            this.tag9.Size = new System.Drawing.Size(80, 80);
            this.tag9.TabIndex = 0;
            this.tag9.Text = "0";
            this.tag9.UseVisualStyleBackColor = true;
            this.tag9.Visible = false;
            // 
            // tag8
            // 
            this.tag8.Location = new System.Drawing.Point(300, 300);
            this.tag8.Name = "tag8";
            this.tag8.Size = new System.Drawing.Size(80, 80);
            this.tag8.TabIndex = 1;
            this.tag8.Text = "8";
            this.tag8.UseVisualStyleBackColor = true;
            // 
            // tag7
            // 
            this.tag7.Location = new System.Drawing.Point(200, 300);
            this.tag7.Name = "tag7";
            this.tag7.Size = new System.Drawing.Size(80, 80);
            this.tag7.TabIndex = 2;
            this.tag7.Text = "7";
            this.tag7.UseVisualStyleBackColor = true;
            // 
            // tag6
            // 
            this.tag6.Location = new System.Drawing.Point(400, 200);
            this.tag6.Name = "tag6";
            this.tag6.Size = new System.Drawing.Size(80, 80);
            this.tag6.TabIndex = 3;
            this.tag6.Text = "6";
            this.tag6.UseVisualStyleBackColor = true;
            // 
            // tag5
            // 
            this.tag5.Location = new System.Drawing.Point(300, 200);
            this.tag5.Name = "tag5";
            this.tag5.Size = new System.Drawing.Size(80, 80);
            this.tag5.TabIndex = 4;
            this.tag5.Text = "5";
            this.tag5.UseVisualStyleBackColor = true;
            // 
            // tag4
            // 
            this.tag4.Location = new System.Drawing.Point(200, 200);
            this.tag4.Name = "tag4";
            this.tag4.Size = new System.Drawing.Size(80, 80);
            this.tag4.TabIndex = 5;
            this.tag4.Text = "4";
            this.tag4.UseVisualStyleBackColor = true;
            // 
            // tag3
            // 
            this.tag3.Location = new System.Drawing.Point(400, 100);
            this.tag3.Name = "tag3";
            this.tag3.Size = new System.Drawing.Size(80, 80);
            this.tag3.TabIndex = 6;
            this.tag3.Text = "3";
            this.tag3.UseVisualStyleBackColor = true;
            // 
            // tag2
            // 
            this.tag2.Location = new System.Drawing.Point(300, 100);
            this.tag2.Name = "tag2";
            this.tag2.Size = new System.Drawing.Size(80, 80);
            this.tag2.TabIndex = 7;
            this.tag2.Text = "2";
            this.tag2.UseVisualStyleBackColor = true;
            // 
            // tag1
            // 
            this.tag1.Location = new System.Drawing.Point(200, 100);
            this.tag1.Name = "tag1";
            this.tag1.Size = new System.Drawing.Size(80, 80);
            this.tag1.TabIndex = 8;
            this.tag1.Text = "1";
            this.tag1.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shuffleTags,
            this.quitMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // shuffleTags
            // 
            this.shuffleTags.Name = "shuffleTags";
            this.shuffleTags.Size = new System.Drawing.Size(148, 20);
            this.shuffleTags.Text = "Перемешать пятнашки";
            this.shuffleTags.Click += new System.EventHandler(this.shuffleTags_Click);
            // 
            // quitMenu
            // 
            this.quitMenu.Name = "quitMenu";
            this.quitMenu.Size = new System.Drawing.Size(54, 20);
            this.quitMenu.Text = "Выход";
            this.quitMenu.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tag1);
            this.Controls.Add(this.tag2);
            this.Controls.Add(this.tag3);
            this.Controls.Add(this.tag4);
            this.Controls.Add(this.tag5);
            this.Controls.Add(this.tag6);
            this.Controls.Add(this.tag7);
            this.Controls.Add(this.tag8);
            this.Controls.Add(this.tag9);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button tag9;
        private System.Windows.Forms.Button tag8;
        private System.Windows.Forms.Button tag7;
        private System.Windows.Forms.Button tag6;
        private System.Windows.Forms.Button tag5;
        private System.Windows.Forms.Button tag4;
        private System.Windows.Forms.Button tag3;
        private System.Windows.Forms.Button tag2;
        private System.Windows.Forms.Button tag1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem shuffleTags;
        private System.Windows.Forms.ToolStripMenuItem quitMenu;
    }
}

