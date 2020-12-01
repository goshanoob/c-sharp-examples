namespace RectWindowsForms
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sizeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.paintMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sizeMenu,
            this.paintMenu,
            this.quitToolMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sizeMenu
            // 
            this.sizeMenu.Name = "sizeMenu";
            this.sizeMenu.Size = new System.Drawing.Size(39, 20);
            this.sizeMenu.Text = "Size";
            this.sizeMenu.Click += new System.EventHandler(this.sizeMenu_Click);
            // 
            // paintMenu
            // 
            this.paintMenu.Name = "paintMenu";
            this.paintMenu.Size = new System.Drawing.Size(46, 20);
            this.paintMenu.Text = "Paint";
            this.paintMenu.Click += new System.EventHandler(this.paintMenu_Click);
            // 
            // quitToolMenu
            // 
            this.quitToolMenu.Name = "quitToolMenu";
            this.quitToolMenu.Size = new System.Drawing.Size(42, 20);
            this.quitToolMenu.Text = "Quit";
            this.quitToolMenu.Click += new System.EventHandler(this.quitToolMenu_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Рисование прямоугольников";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sizeMenu;
        private System.Windows.Forms.ToolStripMenuItem paintMenu;
        private System.Windows.Forms.ToolStripMenuItem quitToolMenu;
    }
}

