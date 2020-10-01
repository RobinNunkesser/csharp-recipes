using System.Threading.Tasks;
using NUnit.Framework;
using UltimateAnswer.Common;
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
        public void Test1()
        {
            var command = new GetAnswerCommand(new MockedSuperComputer());
            command.Execute(
                new GetAnswerCommandDTO {Question = "Ultimate Question"},
                success => Assert.AreEqual("42", success),
                error => Assert.Fail(error.Message));

            Assert.Pass();
        }
    }

    public class MockedSuperComputer : ISuperComputer
    {
        public async Task<Result<string>> Answer(string question)
        {
            return new Result<string>("42");
        }
    }
}