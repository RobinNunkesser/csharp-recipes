using System.Threading.Tasks;
using NUnit.Framework;
using UltimateAnswer.Core.Ports;

namespace UltimateAnswer.Core.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            var service = new GetAnswerService(new MockedSuperComputer());
            await service.Execute("Ultimate Question",
                success => Assert.AreEqual("42", success),
                error => Assert.Fail(error.Message));

            Assert.Pass();
        }
    }

    public class MockedSuperComputer : ISuperComputer
    {
        async Task<string> ISuperComputer.Answer(string question)
        {
            return "42";
        }
    }
}