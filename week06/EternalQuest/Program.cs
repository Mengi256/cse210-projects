
//
// CREATIVITY / EXCEEDS CORE REQUIREMENTS:
// Added a 4th goal type: NegativeGoal (NegativeGoal.cs)
// This is a bad habit tracker. Each time the user records the event,
// points are DEDUCTED from their score instead of added. For example,
// "Skipped the gym" or "Ate junk food" could be negative goals.
// This encourages accountability not all choices earn rewards.
// NegativeGoal inherits from Goal and overrides all abstract methods.
// RecordEvent() returns a negative int, which GoalManager subtracts from the score.

GoalManager manager = new GoalManager();

Console.WriteLine("=========================================");
Console.WriteLine("   Welcome To The Eternal Quest Program!! ");
Console.WriteLine("=========================================");
Console.Write("Enter your name: ");
manager.SetPlayerName(Console.ReadLine());

bool running = true;

while (running)
{
    manager.DisplayPlayerInfo();
    Console.WriteLine("\n  Menu Options:");
    Console.WriteLine("  1. Create New Goal");
    Console.WriteLine("  2. List Goals");
    Console.WriteLine("  3. Save Goals");
    Console.WriteLine("  4. Load Goals");
    Console.WriteLine("  5. Record Event");
    Console.WriteLine("  6. Quit");
    Console.Write("\n  Select an option: ");

    switch (Console.ReadLine())
    {
        case "1": manager.CreateGoal(); break;
        case "2":
            Console.WriteLine("\n  Your Goals:");
            manager.ListGoalNames();
            break;
        case "3":
            Console.Write("  Filename to save: ");
            manager.SaveGoals(Console.ReadLine());
            break;
        case "4":
            Console.Write("  Filename to load: ");
            manager.LoadGoals(Console.ReadLine());
            break;
        case "5": manager.RecordEvent(); break;
        case "6":
            running = false;
            Console.WriteLine("\n  Thank you for questing! Goodbye!");
            break;
        default:
            Console.WriteLine("  Invalid selection.");
            break;
    }
}