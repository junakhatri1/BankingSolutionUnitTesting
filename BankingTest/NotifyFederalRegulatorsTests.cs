using BankingDomain;
using Moq;
using Xunit;

namespace BankingTest
{
   public class NotifyFederalRegulatorsTests
    {
        [Fact]
        public void CanDoIt()
        {
            INotifyTheFeds notifier = new NotifyFederalRegulators();
            var accountStub = new Mock<IGiveFederalRegulatorsAccountInformation>();
            accountStub.Setup(b => b.GetBalance()).Returns(5000);
            notifier.Notify(accountStub.Object, 300);
        }
    }
}
    

