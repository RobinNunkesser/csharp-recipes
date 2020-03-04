using System;
using NUnit.Framework;

namespace DependencyInjectionRecipe.Tests
{
    [TestFixture]
    public class Tests
    {
        private IDependencyExample _dependency; 
            
        [SetUp]
        public void SetUp()
        {
            Startup.Init(null);
            _dependency = (IDependencyExample) ServiceProvider.Provider.GetService(
                typeof(IDependencyExample)); 
        }
        
        [Test]
        public void TestDependency()
        {
            Assert.AreEqual("Test",_dependency.GetEnvironment());
        }
    }
}