using CommunalServices.resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CommunalServices.Tests
{
    public class ReportResolverTests
    {
        [Fact]
        public void checkPaymentReport()
        {
            ReportResolver.getPaymentReport();
        }

        [Fact]
        public void checkReportDebtor()
        {
            ReportResolver.getReportDebtor();
        }

        [Fact]
        public void checkValueOfServices()
        {
            ReportResolver.getValueOfServices();
        }
    }
}
