
public class NegativeGoal : Goal
{
    private int _timesOccurred;
    private int _penaltyPoints;

    public NegativeGoal(string name, string description, int penaltyPoints)
        : base(name, description, 0)
    {
        _timesOccurred = 0;
        _penaltyPoints = penaltyPoints;
    }

    public NegativeGoal(string name, string description, int penaltyPoints, int timesOccurred)
        : base(name, description, 0)
    {
        _timesOccurred = timesOccurred;
        _penaltyPoints = penaltyPoints;
    }

    
    public override int RecordEvent()
    {
        _timesOccurred++;
        Console.WriteLine($"  Oops! -{_penaltyPoints} points for: {_name}");
        return -_penaltyPoints;
    }

    public override bool IsComplete() => false;

    public override string GetDisplayString()
    {
        return $"[✗] {_name} ({_description}) -- Occurred: {_timesOccurred} times | Penalty: -{_penaltyPoints} pts";
    }

    public override string GetSaveString()
    {
        return $"NegativeGoal:{_name},{_description},{_penaltyPoints},{_timesOccurred}";
    }
}