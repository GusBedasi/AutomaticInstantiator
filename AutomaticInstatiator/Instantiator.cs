using System.Reflection;

namespace AutomaticInstatiator
{
    public class Instantiator
    {
        public IEnumerable<IInstantiator> CreateInstances()
        {
            var currentAssembly = typeof(IInstantiator).GetTypeInfo().Assembly;

            var classesToInstatiate = currentAssembly.DefinedTypes
                .Where(x => x.ImplementedInterfaces
                    .Any(x => x == typeof(IInstantiator)))
                .ToList();

            var classesCreated = new List<IInstantiator>();

            foreach (var @class in classesToInstatiate)
                classesCreated.Add((IInstantiator)Activator.CreateInstance(@class));

            return classesCreated.AsEnumerable();
        }
    }
}
