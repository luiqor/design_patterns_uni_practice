using System.Windows.Forms;

namespace WinFormsAbstractFactory
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private int secretKey = 1;
        private void Form1_Load(object sender, EventArgs e)
        {
            KeyTextbox.Text = secretKey.ToString();
        }

        private void EncipherButton_Click(object sender, EventArgs e)
        {
            string language = languageCombobox.Text.Trim();
            int secretKey = Convert.ToInt32(KeyTextbox.Text);

            string message = DecipheredRichTextBox.Text;
            string encriptedMessage = "";

            if (language == "Українська")
            {
                Client client = new Client(new UkrFactory());
                encriptedMessage = client.EncryptLanguage(message, secretKey);
            }
            else if (language == "Англійська")
            {
                Client client = new Client(new EngFactory());
                encriptedMessage = client.EncryptLanguage(message, secretKey);

            }
            else
            {
                ShowLanguageError();
            }

            EncipheredRichTextBox.Text = encriptedMessage;

        }

        private void DecipherButton_Click(object sender, EventArgs e)
        {
            string language = languageCombobox.Text.Trim();
            int secretKey = Convert.ToInt32(KeyTextbox.Text);

            string chipheredMessage = EncipheredRichTextBox.Text;
            string decryptedMessage = "";
            if (language == "Українська")
            {
                Client client = new Client(new UkrFactory());
                decryptedMessage = client.DecryptLanguage(chipheredMessage, secretKey);
            }
            else if (language == "Англійська")
            {
                Client client = new Client(new EngFactory());
                decryptedMessage = client.DecryptLanguage(chipheredMessage, secretKey);
            }
            else
            {
                ShowLanguageError();
            }
            DecipheredRichTextBox.Text = decryptedMessage;
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            if (secretKey > 1)
            {
                secretKey--;
                KeyTextbox.Text = secretKey.ToString();
            }

        }
        private void PlusButton_Click(object sender, EventArgs e)
        {
            if (secretKey >= 1)
            {
                secretKey++;
                KeyTextbox.Text = secretKey.ToString();
            }

        }

        public void ShowLanguageError()
        {
            MessageBox.Show("Ви не обрали мову", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void ShowKeyValueError()
        {
            MessageBox.Show("Число для ключа має бути числовим невід'ємним значенням!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void keyCombobox_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(KeyTextbox.Text, out secretKey) || secretKey <= 0)
            {
                ShowKeyValueError();
                secretKey = 1;
                KeyTextbox.Text = secretKey.ToString();
            }
            else
            {
                secretKey = Convert.ToInt32(KeyTextbox.Text);
            }

        }
    }
}