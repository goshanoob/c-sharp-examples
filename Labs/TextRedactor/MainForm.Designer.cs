namespace Labs.TextRedactor
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.fontMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fontMenuUpper = new System.Windows.Forms.ToolStripMenuItem();
            this.fontMenuLower = new System.Windows.Forms.ToolStripMenuItem();
            this.fontMenuFontName = new System.Windows.Forms.ToolStripMenuItem();
            this.fontMenuFontNameArial = new System.Windows.Forms.ToolStripMenuItem();
            this.fontMenuFontNameArialCalibri = new System.Windows.Forms.ToolStripMenuItem();
            this.fontMenuFontNameImpact = new System.Windows.Forms.ToolStripMenuItem();
            this.fontMenuFontNameTimes = new System.Windows.Forms.ToolStripMenuItem();
            this.quitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.textBox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.symbolCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.openButton = new System.Windows.Forms.Button();
            this.pasteButton = new System.Windows.Forms.Button();
            this.copyButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.newFileButton = new System.Windows.Forms.Button();
            this.FontBox = new System.Windows.Forms.ComboBox();
            this.fontSize = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.fontMenu,
            this.quitMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuOpen,
            this.fileMenuSave,
            this.fileMenuSaveAs,
            this.fileMenuQuit});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(48, 20);
            this.fileMenu.Text = "Файл";
            // 
            // fileMenuOpen
            // 
            this.fileMenuOpen.Name = "fileMenuOpen";
            this.fileMenuOpen.Size = new System.Drawing.Size(154, 22);
            this.fileMenuOpen.Text = "Открыть";
            this.fileMenuOpen.Click += new System.EventHandler(this.fileMenuOpen_Click);
            // 
            // fileMenuSave
            // 
            this.fileMenuSave.Name = "fileMenuSave";
            this.fileMenuSave.Size = new System.Drawing.Size(154, 22);
            this.fileMenuSave.Text = "Сохранить";
            this.fileMenuSave.Click += new System.EventHandler(this.fileMenuSave_Click);
            // 
            // fileMenuSaveAs
            // 
            this.fileMenuSaveAs.Name = "fileMenuSaveAs";
            this.fileMenuSaveAs.Size = new System.Drawing.Size(180, 22);
            this.fileMenuSaveAs.Text = "Сохранить как";
            this.fileMenuSaveAs.Click += new System.EventHandler(this.fileMenuSaveAs_Click);
            // 
            // fileMenuQuit
            // 
            this.fileMenuQuit.Name = "fileMenuQuit";
            this.fileMenuQuit.Size = new System.Drawing.Size(154, 22);
            this.fileMenuQuit.Text = "Закрыть";
            this.fileMenuQuit.Click += new System.EventHandler(this.fileMenuQuit_Click);
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editMenuCopy,
            this.editMenuPaste});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(59, 20);
            this.editMenu.Text = "Правка";
            // 
            // editMenuCopy
            // 
            this.editMenuCopy.Name = "editMenuCopy";
            this.editMenuCopy.Size = new System.Drawing.Size(180, 22);
            this.editMenuCopy.Text = "Копировать";
            // 
            // editMenuPaste
            // 
            this.editMenuPaste.Name = "editMenuPaste";
            this.editMenuPaste.Size = new System.Drawing.Size(180, 22);
            this.editMenuPaste.Text = "Вставить";
            // 
            // fontMenu
            // 
            this.fontMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontMenuUpper,
            this.fontMenuLower,
            this.fontMenuFontName});
            this.fontMenu.Name = "fontMenu";
            this.fontMenu.Size = new System.Drawing.Size(58, 20);
            this.fontMenu.Text = "Шрифт";
            // 
            // fontMenuUpper
            // 
            this.fontMenuUpper.Name = "fontMenuUpper";
            this.fontMenuUpper.Size = new System.Drawing.Size(174, 22);
            this.fontMenuUpper.Text = "Увеличить";
            // 
            // fontMenuLower
            // 
            this.fontMenuLower.Name = "fontMenuLower";
            this.fontMenuLower.Size = new System.Drawing.Size(174, 22);
            this.fontMenuLower.Text = "Уменьшить";
            // 
            // fontMenuFontName
            // 
            this.fontMenuFontName.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontMenuFontNameArial,
            this.fontMenuFontNameArialCalibri,
            this.fontMenuFontNameImpact,
            this.fontMenuFontNameTimes});
            this.fontMenuFontName.Name = "fontMenuFontName";
            this.fontMenuFontName.Size = new System.Drawing.Size(174, 22);
            this.fontMenuFontName.Text = "Название шрифта";
            // 
            // fontMenuFontNameArial
            // 
            this.fontMenuFontNameArial.Name = "fontMenuFontNameArial";
            this.fontMenuFontNameArial.Size = new System.Drawing.Size(173, 22);
            this.fontMenuFontNameArial.Text = "Arial";
            // 
            // fontMenuFontNameArialCalibri
            // 
            this.fontMenuFontNameArialCalibri.Name = "fontMenuFontNameArialCalibri";
            this.fontMenuFontNameArialCalibri.Size = new System.Drawing.Size(173, 22);
            this.fontMenuFontNameArialCalibri.Text = "Calibri";
            // 
            // fontMenuFontNameImpact
            // 
            this.fontMenuFontNameImpact.Name = "fontMenuFontNameImpact";
            this.fontMenuFontNameImpact.Size = new System.Drawing.Size(173, 22);
            this.fontMenuFontNameImpact.Text = "Impact";
            // 
            // fontMenuFontNameTimes
            // 
            this.fontMenuFontNameTimes.Name = "fontMenuFontNameTimes";
            this.fontMenuFontNameTimes.Size = new System.Drawing.Size(173, 22);
            this.fontMenuFontNameTimes.Text = "Times New Roman";
            // 
            // quitMenu
            // 
            this.quitMenu.Name = "quitMenu";
            this.quitMenu.Size = new System.Drawing.Size(54, 20);
            this.quitMenu.Text = "Выход";
            this.quitMenu.Click += new System.EventHandler(this.quitMenu_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Location = new System.Drawing.Point(9, 53);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox.Size = new System.Drawing.Size(794, 374);
            this.textBox.TabIndex = 8;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.symbolCount});
            this.statusStrip1.Location = new System.Drawing.Point(634, 429);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(166, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(136, 17);
            this.toolStripStatusLabel1.Text = "Количество символов: ";
            // 
            // symbolCount
            // 
            this.symbolCount.Name = "symbolCount";
            this.symbolCount.Size = new System.Drawing.Size(13, 17);
            this.symbolCount.Text = "0";
            this.symbolCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // openButton
            // 
            this.openButton.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.open;
            this.openButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.openButton.Location = new System.Drawing.Point(31, 24);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(15, 21);
            this.openButton.TabIndex = 10;
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // pasteButton
            // 
            this.pasteButton.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.insert;
            this.pasteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pasteButton.Location = new System.Drawing.Point(88, 24);
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.Size = new System.Drawing.Size(15, 21);
            this.pasteButton.TabIndex = 7;
            this.pasteButton.UseVisualStyleBackColor = true;
            this.pasteButton.Click += new System.EventHandler(this.pasteButton_Click);
            // 
            // copyButton
            // 
            this.copyButton.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.copy;
            this.copyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.copyButton.Location = new System.Drawing.Point(69, 24);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(15, 21);
            this.copyButton.TabIndex = 5;
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.save;
            this.saveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.saveButton.Location = new System.Drawing.Point(50, 24);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(15, 21);
            this.saveButton.TabIndex = 4;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // newFileButton
            // 
            this.newFileButton.BackgroundImage = global::WindowsFormsApp1.Properties.Resources._new;
            this.newFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.newFileButton.Location = new System.Drawing.Point(12, 24);
            this.newFileButton.Name = "newFileButton";
            this.newFileButton.Size = new System.Drawing.Size(15, 21);
            this.newFileButton.TabIndex = 3;
            this.newFileButton.UseVisualStyleBackColor = true;
            this.newFileButton.Click += new System.EventHandler(this.newFileButton_Click);
            // 
            // FontBox
            // 
            this.FontBox.DisplayMember = "Calibri";
            this.FontBox.FormattingEnabled = true;
            this.FontBox.Items.AddRange(new object[] {
            "Arial",
            "Calibri",
            "Impact",
            "Times New Roman"});
            this.FontBox.Location = new System.Drawing.Point(237, 25);
            this.FontBox.Name = "FontBox";
            this.FontBox.Size = new System.Drawing.Size(121, 21);
            this.FontBox.TabIndex = 11;
            this.FontBox.Text = "Calibri";
            this.FontBox.SelectedValueChanged += new System.EventHandler(this.FontBox_SelectedValueChanged);
            // 
            // fontSize
            // 
            this.fontSize.Location = new System.Drawing.Point(111, 25);
            this.fontSize.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.fontSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.fontSize.Name = "fontSize";
            this.fontSize.Size = new System.Drawing.Size(120, 20);
            this.fontSize.TabIndex = 12;
            this.fontSize.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.fontSize.ValueChanged += new System.EventHandler(this.fontSize_ValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fontSize);
            this.Controls.Add(this.FontBox);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.pasteButton);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.newFileButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Текстовый редактор";
            this.Load += new System.EventHandler(this.FormRedactor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenuOpen;
        private System.Windows.Forms.ToolStripMenuItem fileMenuSave;
        private System.Windows.Forms.ToolStripMenuItem fileMenuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem fileMenuQuit;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem editMenuCopy;
        private System.Windows.Forms.ToolStripMenuItem editMenuPaste;
        private System.Windows.Forms.ToolStripMenuItem fontMenu;
        private System.Windows.Forms.ToolStripMenuItem fontMenuUpper;
        private System.Windows.Forms.ToolStripMenuItem fontMenuLower;
        private System.Windows.Forms.ToolStripMenuItem fontMenuFontName;
        private System.Windows.Forms.ToolStripMenuItem fontMenuFontNameArial;
        private System.Windows.Forms.ToolStripMenuItem fontMenuFontNameArialCalibri;
        private System.Windows.Forms.ToolStripMenuItem fontMenuFontNameImpact;
        private System.Windows.Forms.ToolStripMenuItem fontMenuFontNameTimes;
        private System.Windows.Forms.ToolStripMenuItem quitMenu;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button newFileButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button pasteButton;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel symbolCount;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.ComboBox FontBox;
        private System.Windows.Forms.NumericUpDown fontSize;
    }
}

