using MongoDB.Driver;
using System;
using Xunit;
using CommunalServices.daos;

namespace CommunalServices.Tests
{
    public class MongoDAOTests
    {
        [Fact]
        public void ConnectionSuccessful()
        {
            MongoClient client = null;
            try
            {
                client = MongoDAO.createConnect();
            }
            catch { }

            Assert.NotNull(client);
        }
    }
}
