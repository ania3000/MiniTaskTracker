using MiniTaskTracker;
using System;
using System.Collections.Generic;
using System.Linq;

var manager = new TaskManager();
bool isRunning = true;

while (isRunning)
{
    Console.WriteLine();
    Console.WriteLine("=== MINI TASK TRACKER ===");
    Console.WriteLine("1. Show tasks");
    Console.WriteLine("2. Add task");
    Console.WriteLine("3. Delete task");
    Console.WriteLine("4. Complete task");
    Console.WriteLine("5. Exit");
    Console.Write("Choose an option: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            if (manager.Tasks.Count == 0)
            {
                Console.WriteLine("No tasks yet.");
                break;
            }

            foreach (TaskItem task in manager.Tasks)
            {
                Console.WriteLine(
                    $"#{task.Id} | {task.Title} | {task.Status} | " +
                    $"{task.Priority} | {task.Difficulty}");
            }

            break;

        case "2":
            Console.Write("Enter task title: ");
            string? title = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Title cannot be empty.");
                break;
            }

            Console.Write("Enter description (optional): ");
            string? description = Console.ReadLine();

            Console.WriteLine("Choose difficulty");
            Console.WriteLine("Easy (1), Medium (2), Hard (3)");
            Console.Write("Your choice: ");

            TaskDifficulty difficulty = TaskDifficulty.Medium;

            string? difficultyInput = Console.ReadLine();

            switch (difficultyInput)
            {
                case "1":
                    difficulty = TaskDifficulty.Easy;
                    break;

                case "2":
                    difficulty = TaskDifficulty.Medium;
                    break;

                case "3":
                    difficulty = TaskDifficulty.Hard;
                    break;

                default:
                    Console.WriteLine(
                        "Некорректный выбор. Установлена средняя сложность.");
                    break;
            }

            manager.AddTask(title, description, difficulty);

            Console.WriteLine("Task added!");

            break;

        case "3":
            Console.Write("Enter task ID to delete: ");
            string? deleteInput = Console.ReadLine();

            if (!int.TryParse(deleteInput, out int deleteId))
            {
                Console.WriteLine("Please enter a valid number.");
                break;
            }

            if (!manager.DeleteTask(deleteId))
            {
                Console.WriteLine("Task not found.");
                break;
            }

            Console.WriteLine("Task deleted!");

            break;

        case "4":
            Console.Write("Enter task ID to complete: ");
            string? completeInput = Console.ReadLine();

            if (!int.TryParse(completeInput, out int completeId))
            {
                Console.WriteLine("Please enter a valid number.");
                break;
            }

            if (!manager.CompleteTask(completeId))
            {
                Console.WriteLine("Task not found.");
                break;
            }

            Console.WriteLine("Task completed!");

            break;

        case "5":
            isRunning = false;
            Console.WriteLine("Goodbye!");
            break;

        default:
            Console.WriteLine("Unknown option. Try again.");
            break;
    }
}