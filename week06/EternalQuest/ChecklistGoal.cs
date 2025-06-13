public class ChecklistGoal : Goal
{
    private int _target;
    private int _current;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int current = 0)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _current = current;
    }

    public override int RecordEvent()
    {
        if (_current < _target)
        {
            _current++;
            return _current == _target ? _points + _bonus : _points;
        }
        return 0;
    }

    public override bool IsComplete() => _current >= _target;

    public override string GetStatus() =>
        (_current >= _target ? "[X]" : "[ ]") + $" {_name} -- Completed {_current}/{_target} times";

    public override string Serialize() =>
        $"ChecklistGoal|{_name}|{_description}|{_points}|{_target}|{_bonus}|{_current}";
}