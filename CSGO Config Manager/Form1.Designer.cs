namespace CSGO_Config_Manager
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cb_account = new System.Windows.Forms.ComboBox();
            this.b_refresh = new System.Windows.Forms.Button();
            this.tb_log = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.b_import = new System.Windows.Forms.Button();
            this.b_export = new System.Windows.Forms.Button();
            this.clb_copyto = new System.Windows.Forms.CheckedListBox();
            this.b_copy = new System.Windows.Forms.Button();
            this.b_open = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_account
            // 
            this.cb_account.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_account.FormattingEnabled = true;
            this.cb_account.Location = new System.Drawing.Point(13, 34);
            this.cb_account.Name = "cb_account";
            this.cb_account.Size = new System.Drawing.Size(378, 21);
            this.cb_account.TabIndex = 1;
            this.cb_account.SelectedIndexChanged += new System.EventHandler(this.cb_account_SelectedIndexChanged);
            // 
            // b_refresh
            // 
            this.b_refresh.Location = new System.Drawing.Point(397, 33);
            this.b_refresh.Name = "b_refresh";
            this.b_refresh.Size = new System.Drawing.Size(75, 23);
            this.b_refresh.TabIndex = 2;
            this.b_refresh.Text = "Refresh";
            this.b_refresh.UseVisualStyleBackColor = true;
            this.b_refresh.Click += new System.EventHandler(this.b_refresh_Click);
            // 
            // tb_log
            // 
            this.tb_log.HideSelection = false;
            this.tb_log.Location = new System.Drawing.Point(12, 269);
            this.tb_log.Name = "tb_log";
            this.tb_log.ReadOnly = true;
            this.tb_log.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.tb_log.Size = new System.Drawing.Size(460, 80);
            this.tb_log.TabIndex = 3;
            this.tb_log.TabStop = false;
            this.tb_log.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select an account:";
            // 
            // b_import
            // 
            this.b_import.Location = new System.Drawing.Point(12, 61);
            this.b_import.Name = "b_import";
            this.b_import.Size = new System.Drawing.Size(75, 23);
            this.b_import.TabIndex = 5;
            this.b_import.Text = "Import";
            this.b_import.UseVisualStyleBackColor = true;
            this.b_import.Click += new System.EventHandler(this.b_import_Click);
            // 
            // b_export
            // 
            this.b_export.Location = new System.Drawing.Point(316, 61);
            this.b_export.Name = "b_export";
            this.b_export.Size = new System.Drawing.Size(75, 23);
            this.b_export.TabIndex = 6;
            this.b_export.Text = "Export";
            this.b_export.UseVisualStyleBackColor = true;
            this.b_export.Click += new System.EventHandler(this.b_export_Click);
            // 
            // clb_copyto
            // 
            this.clb_copyto.CheckOnClick = true;
            this.clb_copyto.FormattingEnabled = true;
            this.clb_copyto.Location = new System.Drawing.Point(12, 199);
            this.clb_copyto.Name = "cbl_copyto";
            this.clb_copyto.Size = new System.Drawing.Size(379, 64);
            this.clb_copyto.TabIndex = 7;
            this.clb_copyto.SelectedIndexChanged += new System.EventHandler(this.cbl_copyto_SelectedIndexChanged);
            // 
            // b_copy
            // 
            this.b_copy.Location = new System.Drawing.Point(12, 170);
            this.b_copy.Name = "b_copy";
            this.b_copy.Size = new System.Drawing.Size(98, 23);
            this.b_copy.TabIndex = 8;
            this.b_copy.Text = "Copy Config to...";
            this.b_copy.UseVisualStyleBackColor = true;
            this.b_copy.Click += new System.EventHandler(this.b_copy_Click);
            // 
            // b_open
            // 
            this.b_open.Location = new System.Drawing.Point(167, 61);
            this.b_open.Name = "b_open";
            this.b_open.Size = new System.Drawing.Size(75, 23);
            this.b_open.TabIndex = 9;
            this.b_open.Text = "Open";
            this.b_open.UseVisualStyleBackColor = true;
            this.b_open.Click += new System.EventHandler(this.b_open_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.b_open);
            this.Controls.Add(this.b_copy);
            this.Controls.Add(this.clb_copyto);
            this.Controls.Add(this.b_export);
            this.Controls.Add(this.b_import);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_log);
            this.Controls.Add(this.b_refresh);
            this.Controls.Add(this.cb_account);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "CS:GO Config Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_account;
        private System.Windows.Forms.Button b_refresh;
        private System.Windows.Forms.RichTextBox tb_log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button b_import;
        private System.Windows.Forms.Button b_export;
        private System.Windows.Forms.CheckedListBox clb_copyto;
        private System.Windows.Forms.Button b_copy;
        private System.Windows.Forms.Button b_open;
    }
}

