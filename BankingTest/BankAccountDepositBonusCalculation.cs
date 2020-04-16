using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTest
{
    public class BankAccountDepositBonusCalculation
    {
        [Theory]
        [InlineData(100, 42)]
        [InlineData(150, 12)]
        public void DepositUsesTheBonusCalculator(decimal amountToDeposit, decimal expected)
        {
            //make sure the bonus calculator
            // -- is given the right arguments(balance, amountOfDeposit)s
            // --AND the amount returned from it is added to the deposit

            //Given
            var stubbedCalculator = new Mock<ICalculateAccountBonuses>();
            var account = new BankAccount(stubbedCalculator.Object, null);
            var openingBalance = account.GetBalance();
           stubbedCalculator.Setup(r => r.GetDepositBonusFor(openingBalance, amountToDeposit)).Returns(expected);

            //When
            account.Deposit(amountToDeposit);

            //Then
            Assert.Equal(openingBalance + amountToDeposit + expected, account.GetBalance());
        }

    }
}
