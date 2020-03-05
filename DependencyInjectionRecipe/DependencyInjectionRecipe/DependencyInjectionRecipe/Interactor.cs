using System;
namespace DependencyInjectionRecipe
{
    public class Interactor
    {
        private IDependencyExample Dependency =>
            (IDependencyExample)ServiceProvider.Provider.GetService(
                typeof(IDependencyExample));

        public String Execute()
        {
            return Dependency.GetEnvironment();
        }
    }
}
