using BankingDomain;
using Xunit;

namespace BankingTest
{
   public class BankAccountTests
    {
        BankAccount Account;
        decimal OpeningBalance;
        public BankAccountTests()
        {
            Account = new BankAccount(new DummyBonusCalculator());
            OpeningBalance = Account.GetBalance();
        }
        [Fact]
        public void NewAccountsHaveAppropriateBalance()
        {
            //write the code you wish you had (WTCYWYH) (Corey Haines)
           
            Assert.Equal(1200M, OpeningBalance);
        }

        [Fact]
        public void DepositingIncreasesBalance()
        {
            //(Arrange) Given - I have a new account and I have the balance af that account     
            var amountToDeposit = 100M;
            //(Act) when I deposit $100
            Account.Deposit(amountToDeposit);
            //(Assert) Then the accounts balance should be the opening balance plus 100 
            Assert.Equal(OpeningBalance + amountToDeposit, Account.GetBalance());
        }
   
        [Fact]
        public void WithdrawalDecreaseBalance()
        {
           
            var amountToWithdraw = 100M;
            //(Act) when I deposit $100
            Account.Withdraw(amountToWithdraw);
            //(Assert) Then the accounts balance should be the opening balance plus 100 
            Assert.Equal(OpeningBalance - amountToWithdraw, Account.GetBalance());

        }
    }

    public class DummyBonusCalculator : ICalculateAccountBonuses
    {
        public decimal GetDepositBonusFor(decimal balance, decimal amountToDeposit)
        {
            return 0;
        }
    }
}
