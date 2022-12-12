using System;
using System.Collections.Generic;
using TestsGeneratorDll;

namespace TestsGeneratorConsole
{


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tests Generating in process...");

            List<string> files = new List<string>()
            {
                @"Z:\\spp\\lr_4\\TestsGenerator-main\\TestsGeneratorConsole\\bin\\Debug\\TestsGeneratorConsole.exe",
                @"Z:\\spp\\lr_4\\TestsGenerator-main\\TestsGeneratorDll\\bin\Debug\\TestsGeneratorDll.dll"
            };
            TestsGenerator.GenerateXUnitTests(files, @"Z:\\spp\\lr_4\\Results\\", 10);

            Console.WriteLine("Thanks for waiting. All Done!");
            Console.ReadLine();
        }

    }


    public class Tests
    {
        static void TestOne()
        {
            Console.WriteLine(nameof(TestOne));
        }

        static void TestTwo()
        {
            Console.WriteLine(nameof(TestTwo));
        }

        static void TestThree()
        {
            Console.WriteLine(nameof(TestTwo));
        }
    }

    public class Bsuir
    {
        public class Fksis
        {
            public class Poit
            {
                static string GetSpeciality()
                {
                    Console.WriteLine("Hello, this is POIT");
                    return String.Empty;
                }
            }



            static string GetFaculty()
            {
                Console.WriteLine("Hello, this is FKSIS");
                return String.Empty;
            }
        }


        static string GetUniversity()
        {
            Console.WriteLine("Hello, this is BSUIR");
            return String.Empty;
        }
    }



    public class MyClass
    {
        public void MyMethodWithInt(int a)
        {
            Console.WriteLine("Method (int)");
        }

        public void MyMethodWithDouble(double a)
        {
            Console.WriteLine("Method (double)");
        }
    }
}
