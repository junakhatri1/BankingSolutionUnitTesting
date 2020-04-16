using System;
using System.Collections.Generic;
using System.Text;

namespace BankingDomain
{
    public interface IGiveFederalRegulatorsAccountInformation
    {
        int AccountNumber { get; set; }

        decimal GetBalance();
    }
}
