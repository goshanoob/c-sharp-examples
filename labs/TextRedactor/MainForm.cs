using System;
using System.Windows.Forms;

namespace Labs.TextRedactor
{
    // Интерфейс IUIterface содержит события открытия файла и сохранения, а также два свойства: с содержимым
    // файла и путь к файлу.
    public interface IUIterface
    {
        event EventHandler OpenFile;
        event EventHandler SaveFile;
        string TextContent { get; set; }
        string FilePath { get; set; }
    }

    public partial class MainForm : Form, IUIterface
    {
        public event EventHandler OpenFile;
        public event EventHandler SaveFile;
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
            Text += " *";
            SetSymbolCount();
        }
        private void SetSymbolCount()
        {
            symbolCount.Text = TextContent.Length.ToString(); // вернули количество символов в тексте формы
        }
        private void fileMenuOpen_Click(object sender, EventArgs e)
        {
            openButton_Click(this, EventArgs.Empty);
        }
        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            FD.Filter = "Текстовый документ|*.txt";
            if (FD.ShowDialog() == DialogResult.OK)
            {
                FilePath = FD.FileName;
                // OpenFile?.Invoke(this, EventArgs.Empty); // можно так
                if (OpenFile != null)
                {
                    OpenFile(this, EventArgs.Empty);
                }
                fontSize_TextChanged(this, EventArgs.Empty); // выставили шрифт
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
            new NotImplementedException(); // не реализовано
        }
        private void pasteButton_Click(object sender, EventArgs e)
        {
            new NotImplementedException();
        }
        private void FormRedactor_Load(object sender, EventArgs e)
        {
            Text += " Новый файл";
            textBox.Clear();
            TextContent = "";
            FilePath = null;
            ToolTip tip = new ToolTip();
            tip.SetToolTip(openButton, "Открыть файл");
            tip.SetToolTip(newFileButton, "Открыть файл");
            tip.SetToolTip(saveButton, "Сохранить файл");
            tip.SetToolTip(copyButton, "Копировать в буфер");
            tip.SetToolTip(pasteButton, "Вставить текст");

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
                if (FilePath == null) fileMenuSaveAs_Click(this, EventArgs.Empty); // вызов меню Сохранить как
                SaveFile(this, EventArgs.Empty);
            }
            FormRedactor_Load(this, EventArgs.Empty);

        }
        private void fileMenuQuit_Click(object sender, EventArgs e)
        {
            newFileButton_Click(this, EventArgs.Empty);
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

        private void fontSize_ValueChanged(object sender, EventArgs e)
        {
            fontSize_TextChanged(this, EventArgs.Empty);
        }

        private void fileMenuSaveAs_Click(object sender, EventArgs e)
        {
            new NotImplementedException();
        }
    }
}
