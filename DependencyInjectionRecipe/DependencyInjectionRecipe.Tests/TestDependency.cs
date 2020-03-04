namespace DependencyInjectionRecipe.Tests
{
    public class TestDependency : IDependencyExample
    {
        public string GetEnvironment() => "Test";
    }
}