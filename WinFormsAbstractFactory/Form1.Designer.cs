namespace WinFormsAbstractFactory
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AppNameLabel = new Label();
            OriginalTextLabel = new Label();
            DecipheredRichTextBox = new RichTextBox();
            EncipherButton = new Button();
            languageCombobox = new ComboBox();
            EncipheredRichTextBox = new RichTextBox();
            LanguageLabel = new Label();
            KeyLabel = new Label();
            KeyTextbox = new TextBox();
            PlusButton = new Button();
            MinusButton = new Button();
            DecipherButton = new Button();
            CipheredTextLabel = new Label();
            SuspendLayout();
            // 
            // AppNameLabel
            // 
            AppNameLabel.AutoSize = true;
            AppNameLabel.Font = new Font("Candara", 18F, FontStyle.Bold, GraphicsUnit.Point);
            AppNameLabel.Location = new Point(88, 25);
            AppNameLabel.Name = "AppNameLabel";
            AppNameLabel.Size = new Size(231, 29);
            AppNameLabel.TabIndex = 1;
            AppNameLabel.Text = "Шифрування текстів";
            // 
            // OriginalTextLabel
            // 
            OriginalTextLabel.AutoSize = true;
            OriginalTextLabel.Font = new Font("Candara", 14F, FontStyle.Regular, GraphicsUnit.Point);
            OriginalTextLabel.Location = new Point(88, 58);
            OriginalTextLabel.Name = "OriginalTextLabel";
            OriginalTextLabel.Size = new Size(239, 23);
            OriginalTextLabel.TabIndex = 2;
            OriginalTextLabel.Text = "Оригінальне повідомлення:";
            // 
            // DecipheredRichTextBox
            // 
            DecipheredRichTextBox.Font = new Font("Candara", 10F, FontStyle.Regular, GraphicsUnit.Point);
            DecipheredRichTextBox.Location = new Point(88, 84);
            DecipheredRichTextBox.Name = "DecipheredRichTextBox";
            DecipheredRichTextBox.Size = new Size(664, 133);
            DecipheredRichTextBox.TabIndex = 3;
            DecipheredRichTextBox.Text = "";
            // 
            // EncipherButton
            // 
            EncipherButton.BackColor = Color.White;
            EncipherButton.Font = new Font("Candara", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EncipherButton.Location = new Point(511, 223);
            EncipherButton.Name = "EncipherButton";
            EncipherButton.Size = new Size(241, 28);
            EncipherButton.TabIndex = 4;
            EncipherButton.Text = "Encipher";
            EncipherButton.UseVisualStyleBackColor = false;
            EncipherButton.Click += EncipherButton_Click;
            // 
            // languageCombobox
            // 
            languageCombobox.Font = new Font("Candara", 10F, FontStyle.Regular, GraphicsUnit.Point);
            languageCombobox.FormattingEnabled = true;
            languageCombobox.Items.AddRange(new object[] { "Англійська", "Українська" });
            languageCombobox.Location = new Point(221, 262);
            languageCombobox.Name = "languageCombobox";
            languageCombobox.Size = new Size(180, 23);
            languageCombobox.TabIndex = 5;
            // 
            // EncipheredRichTextBox
            // 
            EncipheredRichTextBox.Font = new Font("Candara", 10F, FontStyle.Regular, GraphicsUnit.Point);
            EncipheredRichTextBox.Location = new Point(88, 368);
            EncipheredRichTextBox.Name = "EncipheredRichTextBox";
            EncipheredRichTextBox.Size = new Size(664, 133);
            EncipheredRichTextBox.TabIndex = 6;
            EncipheredRichTextBox.Text = "";
            // 
            // LanguageLabel
            // 
            LanguageLabel.AutoSize = true;
            LanguageLabel.Font = new Font("Candara", 14F, FontStyle.Regular, GraphicsUnit.Point);
            LanguageLabel.Location = new Point(88, 259);
            LanguageLabel.Name = "LanguageLabel";
            LanguageLabel.Size = new Size(127, 23);
            LanguageLabel.TabIndex = 7;
            LanguageLabel.Text = "Оберіть мову:";
            // 
            // KeyLabel
            // 
            KeyLabel.AutoSize = true;
            KeyLabel.Font = new Font("Candara", 14F, FontStyle.Regular, GraphicsUnit.Point);
            KeyLabel.Location = new Point(88, 293);
            KeyLabel.Name = "KeyLabel";
            KeyLabel.Size = new Size(106, 23);
            KeyLabel.TabIndex = 8;
            KeyLabel.Text = "Ключ зсуву:";
            // 
            // KeyTextbox
            // 
            KeyTextbox.Location = new Point(251, 296);
            KeyTextbox.Name = "KeyTextbox";
            KeyTextbox.Size = new Size(41, 23);
            KeyTextbox.TabIndex = 9;
            KeyTextbox.TextChanged += keyCombobox_TextChanged;
            // 
            // PlusButton
            // 
            PlusButton.BackColor = Color.White;
            PlusButton.Font = new Font("Candara", 10F, FontStyle.Regular, GraphicsUnit.Point);
            PlusButton.Location = new Point(298, 296);
            PlusButton.Name = "PlusButton";
            PlusButton.Size = new Size(24, 23);
            PlusButton.TabIndex = 10;
            PlusButton.Text = "+";
            PlusButton.UseVisualStyleBackColor = false;
            PlusButton.Click += PlusButton_Click;
            // 
            // MinusButton
            // 
            MinusButton.BackColor = Color.White;
            MinusButton.Font = new Font("Candara", 10F, FontStyle.Regular, GraphicsUnit.Point);
            MinusButton.Location = new Point(221, 296);
            MinusButton.Name = "MinusButton";
            MinusButton.Size = new Size(24, 23);
            MinusButton.TabIndex = 11;
            MinusButton.Text = "-";
            MinusButton.UseVisualStyleBackColor = false;
            MinusButton.Click += MinusButton_Click;
            // 
            // DecipherButton
            // 
            DecipherButton.BackColor = Color.White;
            DecipherButton.Font = new Font("Candara", 10F, FontStyle.Regular, GraphicsUnit.Point);
            DecipherButton.Location = new Point(511, 507);
            DecipherButton.Name = "DecipherButton";
            DecipherButton.Size = new Size(241, 28);
            DecipherButton.TabIndex = 12;
            DecipherButton.Text = "Decipher";
            DecipherButton.UseVisualStyleBackColor = false;
            DecipherButton.Click += DecipherButton_Click;
            // 
            // CipheredTextLabel
            // 
            CipheredTextLabel.AutoSize = true;
            CipheredTextLabel.Font = new Font("Candara", 14F, FontStyle.Regular, GraphicsUnit.Point);
            CipheredTextLabel.Location = new Point(88, 342);
            CipheredTextLabel.Name = "CipheredTextLabel";
            CipheredTextLabel.Size = new Size(253, 23);
            CipheredTextLabel.TabIndex = 13;
            CipheredTextLabel.Text = "Зашифроване повідомлення:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(834, 588);
            Controls.Add(CipheredTextLabel);
            Controls.Add(DecipherButton);
            Controls.Add(MinusButton);
            Controls.Add(PlusButton);
            Controls.Add(KeyTextbox);
            Controls.Add(KeyLabel);
            Controls.Add(LanguageLabel);
            Controls.Add(EncipheredRichTextBox);
            Controls.Add(languageCombobox);
            Controls.Add(EncipherButton);
            Controls.Add(DecipheredRichTextBox);
            Controls.Add(OriginalTextLabel);
            Controls.Add(AppNameLabel);
            Name = "Form1";
            Text = "Ciphering app";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label AppNameLabel;
        private Label OriginalTextLabel;
        private RichTextBox DecipheredRichTextBox;
        private Button EncipherButton;
        private ComboBox languageCombobox;
        private RichTextBox EncipheredRichTextBox;
        private Label LanguageLabel;
        private Label KeyLabel;
        private TextBox KeyTextbox;
        private Button PlusButton;
        private Button MinusButton;
        private Button DecipherButton;
        private Label CipheredTextLabel;
    }
}