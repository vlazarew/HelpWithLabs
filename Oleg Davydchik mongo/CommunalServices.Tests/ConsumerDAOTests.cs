using MongoDB.Driver;
using System;
using Xunit;
using CommunalServices.daos;
using CommunalServices.model;

namespace CommunalServices.Tests
{
    public class ConsumerDAOTests
    {
        [Fact]
        public void AddConsumer()
        {
            var consumer = new Consumer("����", "������", 0, 0, 15);
            var result = ConsumerDAO.saveConsumer(consumer);

            Assert.True(result);
        }

        [Fact]
        public void getConsumerByCredentialsId()
        {
            var result = ConsumerDAO.getConsumerByCredentialsId(15);

            Assert.NotNull(result);
        }

        [Fact]
        public void getConsumerByNameSurname()
        {
            var result = ConsumerDAO.getConsumerByNameSurname("����", "������");

            Assert.NotNull(result);
        }

        [Fact]
        public void getConsumerById()
        {
            var instance = ConsumerDAO.getConsumerByNameSurname("����", "������");
            var result = ConsumerDAO.getConsumerByCredentialsId(instance.id);

            Assert.NotNull(result);
        }

        [Fact]
        public void UpdateConsumer()
        {
            var instance = ConsumerDAO.getConsumerByNameSurname("����", "������");
            var consumer = new Consumer(instance.id, "����", "������", 1, 1, 10);

            var result = ConsumerDAO.updateConsumer(consumer);

            Assert.True(result);
        }

        [Fact]
        public void DeleteConsumer()
        {
            var instance = ConsumerDAO.getConsumerByNameSurname("����", "������");
            var result = ConsumerDAO.deleteConsumer(instance);

            Assert.True(result);
        }
    }
}
