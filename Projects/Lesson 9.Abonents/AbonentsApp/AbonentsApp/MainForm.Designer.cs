namespace AbonentsApp
{
    partial class MainForm
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
            btnCreateAbontent = new Button();
            dgvAbontnts = new DataGridView();
            ColFullName = new DataGridViewTextBoxColumn();
            ColPhone = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvAbontnts).BeginInit();
            SuspendLayout();
            // 
            // btnCreateAbontent
            // 
            btnCreateAbontent.Location = new Point(55, 51);
            btnCreateAbontent.Name = "btnCreateAbontent";
            btnCreateAbontent.Size = new Size(162, 67);
            btnCreateAbontent.TabIndex = 0;
            btnCreateAbontent.Text = "Додати контакт";
            btnCreateAbontent.UseVisualStyleBackColor = true;
            btnCreateAbontent.Click += btnCreateAbontent_Click;
            // 
            // dgvAbontnts
            // 
            dgvAbontnts.AllowUserToAddRows = false;
            dgvAbontnts.AllowUserToDeleteRows = false;
            dgvAbontnts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAbontnts.Columns.AddRange(new DataGridViewColumn[] { ColFullName, ColPhone });
            dgvAbontnts.Location = new Point(12, 191);
            dgvAbontnts.Name = "dgvAbontnts";
            dgvAbontnts.ReadOnly = true;
            dgvAbontnts.RowHeadersWidth = 62;
            dgvAbontnts.Size = new Size(1181, 412);
            dgvAbontnts.TabIndex = 1;
            // 
            // ColFullName
            // 
            ColFullName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColFullName.HeaderText = "ПІБ";
            ColFullName.MinimumWidth = 8;
            ColFullName.Name = "ColFullName";
            ColFullName.ReadOnly = true;
            // 
            // ColPhone
            // 
            ColPhone.HeaderText = "Телефон";
            ColPhone.MinimumWidth = 8;
            ColPhone.Name = "ColPhone";
            ColPhone.ReadOnly = true;
            ColPhone.Width = 200;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1205, 615);
            Controls.Add(dgvAbontnts);
            Controls.Add(btnCreateAbontent);
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvAbontnts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnCreateAbontent;
        private DataGridView dgvAbontnts;
        private DataGridViewTextBoxColumn ColFullName;
        private DataGridViewTextBoxColumn ColPhone;
    }
}
