using System;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Manager_ActiveDirectory
{
    public partial class LoginForm : Form
    {
        #region Attribute
        private System.ComponentModel.IContainer components = null;
        private string _domainPath = "";

        private System.Windows.Forms.Label _labelMail;
        private System.Windows.Forms.TextBox _textBoxLogin;
        private System.Windows.Forms.Button _buttonLogin;
        private System.Windows.Forms.Label _labelPwd;
        private System.Windows.Forms.TextBox _textBoxPwd;
        private System.Windows.Forms.Button _buttonCancel;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public LoginForm()
        {
            InitializeComponent();
            _textBoxLogin.Text = "";
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods protected
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
        #endregion

        #region Methods private
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this._labelMail = new System.Windows.Forms.Label();
            this._textBoxLogin = new System.Windows.Forms.TextBox();
            this._buttonLogin = new System.Windows.Forms.Button();
            this._labelPwd = new System.Windows.Forms.Label();
            this._textBoxPwd = new System.Windows.Forms.TextBox();
            this._buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _labelMail
            // 
            this._labelMail.AutoSize = true;
            this._labelMail.Location = new System.Drawing.Point(12, 9);
            this._labelMail.Name = "_labelMail";
            this._labelMail.Size = new System.Drawing.Size(60, 13);
            this._labelMail.TabIndex = 0;
            this._labelMail.Text = "Mail / Login";
            // 
            // _textBoxLogin
            // 
            this._textBoxLogin.Location = new System.Drawing.Point(89, 6);
            this._textBoxLogin.Name = "_textBoxLogin";
            this._textBoxLogin.Size = new System.Drawing.Size(218, 20);
            this._textBoxLogin.TabIndex = 1;
            this._textBoxLogin.TextChanged += new System.EventHandler(this._textBoxLogin_TextChanged);
            // 
            // _buttonLogin
            // 
            this._buttonLogin.Location = new System.Drawing.Point(232, 58);
            this._buttonLogin.Name = "_buttonLogin";
            this._buttonLogin.Size = new System.Drawing.Size(75, 23);
            this._buttonLogin.TabIndex = 3;
            this._buttonLogin.Text = "Login";
            this._buttonLogin.UseVisualStyleBackColor = true;
            this._buttonLogin.Click += new System.EventHandler(this._buttonLogin_Click);
            // 
            // _labelPwd
            // 
            this._labelPwd.AutoSize = true;
            this._labelPwd.Location = new System.Drawing.Point(12, 35);
            this._labelPwd.Name = "_labelPwd";
            this._labelPwd.Size = new System.Drawing.Size(53, 13);
            this._labelPwd.TabIndex = 3;
            this._labelPwd.Text = "Password";
            // 
            // _textBoxPwd
            // 
            this._textBoxPwd.Location = new System.Drawing.Point(89, 32);
            this._textBoxPwd.Name = "_textBoxPwd";
            this._textBoxPwd.PasswordChar = '*';
            this._textBoxPwd.Size = new System.Drawing.Size(218, 20);
            this._textBoxPwd.TabIndex = 2;
            // 
            // _buttonCancel
            // 
            this._buttonCancel.Location = new System.Drawing.Point(151, 58);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 4;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            this._buttonCancel.Click += new System.EventHandler(this._buttonCancel_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 90);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._textBoxPwd);
            this.Controls.Add(this._labelPwd);
            this.Controls.Add(this._buttonLogin);
            this.Controls.Add(this._textBoxLogin);
            this.Controls.Add(this._labelMail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoginForm";
            this.Text = "Active Directory authentication";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Event
        private void _buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _buttonLogin_Click(object sender, EventArgs e)
        {
            DirectoryEntry searchRoot = new DirectoryEntry(_domainPath);
            searchRoot.Username = _textBoxLogin.Text;
            searchRoot.Password = _textBoxPwd.Text;
            searchRoot.GetType();
            DirectorySearcher mySearcher = new DirectorySearcher(searchRoot);
            mySearcher.PropertiesToLoad.Add("cn");
            mySearcher.Filter = "(&(anr=" + searchRoot.Username + ")(objectCategory=person))";
            SearchResultCollection results;
            try
            {
                // Lancement de la recherche... 
                results = mySearcher.FindAll();
                this.Visible = false;
                this.ShowInTaskbar = false;

                Enterprise ent = new Enterprise();
                ent.Login = _textBoxLogin.Text;
                ent.Password = _textBoxPwd.Text;
                ActiveDirectoryPreview adp = new ActiveDirectoryPreview();
                adp.Enterprise = ent;
                adp.ShowDialog();
                this.Close();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                _textBoxLogin.BackColor = Color.Orange;
                _textBoxPwd.BackColor = Color.Orange;
            }
        }

        private void _textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            _textBoxPwd.BackColor = Color.White;
            if (!_textBoxLogin.Text.Contains('@') || !_textBoxLogin.Text.Contains(".com"))
            {
                _textBoxLogin.BackColor = Color.LemonChiffon;
                _buttonLogin.Enabled = false;
            }
            else
            {
                _textBoxLogin.BackColor = Color.GreenYellow;
                _buttonLogin.Enabled = true;
            }
        }
        #endregion
    }
}
