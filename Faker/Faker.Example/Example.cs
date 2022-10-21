using Faker.Core;
using Tests.TestClasses;
using System.Collections.Generic;

namespace Faker.Example 
{
    class Example 
    {   
        public static void Main() 
        {

            FakerRealizer faker = new FakerRealizer();
           
            int ch = faker.Create<int>();
            float chfloat = faker.Create<float>();
            double chdouble = faker.Create<double>();
            string str = faker.Create<string>();

            Console.WriteLine($"{ch}\n{chfloat}\n{chdouble}\n{str}\n");
            
            CodeIdentity codeIdentity;
            codeIdentity = faker.Create<CodeIdentity>();
            codeIdentity.showInfo();

         
            List<int> list = faker.Create<List<int>>();
            list.ForEach(Console.WriteLine);

            List<CodeIdentity> identityList = faker.Create<List<CodeIdentity>>();
            foreach(CodeIdentity identity in identityList)
            {
                identity.showInfo();
            }

            DateTime dateTime = faker.Create<DateTime>();
            Console.WriteLine(dateTime.ToString());
        }
    }
}