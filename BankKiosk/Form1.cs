using BankingDomain;
using System;
using System.Windows.Forms;

namespace BankKiosk
{
    public partial class Form1 : Form
    {
        BankAccount Account;
        public Form1(BankAccount account)
        {
            InitializeComponent();
            Account = account;
            //Account = new BankAccount(
            //    new StandardBonusCalculator(new SystemTime()), new NotifyFederalRegulators());
            UpdateUi();
        }

        private void UpdateUi()
        {
            Text = $"You have {Account.GetBalance():c} in your Account";
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            var amount = decimal.Parse(txtAmount.Text);
            Account.Deposit(amount);
            UpdateUi();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            var amount = decimal.Parse(txtAmount.Text);
            Account.Withdraw(amount);
            UpdateUi();
        }
    }
}
