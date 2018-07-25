using System;
using Google.App.Core.Contracts;

namespace Google.App.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
