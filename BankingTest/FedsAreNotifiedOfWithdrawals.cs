using BankingDomain;
using Moq;
using Xunit;

namespace BankingTest
{
    public class FedsAreNotifiedOfWithdrawals
    {
        [Fact]
        public void FedsAreNotified()
        {
            //Given
            var fedMock = new Mock<INotifyTheFeds>();
            var account = new BankAccount(null, fedMock.Object);
            //when
            account.Withdraw(5);
            //Then
            fedMock.Verify(r => r.Notify(account, 5));
        }

    }
}
