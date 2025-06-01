namespace Warehouse;

        using System;
using System.Threading.Tasks;

class Test
    {
        public static async Task Main()
        {
            Console.WriteLine("Testing System.Threading.Tasks...");
            await Task.Delay(1000); // Wait for 1 second
            Console.WriteLine("System.Threading.Tasks works!");
        }
    }


