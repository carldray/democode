using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankApplication
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bankApplicationDataSet.TransactionTypes' table. You can move, or remove it, as needed.
            this.transactionTypesTableAdapter.Fill(this.bankApplicationDataSet.TransactionTypes);
            // TODO: This line of code loads data into the 'bankApplicationDataSet.Accounts' table. You can move, or remove it, as needed.
            this.accountsTableAdapter.Fill(this.bankApplicationDataSet.Accounts);

            PopulateDataGridView();

        }

        private void PopulateDataGridView()
        {
            if (cboAccounts.SelectedValue != null)
            {
                var select = "SELECT Transactions.TransactionID, Accounts.AccountNumber, AccountTypes.AccountType, Customers.CustomerID, Customers.LastName, Customers.FirstName, TransactionTypes.TransactionType, Transactions.TransactionAmount, " +
                            "TransferTypes.TransferType, Accounts_1.AccountNumber AS[Transfer Account], Transactions.CurrentAccountBalance " +
                            "FROM            Transactions INNER JOIN " +
                                                    "Accounts ON Transactions.AccountID = Accounts.AccountID AND Transactions.AccountID = Accounts.AccountID INNER JOIN " +
                                                     "AccountTypes ON Transactions.AccountTypeID = AccountTypes.AccountTypeID INNER JOIN " +
                                                     "Customers ON Accounts.CustomerID = Customers.CustomerID INNER JOIN " +
                                                     "TransactionTypes ON Transactions.TransactionTypeID = TransactionTypes.TransactionTypeID LEFT OUTER JOIN " +
                                                     "TransferTypes ON Transactions.TransferTypeID = TransferTypes.TransferTypeID LEFT OUTER JOIN " +
                                                     "Accounts AS Accounts_1 ON Transactions.TransferAccountID = Accounts_1.AccountID " +
                            "WHERE(Transactions.AccountID = " + Int32.Parse(cboAccounts.SelectedValue.ToString()) + ")";
                string ConnectionString = ConfigurationManager.ConnectionStrings["BankApplication.Properties.Settings.BankApplicationConnectionString"].ConnectionString; //@"Data Source=DESKTOP-9CK957I\SQLEXPRESS;Initial Catalog=BankApplication;Integrated Security=True";
                var dataAdapter = new SqlDataAdapter(select, ConnectionString);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dgvAccountInfo.ReadOnly = true;
                dgvAccountInfo.DataSource = ds.Tables[0];
            }
        }

        private void txtTransactionAmount_Leave(object sender, EventArgs e)
        {
            Decimal val;
            if (Decimal.TryParse(txtTransactionAmount.Text, out val))
            {
                txtTransactionAmount.Text = val.ToString("C");
            }
            else
            {
                MessageBox.Show("Oops!  Bad input!");

                txtTransactionAmount.Focus();
                txtTransactionAmount.Text = "$0.00";
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                TransactionManager tm = new TransactionManager();

                switch (Int32.Parse(cboTransactionType.SelectedValue.ToString()))
                {
                    case 1:
                        tm.Deposit(Int32.Parse(cboAccounts.SelectedValue.ToString()), Decimal.Parse(txtTransactionAmount.Text.Replace("$", "")));
                        break;
                    case 2:
                        tm.Withdrawal(Int32.Parse(cboAccounts.SelectedValue.ToString()), Decimal.Parse(txtTransactionAmount.Text.Replace("$", "")));
                        break;
                    case 3:
                        tm.Transfer(Int32.Parse(cboAccounts.SelectedValue.ToString()), Decimal.Parse(txtTransactionAmount.Text.Replace("$", "")), Int32.Parse(cboTransferAccount.SelectedValue.ToString()));
                        break;
                    default:
                        break;
                }

                MessageBox.Show("Done");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            PopulateDataGridView();

        }

        private void cboAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }
    }
}
