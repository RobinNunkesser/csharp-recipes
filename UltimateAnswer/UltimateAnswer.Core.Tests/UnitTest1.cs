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
            Assert.AreEqual("42", await service.Execute("Ultimate Question"));
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