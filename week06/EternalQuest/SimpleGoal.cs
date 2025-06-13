public class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string name, string description, int points, bool completed = false)
        : base(name, description, points)
    {
        _completed = completed;
    }

    public override int RecordEvent()
    {
        if (!_completed)
        {
            _completed = true;
            return _points;
        }
        return 0;
    }

    public override bool IsComplete() => _completed;

    public override string GetStatus() => (_completed ? "[X]" : "[ ]") + $" {_name}";

    public override string Serialize() => $"SimpleGoal|{_name}|{_description}|{_points}|{_completed}";
}