using System;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

public class BackgroundOperation
{
    public async Task WriteToFileAsync(string message)
    {
        await Task.Delay(3000);
        await File.WriteAllTextAsync("tmp.txt", message);
    }
}

public class Program
{
    static async Task Main(string[] args)
    {
        var operation = new BackgroundOperation();
        bool StoppingCondition = true;

        while (StoppingCondition)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Write \"Hello World\"");
            Console.WriteLine("2. Write Current Date");
            Console.WriteLine("3. Write OS Version");
           Console.WriteLine("4. Exit");

            var input = Console.ReadLine();

            if (int.TryParse(input, out var option) && option >= 1 && option <= 3)
            {
                string message = option switch
                {
                    1 => "Hello World",
                    2 => DateTime.Now.ToString(),
                    3 => Environment.OSVersion.VersionString,
                };

                await operation.WriteToFileAsync(message);
                Console.WriteLine("File write operation in progress...");
            }
            else if (option == 4)
            {
                StoppingCondition = false;
                Console.WriteLine("Exiting from the Kiosk - File Writer...");
            }
            else
            {

                Console.WriteLine("Invalid option. Please select a valid option.");
            }
        }
    }
}
