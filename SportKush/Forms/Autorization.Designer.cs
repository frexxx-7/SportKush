namespace SportKush
{
    partial class Autorization
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
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.PasswordInput = new Guna.UI2.WinForms.Guna2TextBox();
            this.LoginInput = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RegistrationLink = new System.Windows.Forms.LinkLabel();
            this.LogInButton = new Guna.UI2.WinForms.Guna2Button();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 40;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(891, 12);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 0;
            this.guna2ControlBox1.Click += new System.EventHandler(this.guna2ControlBox1_Click);
            // 
            // PasswordInput
            // 
            this.PasswordInput.BackColor = System.Drawing.Color.Transparent;
            this.PasswordInput.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(23)))), ((int)(((byte)(80)))));
            this.PasswordInput.BorderRadius = 10;
            this.PasswordInput.BorderThickness = 2;
            this.PasswordInput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PasswordInput.DefaultText = "";
            this.PasswordInput.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.PasswordInput.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.PasswordInput.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PasswordInput.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PasswordInput.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(226)))), ((int)(((byte)(223)))));
            this.PasswordInput.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PasswordInput.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.PasswordInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(76)))), ((int)(((byte)(124)))));
            this.PasswordInput.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PasswordInput.Location = new System.Drawing.Point(233, 233);
            this.PasswordInput.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.PasswordChar = '\0';
            this.PasswordInput.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.PasswordInput.PlaceholderText = "Пароль";
            this.PasswordInput.SelectedText = "";
            this.PasswordInput.Size = new System.Drawing.Size(452, 43);
            this.PasswordInput.TabIndex = 2;
            this.PasswordInput.TextChanged += new System.EventHandler(this.PasswordInput_TextChanged);
            // 
            // LoginInput
            // 
            this.LoginInput.BackColor = System.Drawing.Color.Transparent;
            this.LoginInput.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(23)))), ((int)(((byte)(80)))));
            this.LoginInput.BorderRadius = 10;
            this.LoginInput.BorderThickness = 2;
            this.LoginInput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.LoginInput.DefaultText = "";
            this.LoginInput.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.LoginInput.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.LoginInput.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.LoginInput.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.LoginInput.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(226)))), ((int)(((byte)(223)))));
            this.LoginInput.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.LoginInput.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.LoginInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(76)))), ((int)(((byte)(124)))));
            this.LoginInput.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.LoginInput.Location = new System.Drawing.Point(233, 147);
            this.LoginInput.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.LoginInput.Name = "LoginInput";
            this.LoginInput.PasswordChar = '\0';
            this.LoginInput.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.LoginInput.PlaceholderText = "Логин";
            this.LoginInput.SelectedText = "";
            this.LoginInput.Size = new System.Drawing.Size(452, 43);
            this.LoginInput.TabIndex = 3;
            this.LoginInput.TextChanged += new System.EventHandler(this.LoginInput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(226)))), ((int)(((byte)(223)))));
            this.label1.Location = new System.Drawing.Point(372, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 33);
            this.label1.TabIndex = 4;
            this.label1.Text = "Авторизация";
            // 
            // RegistrationLink
            // 
            this.RegistrationLink.AutoSize = true;
            this.RegistrationLink.BackColor = System.Drawing.Color.Transparent;
            this.RegistrationLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistrationLink.LinkColor = System.Drawing.Color.Blue;
            this.RegistrationLink.Location = new System.Drawing.Point(248, 282);
            this.RegistrationLink.Name = "RegistrationLink";
            this.RegistrationLink.Size = new System.Drawing.Size(117, 20);
            this.RegistrationLink.TabIndex = 5;
            this.RegistrationLink.TabStop = true;
            this.RegistrationLink.Text = "Регистрация";
            this.RegistrationLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RegistrationLink_LinkClicked);
            // 
            // LogInButton
            // 
            this.LogInButton.BackColor = System.Drawing.Color.Transparent;
            this.LogInButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(76)))), ((int)(((byte)(124)))));
            this.LogInButton.BorderRadius = 7;
            this.LogInButton.BorderThickness = 2;
            this.LogInButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogInButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.LogInButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.LogInButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.LogInButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.LogInButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(226)))), ((int)(((byte)(223)))));
            this.LogInButton.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.LogInButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(76)))), ((int)(((byte)(124)))));
            this.LogInButton.Location = new System.Drawing.Point(346, 437);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(235, 53);
            this.LogInButton.TabIndex = 6;
            this.LogInButton.Text = "Войти";
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.BackColor = System.Drawing.Color.Transparent;
            this.ErrorLabel.Font = new System.Drawing.Font("Microsoft Himalaya", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(248, 330);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(57, 24);
            this.ErrorLabel.TabIndex = 14;
            this.ErrorLabel.Text = "error";
            this.ErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ErrorLabel.Visible = false;
            // 
            // Autorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SportKush.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(948, 554);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.LogInButton);
            this.Controls.Add(this.RegistrationLink);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoginInput);
            this.Controls.Add(this.PasswordInput);
            this.Controls.Add(this.guna2ControlBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Autorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2TextBox PasswordInput;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox LoginInput;
        private System.Windows.Forms.LinkLabel RegistrationLink;
        private Guna.UI2.WinForms.Guna2Button LogInButton;
        private System.Windows.Forms.Label ErrorLabel;
    }
}

