using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunalServices.resolvers;
using Xunit;

namespace CommunalServices.Tests
{
    public class CredentialsResolverTests
    {
        [Fact]
        public void UserRegisterSuccessful()
        {
            CredentialsResolver.createCredentialsAndConsumer("admin1", "admin1", "Пушкина", "Колотушкина", 45, new List<string>() { "88005553534" }, true, "Админ", "Админович");
        }
    }
}
