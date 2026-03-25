namespace EmailSend
{
    partial class SendForm
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
            label1 = new Label();
            label2 = new Label();
            txtSubject = new TextBox();
            label3 = new Label();
            txtBody = new TextBox();
            label4 = new Label();
            txtPath = new TextBox();
            btnSelect = new Button();
            btnCancel = new Button();
            btnSend = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(333, 18);
            label1.Name = "label1";
            label1.Size = new Size(224, 38);
            label1.TabIndex = 0;
            label1.Text = "Відпрака листа";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.Blue;
            label2.Location = new Point(21, 87);
            label2.Name = "label2";
            label2.Size = new Size(136, 32);
            label2.TabIndex = 0;
            label2.Text = "Тема листа";
            // 
            // txtSubject
            // 
            txtSubject.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtSubject.Location = new Point(219, 87);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(608, 39);
            txtSubject.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.Blue;
            label3.Location = new Point(21, 148);
            label3.Name = "label3";
            label3.Size = new Size(60, 32);
            label3.TabIndex = 0;
            label3.Text = "Тіло";
            // 
            // txtBody
            // 
            txtBody.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtBody.Location = new Point(219, 148);
            txtBody.Multiline = true;
            txtBody.Name = "txtBody";
            txtBody.Size = new Size(608, 196);
            txtBody.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.Blue;
            label4.Location = new Point(21, 371);
            label4.Name = "label4";
            label4.Size = new Size(171, 32);
            label4.TabIndex = 0;
            label4.Text = "Файл до листа";
            // 
            // txtPath
            // 
            txtPath.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtPath.Location = new Point(219, 364);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(608, 39);
            txtPath.TabIndex = 4;
            // 
            // btnSelect
            // 
            btnSelect.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnSelect.ForeColor = Color.Red;
            btnSelect.Location = new Point(21, 289);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(81, 55);
            btnSelect.TabIndex = 3;
            btnSelect.Text = "🗃️";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnCancel.Location = new Point(495, 431);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(160, 52);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Скасувати";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            btnSend.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSend.ForeColor = Color.Blue;
            btnSend.Location = new Point(225, 431);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(160, 52);
            btnSend.TabIndex = 5;
            btnSend.Text = "Надіслати";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // SendForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(848, 507);
            Controls.Add(btnSend);
            Controls.Add(btnCancel);
            Controls.Add(btnSelect);
            Controls.Add(txtBody);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtPath);
            Controls.Add(txtSubject);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SendForm";
            Text = "Надсилання листа";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtSubject;
        private Label label3;
        private TextBox txtBody;
        private Label label4;
        private TextBox txtPath;
        private Button btnSelect;
        private Button btnCancel;
        private Button btnSend;
    }
}
