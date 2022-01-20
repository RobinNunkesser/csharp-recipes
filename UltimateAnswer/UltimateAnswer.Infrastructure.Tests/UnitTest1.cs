using System.Threading.Tasks;
using NUnit.Framework;
using UltimateAnswer.Infrastructure.Adapters;

namespace UltimateAnswer.Infrastructure.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestDeepThought()
        {
            var deepThought = new DeepThought();
            var answer = await deepThought.ProvideAnswer();
            Assert.AreEqual(42, answer);
        }

        [Test]
        public async Task TestSuperComputerAdapter()
        {
            var superComputer = new SuperComputerAdapter();
            var answer = await superComputer.Answer("");
            Assert.AreEqual("42", answer);
        }

    }
}