using System.Linq;

namespace MiniTaskTracker;

public class TaskManager
{
    private readonly List<TaskItem> _tasks;

    private int _nextId;

    public IReadOnlyList<TaskItem> Tasks => _tasks;

    public TaskManager()
    {
        _tasks = TaskStorage.Load();

        _nextId = _tasks.Count > 0
            ? _tasks.Max(task => task.Id) + 1
            : 1;
    }

    public TaskItem AddTask(
        string title,
        string? description,
        TaskDifficulty difficulty)
    {
        var task = new TaskItem
        {
            Id = _nextId++,
            Title = title.Trim(),
            Description = description?.Trim() ?? string.Empty,
            Difficulty = difficulty,
            CreatedAt = DateTime.Now
        };

        _tasks.Add(task);
        TaskStorage.Save(_tasks);

        return task;
    }

    public bool DeleteTask(int id)
    {
        TaskItem? task = _tasks.FirstOrDefault(task => task.Id == id);

        if (task is null)
        {
            return false;
        }

        _tasks.Remove(task);
        TaskStorage.Save(_tasks);

        return true;
    }

    public bool CompleteTask(int id)
    {
        TaskItem? task = _tasks.FirstOrDefault(task => task.Id == id);

        if (task is null)
        {
            return false;
        }

        task.Status = TaskState.Done;
        TaskStorage.Save(_tasks);

        return true;
    }
}
