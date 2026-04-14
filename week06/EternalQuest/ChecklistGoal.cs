

public class ChecklistGoal : Goal
{
    private int _currentCount;
    private int _requiredCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int requiredCount, int bonusPoints)
        : base(name, description, points)
    {
        _currentCount = 0;
        _requiredCount = requiredCount;
        _bonusPoints = bonusPoints;
    }

    public ChecklistGoal(string name, string description, int points, int requiredCount, int bonusPoints, int currentCount)
        : base(name, description, points)
    {
        _currentCount = currentCount;
        _requiredCount = requiredCount;
        _bonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine("This checklist goal is already fully completed!");
            return 0;
        }

        _currentCount++;

        if (IsComplete())
        {
            Console.WriteLine($"  *** Goal complete! Bonus: {_bonusPoints} points! ***");
            return _points + _bonusPoints;
        }

        return _points;
    }

    public override bool IsComplete() => _currentCount >= _requiredCount;

    public override string GetDisplayString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_name} ({_description}) -- Completed: {_currentCount}/{_requiredCount}";
    }

    public override string GetSaveString()
    {
        return $"ChecklistGoal:{_name},{_description},{_points},{_requiredCount},{_bonusPoints},{_currentCount}";
    }
}