using System;
namespace csharp_selenium_browserstack
{
    public class Program
    {
        static void Main(string[] args)
        {
            foreach (Object obj in args)
            {
                String test = obj.ToString();
                switch (test)
                {
                    case "single":
                        Console.WriteLine("Running single");
                        SingleTest.execute();
                        break;
                    case "local":
                        Console.WriteLine("Running local");
                        LocalTest.execute();
                        break;
                    case "parallel":
                        Console.WriteLine("Running parallel");
                        ParallelTests.execute();
                        break;
                    default:
                        Console.WriteLine("Test type not found");
                        break;
                }
            }
        }
    }
}
