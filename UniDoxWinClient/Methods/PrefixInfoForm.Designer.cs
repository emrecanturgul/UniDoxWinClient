namespace UniDoxWinClient.Methods
{
    partial class PrefixInfoForm
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
            this.btnLoadPrefixes = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Prefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadPrefixes
            // 
            this.btnLoadPrefixes.Location = new System.Drawing.Point(12, 12);
            this.btnLoadPrefixes.Name = "btnLoadPrefixes";
            this.btnLoadPrefixes.Size = new System.Drawing.Size(150, 35);
            this.btnLoadPrefixes.TabIndex = 0;
            this.btnLoadPrefixes.Text = "Prefix Listesini Yükle";
            this.btnLoadPrefixes.UseVisualStyleBackColor = true;
            this.btnLoadPrefixes.Click += new System.EventHandler(this.btnLoadPrefixes_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Prefix,
            this.Status,
            this.EmailStatus});
            this.dataGridView1.Location = new System.Drawing.Point(12, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(560, 350);
            this.dataGridView1.TabIndex = 1;
            // 
            // Prefix
            // 
            this.Prefix.HeaderText = "Prefix";
            this.Prefix.Name = "Prefix";
            this.Prefix.ReadOnly = true;
            this.Prefix.Width = 200;
            // 
            // Status
            // 
            this.Status.HeaderText = "Durum";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 150;
            // 
            // EmailStatus
            // 
            this.EmailStatus.HeaderText = "Email Durumu";
            this.EmailStatus.Name = "EmailStatus";
            this.EmailStatus.ReadOnly = true;
            this.EmailStatus.Width = 150;
            // 
            // PrefixInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 422);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnLoadPrefixes);
            this.Name = "PrefixInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Prefix Bilgi Formu";
            this.Load += new System.EventHandler(this.PrefixInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadPrefixes;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailStatus;
    }
}