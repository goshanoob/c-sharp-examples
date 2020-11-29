namespace goshanoob.MatchesCounter
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
            this.countWordsButton = new System.Windows.Forms.Button();
            this.audioText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loginBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.wordsCounterBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // countWordsButton
            // 
            this.countWordsButton.Location = new System.Drawing.Point(26, 37);
            this.countWordsButton.Name = "countWordsButton";
            this.countWordsButton.Size = new System.Drawing.Size(525, 70);
            this.countWordsButton.TabIndex = 0;
            this.countWordsButton.Text = "Подсчитать слова в текстах аудио на странице пользователя";
            this.countWordsButton.UseVisualStyleBackColor = true;
            this.countWordsButton.Click += new System.EventHandler(this.countWordsButton_Click);
            // 
            // audioText
            // 
            this.audioText.Location = new System.Drawing.Point(26, 118);
            this.audioText.Multiline = true;
            this.audioText.Name = "audioText";
            this.audioText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.audioText.Size = new System.Drawing.Size(525, 402);
            this.audioText.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Логин VK";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Пароль";
            // 
            // loginBox
            // 
            this.loginBox.Location = new System.Drawing.Point(84, 6);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(145, 20);
            this.loginBox.TabIndex = 5;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(320, 6);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(140, 20);
            this.passwordBox.TabIndex = 6;
            this.passwordBox.UseSystemPasswordChar = true;
            // 
            // wordsCounterBox
            // 
            this.wordsCounterBox.Location = new System.Drawing.Point(583, 37);
            this.wordsCounterBox.Multiline = true;
            this.wordsCounterBox.Name = "wordsCounterBox";
            this.wordsCounterBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.wordsCounterBox.Size = new System.Drawing.Size(540, 483);
            this.wordsCounterBox.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 595);
            this.Controls.Add(this.wordsCounterBox);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.loginBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.audioText);
            this.Controls.Add(this.countWordsButton);
            this.Name = "Form1";
            this.Text = "Подсчёт количества слов в тексах аудио";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button countWordsButton;
        private System.Windows.Forms.TextBox audioText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox loginBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox wordsCounterBox;
    }
}

