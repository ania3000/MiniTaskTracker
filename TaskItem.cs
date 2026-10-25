namespace MiniTaskTracker;

public enum TaskState
{
    Todo,
    InProgress,
    Done
}

public enum TaskPriority
{
    Low,
    Medium,
    High
}

public enum TaskDifficulty
{
    Easy,
    Medium,
    Hard
}

public class TaskItem
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public TaskState Status { get; set; } = TaskState.Todo;

    public TaskPriority Priority { get; set; } = TaskPriority.Medium;
    
    public TaskDifficulty Difficulty { get; set; } = TaskDifficulty.Medium;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
