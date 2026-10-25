using System.Text.Json;

namespace MiniTaskTracker;

public static class TaskStorage
{
    private const string FilePath = "tasks.json";

    public static void Save(List<TaskItem> tasks)
    {
        string json = JsonSerializer.Serialize(
            tasks,
            new JsonSerializerOptions { WriteIndented = true }
        );

        File.WriteAllText(FilePath, json);
    }

    public static List<TaskItem> Load()
    {
        if (!File.Exists(FilePath))
        {
            return new List<TaskItem>();
        }

        string json = File.ReadAllText(FilePath);

        return JsonSerializer.Deserialize<List<TaskItem>>(json)
               ?? new List<TaskItem>();
    }
}
