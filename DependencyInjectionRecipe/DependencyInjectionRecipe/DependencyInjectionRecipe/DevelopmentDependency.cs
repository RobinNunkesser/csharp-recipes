namespace DependencyInjectionRecipe
{
    public class DevelopmentDependency : IDependencyExample
    {
        public string GetEnvironment() => "Development";
    }
}