using System;
using System.Windows.Forms;

namespace Labs.TextRedactor
{
    public interface IUIterface
    {
        event EventHandler OpenFile;
        event EventHandler SaveFile;
        event EventHandler ContentChanged;
        string TextContent { get; set; }
        string FilePath { get; set; }
    }

    public partial class MainForm : Form, IUIterface
    {
        public event EventHandler OpenFile;
        public event EventHandler SaveFile;
        public event EventHandler ContentChanged;
        public string TextContent
        {
            get
            {
                return textBox.Text;
            }
            set
            {
                textBox.Text = value;
            }
        }
        public string FilePath { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (ContentChanged != null)
            {
                ContentChanged(this, EventArgs.Empty);
            }

            // ContentChanged?.Invoke(this, EventArgs.Empty); // можно так
            this.Text += " *";
            SetSymbolCount();
        }
        private void SetSymbolCount()
        {
            symbolCount.Text = TextContent.Length.ToString();
        }
        private void fileMenuOpen_Click(object sender, EventArgs e)
        {
            if (OpenFile != null)
            {
                OpenFile(this, EventArgs.Empty);
            }
        }
        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            FD.Filter = "*.txt";
            if (FD.ShowDialog() == DialogResult.OK)
            {
                FilePath = FD.FileName;
                if (OpenFile != null)
                {
                    OpenFile(this, EventArgs.Empty);
                }
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (SaveFile != null)
            {
                SaveFile(this, EventArgs.Empty);
            }
        }
        private void fileMenuSave_Click(object sender, EventArgs e)
        {
            saveButton_Click(this, EventArgs.Empty);
        }
        private void copyButton_Click(object sender, EventArgs e)
        {
            new NotImplementedException();
        }
        private void pasteButton_Click(object sender, EventArgs e)
        {
            new NotImplementedException();
        }
        private void FormRedactor_Load(object sender, EventArgs e)
        {
            this.Text += " Новый файл";
        }
        private void newFileButton_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("Сохранить файл?", "Закрытие текущего файла", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            else if (result == DialogResult.Yes && SaveFile != null)
            {
                SaveFile(this, EventArgs.Empty);
            }
            Text = "";
            FormRedactor_Load(this, EventArgs.Empty);

        }
        private void fileMenuQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void quitMenu_Click(object sender, EventArgs e)
        {
            newFileButton_Click(this, EventArgs.Empty);
        }

        private void fontSize_TextChanged(object sender, EventArgs e)
        {
            textBox.Font = new System.Drawing.Font(FontBox.Text, Single.Parse(fontSize.Text));
        }

        private void FontBox_SelectedValueChanged(object sender, EventArgs e)
        {
            fontSize_TextChanged(this, EventArgs.Empty);
        }

    }
}
