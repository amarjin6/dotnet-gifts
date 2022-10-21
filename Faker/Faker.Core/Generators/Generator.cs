using System.Reflection;
using System.Runtime.CompilerServices;

namespace Faker.Core.Generators
{
    internal abstract class Generator
    {
        public static IReadOnlyDictionary<Type, Func<object>> BasicGenerators => basicGenerators;
        protected readonly static Dictionary<Type, Func<object>> basicGenerators = new();
        protected readonly static Random random = new(0);

        static Generator()
        {
            InitAll();
        }

        protected static byte[] GetBytes(int length)
        {
            byte[] bytes = new byte[length];
            random.NextBytes(bytes);
            return bytes;
        }

        private static void InitAll()
        {
            var subClasses = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsAssignableTo(typeof(Generator)) && x != typeof(Generator));
            foreach (var subClass in subClasses)
            {
                RuntimeHelpers.RunClassConstructor(subClass.TypeHandle);
            }
        }
    }
}