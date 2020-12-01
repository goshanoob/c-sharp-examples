namespace lab12
{
    partial class Form3
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
            this.perim = new System.Windows.Forms.Label();
            this.plosh = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // perim
            // 
            this.perim.AutoSize = true;
            this.perim.Location = new System.Drawing.Point(23, 36);
            this.perim.Name = "perim";
            this.perim.Size = new System.Drawing.Size(35, 13);
            this.perim.TabIndex = 0;
            this.perim.Text = "label1";
            // 
            // plosh
            // 
            this.plosh.AutoSize = true;
            this.plosh.Location = new System.Drawing.Point(23, 87);
            this.plosh.Name = "plosh";
            this.plosh.Size = new System.Drawing.Size(35, 13);
            this.plosh.TabIndex = 1;
            this.plosh.Text = "label2";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 139);
            this.Controls.Add(this.plosh);
            this.Controls.Add(this.perim);
            this.Name = "Form3";
            this.Text = "Результаты";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label perim;
        private System.Windows.Forms.Label plosh;
    }
}