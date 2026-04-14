

using System;


public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private string _playerName;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _playerName = "Adventurer";
    }

    public void SetPlayerName(string name) => _playerName = name;

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\n  Player: {_playerName}   Score: {_score} points");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("  No goals yet. Create some!");
            return;
        }
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDisplayString()}");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("  No goals to record. Create some first!");
            return;
        }

        Console.WriteLine("\n  Which goal did you accomplish?");
        ListGoalNames();
        Console.Write("  Enter choice: ");

        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= _goals.Count)
        {
            int pointsEarned = _goals[choice - 1].RecordEvent();
            _score += pointsEarned;

            if (pointsEarned > 0)
                Console.WriteLine($"  You earned {pointsEarned} points! Total: {_score}");
            else if (pointsEarned < 0)
                Console.WriteLine($"  Points deducted. Total: {_score}");
        }
        else
        {
            Console.WriteLine("  Invalid selection.");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\n  Goal types:");
        Console.WriteLine("  1. Simple Goal   (completed once)");
        Console.WriteLine("  2. Eternal Goal  (never ends, earns points every time)");
        Console.WriteLine("  3. Checklist Goal (done N times for bonus)");
        Console.WriteLine("  4. Negative Goal  (bad habit — deducts points)");
        Console.Write("  Choice: ");
        string typeChoice = Console.ReadLine();

        Console.Write("  Goal name: ");
        string name = Console.ReadLine();
        Console.Write("  Description: ");
        string description = Console.ReadLine();

        switch (typeChoice)
        {
            case "1":
                Console.Write("  Points value: ");
                _goals.Add(new SimpleGoal(name, description, int.Parse(Console.ReadLine())));
                Console.WriteLine("  Simple goal created!");
                break;
            case "2":
                Console.Write("  Points per occurrence: ");
                _goals.Add(new EternalGoal(name, description, int.Parse(Console.ReadLine())));
                Console.WriteLine("  Eternal goal created!");
                break;
            case "3":
                Console.Write("  Points per completion: ");
                int pts = int.Parse(Console.ReadLine());
                Console.Write("  Times required: ");
                int required = int.Parse(Console.ReadLine());
                Console.Write("  Bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, pts, required, bonus));
                Console.WriteLine("  Checklist goal created!");
                break;
            case "4":
                Console.Write("  Penalty points per occurrence: ");
                _goals.Add(new NegativeGoal(name, description, int.Parse(Console.ReadLine())));
                Console.WriteLine("  Negative goal created!");
                break;
            default:
                Console.WriteLine("  Invalid choice.");
                break;
        }
    }

    public void SaveGoals(string filename)
    {
        using StreamWriter writer = new StreamWriter(filename);
        writer.WriteLine($"{_playerName},{_score}");
        foreach (Goal goal in _goals)
            writer.WriteLine(goal.GetSaveString());
        Console.WriteLine($"  Saved to {filename}");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("  File not found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);

        string[] header = lines[0].Split(',');
        _playerName = header[0];
        _score = int.Parse(header[1]);

        for (int i = 1; i < lines.Length; i++)
        {
            int colonIndex = lines[i].IndexOf(':');
            string goalType = lines[i].Substring(0, colonIndex);
            string[] parts = lines[i].Substring(colonIndex + 1).Split(',');

            Goal goal = goalType switch
            {
                "SimpleGoal"    => new SimpleGoal(parts[0], parts[1], int.Parse(parts[2]), bool.Parse(parts[3])),
                "EternalGoal"   => new EternalGoal(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3])),
                "ChecklistGoal" => new ChecklistGoal(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5])),
                "NegativeGoal"  => new NegativeGoal(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3])),
                _ => null
            };

            if (goal != null) _goals.Add(goal);
        }

        Console.WriteLine($"  Loaded {_goals.Count} goals for {_playerName}. Score: {_score}");
    }
}