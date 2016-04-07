using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Manager_ActiveDirectory
{
    public partial class ActiveDirectoryPreview : Form
    {
        #region Attribute
        private List<LDAP.User> _users;
        private Enterprise _enterprise;

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel _panelResearch;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.TextBox _textBoxUser;
        private System.Windows.Forms.Label _labelUser;
        private System.Windows.Forms.TextBox _textBoxMail;
        private System.Windows.Forms.Label _labelMail;
        private System.Windows.Forms.Button _buttonSearch;
        private System.Windows.Forms.TextBox _textBoxDisplay;
        private System.Windows.Forms.Label label1;
        #endregion

        #region Properties
        public Enterprise Enterprise
        {
            get { return _enterprise; }
            set
            {
                _enterprise = value;
                LoadAD();
            }
        }
        #endregion

        #region Constructor
        public ActiveDirectoryPreview()
        {
            _users = new List<LDAP.User>();
            InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActiveDirectoryPreview));
            this._panelResearch = new System.Windows.Forms.Panel();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this._labelUser = new System.Windows.Forms.Label();
            this._textBoxUser = new System.Windows.Forms.TextBox();
            this._labelMail = new System.Windows.Forms.Label();
            this._textBoxMail = new System.Windows.Forms.TextBox();
            this._buttonSearch = new System.Windows.Forms.Button();
            this._textBoxDisplay = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._panelResearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _panelResearch
            // 
            this._panelResearch.Controls.Add(this._textBoxDisplay);
            this._panelResearch.Controls.Add(this.label1);
            this._panelResearch.Controls.Add(this._buttonSearch);
            this._panelResearch.Controls.Add(this._textBoxMail);
            this._panelResearch.Controls.Add(this._labelMail);
            this._panelResearch.Controls.Add(this._textBoxUser);
            this._panelResearch.Controls.Add(this._labelUser);
            this._panelResearch.Dock = System.Windows.Forms.DockStyle.Top;
            this._panelResearch.Location = new System.Drawing.Point(0, 0);
            this._panelResearch.Name = "_panelResearch";
            this._panelResearch.Size = new System.Drawing.Size(784, 44);
            this._panelResearch.TabIndex = 1;
            // 
            // _dataGridView
            // 
            this._dataGridView.AllowUserToAddRows = false;
            this._dataGridView.AllowUserToOrderColumns = true;
            this._dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridView.Location = new System.Drawing.Point(0, 44);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.RowHeadersVisible = false;
            this._dataGridView.Size = new System.Drawing.Size(784, 522);
            this._dataGridView.TabIndex = 2;
            // 
            // _labelUser
            // 
            this._labelUser.Location = new System.Drawing.Point(227, 15);
            this._labelUser.Name = "_labelUser";
            this._labelUser.Size = new System.Drawing.Size(60, 17);
            this._labelUser.TabIndex = 0;
            this._labelUser.Text = "User name";
            // 
            // _textBoxUser
            // 
            this._textBoxUser.Location = new System.Drawing.Point(293, 12);
            this._textBoxUser.Name = "_textBoxUser";
            this._textBoxUser.Size = new System.Drawing.Size(168, 20);
            this._textBoxUser.TabIndex = 2;
            this._textBoxUser.TextChanged += new System.EventHandler(this._textBox_TextChanged);
            // 
            // _labelMail
            // 
            this._labelMail.Location = new System.Drawing.Point(11, 15);
            this._labelMail.Name = "_labelMail";
            this._labelMail.Size = new System.Drawing.Size(49, 17);
            this._labelMail.TabIndex = 2;
            this._labelMail.Text = "Mail";
            // 
            // _textBoxMail
            // 
            this._textBoxMail.Location = new System.Drawing.Point(66, 12);
            this._textBoxMail.Name = "_textBoxMail";
            this._textBoxMail.Size = new System.Drawing.Size(155, 20);
            this._textBoxMail.TabIndex = 1;
            this._textBoxMail.TextChanged += new System.EventHandler(this._textBox_TextChanged);
            // 
            // _buttonSearch
            // 
            this._buttonSearch.Location = new System.Drawing.Point(697, 10);
            this._buttonSearch.Name = "_buttonSearch";
            this._buttonSearch.Size = new System.Drawing.Size(75, 23);
            this._buttonSearch.TabIndex = 4;
            this._buttonSearch.Text = "Search";
            this._buttonSearch.UseVisualStyleBackColor = true;
            this._buttonSearch.Click += new System.EventHandler(this._buttonSearch_Click);
            // 
            // _textBoxDisplay
            // 
            this._textBoxDisplay.Location = new System.Drawing.Point(557, 12);
            this._textBoxDisplay.Name = "_textBoxDisplay";
            this._textBoxDisplay.Size = new System.Drawing.Size(134, 20);
            this._textBoxDisplay.TabIndex = 3;
            this._textBoxDisplay.TextChanged += new System.EventHandler(this._textBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(467, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Displayed name";
            // 
            // ActiveDirectoryPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 566);
            this.Controls.Add(this._dataGridView);
            this.Controls.Add(this._panelResearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ActiveDirectoryPreview";
            this.Text = "Active directory";
            this._panelResearch.ResumeLayout(false);
            this._panelResearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this.ResumeLayout(false);

        }
        private void RefreshTable()
        {
            if (!string.IsNullOrEmpty(_textBoxDisplay.Text) && !string.IsNullOrEmpty(_textBoxMail.Text) && !string.IsNullOrEmpty(_textBoxUser.Text))
            {
                _dataGridView.DataSource = _users.Where(u =>
                ((!string.IsNullOrEmpty(u.DisplayName)) && u.DisplayName.ToLower().Contains(_textBoxDisplay.Text.ToLower()))
                && ((!string.IsNullOrEmpty(u.Email)) && u.Email.ToLower().Contains(_textBoxMail.Text.ToLower()))
                && ((!string.IsNullOrEmpty(u.UserName)) && u.UserName.ToLower().Contains(_textBoxUser.Text.ToLower()))
                ).ToList();
            }
            else if (!string.IsNullOrEmpty(_textBoxDisplay.Text) && !string.IsNullOrEmpty(_textBoxUser.Text))
            {
                _dataGridView.DataSource = _users.Where(u =>
                ((!string.IsNullOrEmpty(u.DisplayName)) && u.DisplayName.ToLower().Contains(_textBoxDisplay.Text.ToLower()))
                && ((!string.IsNullOrEmpty(u.UserName)) && u.UserName.ToLower().Contains(_textBoxUser.Text.ToLower()))
                ).ToList();
            }
            else if (!string.IsNullOrEmpty(_textBoxDisplay.Text) && !string.IsNullOrEmpty(_textBoxMail.Text))
            {
                _dataGridView.DataSource = _users.Where(u =>
                ((!string.IsNullOrEmpty(u.DisplayName)) && u.DisplayName.ToLower().Contains(_textBoxDisplay.Text.ToLower()))
                && ((!string.IsNullOrEmpty(u.Email)) && u.Email.ToLower().Contains(_textBoxMail.Text.ToLower()))
                ).ToList();
            }
            else if (!string.IsNullOrEmpty(_textBoxMail.Text) && !string.IsNullOrEmpty(_textBoxUser.Text))
            {
                _dataGridView.DataSource = _users.Where(u =>
                ((!string.IsNullOrEmpty(u.Email)) && u.Email.ToLower().Contains(_textBoxMail.Text.ToLower()))
                && ((!string.IsNullOrEmpty(u.UserName)) && u.UserName.ToLower().Contains(_textBoxUser.Text.ToLower()))
                ).ToList();
            }
            else if (!string.IsNullOrEmpty(_textBoxDisplay.Text))
            {
                _dataGridView.DataSource = _users.Where(u => ((!string.IsNullOrEmpty(u.DisplayName)) && u.DisplayName.ToLower().Contains(_textBoxDisplay.Text.ToLower()))).ToList();
            }
            else if (!string.IsNullOrEmpty(_textBoxMail.Text))
            {
                _dataGridView.DataSource = _users.Where(u => ((!string.IsNullOrEmpty(u.Email)) && u.Email.ToLower().Contains(_textBoxMail.Text.ToLower()))).ToList();
            }
            else if (!string.IsNullOrEmpty(_textBoxUser.Text))
            {
                _dataGridView.DataSource = _users.Where(u => ((!string.IsNullOrEmpty(u.UserName)) && u.UserName.ToLower().Contains(_textBoxUser.Text.ToLower()))).ToList();
            }
            //else
            //{
            //    _dataGridView.DataSource = _users;
            //}
            //if (_dataGridView.Columns["Email"] != null) _dataGridView.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void LoadAD()
        {
            try
            {
                _users = _enterprise.Users;
                _dataGridView.DataSource = _users;
            }
            catch (System.Exception exp)
            {
                System.Console.WriteLine("Cannot load AD : " + exp.Message);
            }
        }
        #endregion

        #region event
        private void _buttonSearch_Click(object sender, System.EventArgs e)
        {
            if (_textBoxDisplay.Text.Length > 2 || _textBoxMail.Text.Length > 2 || _textBoxUser.Text.Length > 2)
            {
                Cursor = Cursors.WaitCursor;
                RefreshTable();
                Cursor = Cursors.Arrow;
            }
        }
        private void _textBox_TextChanged(object sender, System.EventArgs e)
        {
            if (_textBoxDisplay.Text.Length > 2 || _textBoxMail.Text.Length > 2 || _textBoxUser.Text.Length > 2)
            {
                Cursor = Cursors.WaitCursor;
                RefreshTable();
                Cursor = Cursors.Arrow;
            }
        }
        #endregion
    }
}
