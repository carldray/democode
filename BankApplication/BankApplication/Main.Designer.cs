namespace BankApplication
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.cboAccounts = new System.Windows.Forms.ComboBox();
            this.bankApplicationDataSet = new BankApplication.BankApplicationDataSet();
            this.accountsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountsTableAdapter = new BankApplication.BankApplicationDataSetTableAdapters.AccountsTableAdapter();
            this.lblAccounts = new System.Windows.Forms.Label();
            this.transactionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transactionsTableAdapter = new BankApplication.BankApplicationDataSetTableAdapters.TransactionsTableAdapter();
            this.accountsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboTransactionType = new System.Windows.Forms.ComboBox();
            this.transactionTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transactionTypesTableAdapter = new BankApplication.BankApplicationDataSetTableAdapters.TransactionTypesTableAdapter();
            this.lblTransactionType = new System.Windows.Forms.Label();
            this.txtTransactionAmount = new System.Windows.Forms.TextBox();
            this.lblTransactionAmount = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.cboTransferAccount = new System.Windows.Forms.ComboBox();
            this.lblTransferAccount = new System.Windows.Forms.Label();
            this.dgvAccountInfo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.bankApplicationDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsBindingSource1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // cboAccounts
            // 
            this.cboAccounts.DataSource = this.accountsBindingSource;
            this.cboAccounts.DisplayMember = "AccountNumber";
            this.cboAccounts.FormattingEnabled = true;
            this.cboAccounts.Location = new System.Drawing.Point(9, 32);
            this.cboAccounts.Name = "cboAccounts";
            this.cboAccounts.Size = new System.Drawing.Size(316, 21);
            this.cboAccounts.TabIndex = 0;
            this.cboAccounts.ValueMember = "AccountID";
            this.cboAccounts.SelectedIndexChanged += new System.EventHandler(this.cboAccounts_SelectedIndexChanged);
            // 
            // bankApplicationDataSet
            // 
            this.bankApplicationDataSet.DataSetName = "BankApplicationDataSet";
            this.bankApplicationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // accountsBindingSource
            // 
            this.accountsBindingSource.DataMember = "Accounts";
            this.accountsBindingSource.DataSource = this.bankApplicationDataSet;
            // 
            // accountsTableAdapter
            // 
            this.accountsTableAdapter.ClearBeforeFill = true;
            // 
            // lblAccounts
            // 
            this.lblAccounts.AutoSize = true;
            this.lblAccounts.Location = new System.Drawing.Point(6, 16);
            this.lblAccounts.Name = "lblAccounts";
            this.lblAccounts.Size = new System.Drawing.Size(47, 13);
            this.lblAccounts.TabIndex = 1;
            this.lblAccounts.Text = "Account";
            // 
            // transactionsBindingSource
            // 
            this.transactionsBindingSource.DataMember = "Transactions";
            this.transactionsBindingSource.DataSource = this.bankApplicationDataSet;
            // 
            // transactionsTableAdapter
            // 
            this.transactionsTableAdapter.ClearBeforeFill = true;
            // 
            // accountsBindingSource1
            // 
            this.accountsBindingSource1.DataMember = "Accounts";
            this.accountsBindingSource1.DataSource = this.bankApplicationDataSet;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTransferAccount);
            this.groupBox1.Controls.Add(this.cboTransferAccount);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.lblTransactionAmount);
            this.groupBox1.Controls.Add(this.txtTransactionAmount);
            this.groupBox1.Controls.Add(this.lblTransactionType);
            this.groupBox1.Controls.Add(this.cboTransactionType);
            this.groupBox1.Controls.Add(this.lblAccounts);
            this.groupBox1.Controls.Add(this.cboAccounts);
            this.groupBox1.Location = new System.Drawing.Point(21, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(652, 227);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // cboTransactionType
            // 
            this.cboTransactionType.DataSource = this.transactionTypesBindingSource;
            this.cboTransactionType.DisplayMember = "TransactionType";
            this.cboTransactionType.FormattingEnabled = true;
            this.cboTransactionType.Location = new System.Drawing.Point(9, 81);
            this.cboTransactionType.Name = "cboTransactionType";
            this.cboTransactionType.Size = new System.Drawing.Size(316, 21);
            this.cboTransactionType.TabIndex = 2;
            this.cboTransactionType.ValueMember = "TransactionTypeID";
            // 
            // transactionTypesBindingSource
            // 
            this.transactionTypesBindingSource.DataMember = "TransactionTypes";
            this.transactionTypesBindingSource.DataSource = this.bankApplicationDataSet;
            // 
            // transactionTypesTableAdapter
            // 
            this.transactionTypesTableAdapter.ClearBeforeFill = true;
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.AutoSize = true;
            this.lblTransactionType.Location = new System.Drawing.Point(6, 65);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(90, 13);
            this.lblTransactionType.TabIndex = 3;
            this.lblTransactionType.Text = "Transaction Type";
            // 
            // txtTransactionAmount
            // 
            this.txtTransactionAmount.Location = new System.Drawing.Point(9, 133);
            this.txtTransactionAmount.Name = "txtTransactionAmount";
            this.txtTransactionAmount.Size = new System.Drawing.Size(316, 20);
            this.txtTransactionAmount.TabIndex = 4;
            this.txtTransactionAmount.Text = "$0.00";
            this.txtTransactionAmount.Leave += new System.EventHandler(this.txtTransactionAmount_Leave);
            // 
            // lblTransactionAmount
            // 
            this.lblTransactionAmount.AutoSize = true;
            this.lblTransactionAmount.Location = new System.Drawing.Point(6, 117);
            this.lblTransactionAmount.Name = "lblTransactionAmount";
            this.lblTransactionAmount.Size = new System.Drawing.Size(102, 13);
            this.lblTransactionAmount.TabIndex = 5;
            this.lblTransactionAmount.Text = "Transaction Amount";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(9, 171);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(130, 38);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // cboTransferAccount
            // 
            this.cboTransferAccount.DataSource = this.accountsBindingSource1;
            this.cboTransferAccount.DisplayMember = "AccountNumber";
            this.cboTransferAccount.FormattingEnabled = true;
            this.cboTransferAccount.Location = new System.Drawing.Point(344, 81);
            this.cboTransferAccount.Name = "cboTransferAccount";
            this.cboTransferAccount.Size = new System.Drawing.Size(288, 21);
            this.cboTransferAccount.TabIndex = 7;
            this.cboTransferAccount.ValueMember = "AccountID";
            // 
            // lblTransferAccount
            // 
            this.lblTransferAccount.AutoSize = true;
            this.lblTransferAccount.Location = new System.Drawing.Point(341, 65);
            this.lblTransferAccount.Name = "lblTransferAccount";
            this.lblTransferAccount.Size = new System.Drawing.Size(103, 13);
            this.lblTransferAccount.TabIndex = 8;
            this.lblTransferAccount.Text = "Destination Account";
            // 
            // dgvAccountInfo
            // 
            this.dgvAccountInfo.AllowUserToAddRows = false;
            this.dgvAccountInfo.AllowUserToDeleteRows = false;
            this.dgvAccountInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccountInfo.Location = new System.Drawing.Point(21, 300);
            this.dgvAccountInfo.Name = "dgvAccountInfo";
            this.dgvAccountInfo.ReadOnly = true;
            this.dgvAccountInfo.Size = new System.Drawing.Size(655, 203);
            this.dgvAccountInfo.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 543);
            this.Controls.Add(this.dgvAccountInfo);
            this.Controls.Add(this.groupBox1);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bankApplicationDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsBindingSource1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboAccounts;
        private BankApplicationDataSet bankApplicationDataSet;
        private System.Windows.Forms.BindingSource accountsBindingSource;
        private BankApplicationDataSetTableAdapters.AccountsTableAdapter accountsTableAdapter;
        private System.Windows.Forms.Label lblAccounts;
        private System.Windows.Forms.BindingSource transactionsBindingSource;
        private BankApplicationDataSetTableAdapters.TransactionsTableAdapter transactionsTableAdapter;
        private System.Windows.Forms.BindingSource accountsBindingSource1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboTransactionType;
        private System.Windows.Forms.BindingSource transactionTypesBindingSource;
        private BankApplicationDataSetTableAdapters.TransactionTypesTableAdapter transactionTypesTableAdapter;
        private System.Windows.Forms.Label lblTransactionType;
        private System.Windows.Forms.Label lblTransactionAmount;
        private System.Windows.Forms.TextBox txtTransactionAmount;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblTransferAccount;
        private System.Windows.Forms.ComboBox cboTransferAccount;
        private System.Windows.Forms.DataGridView dgvAccountInfo;
    }
}