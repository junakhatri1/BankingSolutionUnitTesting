using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTest
{
    public class OverdraftNotAllowed
    {
        //[Fact]
        //public void SystemcyrrentlyAllowsOverdraftButShouldnt()
        //{
        //    var bankAccount = new BankAccount(null);
        //    var openingBalance = bankAccount.GetBalance();
        //    bankAccount.Withdraw(openingBalance + 1);
        //    Assert.Equal(-1, bankAccount.GetBalance());
        //}

        [Fact]
        public void OverdraftDoesnotRemoveMoneyFromAccount()
        {
            var bankAccount = new BankAccount(null, new Mock<INotifyTheFeds>().Object);
            var openingBalance = bankAccount.GetBalance();
            try
            {
                bankAccount.Withdraw(openingBalance + 1);
            }
            catch (OverdraftException)
            {

                //Known 
            }
            Assert.Equal(openingBalance, bankAccount.GetBalance());
        }


        [Fact]
        public void OverdraftThrows()
        {
            var bankAccount = new BankAccount(null, new Mock<INotifyTheFeds>().Object);
            var openingBalance = bankAccount.GetBalance();
           Assert.Throws<OverdraftException>(() => bankAccount.Withdraw(openingBalance + 1));
          
        }


        [Fact]
        public void CanTakeAllMoney()
        {
            var bankAccount = new BankAccount(null, new Mock<INotifyTheFeds>().Object);
            bankAccount.Withdraw(bankAccount.GetBalance());
            var openingBalance = bankAccount.GetBalance();
            
            Assert.Equal(0, bankAccount.GetBalance());
        }
    }
}
