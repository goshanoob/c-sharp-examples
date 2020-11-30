namespace goshanoob.CleanUpApp
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
            this.filesListBox = new System.Windows.Forms.ListBox();
            this.updateFileListButton = new System.Windows.Forms.Button();
            this.testSortButton = new System.Windows.Forms.Button();
            this.sortButton = new System.Windows.Forms.Button();
            this.sortedListBox = new System.Windows.Forms.ListBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.catalogueTextBox = new System.Windows.Forms.TextBox();
            this.changeCatalogueButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // filesListBox
            // 
            this.filesListBox.FormattingEnabled = true;
            this.filesListBox.HorizontalScrollbar = true;
            this.filesListBox.Location = new System.Drawing.Point(12, 87);
            this.filesListBox.Name = "filesListBox";
            this.filesListBox.Size = new System.Drawing.Size(569, 667);
            this.filesListBox.TabIndex = 0;
            // 
            // updateFileListButton
            // 
            this.updateFileListButton.Location = new System.Drawing.Point(48, 21);
            this.updateFileListButton.Name = "updateFileListButton";
            this.updateFileListButton.Size = new System.Drawing.Size(111, 45);
            this.updateFileListButton.TabIndex = 1;
            this.updateFileListButton.Text = "Обновить список файлов";
            this.updateFileListButton.UseVisualStyleBackColor = true;
            this.updateFileListButton.Click += new System.EventHandler(this.updateFileListButton_Click);
            // 
            // testSortButton
            // 
            this.testSortButton.Location = new System.Drawing.Point(200, 20);
            this.testSortButton.Name = "testSortButton";
            this.testSortButton.Size = new System.Drawing.Size(114, 45);
            this.testSortButton.TabIndex = 2;
            this.testSortButton.Text = "Тестовая сортировка";
            this.testSortButton.UseVisualStyleBackColor = true;
            this.testSortButton.Click += new System.EventHandler(this.testSortButton_Click);
            // 
            // sortButton
            // 
            this.sortButton.Location = new System.Drawing.Point(353, 21);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(105, 43);
            this.sortButton.TabIndex = 3;
            this.sortButton.Text = "Сортировать";
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // 
            // sortedListBox
            // 
            this.sortedListBox.FormattingEnabled = true;
            this.sortedListBox.Location = new System.Drawing.Point(596, 114);
            this.sortedListBox.Name = "sortedListBox";
            this.sortedListBox.Size = new System.Drawing.Size(660, 641);
            this.sortedListBox.TabIndex = 4;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(926, 47);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(41, 13);
            this.statusLabel.TabIndex = 5;
            this.statusLabel.Text = "Сатутс";
            // 
            // catalogueTextBox
            // 
            this.catalogueTextBox.Location = new System.Drawing.Point(505, 44);
            this.catalogueTextBox.Multiline = true;
            this.catalogueTextBox.Name = "catalogueTextBox";
            this.catalogueTextBox.Size = new System.Drawing.Size(208, 20);
            this.catalogueTextBox.TabIndex = 6;
            // 
            // changeCatalogueButton
            // 
            this.changeCatalogueButton.Location = new System.Drawing.Point(740, 23);
            this.changeCatalogueButton.Name = "changeCatalogueButton";
            this.changeCatalogueButton.Size = new System.Drawing.Size(75, 43);
            this.changeCatalogueButton.TabIndex = 7;
            this.changeCatalogueButton.Text = "Изменить каталог";
            this.changeCatalogueButton.UseVisualStyleBackColor = true;
            this.changeCatalogueButton.Click += new System.EventHandler(this.changeCatalogueButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(502, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Рабочий каталог";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(692, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(593, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Тестовая сортировка:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 761);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.changeCatalogueButton);
            this.Controls.Add(this.catalogueTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.sortedListBox);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.testSortButton);
            this.Controls.Add(this.updateFileListButton);
            this.Controls.Add(this.filesListBox);
            this.Name = "Form1";
            this.Text = "Сортировка файлов по папкам";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox filesListBox; 
        private System.Windows.Forms.Button updateFileListButton;
        private System.Windows.Forms.Button testSortButton;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.ListBox sortedListBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TextBox catalogueTextBox;
        private System.Windows.Forms.Button changeCatalogueButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

