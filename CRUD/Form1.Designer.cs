namespace CRUD
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
            groupBox1 = new GroupBox();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnRead = new Button();
            btnInsert = new Button();
            btnClear = new Button();
            txtEmail = new TextBox();
            label3 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            txtID = new TextBox();
            label1 = new Label();
            dgvCustomerDetails = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomerDetails).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnRead);
            groupBox1.Controls.Add(btnInsert);
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtID);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(28, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(437, 368);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(342, 139);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(192, 64, 0);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(261, 139);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnRead
            // 
            btnRead.BackColor = Color.FromArgb(192, 0, 192);
            btnRead.ForeColor = Color.White;
            btnRead.Location = new Point(180, 139);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(75, 23);
            btnRead.TabIndex = 9;
            btnRead.Text = "Read";
            btnRead.UseVisualStyleBackColor = false;
            btnRead.Click += btnRead_Click;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(0, 64, 0);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(99, 139);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(75, 23);
            btnInsert.TabIndex = 8;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Navy;
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(18, 139);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 7;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(115, 98);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(181, 23);
            txtEmail.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 101);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 5;
            label3.Text = "Email";
            label3.Click += label3_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(115, 62);
            txtName.Name = "txtName";
            txtName.Size = new Size(181, 23);
            txtName.TabIndex = 4;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 65);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 3;
            label2.Text = "Name";
            // 
            // txtID
            // 
            txtID.Location = new Point(115, 30);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(100, 23);
            txtID.TabIndex = 2;
            txtID.TextChanged += txtID_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 33);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 1;
            label1.Text = "Customer ID";
            // 
            // dgvCustomerDetails
            // 
            dgvCustomerDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomerDetails.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colEmail });
            dgvCustomerDetails.Location = new Point(471, 12);
            dgvCustomerDetails.Name = "dgvCustomerDetails";
            dgvCustomerDetails.Size = new Size(326, 368);
            dgvCustomerDetails.TabIndex = 1;
            dgvCustomerDetails.CellClick += dgvCustomerDetails_CellClick;
            dgvCustomerDetails.CellContentClick += dgvCustomerDetails_CellContentClick;
            // 
            // colId
            // 
            colId.HeaderText = "Id";
            colId.Name = "colId";
            // 
            // colName
            // 
            colName.HeaderText = "Name";
            colName.Name = "colName";
            // 
            // colEmail
            // 
            colEmail.HeaderText = "Email";
            colEmail.Name = "colEmail";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvCustomerDetails);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomerDetails).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtEmail;
        private Label label3;
        private TextBox txtName;
        private Label label2;
        private TextBox txtID;
        private Label label1;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnRead;
        private Button btnInsert;
        private Button btnClear;
        private DataGridView dgvCustomerDetails;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colEmail;
    }
}
