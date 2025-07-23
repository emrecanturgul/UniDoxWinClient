namespace UniDoxWinClient.Methods
{
    partial class DocumentResultsForm
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
            this.lblQueryInfo = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Sira = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblQueryInfo
            // 
            this.lblQueryInfo.AutoSize = true;
            this.lblQueryInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblQueryInfo.Location = new System.Drawing.Point(12, 15);
            this.lblQueryInfo.Name = "lblQueryInfo";
            this.lblQueryInfo.Size = new System.Drawing.Size(94, 17);
            this.lblQueryInfo.TabIndex = 0;
            this.lblQueryInfo.Text = "Sorgu Bilgisi";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sira,
            this.DocumentId,
            this.UUID,
            this.Date,
            this.Source,
            this.Destination,
            this.Amount,
            this.State});
            this.dataGridView1.Location = new System.Drawing.Point(12, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(960, 400);
            this.dataGridView1.TabIndex = 1;
            // 
            // Sira
            // 
            this.Sira.HeaderText = "Sıra";
            this.Sira.Name = "Sira";
            this.Sira.ReadOnly = true;
            this.Sira.Width = 50;
            // 
            // DocumentId
            // 
            this.DocumentId.HeaderText = "Belge ID";
            this.DocumentId.Name = "DocumentId";
            this.DocumentId.ReadOnly = true;
            this.DocumentId.Width = 120;
            // 
            // UUID
            // 
            this.UUID.HeaderText = "UUID";
            this.UUID.Name = "UUID";
            this.UUID.ReadOnly = true;
            this.UUID.Width = 250;
            // 
            // Date
            // 
            this.Date.HeaderText = "Tarih";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 100;
            // 
            // Source
            // 
            this.Source.HeaderText = "Gönderen";
            this.Source.Name = "Source";
            this.Source.ReadOnly = true;
            this.Source.Width = 150;
            // 
            // Destination
            // 
            this.Destination.HeaderText = "Alıcı";
            this.Destination.Name = "Destination";
            this.Destination.ReadOnly = true;
            this.Destination.Width = 150;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Tutar";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // State
            // 
            this.State.HeaderText = "Durum";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Width = 120;
            // 
            // DocumentResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblQueryInfo);
            this.Name = "DocumentResultsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Belge Sorgu Sonuçları";
            this.Load += new System.EventHandler(this.DocumentResultsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQueryInfo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sira;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destination;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
    }
}