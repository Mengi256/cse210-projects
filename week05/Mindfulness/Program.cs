// EXCEEDS CORE REQUIREMENTS:
// 1. Menu loops until the user chooses to quit.
// 2. Tracks and displays how many times each activity was run per session.
// 3. Spinner and countdown both use backspace (\b) for in-place animation.

using System;


class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> activityCount = new Dictionary<string, int>
        {
            { "Breathing", 0 },
            { "Reflecting", 0 },
            { "Listing", 0 }
        };

        bool quit = false;

        while (!quit)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity ");
            Console.WriteLine("  2. Start Reflecting Activity ");
            Console.WriteLine("  3. Start Listing Activity ");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            switch (Console.ReadLine())
            {
                case "1":
                    new BreathingActivity().Run();
                    activityCount["Breathing"]++;
                    break;
                case "2":
                    new ReflectingActivity().Run();
                    activityCount["Reflecting"]++;
                    break;
                case "3":
                    new ListingActivity().Run();
                    activityCount["Listing"]++;
                    break;
                case "4":
                    quit = true;
                    Console.WriteLine("\nSession Summary:");
                    foreach (var entry in activityCount)
                        Console.WriteLine($"  {entry.Key}: {entry.Value} time(s)");
                    Console.WriteLine("\nGoodbye!!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}