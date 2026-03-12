namespace WinGridView
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
            btnAdd = new Button();
            dgvUsers = new DataGridView();
            dgvUsersId = new DataGridViewTextBoxColumn();
            dgvUsersPIB = new DataGridViewTextBoxColumn();
            dgvUsersPhone = new DataGridViewTextBoxColumn();
            dgvUsersAge = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnAdd.ForeColor = Color.Blue;
            btnAdd.Location = new Point(1037, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(191, 63);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Додати";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { dgvUsersId, dgvUsersPIB, dgvUsersPhone, dgvUsersAge });
            dgvUsers.Location = new Point(12, 104);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersWidth = 62;
            dgvUsers.Size = new Size(1216, 358);
            dgvUsers.TabIndex = 1;
            // 
            // dgvUsersId
            // 
            dgvUsersId.FillWeight = 50F;
            dgvUsersId.HeaderText = "Id";
            dgvUsersId.MinimumWidth = 8;
            dgvUsersId.Name = "dgvUsersId";
            dgvUsersId.ReadOnly = true;
            dgvUsersId.Width = 150;
            // 
            // dgvUsersPIB
            // 
            dgvUsersPIB.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvUsersPIB.HeaderText = "ПІБ";
            dgvUsersPIB.MinimumWidth = 8;
            dgvUsersPIB.Name = "dgvUsersPIB";
            dgvUsersPIB.ReadOnly = true;
            // 
            // dgvUsersPhone
            // 
            dgvUsersPhone.FillWeight = 75F;
            dgvUsersPhone.HeaderText = "Телефон";
            dgvUsersPhone.MinimumWidth = 8;
            dgvUsersPhone.Name = "dgvUsersPhone";
            dgvUsersPhone.ReadOnly = true;
            dgvUsersPhone.Width = 150;
            // 
            // dgvUsersAge
            // 
            dgvUsersAge.FillWeight = 50F;
            dgvUsersAge.HeaderText = "Вік";
            dgvUsersAge.MinimumWidth = 8;
            dgvUsersAge.Name = "dgvUsersAge";
            dgvUsersAge.ReadOnly = true;
            dgvUsersAge.Width = 150;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1240, 493);
            Controls.Add(dgvUsers);
            Controls.Add(btnAdd);
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAdd;
        private DataGridView dgvUsers;
        private DataGridViewTextBoxColumn dgvUsersId;
        private DataGridViewTextBoxColumn dgvUsersPIB;
        private DataGridViewTextBoxColumn dgvUsersPhone;
        private DataGridViewTextBoxColumn dgvUsersAge;
    }
}
