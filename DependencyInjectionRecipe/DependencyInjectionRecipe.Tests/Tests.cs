using System;
using NUnit.Framework;

namespace DependencyInjectionRecipe.Tests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void SetUp()
        {
            Startup.Init(null);
        }
        
        [Test]
        public void TestDependency()
        {
            Assert.AreEqual("Test",new Interactor().Execute());
        }
    }
}