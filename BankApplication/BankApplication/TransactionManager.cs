using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace BankApplication
{
    class TransactionManager
    {
        public void Deposit(int accountid, decimal transactionamount)
        {
            DataTable dtbase = FindBaseInfo(accountid);

            if (transactionamount < 0)
            {
                return;
            }

            string ConnectionString = ConfigurationManager.ConnectionStrings["BankApplication.Properties.Settings.BankApplicationConnectionString"].ConnectionString; //@"Data Source=DESKTOP-9CK957I\SQLEXPRESS;Initial Catalog=BankApplication;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                String sql = "[dbo].[sp_Transaction]";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    //AccountID, AccountTypeID, TransactionTypeID, TransactionAmount, CurrentAccountBalance
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@acctnumber", SqlDbType.Int);
                    command.Parameters["@acctnumber"].Value = accountid;
                    command.Parameters.Add("@accttype", SqlDbType.Int);
                    command.Parameters["@accttype"].Value = dtbase.Rows[0][2];
                    command.Parameters.Add("@transtype", SqlDbType.Int);
                    command.Parameters["@transtype"].Value = 1;  // 1 = Deposit
                    command.Parameters.Add("@transamt", SqlDbType.Money);
                    command.Parameters["@transamt"].Value = transactionamount;

                    // What will the balance become after deposit is made?
                    decimal currentaccountbalance = Decimal.Parse(dtbase.Rows[0][1].ToString()) + transactionamount;
                    command.Parameters.Add("@currentbalance", SqlDbType.Money);
                    command.Parameters["@currentbalance"].Value = currentaccountbalance;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {

                    }

                }

            }
                
        }

        public void Withdrawal(int accountid, decimal transactionamount)
        {
            if(transactionamount < 0)
            {
                return;
            }

            DataTable dtbase = FindBaseInfo(accountid);

            // Determine Account Type
            if (dtbase.Rows.Count > 0 && dtbase.Rows[0][2].ToString() == "3")
            {
                if (transactionamount > 1000)
                {
                    return;
                }
            }

            string ConnectionString = ConfigurationManager.ConnectionStrings["BankApplication.Properties.Settings.BankApplicationConnectionString"].ConnectionString; //@"Data Source=DESKTOP-9CK957I\SQLEXPRESS;Initial Catalog=BankApplication;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                String sql = "[dbo].[sp_Transaction]";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    //AccountID, AccountTypeID, TransactionTypeID, TransactionAmount, CurrentAccountBalance
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@acctnumber", SqlDbType.Int);
                    command.Parameters["@acctnumber"].Value = accountid;
                    command.Parameters.Add("@accttype", SqlDbType.Int);
                    command.Parameters["@accttype"].Value = dtbase.Rows[0][2];
                    command.Parameters.Add("@transtype", SqlDbType.Int);
                    command.Parameters["@transtype"].Value = 2;  // 2 = Withdrawal
                    command.Parameters.Add("@transamt", SqlDbType.Money);
                    command.Parameters["@transamt"].Value = transactionamount;

                    // What will the balance become after deposit is made?
                    decimal currentaccountbalance = Decimal.Parse(dtbase.Rows[0][1].ToString()) - transactionamount;
                    command.Parameters.Add("@currentbalance", SqlDbType.Money);
                    command.Parameters["@currentbalance"].Value = currentaccountbalance;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {

                    }

                }

            }

        }

        public void Transfer(int accountid, decimal transactionamount, int transferaccountid)
        {
            if (transactionamount < 0)
            {
                return;
            }

            DataTable dtbase = FindBaseInfo(accountid);
            DataTable dttarget = FindBaseInfo(transferaccountid);

            string ConnectionString = ConfigurationManager.ConnectionStrings["BankApplication.Properties.Settings.BankApplicationConnectionString"].ConnectionString; //@"Data Source=DESKTOP-9CK957I\SQLEXPRESS;Initial Catalog=BankApplication;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                String sqlTo = "[dbo].[sp_Transfer]";

                using (SqlCommand command = new SqlCommand(sqlTo, connection))
                {
                    //AccountID, AccountTypeID, TransactionTypeID, TransactionAmount, CurrentAccountBalance
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@acctnumber", SqlDbType.Int);
                    command.Parameters["@acctnumber"].Value = accountid;
                    command.Parameters.Add("@accttype", SqlDbType.Int);
                    command.Parameters["@accttype"].Value = dtbase.Rows[0][2];
                    command.Parameters.Add("@transtype", SqlDbType.Int);
                    command.Parameters["@transtype"].Value = 3;  // 3 = Transfer
                    command.Parameters.Add("@transamt", SqlDbType.Money);
                    command.Parameters["@transamt"].Value = transactionamount;

                    // What will the balance become after deposit is made?
                    decimal currentaccountbalance = Decimal.Parse(dtbase.Rows[0][1].ToString()) - transactionamount;
                    command.Parameters.Add("@currentbalance", SqlDbType.Money);
                    command.Parameters["@currentbalance"].Value = currentaccountbalance;

                    command.Parameters.Add("@transfertype", SqlDbType.Int);
                    command.Parameters["@transfertype"].Value = 1;
                    command.Parameters.Add("@transferacctnumber", SqlDbType.Int);
                    command.Parameters["@transferacctnumber"].Value = transferaccountid;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {

                    }
                }

                    String sqlFrom = "[dbo].[sp_Transfer]";

                using (SqlCommand command = new SqlCommand(sqlFrom, connection))
                {
                    //AccountID, AccountTypeID, TransactionTypeID, TransactionAmount, CurrentAccountBalance
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@acctnumber", SqlDbType.Int);
                    command.Parameters["@acctnumber"].Value = transferaccountid;
                    command.Parameters.Add("@accttype", SqlDbType.Int);
                    command.Parameters["@accttype"].Value = dttarget.Rows[0][2];
                    command.Parameters.Add("@transtype", SqlDbType.Int);
                    command.Parameters["@transtype"].Value = 3;  // 3 = Transfer
                    command.Parameters.Add("@transamt", SqlDbType.Money);
                    command.Parameters["@transamt"].Value = transactionamount;

                    // What will the balance become after deposit is made?
                    decimal currentaccountbalance = Decimal.Parse(dttarget.Rows[0][1].ToString()) + transactionamount;
                    command.Parameters.Add("@currentbalance", SqlDbType.Money);
                    command.Parameters["@currentbalance"].Value = currentaccountbalance;

                    command.Parameters.Add("@transfertype", SqlDbType.Int);
                    command.Parameters["@transfertype"].Value = 2;
                    command.Parameters.Add("@transferacctnumber", SqlDbType.Int);
                    command.Parameters["@transferacctnumber"].Value = accountid;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {

                    }

                }

            }
        }

        public DataTable FindBaseInfo(int accountnumber)
        {
            DataTable dt = new DataTable();

            string ConnectionString = ConfigurationManager.ConnectionStrings["BankApplication.Properties.Settings.BankApplicationConnectionString"].ConnectionString; //@"Data Source=DESKTOP-9CK957I\SQLEXPRESS;Initial Catalog=BankApplication;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                String sql = "[dbo].[sp_BaseInfo]";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@acctnum", SqlDbType.Int);
                    command.Parameters["@acctnum"].Value = accountnumber;

                    try
                    {
                        connection.Open();
                        SqlDataReader dr = command.ExecuteReader();
                        dt.Load(dr);
                        connection.Close();

                    }
                    catch (Exception ex)
                    {

                    }

                }

                
            }

            return dt;
        }

    }
}
